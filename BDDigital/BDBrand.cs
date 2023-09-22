using CommonDigital;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDigital
{
    public class BDBrand
    {
        #region -> Constructor  
        private static volatile BDBrand _instance;
        string cnn = "dbConnection";

        static BDBrand()
        {
            BDBrand._instance = null;
        }
        public BDBrand(string pConnectionString)
        {
            if (!string.IsNullOrEmpty(pConnectionString.Trim()))
            {
                Cnn = pConnectionString;
            }
        }
        public string Cnn { get => cnn; set => cnn = value; }
        public static BDBrand Instance(string lscnn)
        {

            if (BDBrand._instance == null)
            {
                lock (typeof(BDBrand))
                {
                    if (BDBrand._instance == null)
                    {
                        BDBrand._instance = new BDBrand(lscnn);
                    }
                }
            }
            return BDBrand._instance;
        }
        #endregion
        #region Metodos

        public List<Brand> GetList()
        {
            try
            {

                List<Brand> lstItems = new List<Brand>();
                Brand Item = new Brand();

                DBHelper dBHelper = new DBHelper(Cnn);

                DataTable dataTable = dBHelper.ExecuteTable(CommandType.StoredProcedure, "BrandSelect");
                foreach (DataRow R in dataTable.Rows)
                {
                    Item = new Brand();
                    Item.IdCountry = int.Parse(R["IdCountry"].ToString());
                    Item.IdIndustry = int.Parse(R["IdIndustry"].ToString());
                    Item.IdBrand = int.Parse(R["IdBrand"].ToString());
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
