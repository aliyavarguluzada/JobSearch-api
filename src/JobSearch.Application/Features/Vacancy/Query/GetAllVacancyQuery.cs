using JobSearch.Application.Result;
using JobSearch.Models.v1.Vacancy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Features.Vacancy.Query
{
    public class GetAllVacancyQuery : IRequest<List<GetAllVacanciesDto>>
    {

    }
}
