using CommonDigital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    
    public class BDIndustry
    {

        #region -> Constructor  
        private static volatile BDIndustry _instance;
        string cnn = "dbConnection";

        static BDIndustry()
        {
            BDIndustry._instance = null;
        }
        public BDIndustry(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDIndustry Instance(string lscnn)
        {

            if (BDIndustry._instance == null)
            {
                lock (typeof(BDIndustry))
                {
                    if (BDIndustry._instance == null)
                    {
                        BDIndustry._instance = new BDIndustry(lscnn);
                    }
                }
            }
            return BDIndustry._instance;
        }
        #endregion
        #region Metodos

        public List<Industry> GetList()
        {
            try
            {

                List<Industry> lstItems = new List<Industry>();
                Industry Item = new Industry();

                DBHelper dBHelper = new DBHelper(Cnn);

                //List<IDataParameter> dataParameters = new List<IDataParameter>();
                //IDataParameter dataParameter = dBHelper.CreateParameter("@Usuario", DbType.String, Login.UserName);
                //dataParameters.Add(dataParameter);
                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "IndustrySelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Industry();
                    Item.IdIndustry = int.Parse(R["IdIndustry"].ToString());
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
