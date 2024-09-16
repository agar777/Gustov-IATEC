using Moq;
using Xunit;
using System;
using System.Threading.Tasks;

public class VacationServiceTests
{
    private readonly Mock<IVacationRepository> _vacationRepository;
    private readonly Mock<IRequestService> _requestService;
    private readonly Mock<IVacationValidator> _vacationValidator;
    private readonly VacationService _vacationService;

    public VacationServiceTests()
    {
        _vacationRepository = new Mock<IVacationRepository>();
        _requestService = new Mock<IRequestService>();
        _vacationValidator = new Mock<IVacationValidator>();
        _vacationService = new VacationService(
            _vacationRepository.Object,
            _requestService.Object,
            _vacationValidator.Object
        );
    }

    [Fact]
    public async Task GetById_ShouldReturnVacationDto_WhenVacationExists()
    {
        var vacation = new Vacation
        {
            Id = 1,
            RequestId = 1,
            StartDate = new DateOnly(2023, 1, 1),
            EndDate = new DateOnly(2023, 1, 15),
            Request = new Request
            {
                Id = 1,
                EmployeeId = 1,
                RequestDate = new DateOnly(2022, 12, 1),
                Status = "Approved",
                Employee = new Employee
                {
                    Id = 1,
                    Name = "Marcela",
                    LastName = "Lopez",
                    Address = "Miami",
                    HireDate = new DateOnly(2021, 1, 1)
                }
            }
        };

        _vacationRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(vacation);
        _vacationValidator.Setup(v => v.ValidateVacationDay(_requestService.Object, 1))
                          .Returns((15, new DateOnly(2023, 1, 15), 2));

        var result = await _vacationService.GetById(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(1, result.RequestId);
        Assert.Equal(new DateOnly(2023, 1, 1), result.StartDate);
        Assert.Equal(new DateOnly(2023, 1, 15), result.EndDate);
        Assert.Equal(15, result.TotalDays);
        Assert.Equal(2, result.YearsWorked);
        Assert.NotNull(result.Request);
        Assert.Equal(1, result.Request.Id);
        Assert.Equal(1, result.Request.EmployeeId);
        Assert.Equal(new DateOnly(2022, 12, 1), result.Request.RequestDate);
        Assert.Equal("Approved", result.Request.Status);
        Assert.NotNull(result.Request.Employee);
        Assert.Equal(1, result.Request.Employee.Id);
        Assert.Equal("Marcela", result.Request.Employee.Name);
        Assert.Equal("Lopez", result.Request.Employee.LastName);
        Assert.Equal("Miami", result.Request.Employee.Address);
        Assert.Equal(new DateOnly(2021, 1, 1), result.Request.Employee.HireDate);
    }

    [Fact]
    public async Task SaveVacation_ShouldCallRepositorySaveVacation_WhenVacationIsValid()
    {
        var requestId = 1;
        var request = new RequestDto
        {
            Id = 1,
            RequestDate = new DateOnly(2022, 12, 1)
        };

        _requestService.Setup(rs => rs.GetById(requestId)).Returns(request);
        _vacationValidator.Setup(v => v.ValidateVacationRequest(_requestService.Object, requestId))
                          .Returns(true);
        _vacationValidator.Setup(v => v.ValidateVacationDay(_requestService.Object, requestId))
                          .Returns((15, new DateOnly(2023, 1, 15), 2));

        await _vacationService.SaveVacation(requestId);

        _requestService.Verify(rs => rs.Update(requestId), Times.Once);
        _vacationRepository.Verify(repo => repo.SaveVacation(It.Is<Vacation>(v =>
            v.RequestId == requestId &&
            v.StartDate == request.RequestDate &&
            v.EndDate == new DateOnly(2023, 1, 15)
        )), Times.Once);
    }

    [Fact]
    public async Task SaveVacation_ShouldNotCallRepositorySaveVacation_WhenRequestIsNotValid()
    {
        var requestId = 1;
        _vacationValidator.Setup(v => v.ValidateVacationRequest(_requestService.Object, requestId))
                          .Returns(false);

        await _vacationService.SaveVacation(requestId);
        _requestService.Verify(rs => rs.Update(requestId), Times.Never);
        _vacationRepository.Verify(repo => repo.SaveVacation(It.IsAny<Vacation>()), Times.Never);
    }
}
