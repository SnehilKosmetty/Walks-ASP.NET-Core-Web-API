﻿using System.ComponentModel.DataAnnotations;

namespace Walks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to be a minimum of 3 charcters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 charcters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be a maximum of 3 charcters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
