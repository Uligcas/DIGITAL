using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    public class DBHelper
    {
        private DBHelper.Providers _factory = DBHelper.Providers.SqlClient;

        private string _connectionString = "";

        private static volatile DBHelper _instance;

        public string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
            set
            {
                this._connectionString = value;
            }
        }

        public DBHelper.Providers Factory
        {
            get
            {
                return this._factory;
            }
            set
            {
                this._factory = value;
            }
        }

        static DBHelper()
        {
            DBHelper._instance = null;
        }

        protected DBHelper()
        {
        }

        public DBHelper( string connectionString)
        {
            this._connectionString = connectionString;
            if (_factory != DBHelper.Providers.SqlClient)
            {
                this._factory = DBHelper.Providers.MySql;
            }
            else
            {
                this._factory = DBHelper.Providers.SqlClient;
            }
        }

        public IDataParameter CreateParameter(string name, DbType type, object value)
        {
            return this.CreateParameter(name, type, value, ParameterDirection.Input);
        }

        public IDataParameter CreateParameter(string name, DbType type, object value, ParameterDirection direction)
        {
            DbParameter dbParameter = null;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbCommand dbCommand = factory.CreateConnection().CreateCommand();
            dbCommand.CommandTimeout = 0;
            dbParameter = dbCommand.CreateParameter();
            if (dbParameter != null)
            {
                dbParameter.ParameterName = name;
                dbParameter.DbType = type;
                dbParameter.Direction = direction;
                dbParameter.Value = value;
            }
            return dbParameter;
        }

        public IDataParameter CreateParameter(string name, DbType type, object value, ParameterDirection direction, int pSize)
        {
            DbParameter dbParameter = null;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbCommand dbCommand = factory.CreateConnection().CreateCommand();
            dbCommand.CommandTimeout = 0;
            dbParameter = dbCommand.CreateParameter();
            if (dbParameter != null)
            {
                dbParameter.ParameterName = name;
                dbParameter.DbType = type;
                dbParameter.Direction = direction;
                dbParameter.Value = value;
                dbParameter.Size = pSize;
            }
            return dbParameter;
        }

        public bool ExecuteAdapter(ref DataTable oTable, string cmdText)
        {
            bool flag;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            connectionString.ConnectionString = this.ConnectionString;
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            DbDataAdapter dbDataAdapter = factory.CreateDataAdapter();
            DbCommandBuilder dbCommandBuilder = factory.CreateCommandBuilder();
            DbTransaction dbTransaction = null;
            try
            {
                try
                {
                    if (connectionString.State != ConnectionState.Open)
                    {
                        connectionString.Open();
                    }
                    dbTransaction = connectionString.BeginTransaction();
                    dbCommand.Transaction = dbTransaction;
                    dbCommand.Connection = connectionString;
                    dbCommand.CommandText = cmdText;
                    dbCommand.CommandType = CommandType.Text;
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbCommandBuilder.DataAdapter = dbDataAdapter;
                    dbDataAdapter.Fill(oTable);
                    dbDataAdapter.SelectCommand.CommandText = "SELECT @@IDENTITY";
                    dbTransaction.Commit();
                    flag = true;
                }
                catch (NullReferenceException nullReferenceException)
                {
                    throw new Exception("NullReferenceException ", nullReferenceException);
                }
                catch (DbException dbException)
                {
                    throw new Exception("DB Exception ", dbException);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    dbTransaction.Rollback();
                    throw new Exception("ExeculateAdapter", exception);
                }
            }
            finally
            {
                if (connectionString.State == ConnectionState.Open)
                {
                    connectionString.Close();
                }
                dbCommand = null;
                dbDataAdapter = null;
                dbCommandBuilder = null;
            }
            return flag;
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            return this.ExecuteDataSet(cmdType, cmdText, null);
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            DataSet dataSet;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            DbDataAdapter dbDataAdapter = factory.CreateDataAdapter();
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            try
            {
                try
                {
                    connectionString.ConnectionString = this.ConnectionString;
                    dbCommand = connectionString.CreateCommand();
                    dbCommand.CommandTimeout = 0;
                    this.PrepareCommand(ref dbCommand, ref connectionString, ref cmdType, ref cmdText, ref cmdParms);
                    dbDataAdapter = factory.CreateDataAdapter();
                    DataSet dataSet1 = new DataSet();
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbDataAdapter.Fill(dataSet1);
                    dbCommand.Parameters.Clear();
                    dataSet = dataSet1;
                }
                catch (DbException dbException)
                {
                    throw new Exception("SQL Exception ", dbException);
                }
                catch (Exception exception)
                {
                    throw new Exception("Execute DataSet", exception);
                }
            }
            finally
            {
                connectionString.Close();
                dbCommand = null;
                dbDataAdapter = null;
            }
            return dataSet;
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            return this.ExecuteNonQuery(cmdType, cmdText, null);
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            int num = -1;
            return this.ExecuteNonQuery(cmdType, cmdText, cmdParms, ref num);
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms, ref int tSequency)
        {
            int num;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            try
            {
                try
                {
                    connectionString.ConnectionString = this.ConnectionString;
                    dbCommand.Connection = connectionString;
                    dbCommand.CommandText = cmdText;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandType = cmdType;
                    if (cmdParms != null)
                    {
                        foreach (DbParameter cmdParm in cmdParms)
                        {
                            dbCommand.Parameters.Add(cmdParm);
                        }
                    }
                    connectionString.Open();
                    int num1 = dbCommand.ExecuteNonQuery();
                    if (tSequency != -1)
                    {
                        tSequency = int.Parse(dbCommand.Parameters["@New_FACTURA_ID"].Value.ToString());
                    }
                    dbCommand.Parameters.Clear();
                    num = num1;
                }
                catch (DbException dbException)
                {
                    throw new Exception(string.Concat("DB Exception ", dbException.Message));
                }
                catch (Exception exception)
                {
                    throw new Exception("ExecuteNonQuery Function", exception);
                }
            }
            finally
            {
                dbCommand.Parameters.Clear();
                connectionString.Close();
                dbCommand = null;
                cmdParms = null;
            }
            return num;
        }

        public DbDataReader ExecuteReader(CommandType cmdType, string cmdText)
        {
            return this.ExecuteReader(cmdType, cmdText, null);
        }

        public DbDataReader ExecuteReader(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            DbDataReader dbDataReaders;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            connectionString.ConnectionString = this.ConnectionString;
            factory.CreateDataAdapter();
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            DbDataReader dbDataReaders1 = null;
            try
            {
                try
                {
                    this.PrepareCommand(ref dbCommand, ref connectionString, ref cmdType, ref cmdText, ref cmdParms);
                    dbDataReaders1 = dbCommand.ExecuteReader();
                    dbCommand.Parameters.Clear();
                    if (cmdParms != null)
                    {
                        foreach (DbParameter cmdParm in cmdParms)
                        {
                            dbCommand.Parameters.Add(cmdParm);
                        }
                    }
                    dbDataReaders = dbDataReaders1;
                }
                catch (DbException dbException)
                {
                    throw new Exception("SQL Exception ", dbException);
                }
                catch (Exception exception)
                {
                    throw new Exception("ExecuteReader", exception);
                }
            }
            finally
            {
                dbCommand = null;
            }
            return dbDataReaders;
        }

        public DataRow ExecuteRow(CommandType cmdType, string cmdText)
        {
            return this.ExecuteRow(cmdType, cmdText, null);
        }

        public DataRow ExecuteRow(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            DataRow item;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            connectionString.ConnectionString = this.ConnectionString;
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            DbDataAdapter dbDataAdapter = factory.CreateDataAdapter();
            DataTable dataTable = new DataTable();
            try
            {
                try
                {
                    this.PrepareCommand(ref dbCommand, ref connectionString, ref cmdType, ref cmdText, ref cmdParms);
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbDataAdapter.Fill(dataTable);
                    dbCommand.Parameters.Clear();
                    if (dataTable.Rows.Count != 0)
                    {
                        item = dataTable.Rows[0];
                    }
                    else
                    {
                        item = null;
                    }
                }
                catch (DbException dbException)
                {
                    throw new Exception("DB Exception ", dbException);
                }
                catch (Exception exception)
                {
                    throw new Exception("ExecuteRow", exception);
                }
            }
            finally
            {
                connectionString.Close();
                dataTable = null;
                dbCommand = null;
                dbDataAdapter = null;
            }
            return item;
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            return this.ExecuteScalar(cmdType, cmdText, null);
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            object obj;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbConnection connectionString = factory.CreateConnection();
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            DbTransaction dbTransaction = null;
            try
            {
                try
                {
                    connectionString.ConnectionString = this.ConnectionString;
                    dbCommand.Connection = connectionString;
                    dbCommand.CommandText = cmdText;
                    dbCommand.Parameters.Clear();
                    dbCommand.CommandType = cmdType;
                    if (cmdParms != null)
                    {
                        foreach (DbParameter cmdParm in cmdParms)
                        {
                            dbCommand.Parameters.Add(cmdParm);
                        }
                    }
                    connectionString.Open();
                    dbTransaction = connectionString.BeginTransaction();
                    dbCommand.Transaction = dbTransaction;
                    object obj1 = dbCommand.ExecuteScalar();
                    dbCommand.Parameters.Clear();
                    dbTransaction.Commit();
                    obj = obj1;
                }
                catch (DbException dbException1)
                {
                    DbException dbException = dbException1;
                    dbTransaction.Rollback();
                    throw new Exception(string.Concat("DB Exception ", dbException.Message));
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    dbTransaction.Rollback();
                    throw new Exception("ExecuteNonQuery Function", exception);
                }
            }
            finally
            {
                connectionString.Close();
                dbCommand = null;
                cmdParms = null;
            }
            return obj;
        }

        public DataTable ExecuteTable(CommandType cmdType, string cmdText)
        {
            return this.ExecuteTable(cmdType, cmdText, null);
        }

        public DataTable ExecuteTable(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            DataTable dataTable;
            DbProviderFactory factory = DbProviderFactories.GetFactory(this.GetFactoryByProvider(this._factory));
            DbDataAdapter dbDataAdapter = null;
            DbConnection connectionString = factory.CreateConnection();
            DbCommand dbCommand = connectionString.CreateCommand();
            dbCommand.CommandTimeout = 0;
            try
            {
                try
                {
                    connectionString.ConnectionString = this.ConnectionString;
                    this.PrepareCommand(ref dbCommand, ref connectionString, ref cmdType, ref cmdText, ref cmdParms);
                    dbDataAdapter = factory.CreateDataAdapter();
                    DataTable dataTable1 = new DataTable();
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbDataAdapter.Fill(dataTable1);
                    dbCommand.Parameters.Clear();
                    dataTable = dataTable1;
                }
                catch (DbException dbException)
                {
                    throw new Exception("DB Exception ", dbException);
                }
                catch (Exception exception)
                {
                    throw new Exception("ExecuteTable Exception :", exception);
                }
            }
            finally
            {
                connectionString.Close();
                dbCommand = null;
                dbDataAdapter = null;
            }
            return dataTable;
        }

        private string GetFactoryByProvider(DBHelper.Providers oGetFactory)
        {
            string str;
            switch (oGetFactory)
            {
                case DBHelper.Providers.Odbc:
                    {
                        str = "System.Data.Odbc";
                        break;
                    }
                case DBHelper.Providers.OleDb:
                    {
                        str = "System.Data.OleDb";
                        break;
                    }
                case DBHelper.Providers.SqlClient:
                    {
                        str = "System.Data.SqlClient";
                        break;
                    }
                case DBHelper.Providers.MySql:
                    {
                        str = "MySql.Data.MySqlClient";
                        break;
                    }
                default:
                    {
                        str = "";
                        break;
                    }
            }
            return str;
        }

        public static DBHelper Instance()
        {
            if (DBHelper._instance == null)
            {
                lock (typeof(DBHelper))
                {
                    if (DBHelper._instance == null)
                    {
                        DBHelper._instance = new DBHelper();
                    }
                }
            }
            return DBHelper._instance;
        }

        public bool PrepareCommand(ref DbCommand cmd, ref DbConnection conn, ref CommandType cmdType, ref string cmdText, ref List<IDataParameter> cmdParms)
        {
            bool flag;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.Parameters.Clear();
                cmd.CommandType = (CommandType)((int)cmdType);
                if (cmdParms != null)
                {
                    foreach (DbParameter cmdParm in cmdParms)
                    {
                        cmd.Parameters.Add(cmdParm);
                    }
                }
                flag = true;
            }
            catch (DbException dbException)
            {
                throw new Exception("DB Exception x1 ", dbException);
            }
            catch (Exception exception)
            {
                throw new Exception("PrepareCommand x2: ", exception);
            }
            return flag;
        }

        public int SQLCnn(CommandType cmdType, string cmdText, List<IDataParameter> cmdParms)
        {
            int num;
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                try
                {
                    sqlConnection.ConnectionString = this.ConnectionString;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = cmdText;
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandType = cmdType;
                    if (cmdParms != null)
                    {
                        foreach (DbParameter cmdParm in cmdParms)
                        {
                            SqlParameter sqlParameter = new SqlParameter()
                            {
                                ParameterName = cmdParm.ParameterName,
                                DbType = cmdParm.DbType,
                                Direction = cmdParm.Direction,
                                Value = cmdParm.Value
                            };
                            sqlCommand.Parameters.Add(sqlParameter);
                        }
                    }
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    num = 1;
                }
                catch (SqlException sqlException)
                {
                    throw new Exception(string.Concat("DB Exception ", sqlException.Message));
                }
                catch (Exception exception)
                {
                    throw new Exception("ExecuteNonQuery Function", exception);
                }
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Close();
                sqlCommand = null;
                cmdParms = null;
            }
            return num;
        }

        public enum Providers
        {
            Odbc = 1,
            OleDb = 2,
            SqlClient = 3,
            MySql = 4
        }
    }
}
