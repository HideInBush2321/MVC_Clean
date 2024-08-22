using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class CategoryDBRepository : ICategoryDBRepository
    {
        private readonly ISQLDataAccess _db;
        public CategoryDBRepository(ISQLDataAccess db)
        {
            _db = db;
        }
        public List<DBCategoryModel> SelectAllCategories()
        {
            string query = @"SELECT * FROM Categories";

            return _db.Select<DBCategoryModel>(query);
        }
    }
}