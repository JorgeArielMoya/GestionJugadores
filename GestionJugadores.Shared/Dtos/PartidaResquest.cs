namespace GestionJugadores.Shared.Dtos;

public record PartidaResponse(
    int PartidaId,
    int Jugador1Id,
    int? Jugador2Id
);