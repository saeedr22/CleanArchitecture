using CA.Application.DTO.External;
using CA.Application.Services;
using CA.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Destination destination)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}
