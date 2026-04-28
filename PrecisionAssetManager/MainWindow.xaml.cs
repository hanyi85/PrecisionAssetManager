using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace PrecisionAssetManager
{
    public partial class MainWindow : Window
    {
        private List<AssetViewModel> _assetList = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _assetList = new List<AssetViewModel>
            {
                new AssetViewModel { Model = "MR15MN 迷你導軌", Cost = 3500, CurrentMileage = 1200, MaxLife = 5000 },
                new AssetViewModel { Model = "ARC20FN 高負荷導軌", Cost = 8200, CurrentMileage = 4850, MaxLife = 6000 },
                new AssetViewModel { Model = "S0-100 線性馬達模組", Cost = 45000, CurrentMileage = 1500, MaxLife = 20000 },
                new AssetViewModel { Model = "HR20 交叉滾子軸承", Cost = 12000, CurrentMileage = 9500, MaxLife = 10000 }
            };
            dgAssets.ItemsSource = _assetList;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "CSV 檔案 (*.csv)|*.csv", FileName = $"資產評估報告_{DateTime.Now:yyyyMMdd}" };
            if (saveFileDialog.ShowDialog() == true)
            {
                var csv = new StringBuilder();
                csv.AppendLine("零件型號,原始成本,累積里程,額定壽命,剩餘價值,健康狀態");
                foreach (var item in _assetList)
                    csv.AppendLine($"{item.Model},{item.Cost},{item.CurrentMileage},{item.MaxLife},{item.BookValue:F0},{item.HealthStatus}");

                File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                MessageBox.Show("報表匯出成功！");
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e) => LoadData();
    }

    public class AssetViewModel : INotifyPropertyChanged
    {
        private double _currentMileage;
        public string Model { get; set; } = string.Empty;
        public double Cost { get; set; }
        public double MaxLife { get; set; }
        public double CurrentMileage
        {
            get => _currentMileage;
            set { _currentMileage = value; OnPropertyChanged(); OnPropertyChanged(nameof(BookValue)); OnPropertyChanged(nameof(HealthStatus)); }
        }
        public double BookValue => Math.Max(0, Cost * (1 - (CurrentMileage / MaxLife)));
        public string HealthStatus => (CurrentMileage / MaxLife) >= 0.9 ? " 建議更換" : (CurrentMileage / MaxLife) >= 0.7 ? " 安排保養" : "良好";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}