using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.BookingTypeDTOs;
using Application.ViewModels.InvoiceDTOs;
using AutoMapper;
using Domain.Entites;

namespace Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<InvoiceViewDTO>> CreateInvoiceAsync(InvoiceCreateDTO createdto)
        {
            var reponse = new ServiceResponse<InvoiceViewDTO>();

            try
            {
                var entity = _mapper.Map<Invoice>(createdto);

                await _unitOfWork.InvoiceRepository.AddAsync(entity);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<InvoiceViewDTO>(entity);
                    reponse.Success = true;
                    reponse.Message = "Create new Invoice successfully";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "Create new Invoice fail";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }

        public async Task<ServiceResponse<InvoiceViewDTO>> DeleteInvoiceAsync(int id)
        {
            var reponse = new ServiceResponse<InvoiceViewDTO>();
            try
            {
                var Checked = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);

                if (Checked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found invoice, you are sure input";
                    reponse.Error = "Not found invoice";
                }
                else if (Checked.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "invoice are deleted, can not delete invoice.";
                }
                else
                {

                    _unitOfWork.InvoiceRepository.SoftRemove(Checked);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Success = true;
                        reponse.Message = "Update invoice successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update invoice fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update invoice fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<InvoiceViewDTO>> GetInvoiceByIdAsync(int id)
        {
            var _response = new ServiceResponse<InvoiceViewDTO>();
            try
            {
                var c = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);
                if (c == null)
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Invoice ";
                }
                else
                {
                    _response.Data = _mapper.Map<InvoiceViewDTO>(c);
                    _response.Success = true;
                    _response.Message = "Invoice Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        public async Task<ServiceResponse<IEnumerable<InvoiceViewDTO>>> GetInvoicesAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<InvoiceViewDTO>>();
            List<InvoiceViewDTO> InvoiceDTOs = new List<InvoiceViewDTO>();
            try
            {
                var bs = await _unitOfWork.InvoiceRepository.GetAllAsync();
                foreach (var b in bs)
                {
                    InvoiceDTOs.Add(_mapper.Map<InvoiceViewDTO>(b));
                }
                if (InvoiceDTOs.Count > 0)
                {
                    reponse.Data = InvoiceDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {InvoiceDTOs.Count} Invoice.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {InvoiceDTOs.Count} Invoice.";
                    reponse.Error = "Not have a Invoice";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<InvoiceViewDTO>> UpdateInvoiceAsync(int id, InvoiceUpdateDTO updatedto)
        {
            var reponse = new ServiceResponse<InvoiceViewDTO>();

            try
            {
                var enityById = await _unitOfWork.InvoiceRepository.GetByIdAsync(id);

                if (enityById != null)
                {
                    var newb = _mapper.Map(updatedto, enityById);
                    var bAfter = _mapper.Map<Invoice>(newb);
                    _unitOfWork.InvoiceRepository.Update(bAfter);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Success = true;
                        reponse.Data = _mapper.Map<InvoiceViewDTO>(bAfter);
                        reponse.Message = $"Successfull for update Invoice.";
                        return reponse;
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Error = "Save update failed";
                        return reponse;
                    }

                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have no Invoice.";
                    reponse.Error = "Not have a Invoice";
                    return reponse;
                }

            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }
    }
}
