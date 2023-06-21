using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries
{
    public class BaseQueryType 
    {
        private IDbConnection _dbConnection;
        public IDbConnection _db { get; set; }

        public BaseQueryType(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _db = dbConnection;
        }
    }
}
