using CA.Shared.Abstractions.Exceptions;

namespace CA.Domain.Exceptions
{
    public class TravelerCheckListIdException : TravelerCheckListException
    {

        public TravelerCheckListIdException() : base("Traveler Checklist ID cannot be empty.")
        {
        }
    }
}
