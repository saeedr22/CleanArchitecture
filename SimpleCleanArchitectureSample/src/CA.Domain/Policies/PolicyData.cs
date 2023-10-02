using CA.Domain.ValueObjects;

namespace CA.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature,
        Destination Destination);
}
