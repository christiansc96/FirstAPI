using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DominiCode.Models;
using DominiCodeAPI.DTOs;
using DominiCodeAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Domini.Repository;

namespace DominiCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IDominiRepository _DominiRepository;
        public CategoriesController(IDominiRepository dominiRepository)
        {
            _DominiRepository = dominiRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var logicValidation = new LogicValidations();
            var categorisListDTO = new List<CategoriesDTO>();

            var categoriesFromDatabase = await _DominiRepository.GetClientCategories();
            if (logicValidation.ValidateDataCount(categoriesFromDatabase.Count))
            {
                foreach (var category in categoriesFromDatabase)
                {
                    var categoryDTO = new CategoriesDTO(category);
                    categorisListDTO.Add(categoryDTO);
                }
                return Ok(categorisListDTO);
            }
            else
            {
                return Ok(categorisListDTO);
            }
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var logicValidation = new LogicValidations();

            var categoryFromDatabase = await _DominiRepository.GetClientCategory(id);
            if (logicValidation.IsNotNull(categoryFromDatabase))
            {
                var categoryDTO = new CategoriesDTO(categoryFromDatabase);
                return Ok(categoryDTO);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(ClientCategory category)
        {
            var logicValidation = new LogicValidations();

            var categoryFromDatabase = await _DominiRepository.PostClientCategory(category);
            if (logicValidation.IsNotNull(categoryFromDatabase))
            {
                var categoryDTO = new CategoriesDTO(categoryFromDatabase);
                return Ok(categoryDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var logicValidation = new LogicValidations();

            var categoryFromDatabase = await _DominiRepository.GetClientCategory(id);
            if (!logicValidation.IsNotNull(categoryFromDatabase))
            {
                return NotFound();
            }

            var resulFromDatabase = await _DominiRepository.DeleteClientCategory(categoryFromDatabase);
            if (!resulFromDatabase)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}