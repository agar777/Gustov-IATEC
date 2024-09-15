
public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

     public async Task<IEnumerable<EmployeeDto>> GetAll()
    {
        var employees = await employeeRepository.GetAll();
        return employees.Select(e=>new EmployeeDto{
            Id = e.Id,
            Name = e.Name,
            LastName = e.LastName,
            Address  = e.Address,   
            HireDate = e.HireDate
        });
    }

    public async Task<EmployeeDto> GetById(int id)
    {
        var employee = await employeeRepository.GetById(id);
        if (employee==null)
        {
            return null;
        }

        return new EmployeeDto{
            Id = employee.Id,
            Name = employee.Name,
            LastName = employee.LastName,
            Address  = employee.Address,
            HireDate = employee.HireDate
        };
    }

    public async Task Save(EmployeeDto employeeDto)
    {

        var employee = new Employee{
            Name = employeeDto.Name,
            LastName = employeeDto.LastName,
            Address  = employeeDto.Address,
            HireDate  = employeeDto.HireDate
        };
        await employeeRepository.Save(employee);
    }

    public async Task Update(EmployeeDto employeeDto)
    {
        var employee = await employeeRepository.GetById(employeeDto.Id);
        if (employee!=null)
        {
            employee.Name = employeeDto.Name;
            employee.LastName = employeeDto.LastName;
            employee.Address  = employeeDto.Address;
            employee.HireDate = employeeDto.HireDate;
            await employeeRepository.Update(employee);
        }
    }

    public async Task Delete(int id)
    {
        await employeeRepository.Delete(id);
    }
}