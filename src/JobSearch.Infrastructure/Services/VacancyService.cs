using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;

namespace JobSearch.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VacancyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request)
        {

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    return ApiResult<CreateVacancyResponse>.Error();


                var vacancy = new JobSearch.Domain.Entities.Vacancy()
                {
                    Name = request.Name,
                    Description = request.Description,
                    AddressId = request.AddressId,
                    CategoryId = request.CategoryId,
                    CompanyId = request.CompanyId,
                    IsPremium = request.IsPremium,
                    JobTypeId = request.JobTypeId,
                    OpportunityTypeId = request.OpportunityTypeId,
                    PhoneId = request.PhoneId,
                    SalaryId = request.SalaryId,
                    SeniorityId = request.SeniorityId,
                    Website = request.Website
                };

                var response = new CreateVacancyResponse()
                {
                    Name = vacancy.Name,
                    Description = vacancy.Description
                };

                await _unitOfWork.Vacancies.Table.AddAsync(vacancy);
                await _unitOfWork.Vacancies.Complete();


                return ApiResult<CreateVacancyResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return ApiResult<CreateVacancyResponse>.Error();
            }
        }

        public async Task<List<GetAllVacanciesDto>> GetAll()
        {
            try
            {
                var vacancies = _unitOfWork.VacanciesRead.GetAll();

                var dto = vacancies.Select(c => new GetAllVacanciesDto()
                {
                    VacancyId = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    PhoneId = c.PhoneId,
                    AddressId = c.AddressId,
                    CategoryId = c.CategoryId,
                    CompanyId = c.CompanyId,
                    IsPremium = c.IsPremium,
                    JobTypeId = c.JobTypeId,
                    OpportunityTypeId = c.OpportunityTypeId,
                    SalaryId = c.SalaryId,
                    SeniorityId = c.SeniorityId,
                    Website = c.Website

                }).ToList();

                return dto;

            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return new List<GetAllVacanciesDto>();
            }
        }
    }
}
