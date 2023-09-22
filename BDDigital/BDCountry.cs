using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDigital;
using System.Security.Cryptography;

namespace BDDigital
{
    public class BDCountry
    {

        #region -> Constructor  
        private static volatile BDCountry _instance;
        string cnn = "dbConnection";

        static BDCountry()
        {
            BDCountry._instance = null;
        }
        public BDCountry(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDCountry Instance(string lscnn)
        {

            if (BDCountry._instance == null)
            {
                lock (typeof(BDCountry))
                {
                    if (BDCountry._instance == null)
                    {
                        BDCountry._instance = new BDCountry(lscnn);
                    }
                }
            }
            return BDCountry._instance;
        }
        #endregion
        #region Metodos

        public List<Country> GetList()
        {
            try
            {

                List<Country> lstItems = new List<Country>();
                Country Item = new Country();

                DBHelper dBHelper = new DBHelper( Cnn);

                //List<IDataParameter> dataParameters = new List<IDataParameter>();
                //IDataParameter dataParameter = dBHelper.CreateParameter("@Usuario", DbType.String, Login.UserName);
                //dataParameters.Add(dataParameter);
                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "CountrySelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Country();
                    Item.IdCountry = int.Parse(R["IdCountry"].ToString());
                    Item.ISO = R["ISO"].ToString();
                    lstItems.Add(Item);
                }
                return lstItems;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }





        



        #endregion

    }
}
