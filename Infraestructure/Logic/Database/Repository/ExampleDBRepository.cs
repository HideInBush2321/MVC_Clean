using Interfaces.DBAccess;
using Interfaces.Infraestructure.Database;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class ExampleDBRepository : IExampleDBRepository
    {
        private readonly ISQLDataAccess _db;
        public ExampleDBRepository(ISQLDataAccess db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DBExampleEntity>> SelectAllExamplesAsync()
        {
            string query = @"SELECT * FROM example";

            return await _db.SelectAsync<DBExampleEntity>(query);
        }
        public async Task<IEnumerable<DBExampleEntity>> SelectExampleByIdAsync(int id)
        {
            string query = @"SELECT * FROM example where Id = @Id";

            object param = new
            {
                Id = id
            };

            return await _db.SelectAsync<DBExampleEntity>(query, param);
        }
        public async Task InsertUpdateExampleAsync(DBExampleEntity example)
        {
            string query;

            if (example.Id != 0)
            {
                query = @"UPDATE example set
                            Name = @Name,
                            DisplayOrder = @DisplayOrder,
                            CreatedDateTime = @CreatedDateTime
                            where Id = @Id";
            }
            else
            {
                query = @"INSERT INTO example (
                            Name,
                            DisplayOrder,
                            CreatedDateTime) 
                           VALUES (
                            @Name,
                            @DisplayOrder,
                            @CreatedDateTime)";
            }

            await _db.InsertUpdateAsync(query, example);
        }
        public async Task DeleteExampleAsync(int id)
        {
            string query = @"DELETE FROM example where Id = @Id";

            object param = new
            {
                Id = id
            };

            await _db.DeleteAsync(query, param);
        }
    }
}