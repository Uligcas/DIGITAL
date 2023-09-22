using CommonDigital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    public class BDResume
    {
        #region -> Constructor  
        private static volatile BDResume _instance;
        string cnn = "dbConnection";

        static BDResume()
        {
            BDResume._instance = null;
        }
        public BDResume(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDResume Instance(string lscnn)
        {

            if (BDResume._instance == null)
            {
                lock (typeof(BDResume))
                {
                    if (BDResume._instance == null)
                    {
                        BDResume._instance = new BDResume(lscnn);
                    }
                }
            }
            return BDResume._instance;
        }
        #endregion
        #region Metodos

        public List<Resume> GetList()
        {
            try
            {

                List<Resume> lstItems = new List<Resume>();
                Resume Item = new Resume();

                DBHelper dBHelper = new DBHelper(Cnn);

                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "ResumeSelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Resume();
                    Item.Id = int.Parse(R["Id"].ToString());
                    Item.Campaign = int.Parse(R["Campaign"].ToString());
                    Item.IdWebsite = int.Parse(R["IdWebsite"].ToString());
                    Item.IdDevice = int.Parse(R["IdDevice"].ToString());
                    Item.Metrics_count = int.Parse(R["Metrics_count"].ToString());
                    Item.Metrics_impressions = int.Parse(R["Metrics_impressions"].ToString());
                    Item.Metrics_impact = int.Parse(R["Metrics_impact"].ToString());
                    Item.Metrics_valuation = int.Parse(R["Metrics_valuation"].ToString());
                    Item.Metrics_valuation_usd = int.Parse(R["Metrics_valuation_usd"].ToString());
                    Item.Metrics_blocker_avg = int.Parse(R["Metrics_blocker_avg"].ToString());
                    Item.Website_sections = R["Website_sections"].ToString();
                    Item.Ad_type_id = R["Ad_type_id"].ToString();
                    Item.Ad_type = R["Ad_type"].ToString();
                    Item.Ad_link = R["Ad_link"].ToString();
                    Item.Ad_servers = R["Ad_servers"].ToString();
                    Item.Ad_sizes = R["Ad_sizes"].ToString();
                    Item.Ad_lengths = R["Ad_lengths"].ToString();
                    Item.Sold_bys = R["Sold_bys"].ToString();
                    Item.Screenshot_link = R["Screenshot_link"].ToString();
                    Item.Date = DateTime.Parse( R["Date"].ToString());


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
