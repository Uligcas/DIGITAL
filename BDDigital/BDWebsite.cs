using CommonDigital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    
    public class BDWebsite
    {
        #region -> Constructor  
        private static volatile BDWebsite _instance;
        string cnn = "dbConnection";

        static BDWebsite()
        {
            BDWebsite._instance = null;
        }
        public BDWebsite(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDWebsite Instance(string lscnn)
        {

            if (BDWebsite._instance == null)
            {
                lock (typeof(BDWebsite))
                {
                    if (BDWebsite._instance == null)
                    {
                        BDWebsite._instance = new BDWebsite(lscnn);
                    }
                }
            }
            return BDWebsite._instance;
        }
        #endregion
        #region Metodos

        public List<Website> GetList()
        {
            try
            {

                List<Website> lstItems = new List<Website>();
                Website Item = new Website();

                DBHelper dBHelper = new DBHelper(Cnn);
                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "WebsiteSelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Website();
                    Item.IdWebsite = int.Parse(R["IdWebsite"].ToString());
                    Item.Name = R["Name"].ToString();
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
