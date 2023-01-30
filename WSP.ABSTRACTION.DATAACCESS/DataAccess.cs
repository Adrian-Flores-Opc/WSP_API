using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data;
using System.Data.SqlClient;
using WSP.ABSTRACTION.SECRYPT;

namespace WSP.ABSTRACTION.DATAACCESS
{
    public class DataAccess : IDataAccess
    {
        private readonly DBOptions _dbOptions;
        private readonly ManagerSecrypt _secrypt;
        public DataAccess(DBOptions dbOptions, SecryptOptions secryptOptions)
        {
            this._dbOptions = dbOptions;
            this._secrypt = new ManagerSecrypt(secryptOptions.semilla);
        }
        private string Connection(DBOptionItems _dataBase)
        {
            string _connection;
            try
            {
                string _password = this._secrypt.Desencriptar(_dataBase.password);
                _connection = "Persist Security Info=True;User ID=" + _dataBase.user + ";Pwd=" + _password + ";Server=" + _dataBase.server + ";Database=" + _dataBase.dataBase + ";Application Name =" + _dbOptions.name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _connection;
        }

        public HealthCheckResult Check(string name)
        {
            try
            {
                DBOptionItems item = this._dbOptions.connections.FirstOrDefault(x => x.name == name);
                try
                {
                    var conexion = new SqlConnection(Connection(item));
                    conexion.Open();
                    conexion.Close();
                    var response = HealthCheckResult.Healthy($"BATABASE: {item.dataBase}; SERVER: {item.server}; USER: {item.user}");
                    return response;
                }
                catch (Exception ex)
                {
                    return HealthCheckResult.Unhealthy($"COULD NOT CONNECT TO DATABASE: {item.dataBase} SERVER: {item.server}; USER: {item.user}; EXCEPTION: {ex.Message.ToUpper()}");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"CONFIG PARMETER DATABASE: {name}; EXCEPTION: {ex.Message.ToUpper()}");
            }
        }

        public bool ExecuteStoredProcedure(string _name, string _query, ref List<SqlParameter> _parameter)
        {
            using (SqlConnection _connection = new SqlConnection(Connection(this._dbOptions.connections.FirstOrDefault(x => x.name == _name))))
            {
                try
                {
                    SqlCommand _comando = new SqlCommand(_query, _connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 600000
                    };
                    _parameter.ForEach(item => { if (item.Value == null) item.Value = DBNull.Value; _comando.Parameters.Add(item); });
                    _connection.Open();
                    _comando.ExecuteNonQuery();
                    _connection.Close();
                    return true;
                }
                catch (SqlException Error)
                {
                    _connection.Close();
                    SqlConnection.ClearAllPools();
                    throw Error;
                }
            }
        }

        public DataTable SelectStoredProcedure(string _name, string _query, List<SqlParameter> _parameter)
        {
            DataTable _consulta = new DataTable();
            using (SqlConnection _connection = new SqlConnection(Connection(this._dbOptions.connections.FirstOrDefault(x => x.name == _name))))
            {
                try
                {
                    SqlDataAdapter _comando = new SqlDataAdapter(_query, _connection);
                    _comando.SelectCommand.CommandType = CommandType.StoredProcedure;
                    _comando.SelectCommand.CommandTimeout = 3600000;
                    _parameter.ForEach(item => { if (item.Value == null) item.Value = DBNull.Value; _comando.SelectCommand.Parameters.Add(item); });
                    _connection.Open();
                    _comando.Fill(_consulta);
                }
                catch (SqlException Error)
                {
                    _connection.Close();
                    SqlConnection.ClearAllPools();
                    throw Error;
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _consulta;
        }
        public DataTable Select(string _name, string _query)
        {
            DataTable _consulta = new DataTable();
            using (SqlConnection _connection = new SqlConnection(Connection(this._dbOptions.connections.FirstOrDefault(x => x.name == _name))))
            {
                try
                {
                    SqlDataAdapter _comando = new SqlDataAdapter(_query, _connection);
                    _comando.SelectCommand.CommandType = CommandType.Text;
                    _comando.SelectCommand.CommandTimeout = 3600000;
                    _connection.Open();
                    _comando.Fill(_consulta);
                }
                catch (SqlException Error)
                {
                    _connection.Close();
                    SqlConnection.ClearAllPools();
                    throw Error;
                }
                finally
                {
                    _connection.Close();
                }
            }
            return _consulta;
        }
    }
}