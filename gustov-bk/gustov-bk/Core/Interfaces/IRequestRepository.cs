public interface IRequestRepository
{
    Task<IEnumerable<Request>> GetAll();
    Request GetById(int id);
    Task SaveRequest(Request request);
    Task Update(Request request);
    Task<Request> GetRequestsByEmployee(int employeeId, int year);    

}