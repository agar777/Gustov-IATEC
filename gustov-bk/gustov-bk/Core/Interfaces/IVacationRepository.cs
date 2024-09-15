public interface IVacationRepository
{
    Task<Vacation> GetById(int id);
    Task SaveVacation(Vacation vacation);
}