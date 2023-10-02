using CA.Shared.Abstractions.Commands;


namespace CA.Application.Commands
{
    public record AddTravelerItem(Guid TravelerCheckListId, string Name, uint Quantity) : ICommand;
}
