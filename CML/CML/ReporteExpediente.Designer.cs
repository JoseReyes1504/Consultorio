
namespace CML
{
    partial class ReporteExpediente
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CMLDataSet = new CML.CMLDataSet();
            this.ExpedienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExpedienteTableAdapter = new CML.CMLDataSetTableAdapters.ExpedienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CMLDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpedienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Expediente";
            reportDataSource1.Value = this.ExpedienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CML.ExpedienteRep.rdlc";
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
            // ExpedienteBindingSource
            // 
            this.ExpedienteBindingSource.DataMember = "Expediente";
            this.ExpedienteBindingSource.DataSource = this.CMLDataSet;
            // 
            // ExpedienteTableAdapter
            // 
            this.ExpedienteTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteExpediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ReporteExpediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteExpediente";
            this.Load += new System.EventHandler(this.ReporteExpediente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CMLDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpedienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ExpedienteBindingSource;
        private CMLDataSet CMLDataSet;
        private CMLDataSetTableAdapters.ExpedienteTableAdapter ExpedienteTableAdapter;
    }
}