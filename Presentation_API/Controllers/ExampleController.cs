using Domain.Models.DTOs;
using Interfaces.Logic.ThingsMaker;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly IThingsMaker _ThingsMaker;

        public ExampleController(IThingsMaker thinkgsMaker)
        {
            _ThingsMaker = thinkgsMaker;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> GetAllExample()
        {
            var ret = await _ThingsMaker.SelectAllExamplesAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> GetExampleById(int id)
        {
            var ret = await _ThingsMaker.SelectExamplesByIdAsync(id);
            return Ok(ret);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> GetExampleByModel([FromBody] ExampleDTO example)
        {
            var ret = await _ThingsMaker.SelectExamplesByIdAsync(example.Id);
            return Ok(ret);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> AddExample(ExampleDTO example)
        {
            await _ThingsMaker.InsertUpdateExampleAsync(example);

            return Ok(await _ThingsMaker.SelectAllExamplesAsync());
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> UpdateExample(ExampleDTO example)
        {
            await _ThingsMaker.InsertUpdateExampleAsync(example);

            return Ok(await _ThingsMaker.SelectAllExamplesAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ExampleDTO>>> DeleteExampleById(int id)
        {
            await _ThingsMaker.DeleteExampleAsync(id);

            return Ok(await _ThingsMaker.SelectAllExamplesAsync());
        }
    }
}
