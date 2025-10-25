namespace GestionJugadores.Shared.Dtos;

public record MovimientoRequest(
    int PartidaId,
    int JugadorId,
    int PosicionFila,
    int PosicionColumna
);
