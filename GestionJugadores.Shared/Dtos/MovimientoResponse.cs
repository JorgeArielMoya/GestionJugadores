namespace GestionJugadores.Shared.Dtos;

public record MovimientoResponse(
    int MovimientoId,
    int JugadorId,
    int PosicionFila,
    int PosicionColumna
);

