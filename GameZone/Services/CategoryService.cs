﻿
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Categories
                .Select(c => new SelectListItem { Value=c.Id.ToString(), Text=c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
