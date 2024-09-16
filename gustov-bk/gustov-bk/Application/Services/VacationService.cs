
using System.Text.Json;

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
            return new VacationDto();
        }

        return new VacationDto{
            Id = vacation.Id,
            RequestId = vacation.RequestId,
            StartDate = vacation.StartDate,
            EndDate = vacation.EndDate,
            TotalDays= vacationValidator.ValidateVacationDay(requestService,id).daysPerYearWorked,
            YearsWorked= vacationValidator.ValidateVacationDay(requestService,id).yearsWorked,
            Request = vacation.Request != null ? new RequestDto{
                Id = vacation.Request.Id,
                EmployeeId = vacation.Request.EmployeeId,
                RequestDate = vacation.Request.RequestDate,
                Status = vacation.Request.Status,
                Employee = vacation.Request.Employee !=null?new EmployeeDto{
                    Id = vacation.Request.Employee.Id,
                    Name = vacation.Request.Employee.Name,
                    LastName = vacation.Request.Employee.LastName,
                    Address = vacation.Request.Employee.Address,
                    HireDate = vacation.Request.Employee.HireDate,
                }:null
            }:null
        };
    }

    public async Task SaveVacation(int requestId)
    {
        bool isValid = vacationValidator.ValidateVacationRequest(requestService,requestId);
        DateOnly endDate = vacationValidator.ValidateVacationDay(requestService,requestId).endDate;

        if (isValid)
        {
            
            await requestService.Update(requestId);
            var request = requestService.GetById(requestId);
            var vacation = new Vacation{
                RequestId = requestId,
                StartDate = request.RequestDate,
                EndDate = endDate
            };


            await vacationRepository.SaveVacation(vacation);            
        }
    }
}