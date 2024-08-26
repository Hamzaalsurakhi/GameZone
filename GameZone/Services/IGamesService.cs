namespace GameZone.Services
{
    public interface IGamesService
    {
        Task Create(CreateGameFormVM game);
    }
}
