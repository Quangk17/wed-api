using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;


namespace Application.Interfaces
{
    public interface ICourtService
    {
        Task<ServiceResponse<List<CourtDTO>>> GetCourtsAsync();
    }
}
