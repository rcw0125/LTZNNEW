﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;

namespace LTZN.高炉燃料比综合分析
{
    public partial class 原料品味分析 : Form
    {
        public 原料品味分析()
        {
            InitializeComponent();
        }

        private void 原料品味分析_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 200;
            this.sjBegin.Value = DateTime.Today.AddDays(-2);
            this.sjEnd.Value = DateTime.Now;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (sjEnd.Value < sjBegin.Value)
            {
                MessageBox.Show("结束时间应该比开始时间大！");
                return;
            }
           

            c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();
            Color jthf = Color.FromArgb(25, 45, 86);

            // Add the data
            ChartData data = c1Chart1.ChartGroups[0].ChartData;
            ChartDataSeriesCollection series = data.SeriesList;

            ChartData data1 = c1Chart1.ChartGroups[1].ChartData;
            ChartDataSeriesCollection series1 = data1.SeriesList;
            series.Clear();
            series1.Clear();
 
            c1Chart1.ChartArea.AxisY.Max = 70;
            c1Chart1.ChartArea.AxisY.Min = 50;
            c1Chart1.ChartArea.AxisY.Text = "品位";
            
           

          
            ChartDataSeries StuSeries = series.AddNewSeries();
            StuSeries.Label = "烧结矿品位";
            StuSeries.LineStyle.Pattern = LinePatternEnum.Solid;
            StuSeries.LineStyle.Color = Color.FromArgb(140, 200, 217);
            StuSeries.LineStyle.Thickness = 2;
            StuSeries.SymbolStyle.Shape = SymbolShapeEnum.Dot;
            StuSeries.SymbolStyle.Color = Color.FromArgb(140, 200, 217);

            ////plot the student scores
            ChartDataSeries StuSeries2 = series.AddNewSeries();
            StuSeries2.Label = "球团矿品位";
            StuSeries2.LineStyle.Pattern = LinePatternEnum.Solid;
            StuSeries2.LineStyle.Color = Color.Blue;
            StuSeries2.LineStyle.Thickness = 2;
            StuSeries2.SymbolStyle.Shape = SymbolShapeEnum.Dot;
            StuSeries2.SymbolStyle.Color = Color.Blue;

            ChartDataSeries StuSeries3 = series.AddNewSeries();
            StuSeries3.Label = "澳矿品位分析";
            StuSeries3.LineStyle.Pattern = LinePatternEnum.Solid;
            StuSeries3.LineStyle.Color = Color.FromArgb(218, 129, 55);
            StuSeries3.LineStyle.Thickness = 2;
            StuSeries3.SymbolStyle.Shape = SymbolShapeEnum.Dot;
            StuSeries3.SymbolStyle.Color = Color.FromArgb(218, 129, 55);

            ChartDataSeries StuSeries4 = series.AddNewSeries();
            StuSeries4.Label = "块矿";
            StuSeries4.LineStyle.Pattern = LinePatternEnum.Solid;
            StuSeries4.LineStyle.Color = Color.FromArgb(218, 129, 55);
            StuSeries4.LineStyle.Thickness = 2;
            StuSeries4.SymbolStyle.Shape = SymbolShapeEnum.Dot;
            StuSeries4.SymbolStyle.Color = Color.FromArgb(218, 129, 55);


                c1Chart1.ChartArea.AxisX.AnnoFormat = FormatEnum.DateManual;
                c1Chart1.ChartArea.AxisX.AnnoFormatString = "MM/dd";
                c1Chart1.ChartArea.AxisX.UnitMajor = 1;
                c1Chart1.ChartArea.AxisX.AnnotationRotation = 0;
            
                c1Chart1.Legend.Visible = true;
               
                DateTime[] sT;
                double[] s;
                // 烧结矿
                LegendEnviroment.loadSJKPinWei(sjBegin.Value, sjEnd.Value, out sT, out s);
                StuSeries.X.CopyDataIn(sT);
                StuSeries.Y.CopyDataIn(s);
                StuSeries = null;
              // 球团品位
                LegendEnviroment.loadQTKPinWei(sjBegin.Value, sjEnd.Value, out sT, out s);
                StuSeries2.X.CopyDataIn(sT);
                StuSeries2.Y.CopyDataIn(s);
                StuSeries = null;
                // 澳矿品位
                LegendEnviroment.loadAOKPinWei(sjBegin.Value, sjEnd.Value, out sT, out s);
                StuSeries3.X.CopyDataIn(sT);
                StuSeries3.Y.CopyDataIn(s);
                StuSeries = null;
                // 块矿品位
                LegendEnviroment.loadkuaikuangPinWei(sjBegin.Value, sjEnd.Value, out sT, out s);
                StuSeries4.X.CopyDataIn(sT);
                StuSeries4.Y.CopyDataIn(s);
                StuSeries = null;
              

