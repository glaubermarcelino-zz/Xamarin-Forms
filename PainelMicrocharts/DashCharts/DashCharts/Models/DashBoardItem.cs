using System.Collections.Generic;

namespace DashCharts.Models
{
    public enum EChartType
    {
        BarChart,
        PointChart,
        LineChart,
        DonutChart,
        RadialGaugeChart,
        RadarChart
    }
    public class DashBoardItem
    {
        public string Name { get; set; }
        public EChartType Type { get; set; }
        public List<Serie> Series { get; set; }
    }
}
