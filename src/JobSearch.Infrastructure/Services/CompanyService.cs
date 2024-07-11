﻿using JobSearch.Application.Interfaces;
using JobSearch.Application.Repositories;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Company;

namespace JobSearch.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult<CreateCompanyResponse>> Add(CompanyRequest request)
        {
            var company = new JobSearch.Domain.Entities.Company()
            {
                Name = request.Name,
                Email = request.Email,
                About = request.About
            };
            var response = new CreateCompanyResponse()
            {
                Email = company.Email,
                Name = company.Name,
                About = company.About
            };

            _unitOfWork.Companies.Add(company);

            return ApiResult<CreateCompanyResponse>.Ok(response);
        }
    }
}
