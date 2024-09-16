using Moq;
using Xunit;
using System;
using System.Threading.Tasks;

public class VacationServiceTests
{
    private readonly Mock<IVacationRepository> vacationRepository;
    private readonly Mock<IRequestService> requestService;
    private readonly Mock<IVacationValidator> vacationValidator;
    private readonly VacationService vacationService;

    public VacationServiceTests()
    {
        vacationRepository = new Mock<IVacationRepository>();
        requestService = new Mock<IRequestService>();
        vacationValidator = new Mock<IVacationValidator>();
        vacationService = new VacationService(
            vacationRepository.Object,
            requestService.Object,
            vacationValidator.Object
        );
    }

    [Fact]
    public async Task GetById()
    {
        // ShouldReturnVacationDtoWhenVacationExists
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

        vacationRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(vacation);
        vacationValidator.Setup(v => v.ValidateVacationDay(requestService.Object, 1))
                          .Returns((15, new DateOnly(2023, 1, 15), 2));

        var result = await vacationService.GetById(1);

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
    public async Task SaveVacationWhenVacationIsValid()
    {
        // ShouldCallRepositorySaveVacationWhenVacationIsValid
        var requestId = 1;
        var request = new RequestDto
        {
            Id = 1,
            RequestDate = new DateOnly(2022, 12, 1)
        };

        requestService.Setup(rs => rs.GetById(requestId)).Returns(request);
        vacationValidator.Setup(v => v.ValidateVacationRequest(requestService.Object, requestId))
                          .Returns(true);
        vacationValidator.Setup(v => v.ValidateVacationDay(requestService.Object, requestId))
                          .Returns((15, new DateOnly(2023, 1, 15), 2));

        await vacationService.SaveVacation(requestId);

        requestService.Verify(rs => rs.Update(requestId), Times.Once);
        vacationRepository.Verify(repo => repo.SaveVacation(It.Is<Vacation>(v =>
            v.RequestId == requestId &&
            v.StartDate == request.RequestDate &&
            v.EndDate == new DateOnly(2023, 1, 15)
        )), Times.Once);
    }

    [Fact]
    public async Task SaveVacationWhenRequestIsNotValid()
    {
        // ShouldNotCallRepositorySaveVacationWhenRequestIsNotValid
        var requestId = 1;
        vacationValidator.Setup(v => v.ValidateVacationRequest(requestService.Object, requestId))
                          .Returns(false);

        await vacationService.SaveVacation(requestId);
        requestService.Verify(rs => rs.Update(requestId), Times.Never);
        vacationRepository.Verify(repo => repo.SaveVacation(It.IsAny<Vacation>()), Times.Never);
    }
}
