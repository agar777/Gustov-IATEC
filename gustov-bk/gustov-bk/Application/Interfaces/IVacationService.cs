public interface IVacationService
{
    Task<VacationDto> GetById(int id);
    Task SaveVacation(int requestId);   
}