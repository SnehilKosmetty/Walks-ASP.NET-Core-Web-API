using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Models.DTO;

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext _context;
        public RegionsController(WalksDbContext dbContext)
        {
            _context = dbContext;
        }

        //GET All Regions
        //GET : https://localhost:portnumber/api/regions

        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data From Databse - Domain Models
            var regionsDomain = _context.Regions.ToList();

            //Map Domain Model to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var region in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }


            //Return DTOs
            return Ok(regionsDto);

        }

        //Get Single Region(Get Region By ID)
        //GET : https://localhost:portnumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = _context.Regions.Find(id);
            //Get region Domain model from Database
            var region = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain to Region DTO
            var regionsDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };

            //Retrun DTOs Back to client
            return Ok(regionsDto);
        }


        //Post To Create New Region
        //Post : https://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region
            _context.Regions.Add(regionDomainModel);
            _context.SaveChanges();


            //Map Domain model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }


        //Update region 
        //PUT : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if region exists
            var regionDomainModel = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;


            _context.SaveChanges();


            //Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };
            return Ok(regionDto);
        }


        //Delete Region
        //DELETE : https:localhost:portnumber/api/regiosn/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Delete Region
            _context.Regions.Remove(regionDomainModel);
            _context.SaveChanges();

            //Return the deleted region back
            //map domain model to DTO 
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };
            return Ok(regionDto);

        }

    }
}
