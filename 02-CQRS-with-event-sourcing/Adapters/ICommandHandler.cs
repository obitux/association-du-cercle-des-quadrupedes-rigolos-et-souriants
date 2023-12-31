namespace _02_CQRS_with_event_sourcing.Adapters;

public interface ICommandHandler<in TCommand>
{
    void Handle(TCommand command);
}