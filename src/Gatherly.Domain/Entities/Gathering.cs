using System.Net.Http.Headers;
using Gatherly.Domain.Enums;
using Gatherly.Domain.Primitives;


namespace Gatherly.Domain.Entities
{
    public sealed class Gathering : Entity
    {
        private readonly List<Invitation> _invitations = new();
        private readonly List<Attendee> _attendees = new();
        private Gathering(
            Guid id,
            Member creator,
            GatheringType type,
            string name,
            DateTime scheduledAtUtc,
            string location)
            : base(id)
        {
            Creator = creator;
            Type = type;
            Name = name;
            ScheduledAtUtc = scheduledAtUtc;
            Location = location;
        }

        private Gathering()
        {
        }

        public Member Creator { get; private set; }
        public GatheringType Type { get; private set; }
        public string Name { get; private set; }
        public DateTime ScheduledAtUtc { get; private set; }
        public string Location { get; private set; }
        public int? MaximumNumberOfAttendees { get; private set; }
        public DateTime InvitationsExpireAtUtc { get; private set; }
        public int NumberOfAttendees { get;  private set; }
        public bool Cancelled { get; private set; }
        public IReadOnlyCollection<Attendee> Attendees => _attendees;
        public IReadOnlyCollection<Invitation> Invitations => _invitations;

        public static Gathering Create(
             Guid id,
             Member creator,
             GatheringType type,
             string name,
             DateTime scheduledAtUtc,
             string location,
             int? maximumNumberOfAttendees,
             int? invitationsValidBeforeInHours)
        {
           var gathering = new Gathering(
              id,
              creator,
              type,
              name,
              scheduledAtUtc,
              location);

            gathering.CalculateGatheringTypeDetails(maximumNumberOfAttendees, invitationsValidBeforeInHours);

            return gathering;
        }

        private void CalculateGatheringTypeDetails(
            int? maximumNumberOfAttendees,
            int? invitationsValidBeforeInHours)
        {
            switch (Type)
            {
                case GatheringType.WithFixedNumberOfAttendees:
                    if (maximumNumberOfAttendees is null)
                    {
                        throw new Exception(
                            $"{nameof(maximumNumberOfAttendees)} can't be null.");
                    }

                    MaximumNumberOfAttendees = maximumNumberOfAttendees;
                    break;
                case GatheringType.WithExpirationForInvitations:
                    if (invitationsValidBeforeInHours is null)
                    {
                        throw new Exception(
                            $"{nameof(invitationsValidBeforeInHours)} can't be null.");
                    }

                    InvitationsExpireAtUtc =
                        ScheduledAtUtc.AddHours(-invitationsValidBeforeInHours.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(GatheringType));
            }
        }

        public Invitation SendInvitation(Member member)
        {
            if (Creator.Id == member.Id)
            {
               throw new Exception("can't send invitation");
            }

            if (ScheduledAtUtc < DateTime.UtcNow)
            {
                throw new Exception("can't send invitation");
            }

            var invitation = new Invitation(Guid.NewGuid(), member, this);

            _invitations.Add(invitation);

            return invitation;
        }

        public Attendee AcceptInvitation(Invitation invitation)
        {
            var attendee = invitation.Accept();
            _attendees.Add(attendee);
            NumberOfAttendees++;

            return attendee;
        }
    }
}
