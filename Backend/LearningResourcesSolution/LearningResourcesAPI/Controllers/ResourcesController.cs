using LearningResourcesAPI.Adapters;
using LearningResourcesAPI.Domain;
using LearningResourcesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningResourcesAPI.Controllers
{
    public class ResourcesController : ControllerBase
    {
        private readonly LearningResourcesDataContext _context;

        public ResourcesController(LearningResourcesDataContext context)
        {
            _context = context;
        }
        [HttpGet("/resources")]
        public async Task<ActionResult> GetResources()
        {
            var items = await _context.Items
                .Select(item => new GetResourceItem
                {
                    Id = item.Id.ToString(),
                    Description = item.Description,
                    Link = item.Link,
                    Type = item.Type,
                }).ToListAsync();
            var response = new GetResourcesResponse { Items = items };

            return Ok(response);
        }

        [HttpGet("/resources/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _context.Items
                .Where(item => item.Id == id)
                .Select(item => new GetResourceItem
                {
                    Id = item.Id.ToString(),
                    Description = item.Description,
                    Link = item.Link,
                    Type = item.Type,
                }).SingleOrDefaultAsync();

            //if the response is null, return NotFound()/ 404
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }


        [HttpPost("/resources")]
        public async Task<ActionResult> AddItem([FromBody] CreateResourceItem request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            //add it to the database
            //need to make a learningItem first
            var itemToSave = new LearningItem
            {
                Description = request.Description,
                Link = request.Link,
                Type = request.Type,
            };

            _context.Items.Add(itemToSave); //add to the context
            await _context.SaveChangesAsync(); //save to the DB async. it will wait until this is done before continuing

            var response = new GetResourceItem
            {
                Id = itemToSave.Id.ToString(), //the ID is auto created by .Add() and .SaveChangesAsync()
                Description = itemToSave.Description,
                Link = itemToSave.Link,
                Type = itemToSave.Type
            };
            return StatusCode(201, response);
        }
    }
}
