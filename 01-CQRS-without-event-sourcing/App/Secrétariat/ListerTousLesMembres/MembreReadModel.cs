namespace _01_CQRS_without_event_sourcing.App.Secrétariat.ListerTousLesMembres;

public record MembreReadModel(string Id, string Nom, string Prénom, string Email);