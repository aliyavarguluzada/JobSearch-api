using JobSearch.Application.Interfaces;
using JobSearch.Application.Result;
using JobSearch.Models.v1.City;
using MediatR;

namespace JobSearch.Application.Features.City
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, ApiResult<CreateCityResponse>>
    {
        private readonly ICityService _cityService;

        public CreateCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<ApiResult<CreateCityResponse>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        => await _cityService.Add(request.CityRequest);
    }
}
