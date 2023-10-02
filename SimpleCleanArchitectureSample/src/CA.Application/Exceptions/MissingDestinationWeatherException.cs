﻿using CA.Domain.ValueObjects;
using CA.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Exceptions
{
    public class MissingDestinationWeatherException : TravelerCheckListException
    {
        public Destination Destination { get; }

        public MissingDestinationWeatherException(Destination destination)
            : base($"Couldn't fetch weather data for Destination '{destination.Country}/{destination.City}'.")
        {
            Destination = destination;
        }
    }
}
