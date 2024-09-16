public interface IRequestValidator
{
    Task ValidateRequestByEmployee(IRequestRepository requestRepository, RequestDto requestDto);
}
