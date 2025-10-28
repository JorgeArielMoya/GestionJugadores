namespace GestionJugadores.Dtos;

public record PartidaRequest(
    int Jugador1Id,
    int? Jugador2Id
);
