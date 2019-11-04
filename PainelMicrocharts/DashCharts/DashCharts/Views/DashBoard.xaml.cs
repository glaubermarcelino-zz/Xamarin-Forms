using DashCharts.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashCharts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : ContentPage
    {
        public const string BASE_URL = "http://10.0.0.19:5000/api";
        public List<DashBoardItem> Dashboards { get; set; }

        public DashBoard()
        {
            InitializeComponent();

           
        }
        protected async  override void OnAppearing()
        {
            base.OnAppearing();
            await GetCharts();
            ShowCharts();
        }

        private void ShowCharts()
        {
            Chart chart = null;
            foreach (var item in Dashboards)
            {
                switch (item.Type)
                {
                    case EChartType.BarChart:
                        chart = new BarChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.PointChart:
                        chart = new PointChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.LineChart:
                        chart = new LineChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.DonutChart:
                        chart = new DonutChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.RadialGaugeChart:
                        chart = new RadialGaugeChart { Entries = GetEntries(item) };
                        break;
                    case EChartType.RadarChart:
                        chart = new RadarChart { Entries = GetEntries(item) };
                        break;
                    default:
                        break;
                }

                if (chart == null)
                    continue;

                var chartView = new Microcharts.Forms.ChartView { HeightRequest = 140, BackgroundColor = Color.White };
                chartView.Chart = chart;
                lsCharts.Children.Add(chartView);
            }
        }

        List<Microcharts.Entry> GetEntries(DashBoardItem dashboard)
        {
            var entries = new List<Microcharts.Entry>();
            foreach (var serie in dashboard.Series)
            {
                entries.Add(new Microcharts.Entry(serie.Value)
                {
                    Label       = serie.Label,
                    ValueLabel  = serie.ValueLabel,
                    Color       = SKColor.Parse(serie.Color)
                });
            }
            return entries;
        }

        async Task GetCharts()
        {
            var client      = new HttpClient();
            var response    = await client.GetAsync($"{BASE_URL}/dashboard");
            var json        = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrWhiteSpace(json))
                return;
            Dashboards = JsonConvert.DeserializeObject<List<DashBoardItem>>(json);
            ShowCharts();
        }
    }
}