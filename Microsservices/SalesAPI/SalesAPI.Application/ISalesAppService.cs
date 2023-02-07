using FluentValidation.Results;
using SalesAPI.Application.ViewModels;

namespace SalesAPI.Application
{
    public interface ISalesAppService
    {
        Task<List<SalesListViewModel>> GetAll();
        Task<ValidationResult> Register(SalesRegisterViewModel salesRegisterViewModel);
        Task<List<SalesConsolidateReportViewModel>> TotalProductsSold();
    }
}