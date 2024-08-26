namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {

        private readonly ApplicationDbContext _context;
        public DevicesService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices
                .Select(c => new SelectListItem { Value=c.Id.ToString(), Text=c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
