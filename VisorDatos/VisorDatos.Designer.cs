namespace VisorDatos
{
    partial class VisorDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorDatos));
            this.sfSkinManager1 = new Syncfusion.WinForms.Controls.SfSkinManager(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstCampaigne = new Syncfusion.WinForms.ListView.SfListView();
            this.label4 = new System.Windows.Forms.Label();
            this.lstBrand = new Syncfusion.WinForms.ListView.SfListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIndustry = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.dgvDatos = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // sfSkinManager1
            // 
            this.sfSkinManager1.Component = null;
            this.sfSkinManager1.Controls = null;
            this.sfSkinManager1.ThemeName = null;
            this.sfSkinManager1.VisualTheme = Syncfusion.Windows.Forms.VisualTheme.Managed;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lstCampaigne);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lstBrand);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbIndustry);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCountry);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 157);
            this.panel1.TabIndex = 0;
            // 
            // lstCampaigne
            // 
            this.lstCampaigne.AccessibleName = "ScrollControl";
            this.lstCampaigne.Location = new System.Drawing.Point(612, 26);
            this.lstCampaigne.Name = "lstCampaigne";
            this.lstCampaigne.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCampaigne.Size = new System.Drawing.Size(236, 128);
            this.lstCampaigne.TabIndex = 8;
            this.lstCampaigne.Text = "sfListView1";
            this.lstCampaigne.SelectionChanged += new System.EventHandler<Syncfusion.WinForms.ListView.Events.ItemSelectionChangedEventArgs>(this.lstCampaigne_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Campaigne";
            // 
            // lstBrand
            // 
            this.lstBrand.AccessibleName = "ScrollControl";
            this.lstBrand.Location = new System.Drawing.Point(343, 26);
            this.lstBrand.Name = "lstBrand";
            this.lstBrand.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBrand.Size = new System.Drawing.Size(236, 128);
            this.lstBrand.TabIndex = 6;
            this.lstBrand.Text = "sfListView1";
            this.lstBrand.SelectionChanged += new System.EventHandler<Syncfusion.WinForms.ListView.Events.ItemSelectionChangedEventArgs>(this.lstBrand_SelectionChanged);
            this.lstBrand.Click += new System.EventHandler(this.lstBrand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marcas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Industria";
            // 
            // cmbIndustry
            // 
            this.cmbIndustry.BackColor = System.Drawing.Color.White;
            this.cmbIndustry.FormattingEnabled = true;
            this.cmbIndustry.Location = new System.Drawing.Point(83, 37);
            this.cmbIndustry.Name = "cmbIndustry";
            this.cmbIndustry.Size = new System.Drawing.Size(242, 21);
            this.cmbIndustry.TabIndex = 2;
            this.cmbIndustry.SelectedIndexChanged += new System.EventHandler(this.cmbIndustry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pais";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(83, 10);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(242, 21);
            this.cmbCountry.TabIndex = 0;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.cmbCountry_SelectedIndexChanged);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AccessibleName = "Table";
            this.dgvDatos.AllowDraggingColumns = true;
            this.dgvDatos.AllowDrop = true;
            this.dgvDatos.AllowEditing = false;
            this.dgvDatos.AllowFiltering = true;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(2, 159);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(1007, 514);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.Text = "sfDataGrid1";
            // 
            // VisorDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 675);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisorDatos";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Visor de Datos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorDatos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfSkinManager sfSkinManager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIndustry;
        private System.Windows.Forms.Label label3;
        private Syncfusion.WinForms.ListView.SfListView lstBrand;
        private Syncfusion.WinForms.ListView.SfListView lstCampaigne;
        private System.Windows.Forms.Label label4;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgvDatos;
    }
}

