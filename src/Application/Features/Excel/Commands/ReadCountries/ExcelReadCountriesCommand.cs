using Domain.Common;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCountries;

public class ExcelReadCountriesCommand:IRequest<Response<int>>
{
    public string ExcelBase64Fiile { get; set; }
}