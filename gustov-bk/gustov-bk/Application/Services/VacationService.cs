
public class VacationService : IVacationService
{
    private readonly IVacationRepository vacationRepository;
    private readonly IRequestService requestService;
    private readonly IVacationValidator vacationValidator;

    public VacationService(
        IVacationRepository vacationRepository, 
        IRequestService requestService,
        IVacationValidator vacationValidator
    ){
        this.vacationRepository = vacationRepository;
        this.requestService = requestService;
        this.vacationValidator = vacationValidator;
    }

    public async Task<VacationDto> GetById(int id)
    {
        var vacation = await vacationRepository.GetById(id);
        if (vacation == null)
        {
            return null;
        }

        return new VacationDto{
            Id = vacation.Id,
            RequestId = vacation.RequestId,
            StartDate = vacation.StartDate,
            EndDate = vacation.EndDate,
            Request = vacation.Request != null ? new RequestDto{
                Id = vacation.Request.Id,
                EmployeeId = vacation.Request.EmployeeId,
                RequestDate = vacation.Request.RequestDate,
                Status = vacation.Request.Status
            }:null
        };
    }

    public async Task SaveVacation(VacationDto vacationDto)
    {
        bool isValid = vacationValidator.ValidateVacationRequest(requestService,vacationDto);
        DateOnly endDate = vacationValidator.ValidateVacationDay(requestService,vacationDto).endDate;

        if (isValid)
        {
            
            var vacation = new Vacation{
                RequestId = vacationDto.RequestId,
                StartDate = vacationDto.StartDate,
                EndDate = endDate
            };

            await vacationRepository.SaveVacation(vacation);            
        }
    }
}