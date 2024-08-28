﻿

using GameZone.Attribute;
using System.Runtime.CompilerServices;

namespace GameZone.ViewModels
{
    public class CreateGameFormVM
    {
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Devices { get; set; }= Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [AllowedExtentions(FileSettings.AllowedExtensions),
            MaxFile(FileSettings.MinFilesInBYTES)]
        public IFormFile Cover { get; set; } = default!;
    }
}
