using Domain.Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Logic.ThingsMaker
{
    public interface IThingsMaker
    {
        string MakeThis();
        Task<IEnumerable<DBExampleEntity>> SelectAllExamplesAsync();
        Task<IEnumerable<DBExampleEntity>> SelectExamplesByIdAsync(int id);
        Task<string> InsertUpdateExampleAsync(ExampleDTO example);
        Task<string> DeleteExampleAsync(int id);
    }
}
