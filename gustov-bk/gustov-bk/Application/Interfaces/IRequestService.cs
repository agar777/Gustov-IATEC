public interface IRequestService
{
    Task<IEnumerable<RequestDto>> GetAll();
    RequestDto GetById(int id);
    Task SaveRequest(RequestDto requestDto);
    Task Update(int id);

}