using Application.Interfaces.Services.ThingsMakerService;
using Domain.Models.DTOs;
using Interfaces.Logic.ThingsMaker;
using Models.Entities;

namespace DoManyThings
{
    public class ThingsMaker : IThingsMaker
    {
        private readonly IThingsMakerService _thingsMakerService;

        public ThingsMaker(IThingsMakerService thingsMakerService)
        {
            this._thingsMakerService = thingsMakerService;
        }

        public async Task<string> DeleteExampleAsync(int id)
        {
            return await _thingsMakerService.DeleteExampleAsync(id);
        }

        public async Task<string> InsertUpdateExampleAsync(ExampleDTO example)
        {
            return await _thingsMakerService.InsertUpdateExampleAsync(example);
        }

        public string MakeThis()
        {
            var ret = _thingsMakerService.SelectEverything();

            return "";
        }

        public async Task<IEnumerable<DBExampleEntity>> SelectAllExamplesAsync()
        {
            IEnumerable<DBExampleEntity> ret = await _thingsMakerService.SelectAllExamplesAsync();

            return ret;
        }

        public async Task<IEnumerable<DBExampleEntity>> SelectExamplesByIdAsync(int id)
        {
            IEnumerable<DBExampleEntity> ret = await _thingsMakerService.SelectExamplesByIdAsync(id);

            return ret;
        }
    }
}
