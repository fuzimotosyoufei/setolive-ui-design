using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

public static class ChartHelper
{
    private static readonly Font DefaultFont = new Font("メイリオ", 10, FontStyle.Bold);

    public static void SetChart(
        Chart chart,
        Dictionary<string, int> data,
        string seriesName,
        SeriesChartType chartType,
        string labelUnit,
        string xAxisTitle,
        string yAxisTitle = "",
        Color? labelColor = null,
        bool showLegend = false,
        string pieLabelStyle = "Inside")
    {
        chart.Series.Clear();
        var series = chart.Series.Add(seriesName);
        series.ChartType = chartType;
        series.IsValueShownAsLabel = true;
        series.LabelForeColor = labelColor ?? Color.Red;
        series.Font = DefaultFont;

        if (chartType == SeriesChartType.Pie)
        {
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            series.Label = "#VALX\n#VAL" + labelUnit;
            series["PieLabelStyle"] = pieLabelStyle;

            if (showLegend)
            {
                if (chart.Legends.Count == 0)
                    chart.Legends.Add(new Legend());
                chart.Legends[0].Enabled = true;
            }
        }
        else
        {
            foreach (var item in data)
            {
                int idx = series.Points.AddXY(item.Key, item.Value);
                series.Points[idx].Label = item.Value + labelUnit;
            }

            chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            chart.ChartAreas[0].AxisY.Title = yAxisTitle;
        }
    }
}
