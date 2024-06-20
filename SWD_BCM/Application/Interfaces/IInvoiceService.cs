using Application.ServiceResponses;
using Application.ViewModels.InvoiceDTOs;

namespace Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<ServiceResponse<IEnumerable<InvoiceViewDTO>>> GetInvoicesAsync();
        Task<ServiceResponse<InvoiceViewDTO>> GetInvoiceByIdAsync(int id);
        Task<ServiceResponse<InvoiceViewDTO>> CreateInvoiceAsync(InvoiceCreateDTO createdto);
        Task<ServiceResponse<InvoiceViewDTO>> UpdateInvoiceAsync(int id, InvoiceUpdateDTO updatedto);
        Task<ServiceResponse<InvoiceViewDTO>> DeleteInvoiceAsync(int id);
    }
}
