using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RequestServiceTests
{
    private readonly Mock<IRequestRepository> _requestRepository;
    private readonly Mock<IRequestValidator> _requestValidator;
    private readonly RequestService _requestService;

    public RequestServiceTests()
    {
        _requestRepository = new Mock<IRequestRepository>();
        _requestValidator = new Mock<IRequestValidator>();
        _requestService = new RequestService(_requestRepository.Object, _requestValidator.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnRequestDtos_WhenRequestsExist()
    {
        var requests = new List<Request>
        {
            new Request
            {
                Id = 1,
                EmployeeId = 1,
                RequestDate = new DateOnly(2023, 1, 1),
                Status = "Pending",
                Employee = new Employee
                {
                    Id = 1,
                    Name = "Marcela",
                    LastName = "Lopez",
                    Address = "Miami",
                    HireDate = new DateOnly(2023, 1, 1)
                }
            }
        };

        _requestRepository.Setup(repo => repo.GetAll()).ReturnsAsync(requests);

        var result = await _requestService.GetAll();

        var requestDto = result.FirstOrDefault();
        Assert.NotNull(requestDto);
        Assert.Equal(1, requestDto.Id);
        Assert.Equal(1, requestDto.EmployeeId);
        Assert.Equal(new DateOnly(2023, 1, 1), requestDto.RequestDate);
        Assert.Equal("Pending", requestDto.Status);
        Assert.NotNull(requestDto.Employee);
        Assert.Equal(1, requestDto.Employee.Id);
        Assert.Equal("Marcela", requestDto.Employee.Name);
        Assert.Equal("Lopez", requestDto.Employee.LastName);
        Assert.Equal("Miami", requestDto.Employee.Address);
        Assert.Equal(new DateOnly(2023, 1, 1), requestDto.Employee.HireDate);
    }

    [Fact]
    public void GetById_ShouldReturnRequestDto_WhenRequestExists()
    {
        var request = new Request
        {
            Id = 1,
            EmployeeId = 1,
            RequestDate = new DateOnly(2023, 1, 1),
            Status = "Pending",
            Employee = new Employee
            {
                Id = 1,
                Name = "Marcela",
                LastName = "Lopez",
                Address = "Miami",
                HireDate = new DateOnly(2023, 1, 1)
            }
        };

        _requestRepository.Setup(repo => repo.GetById(1)).Returns(request);

        var result = _requestService.GetById(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(1, result.EmployeeId);
        Assert.Equal(new DateOnly(2023, 1, 1), result.RequestDate);
        Assert.Equal("Pending", result.Status);
        Assert.NotNull(result.Employee);
        Assert.Equal(1, result.Employee.Id);
        Assert.Equal("Marcela", result.Employee.Name);
        Assert.Equal("Lopez", result.Employee.LastName);
        Assert.Equal("Miami", result.Employee.Address);
        Assert.Equal(new DateOnly(2023, 1, 1), result.Employee.HireDate);
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenRequestDoesNotExist()
    {
        _requestRepository.Setup(repo => repo.GetById(1)).Returns((Request)null);
        var result = _requestService.GetById(1);
        Assert.Null(result);
    }

    [Fact]
    public async Task SaveRequest_ShouldCallRepositorySaveRequest_WhenRequestDtoIsValid()
    {
        var requestDto = new RequestDto
        {
            EmployeeId = 1,
            RequestDate = new DateOnly(2023, 1, 1),
            Status = "Pending"
        };

        _requestValidator.Setup(v => v.ValidateRequestByEmployee(_requestRepository.Object, requestDto))
                         .Returns(Task.CompletedTask);

        await _requestService.SaveRequest(requestDto);

        _requestRepository.Verify(repo => repo.SaveRequest(It.Is<Request>(r =>
            r.EmployeeId == requestDto.EmployeeId &&
            r.RequestDate == requestDto.RequestDate &&
            r.Status == requestDto.Status
        )), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldCallRepositoryUpdate_WhenRequestExists()
    {
        var request = new Request
        {
            Id = 1,
            EmployeeId = 1,
            RequestDate = new DateOnly(2023, 1, 1),
            Status = "Pending"
        };

        _requestRepository.Setup(repo => repo.GetById(1)).Returns(request);
        await _requestService.Update(1);

        _requestRepository.Verify(repo => repo.Update(It.Is<Request>(r =>
            r.Id == 1 &&
            r.Status == "APPROVED"
        )), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldNotCallRepositoryUpdate_WhenRequestDoesNotExist()
    {
        _requestRepository.Setup(repo => repo.GetById(1)).Returns((Request)null);

        await _requestService.Update(1);

        _requestRepository.Verify(repo => repo.Update(It.IsAny<Request>()), Times.Never);
    }
}
