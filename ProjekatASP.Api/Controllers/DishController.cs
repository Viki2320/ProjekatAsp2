using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Searches;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DishController : ControllerBase
    {
        private UseCaseHandler handler;
        private readonly IApplicationUser actor;
        public static IEnumerable<string> AllowedExtensions =>
            new List<string> { ".jpg", ".png", ".jpeg" };


        public DishController(UseCaseHandler handler, IApplicationUser actor)
        {
            this.handler = handler;
            this.actor = actor;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateDishDto dto, [FromServices] ICreateDishCommand command)
        {
            if (/*dto.NewPrice != null || */dto.NewPrice != 0)
            {
                dto.OnSale = true;
            }
            else
            {
                dto.OnSale = false;
            }

            //if(dto.NewPrice == 0)
            //{
            //    dto.OnSale = false;
            //}
            if(dto.OnSale == false)
            {
                dto.NewPrice = 0;
            }

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.ImageObj.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.ImageObj.CopyTo(fileStream);
            }
            dto.Image = newFileName;
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] DishSearch search, [FromServices] IGetDishesQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        
        [HttpGet("{id}", Name = "Get")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetOneDishQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteDishCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateDishDto dto, [FromServices] IUpdateDishCommand command)
        {

            if (dto.NewPrice != 0)
            {
                dto.IsOnSale = true;
            }
            else
            {
                dto.IsOnSale = false;
            }

           
            if (dto.IsOnSale == false)
            {
                dto.NewPrice = 0;
            }

            if (dto.ImageObj != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.ImageObj.FileName);

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.ImageObj.CopyTo(fileStream);
                }

                dto.Image = newFileName;
            }

            dto.Id = id;
            handler.HandleCommand(command, dto);
            return NoContent();
        }

    }
}
