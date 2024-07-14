using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.Salary;
using MediatR;

namespace JobSearch.Application.Features.Salary
{
    public class CreateSalaryCommandHandler : IRequestHandler<CreateSalaryCommand, ApiResult<CreateSalaryResponse>>
    {
        private readonly ISalaryService _salaryService;

        public CreateSalaryCommandHandler(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public async Task<ApiResult<CreateSalaryResponse>> Handle(CreateSalaryCommand request, CancellationToken cancellationToken)
        => await _salaryService.Add(request.SalaryRequest);
    }
}
