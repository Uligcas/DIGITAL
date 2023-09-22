using CommonDigital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    
    public class BDCampaigne
    {
        #region -> Constructor  
        private static volatile BDCampaigne _instance;
        string cnn = "dbConnection";

        static BDCampaigne()
        {
            BDCampaigne._instance = null;
        }
        public BDCampaigne(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDCampaigne Instance(string lscnn)
        {

            if (BDCampaigne._instance == null)
            {
                lock (typeof(BDCampaigne))
                {
                    if (BDCampaigne._instance == null)
                    {
                        BDCampaigne._instance = new BDCampaigne(lscnn);
                    }
                }
            }
            return BDCampaigne._instance;
        }
        #endregion
        #region Metodos

        public List<Campaign> GetList()
        {
            try
            {

                List<Campaign> lstItems = new List<Campaign>();
                Campaign Item = new Campaign();

                DBHelper dBHelper = new DBHelper(Cnn);

                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "CampaigneSelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Campaign();
                    Item.IdCountry = int.Parse(R["IdCountry"].ToString());
                    Item.IdCampaign = int.Parse(R["IdCampaign"].ToString());
                    Item.IdBrand = int.Parse(R["IdBrand"].ToString());
                    Item.Id = int.Parse(R["Id"].ToString());
                    Item.Name = R["Name"].ToString();
                    Item.LandingPage =  R["LandingPage"].ToString();
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
