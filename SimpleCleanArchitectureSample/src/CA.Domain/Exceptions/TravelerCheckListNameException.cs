using CA.Shared.Abstractions.Exceptions;

namespace CA.Domain.Exceptions
{
    public class TravelerCheckListNameException : TravelerCheckListException
    {

        public TravelerCheckListNameException() : base("Traveler CheckList list name cannot be empty.")
        {
        }
    }
}
