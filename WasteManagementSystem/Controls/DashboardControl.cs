using System;
using System.Windows.Forms;

namespace WasteManagementSystem.Controls
{
    public partial class DashboardControl : UserControl
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiff;
        private System.Windows.Forms.Panel pnlCard; // Wrapper

        public DashboardControl()
        {
            InitializeComponent();
            InitializeChart();
            LoadChartData();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.chartDiff = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlCard = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiff)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            //
            // pnlCard
            //
            this.pnlCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.chartDiff);
            this.pnlCard.Location = new System.Drawing.Point(20, 80);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(560, 300);
            this.pnlCard.TabIndex = 1;
            this.pnlCard.Padding = new System.Windows.Forms.Padding(10);
            // 
            // chartDiff
            // 
            this.chartDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDiff.Location = new System.Drawing.Point(0, 0);
            this.chartDiff.Name = "chartDiff";
            this.chartDiff.Size = new System.Drawing.Size(560, 300);
            this.chartDiff.TabIndex = 0;
            this.chartDiff.Text = "chart1";
             // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.label1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(600, 400);
            ((System.ComponentModel.ISupportInitialize)(this.chartDiff)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeChart()
        {
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
            chartDiff.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("JumlahSampah");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.Color = System.Drawing.Color.SeaGreen;
            series.IsValueShownAsLabel = true;
            chartDiff.Series.Add(series);

            chartDiff.Titles.Add("Jumlah Sampah Per Jenis (Kg)");
        }

        private void LoadChartData()
        {
            try 
            {
                var service = new WasteManagementSystem.Services.WasteService();
                var stats = service.GetWasteByType();

                foreach (var type in stats)
                {
                    chartDiff.Series["JumlahSampah"].Points.AddXY(type.Key, type.Value);
                }
            }
            catch (System.Exception) { }
        }

        private System.Windows.Forms.Label label1;
    }
}