                Area carea = c1Chart1.ChartArea;
                carea.AxisX.ValueLabels.Clear();
                double xMarker = AddChartAxisMarker(carea.AxisX);
              
        }
        private double AddChartAxisMarker(Axis ax)
        {
            // Set the annotation method to Mixed so both automatic
            // Values annotation AND ValueLabels can be used concurrently.
            ax.AnnoMethod = AnnotationMethodEnum.Mixed;

            // Set the GridMajor line pattern to solid.  This will be
            // used for the ValueLabel Gridline draw.
            ax.GridMajor.Pattern = LinePatternEnum.Solid;
            ax.OnTop = true;

            // A convenient value for the axes units.
            ax.UnitMajor = 10;

            // Create the ValueLabel.  Use an arrow, and make it big
            // and red so it cannot be missed.
            ValueLabel vl = ax.ValueLabels.AddNewLabel();
            vl.Appearance = ValueLabelAppearanceEnum.ArrowMarker;
            vl.GridLine = true;
            vl.Moveable = true;
            vl.MarkerSize = 20;
            vl.Color = Color.Red;

            // Put it in the middle of the axis.  For this to work
            // the chart must have been drawn so the axis is properly
            // scaled.  A prior GetImage() will do this.
           
            vl.DateTimeValue = sjEnd.Value.AddDays(-2);

            // Set the event so the data can be recalculated
            // each time the marker is moved.
            vl.ValueChanged += new EventHandler(MarkerMoved);	//!!VBSubst AddHandler vl.ValueChanged, AddressOf MarkerMoved

            // return the numeric location.
            return vl.NumericValue;
        }
        private void MarkerMoved(object sender, EventArgs e)
        {
            SetHistogramData();
        }
        private void SetHistogramData()
        {
           
            Area carea = c1Chart1.ChartArea;
            if (carea.AxisX.ValueLabels[0] != null)
            {
                // get the Target Coordinates
                DateTime xtarget = carea.AxisX.ValueLabels[0].DateTimeValue;
                DateTime xtime= new DateTime (xtarget.Year,xtarget.Month,xtarget.Day);
                DateTime mintime = new DateTime(sjBegin.Value.Year,sjBegin.Value.Month,sjBegin.Value.Day);

                for (int m = 0; m < c1Chart1.ChartGroups[0].ChartData.SeriesList.Count; m++)
                {
                    //// get the data point coordinates from the chart.
                    ChartDataSeries cds = c1Chart1.ChartGroups[0].ChartData.SeriesList[m];
                    PointF[] cdata = (PointF[])cds.PointData.CopyDataOut();

                    double dy = 0;
                    //// find the distance from each scatter point to the target point.
                    int n = cdata.Length;
            
                    for (int i = 0; i < n; i++)
                    {
                        double dx = cdata[i].X;
                        if (dx == xtime.ToOADate())
                        {
                            dy = cdata[i].Y;
                        }
                    }
                    if (m == 0)
                    {
                        c1Chart1.ChartGroups[0].ChartData.SeriesList[m].Label = xtime.GetDateTimeFormats('M')[0].ToString() + " " + "烧结矿品位:" + dy.ToString("0.00");
                    }
                    if (m ==1)
                    {
                        c1Chart1.ChartGroups[0].ChartData.SeriesList[m].Label = xtime.GetDateTimeFormats('M')[0].ToString() + " " + "球团矿品位:" + dy.ToString("0.00");
                    }
                    if (m == 2)
                    {
                        c1Chart1.ChartGroups[0].ChartData.SeriesList[m].Label = xtime.GetDateTimeFormats('M')[0].ToString() + " " + "澳矿品位:" + dy.ToString("0.00");
                    }
                    if (m == 3)
                    {
                        c1Chart1.ChartGroups[0].ChartData.SeriesList[m].Label = xtime.GetDateTimeFormats('M')[0].ToString() + " " + "块矿品位:" + dy.ToString("0.00");
                    }
                  
                  
             
                }     
              
            }
        }

    }
}