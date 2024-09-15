public interface IRequestRepository
{
    Request GetById(int id);
    Task SaveRequest(Request request);
}