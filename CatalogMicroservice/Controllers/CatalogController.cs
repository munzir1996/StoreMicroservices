﻿using CatalogMicroservice.Model;
using CatalogMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CatalogMicroservice.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CatalogController(ICatalogRepository catalogRepository) : ControllerBase
    {

        // GET: api/<catalogcontroller>
        [HttpGet]
        public IActionResult Get()
        {
            var catalogItems = catalogRepository.GetCatalogItems();
            
            return Ok(catalogItems);
        }

        // GET: api/<catalogcontroller>/653e4410614d711b7fc953a7
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var catalogItem = catalogRepository.GetCatalogItem(id);

            return Ok(catalogItem);
        }

        // POST: api/<CatalogController>
        [HttpPost]
        public IActionResult Post([FromBody] CatalogItem catalogItem)
        {
            catalogRepository.InsertCatalogItem(catalogItem);

            return CreatedAtAction(nameof(Get), new { id =  catalogItem.Id }, catalogItem);
        }

        // PUT: api/<CatalogController>
        [HttpPut]
        public IActionResult Put([FromBody] CatalogItem? catalogItem)
        {
            if (catalogItem != null)
            {
                catalogRepository.UpdateCatalogItem(catalogItem);

                return Ok(catalogItem);
            }

            return new NoContentResult();
        }

        // DELETE: api/<CatalogController>/653e4410614d711b7fc953a7
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            catalogRepository.DeleteCatalogItem(id);
            return Ok();
        }

    }

}