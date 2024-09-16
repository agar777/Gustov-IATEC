using Moq;
using Xunit;
using System.Threading.Tasks;

public class EmployeeServiceTest
{
    private readonly Mock<IEmployeeRepository> _employeeRepository;
    private readonly EmployeeService _employeeService;

    public EmployeeServiceTest()
    {
        _employeeRepository = new Mock<IEmployeeRepository>();
        _employeeService = new EmployeeService(_employeeRepository.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmployeeDtos_WhenEmployeesExist()
    {
        var employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Marcela",
                LastName = "Lopez",
                Address = "Miami",
                HireDate = new DateOnly(2023, 1, 1),
                Requests = new List<Request>
                {
                    new Request { Id = 1, RequestDate = new DateOnly(2023, 2, 1), Status = "Pending" }
                }
            }
        };

        _employeeRepository.Setup(repo => repo.GetAll()).ReturnsAsync(employees);

        var result = await _employeeService.GetAll();

        var employeeDto = result.FirstOrDefault();
        Assert.NotNull(employeeDto);
        Assert.Equal(1, employeeDto.Id);
        Assert.Equal("Marcela", employeeDto.Name);
        Assert.Equal("Lopez", employeeDto.LastName);
        Assert.Equal("Miami", employeeDto.Address);
        Assert.Equal(new DateOnly(2023, 1, 1), employeeDto.HireDate);
        Assert.NotNull(employeeDto.Request);
        Assert.Equal(1, employeeDto.Request.Id);
        Assert.Equal(new DateOnly(2023, 2, 1), employeeDto.Request.RequestDate);
        Assert.Equal("Pending", employeeDto.Request.Status);
    }

    [Fact]
    public async Task GetById_ShouldReturnEmployeeDto_WhenEmployeeExists()
    {
        var employee = new Employee
        {
            Id = 1,
            Name = "Marcela",
            LastName = "Lopez",
            Address = "Miami",
            HireDate = new DateOnly(2023, 1, 1)
        };

        _employeeRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(employee);

        var result = await _employeeService.GetById(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Marcela", result.Name);
        Assert.Equal("Lopez", result.LastName);
        Assert.Equal("Miami", result.Address);
        Assert.Equal(new DateOnly(2023, 1, 1), result.HireDate);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenEmployeeDoesNotExist()
    {
        _employeeRepository.Setup(repo => repo.GetById(1)).ReturnsAsync((Employee)null);

        var result = await _employeeService.GetById(1);

        Assert.Null(result);
    }

    [Fact]
    public async Task Save_ShouldCallRepositorySave_WhenEmployeeDtoIsValid()
    {
        var employeeDto = new EmployeeDto
        {
            Name = "Marcela",
            LastName = "Lopez",
            Address = "Miami",
            HireDate = new DateOnly(2023, 1, 1)
        };

        await _employeeService.Save(employeeDto);

        _employeeRepository.Verify(repo => repo.Save(It.Is<Employee>(e =>
            e.Name == employeeDto.Name &&
            e.LastName == employeeDto.LastName &&
            e.Address == employeeDto.Address &&
            e.HireDate == employeeDto.HireDate
        )), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldCallRepositoryUpdate_WhenEmployeeDtoIsValid()
    {
        var employeeDto = new EmployeeDto
        {
            Id = 1,
            Name = "Marcela",
            LastName = "Lopez",
            Address = "Miami",
            HireDate = new DateOnly(2023, 1, 1)
        };

        var existingEmployee = new Employee
        {
            Id = 1,
            Name = "OldName",
            LastName = "OldLastName",
            Address = "OldAddress",
            HireDate = new DateOnly(2022, 1, 1)
        };

        _employeeRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(existingEmployee);
        await _employeeService.Update(employeeDto);
        _employeeRepository.Verify(repo => repo.Update(It.Is<Employee>(e =>
            e.Id == employeeDto.Id &&
            e.Name == employeeDto.Name &&
            e.LastName == employeeDto.LastName &&
            e.Address == employeeDto.Address &&
            e.HireDate == employeeDto.HireDate
        )), Times.Once);
    }

    [Fact]
    public async Task Delete_ShouldCallRepositoryDelete_WhenIdIsValid()
    {
        var id = 1;
        await _employeeService.Delete(id);
        _employeeRepository.Verify(repo => repo.Delete(id), Times.Once);
    }

}
