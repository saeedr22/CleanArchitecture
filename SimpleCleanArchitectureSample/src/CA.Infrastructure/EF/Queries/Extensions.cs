﻿using CA.Application.DTO;
using CA.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static TravelerCheckListDto AsDto(this TravelerCheckListReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Destination = new DestinationDto
                {
                    City = readModel.Destination?.City,
                    Country = readModel.Destination?.Country
                },
                Items = readModel.Items?.Select(pi => new TravelerItemDto
                {
                    Name = pi.Name,
                    Quantity = pi.Quantity,
                    IsTaken = pi.IsTaken,
                })
            };
    }
}
