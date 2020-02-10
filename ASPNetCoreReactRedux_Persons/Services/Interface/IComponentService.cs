using ASPNetCoreReactRedux_Persons.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreReactRedux_Persons.Services
{
    public interface IComponentService
    {
        Task<List<SelectListItem>> GetPessoasAsync();
        Task<List<SelectListItem>> GetCidadesAsync(string uf = "");
        Task<List<SelectListItem>> GetEstadosAsync();
        Task<List<SelectListItem>> GetLinguasAsync();
    }
}
