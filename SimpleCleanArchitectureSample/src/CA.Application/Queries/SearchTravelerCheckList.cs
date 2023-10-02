using CA.Application.DTO;
using CA.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Queries
{
    public class SearchTravelerCheckList : IQuery<IEnumerable<TravelerCheckListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
