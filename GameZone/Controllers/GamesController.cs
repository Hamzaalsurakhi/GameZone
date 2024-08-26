

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;
        public GamesController(ApplicationDbContext dbContext, ICategoryService categoryService, IDevicesService devicesService,
            IGamesService gamesService)
        {
            _context = dbContext;
            _categoryService = categoryService;
            _devicesService = devicesService;
            _gamesService=gamesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            CreateGameFormVM viewModel = new()
            {
                Categories=_categoryService.GetSelectList(),
                Devices=_devicesService.GetDevices()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(CreateGameFormVM model)
        {
            if (!ModelState.IsValid) 
            {
                model.Categories=_categoryService.GetSelectList();
                model.Devices=_devicesService.GetDevices();
                return View(model);
            }
          await  _gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        } 
            
            
    }
}
