﻿using JobSearch.Application.Result;
using JobSearch.Models.v1.City;
using MediatR;

namespace JobSearch.Application.Features.City.Command
{
    public class CreateCityCommand : IRequest<ApiResult<CreateCityResponse>>
    {
        public CreateCityCommand(CityRequest request)
        {
            CityRequest = request;
        }
        public CityRequest CityRequest { get; set; }
    }
}
