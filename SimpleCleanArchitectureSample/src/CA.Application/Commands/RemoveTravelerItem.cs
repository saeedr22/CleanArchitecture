using CA.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Commands
{
    public record RemoveTravelerItem(Guid TravelerCheckListId, string Name) : ICommand;
}
