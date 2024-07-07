using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.InvoiceDTOs;


namespace Application.Interfaces
{
    public interface ICourtService
    {
        Task<ServiceResponse<List<CourtDTO>>> GetCourtsAsync();
        Task<ServiceResponse<CourtDTO>> GetCourtByIdAsync(int id);
        Task<ServiceResponse<CourtDTO>> CreateCourtAsync(CourtCreateDTO createdto);
        Task<ServiceResponse<CourtDTO>> UpdateCourtAsync(int id, CourtUpdateDTO updatedto);
        Task<ServiceResponse<CourtDTO>> DeleteCourtAsync(int id);
    }
}
