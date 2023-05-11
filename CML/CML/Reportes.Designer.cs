
namespace CML
{
    partial class Reportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CMLDataSet = new CML.CMLDataSet();
            this.ConsultaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConsultaTableAdapter = new CML.CMLDataSetTableAdapters.ConsultaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CMLDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Consulta";
            reportDataSource1.Value = this.ConsultaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CML.ConsultaRep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(882, 753);
            this.reportViewer1.TabIndex = 0;
            // 
            // CMLDataSet
            // 
            this.CMLDataSet.DataSetName = "CMLDataSet";
            this.CMLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ConsultaBindingSource
            // 
            this.ConsultaBindingSource.DataMember = "Consulta";
            this.ConsultaBindingSource.DataSource = this.CMLDataSet;
            // 
            // ConsultaTableAdapter
            // 
            this.ConsultaTableAdapter.ClearBeforeFill = true;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CMLDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ConsultaBindingSource;
        private CMLDataSet CMLDataSet;
        private CMLDataSetTableAdapters.ConsultaTableAdapter ConsultaTableAdapter;
    }
}