using GestionJugadores.Dtos;

namespace GestionJugadores.Services;

public interface IPartidasApiService
{
    Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId);
}

public class PartidasApiService(HttpClient httpClient) : IPartidasApiService
{
    public async Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<PartidaResponse>($"api/Partidas/{partidaId}");
            return new Resource<PartidaResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<PartidaResponse>.Error(ex.Message);
        }
    }
}
