using CA.Domain.Consts;
using CA.Domain.Entities;
using CA.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Factories
{
    public interface ITravelerCheckListFactory
    {
        TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination);

        TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, Gender gender,
            Temperature temperature, Destination destination);
    }
}
