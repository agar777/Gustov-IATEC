public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAll();
    Task<EmployeeDto> GetById(int id);
    Task Save(EmployeeDto employeeDto);
    Task Update(EmployeeDto employeeDto);
    Task Delete(int id);
}   