using CA.Domain.Consts;
using CA.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Commands
{
    public record CreateTravelerCheckListWithItems(Guid Id, string Name, ushort Days, Gender Gender,
       DestinationWriteModel Destionation) : ICommand;

    public record DestinationWriteModel(string City, string Country);
}

