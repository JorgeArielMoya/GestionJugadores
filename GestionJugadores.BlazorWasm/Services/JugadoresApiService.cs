using GestionJugadores.Shared;
using GestionJugadores.Shared.Dtos;
using System.Net.Http.Json;

namespace GestionJugadores.BlazorWasm.Services;

public interface IJugadorApiService
{
    Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
}

public class JugadorApiService(HttpClient httpClient) : IJugadorApiService
{
    public async Task<Resource<List<JugadorResponse>>> GetJugadoresAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<JugadorResponse>>("api/Jugadores");
            return new Resource<List<JugadorResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<JugadorResponse>>.Error(ex.Message);
        }
    }
}