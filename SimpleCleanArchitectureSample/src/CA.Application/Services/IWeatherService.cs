using CA.Application.DTO.External;
using CA.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(Destination localization);
    }
}
