

using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.Entities
{
    public sealed class Member : Entity
    {
        private Member(Guid id, string email, string firstName, string lastName)
      : base(id)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }


        public static Member Create(
            Guid id,
            string email,
            string firstName,
            string lastName
           /* bool isEmailUnique*/)
        {

            //if(!isEmailUnique)
            //{
            //    return null;
            //}
            var member = new Member(
                id,
                email,
                firstName,
                lastName);

            return member;
        }

    }
}
