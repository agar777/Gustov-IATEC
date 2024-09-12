public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee> GetById(int id);
    Task Save(Employee employee);
    Task Update(Employee employee);
    Task Delete(int id);
}