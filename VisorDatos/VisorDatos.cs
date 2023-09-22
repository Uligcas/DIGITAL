using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDDigital;
using CommonDigital;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid;
using static Syncfusion.WinForms.Core.NativePaint;

namespace VisorDatos
{
    public partial class VisorDatos : SfForm
    {
        public VisorDatos()
        {
            InitializeComponent();
        }


        string Cnn = string.Empty;
        List<Brand> LstBrands = new List<Brand>();
        List<Campaign> LstCampaign = new List<Campaign>();
        List<Website> LstWebsite = new List<Website>();

        List<Resume> LstResume = new List<Resume>();

        internal  void LoadDatos()

        {
            List<Country> lstCountry = new List<Country>();
            lstCountry = BDCountry.Instance(Cnn).GetList();

            Country Country = new Country();
            Country.ISO = "Todos";
            Country.IdCountry = 0;
            lstCountry.Add(Country);
            cmbCountry.ValueMember = "IdCountry";
            cmbCountry.DisplayMember = "ISO";
            cmbCountry.DataSource = lstCountry;


            List<Industry> lstIndustry = new List<Industry>();
            lstIndustry = BDIndustry.Instance(Cnn).GetList();
            cmbIndustry.ValueMember = "IdIndustry";
            cmbIndustry.DisplayMember = "Name";
            cmbIndustry.DataSource = lstIndustry;

            LstBrands = BDBrand.Instance(Cnn).GetList();
            LstWebsite = BDWebsite.Instance(Cnn).GetList();
            LstCampaign = BDCampaigne.Instance(Cnn).GetList();

            LstResume = BDResume.Instance(Cnn).GetList();




        }



        internal void LoadBrand()
        {

            if (cmbIndustry.Items.Count == 0)
                return;

            if (cmbCountry.Items.Count == 0)
                return;


            List<Brand> Lst = new List<Brand>();
            int Idindustry = 0;
            Idindustry = ((Industry)cmbIndustry.SelectedItem).IdIndustry;
            if (Idindustry > 0)
            {
                
                Lst = LstBrands.Where(x => x.IdIndustry == Idindustry).ToList();
            }
            List<Brand> LstBrandstemp = new List<Brand>();

            int idcountry = 0;
            idcountry = ((Country)cmbCountry.SelectedItem).IdCountry;
            if(idcountry > 0)
            {
                LstBrandstemp = Lst.Where(x => x.IdCountry == idcountry).ToList();
            }

        
            lstBrand.ValueMember = "IdBrand";
            lstBrand.DisplayMember = "Name";
            lstBrand.DataSource = LstBrandstemp;


            


        }


        internal void LoadCampaign()
        {

            if (cmbIndustry.Items.Count == 0)
                return;

            if (cmbCountry.Items.Count == 0)
                return;

            if (lstBrand.SelectedItems.Count == 0)
                return;
            List<Campaign> Lst = new List<Campaign>();
            foreach (Brand I in lstBrand.SelectedItems)
            {
                Lst.AddRange(LstCampaign.Where(x => x.IdCountry == I.IdCountry &&
                                               x.IdBrand == I.IdBrand).ToList());
            }


       


            lstCampaigne.ValueMember = "IdBrand";
            lstCampaigne.DisplayMember = "Name";
            lstCampaigne.DataSource = Lst;


        }


        internal void LoadResume()
        {

            if (cmbIndustry.Items.Count == 0)
                return;

            if (cmbCountry.Items.Count == 0)
                return;

            if (lstBrand.SelectedItems.Count == 0)
                return;

            if (lstCampaigne.SelectedItems.Count == 0)
                return;

            List<Resume> Lst = new List<Resume>();
            foreach (Campaign I in lstCampaigne.SelectedItems)
            {
                Lst.AddRange(LstResume.Where(x => x.Campaign == I.Id).ToList());
            }

            dgvDatos.ClearFilters();

            dgvDatos.ClearSorting();
            dgvDatos.ClearGrouping();
           
            dgvDatos.DataSource = Lst;

           


        }


        private void GridSettings()
        {
            this.dgvDatos.TableSummaryRows.Add(new GridTableSummaryRow()
            {
                Name = "tableSumamryFalse",
                ShowSummaryInRow = false,
                Title = "Resumen :",
                TitleColumnCount = 1,
                Position = VerticalPosition.Top,
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.Data.ISummaryColumn>()
                {


                    new GridSummaryColumn()
                    {
                        Name = "Metrics_count",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:n}",
                        MappingName= "Metrics_count",

                    },

                     new GridSummaryColumn()
                    {
                        Name = "Metrics_impressions",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:n}",
                        MappingName= "Metrics_impressions",

                    },
                      new GridSummaryColumn()
                    {
                        Name = "Metrics_impact",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:n}",
                        MappingName= "Metrics_impact",

                    },
                          new GridSummaryColumn()
                    {
                        Name = "Metrics_valuation",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:n}",
                        MappingName= "Metrics_valuation",

                    },
                              new GridSummaryColumn()
                    {
                        Name = "Metrics_valuation_usd",
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate,
                        Format="{Sum:n}",
                        MappingName="Metrics_valuation_usd",

                    }
                }
            });


        }




        private void VisorDatos_Load(object sender, EventArgs e)
        {
            try
            {
                Cnn = global::VisorDatos.Properties.Settings.Default.Cnn;
                LoadDatos();
                GridSettings();
            }
            catch (Exception ex)
            {

                Error(ex, true);
            }
        }

        public bool Error(Exception ex, bool pMensaje)
        {

            if (pMensaje)
            {
                MessageBox.Show("Ocurrio un error.\nDetails\n" );
            }
                LogWriter.GetInstance().LogWrite(ex.Message + ex.ToString());
            
            return true;
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBrand();
            }
            catch (Exception ex)
            {

                Error(ex, true);
            }
        }

        private void cmbIndustry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBrand();
            }
            catch (Exception ex)
            {

                Error(ex, true);
            }
        }

        private void lstBrand_SelectionChanged(object sender, Syncfusion.WinForms.ListView.Events.ItemSelectionChangedEventArgs e)
        {
            try
            {
                LoadCampaign();
            }
            catch (Exception ex)
            {

                Error(ex, true);
            }
        }

        private void lstBrand_Click(object sender, EventArgs e)
        {

        }

        private void lstCampaigne_SelectionChanged(object sender, Syncfusion.WinForms.ListView.Events.ItemSelectionChangedEventArgs e)
        {
            try
            {
                LoadResume();
            }
            catch (Exception ex)
            {

                Error(ex, true);
            }
        }
    }
}
