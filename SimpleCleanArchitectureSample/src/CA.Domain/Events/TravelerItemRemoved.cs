using CA.Domain.Entities;
using CA.Domain.ValueObjects;
using CA.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Events
{
    public record TravelerItemRemoved(TravelerCheckList TravelerCheckList, TravelerItem TravelerItem) : IDomainEvent;
}
