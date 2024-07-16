using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Pagination;
using JobSearch.Models.v1.Vacancy;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Infrastructure.Services
{
    public class VacancyService : BaseService, IVacancyService
    {
        public VacancyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<ApiResult<CreateVacancyResponse>> Add(VacancyRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();
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

                await _unitOfWork.VacanciesWrite.Table.AddAsync(vacancy);
                await _unitOfWork.VacanciesWrite.Complete();
                await _unitOfWork.CommitTransactionAsync();



                return ApiResult<CreateVacancyResponse>.Ok(response);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResult<CreateVacancyResponse>.Error();
            }
            finally
            {
                await _unitOfWork.DisposeAsync();
            }
        }

        public async Task<List<GetVacancyDto>> GetAll(PaginationModel model)
        {
            try
            {
                var vacancies = _unitOfWork.VacanciesRead.GetAll();

                if (vacancies is null)
                    return new List<GetVacancyDto>();

                var dto = await vacancies.Select(c => new GetVacancyDto()
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

                })
                .Skip((model.PageNumber - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToListAsync();

                return dto;

            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return new List<GetVacancyDto>();
            }
        }

        public async Task<GetVacancyDto> GetById(int id)
        {
            try
            {
                if (id == 0)
                    return new GetVacancyDto();

                var vacancy = await _unitOfWork.VacanciesRead.GetByIdAsync(id);

                if (vacancy is null)
                    return new GetVacancyDto();

                var vacancyDto = new GetVacancyDto()
                {
                    VacancyId = vacancy.Id,
                    Name = vacancy.Name,
                    Description = vacancy.Description,
                    PhoneId = vacancy.PhoneId,
                    AddressId = vacancy.AddressId,
                    CategoryId = vacancy.CategoryId,
                    SeniorityId = vacancy.SeniorityId,
                    SalaryId = vacancy.SalaryId,
                    Website = vacancy.Website,
                    CompanyId = vacancy.CompanyId,
                    IsPremium = vacancy.IsPremium,
                    JobTypeId = vacancy.JobTypeId,
                    OpportunityTypeId = vacancy.OpportunityTypeId
                };

                return vacancyDto;

            }
            catch (Exception)
            {
                await _unitOfWork.DisposeAsync();
                return new GetVacancyDto();
            }
        }
    }
}
