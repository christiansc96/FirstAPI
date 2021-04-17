using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DominiCode.Models;
using DominiCodeAPI.DTOs;
using DominiCodeAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository.Domini.Repository;

namespace DominiCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDominiRepository _bdRepository;
        private readonly LogicValidations logicValidations = new LogicValidations();

        public CategoriesController(IDominiRepository bdRepository)
        {
            _bdRepository = bdRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoriesDTO> categoriesDTO = new List<CategoriesDTO>();

            List<ClientCategory> categoriesFromDatabase = await _bdRepository.GetClientCategories();
            foreach (var category in categoriesFromDatabase)
            {
                CategoriesDTO categoryDTO = new CategoriesDTO() 
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Active = category.Active
                };
                categoriesDTO.Add(categoryDTO);
            }
            return Ok(categoriesDTO);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            ClientCategory categoryFromDatabase = await _bdRepository.GetClientCategory(id);
            if (logicValidations.ValidateIfDataIsNotNull(categoryFromDatabase))
            {
                CategoriesDTO categoryDTO = new CategoriesDTO() 
                {
                    CategoryId = categoryFromDatabase.CategoryId,
                    CategoryName = categoryFromDatabase.CategoryName,
                    Active = categoryFromDatabase.Active
                };
                return Ok(categoryDTO);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoriesDTO model)
        {
            ClientCategory newClientCategory = new ClientCategory()
            {
                CategoryName = model.CategoryName,
                Active = model.Active
            };

            ClientCategory categoryFromDatabase = await _bdRepository.PostClientCategory(newClientCategory);
            if (logicValidations.ValidateIfDataIsNotNull(categoryFromDatabase))
            {
                model.CategoryId = categoryFromDatabase.CategoryId;
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ClientCategory categoryFromDatabase = await _bdRepository.GetClientCategory(id);
            if (!logicValidations.ValidateIfDataIsNotNull(categoryFromDatabase))
            {
                return NotFound();
            }

            bool resulFromDatabase = await _bdRepository.DeleteClientCategory(categoryFromDatabase);
            if (!resulFromDatabase)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}