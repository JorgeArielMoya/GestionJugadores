using GestionJugadores.Shared;
using GestionJugadores.Shared.Dtos;
using System.Net.Http.Json;

namespace GestionJugadores.BlazorWasm.Services;

public interface IMovimientoApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientosByPartidaAsync(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimientoAsync(MovimientoRequest movimientoRequest);
}

public class MovimientosApiService(HttpClient httpClient) : IMovimientoApiService
{
    public async Task<Resource<List<MovimientoResponse>>> GetMovimientosByPartidaAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<MovimientoResponse>>($"api/Movimientos/partida/{partidaId}");
            return new Resource<List<MovimientoResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<MovimientoResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<MovimientoResponse>> PostMovimientoAsync(MovimientoRequest movimientoRequest)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Movimientos", movimientoRequest);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<MovimientoResponse>();
            return new Resource<MovimientoResponse>.Success(created!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<MovimientoResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<MovimientoResponse>.Error("Respuesta inválida del servidor.");
        }
    }
}