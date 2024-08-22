using Application.Interfaces.Services.ThingsMakerService;
using Domain.Models.DTOs;
using Interfaces.Infraestructure.Database;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ThingsMakerService
{
    public class ThingsMakerService : IThingsMakerService
    {
        private readonly IExampleDBRepository exampleDBRepository;

        public ThingsMakerService(IExampleDBRepository exampleDBRepository)
        {
            this.exampleDBRepository = exampleDBRepository;
        }

        public async Task<string> DeleteExampleAsync(int id)
        {
            await exampleDBRepository.DeleteExampleAsync(id);

            return "ok";
        }

        public async Task<string> InsertUpdateExampleAsync(ExampleDTO example)
        {
            DBExampleEntity dBExample = new DBExampleEntity
            {
                Name = example.Name,
                DisplayOrder = example.DisplayOrder,
                CreatedDateTime = example.CreatedDateTime
            };

            await exampleDBRepository.InsertUpdateExampleAsync(dBExample);

            return "ok";
        }

        public async Task<IEnumerable<DBExampleEntity>> SelectAllExamplesAsync()
        {
            return await exampleDBRepository.SelectAllExamplesAsync();
        }

        public string SelectEverything()
        {
            var ret = exampleDBRepository.SelectAllExamplesAsync();
            return "";
        }

        public async Task<IEnumerable<DBExampleEntity>> SelectExamplesByIdAsync(int id)
        {
            return await exampleDBRepository.SelectExampleByIdAsync(id);
        }
    }
}
