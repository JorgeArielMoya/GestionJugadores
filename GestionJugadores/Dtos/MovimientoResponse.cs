﻿namespace GestionJugadores.Dtos;

public record MovimientoResponse(
    int MovimientoId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
);