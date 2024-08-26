namespace GameZone.Services
{
    public class GamesService :IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly string _imagesPath;
        public GamesService(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = dbContext;
            _WebHostEnvironment=webHostEnvironment;
            _imagesPath=$"{_WebHostEnvironment.WebRootPath}/assets/images/Games";
        }

        public async Task Create(CreateGameFormVM model)
        {
            var caverName=$"{Guid.NewGuid()} {Path.GetExtension(model.Cover.FileName)}";

            var path = Path.Combine(_imagesPath, caverName);

            using var stream=File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();

            Game game = new()
            {
                Name=model.Name,
                Description=model.Description,
                CategoryId=model.CategoryId,
                Cover=caverName,
                Devices=model.SelectedDevices.Select(d => new GameDevice { DeviceId =d }).ToList()
            };
            _context.Add(game);
            _context.SaveChanges();
        }
    }
}
