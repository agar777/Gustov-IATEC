public interface IRequestService
{
    RequestDto GetById(int id);
    Task SaveRequest(RequestDto requestDto);
}