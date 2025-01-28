using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Walks.API.Data;
using Walks.API.Models.Domain;
using Walks.API.Models.DTO;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext _context;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(WalksDbContext dbContext, IRegionRepository regionRepository,IMapper mapper)
        {
            this._context = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GET All Regions
        //GET : https://localhost:portnumber/api/regions

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Databse - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain Model to DTOs before AutoMapper

            //var regionsDto = new List<RegionDto>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}

            //Map Domain Model to DTOs After AutoMapper
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            //Return DTOs
            return Ok(regionsDto);

        }

        //Get Single Region(Get Region By ID)
        //GET : https://localhost:portnumber/api/regions/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            

            //Get region Domain model from Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain to Region DTO before AutoMapper

            //var regionsDto = new RegionDto
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImageUrl = region.RegionImageUrl,
            //};

            //Map/Convert Region Domain to Region DTO After AutoMapper
            var regionsDto = mapper.Map<RegionDto>(regionDomain);

            //Retrun DTOs Back to client
            return Ok(regionsDto);
        }


        //Post To Create New Region
        //Post : https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model before AutoMapper

            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};

            //Map or Convert DTO to Domain Model After AutoMapper
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);



            //Map Domain model back to DTO before AutoMapper

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            //Map Domain model back to DTO After AutoMapper
            var regionDto =  mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }


        //Update region 
        //PUT : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map DTO to Domain model before AutoMapper

            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl= updateRegionRequestDto.RegionImageUrl
            //};

            //Map DTO to Domain model After AutoMapper
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            //Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO before AutoMapper

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl

            //};

            //Convert Domain Model to DTO After AutoMapper
            var regionDto = mapper.Map<Region>(regionDomainModel);

            return Ok(regionDto);
        }


        //Delete Region
        //DELETE : https:localhost:portnumber/api/regiosn/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


            //Return the deleted region back

            //map domain model to DTO before AutoMapper
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl

            //};

            //map domain model to DTO After AutoMapper
            var regionDto = mapper.Map<Region>(regionDomainModel);

            return Ok(regionDto);

        }

    }
}
