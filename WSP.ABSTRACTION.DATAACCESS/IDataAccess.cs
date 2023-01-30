using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.DATAACCESS
{
    public interface IDataAccess
    {
        HealthCheckResult Check(string name);
        DataTable SelectStoredProcedure(string name, string query, List<SqlParameter> parameter);
        bool ExecuteStoredProcedure(string name, string query, ref List<SqlParameter> parameter);
        DataTable Select(string name, string query);
    }
}
