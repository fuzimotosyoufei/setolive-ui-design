using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace s._20Vr2
{

    public partial class StoMain : Form
    {

        public StoMain()
        {
            InitializeComponent();
        }

        private void StoMain_Load(object sender, EventArgs e)
        {

            LoadCustomerCards(); // ← これを追加！
            SetoControl.DrawItem += tabControl_DrawItem;
            InfoControl.DrawItem += tabControl_DrawItem;
            ProductControl.DrawItem += tabControl_DrawItem;
            DayControl.DrawItem += tabControl_DrawItem;
            NewPanel.Paint += Panel_Paint;
            CompPanel.Paint += Panel_Paint;
            ShipPanel.Paint += Panel_Paint;

           
        

        var bar4 = new Dictionary<string, int>
        {
            { "オリーブ", 150 },
            { "オリーブケーキ", 230 },
            { "オリーブ化粧品", 180 }
        };

            var line4 = new Dictionary<string, int>
        {
             { "10:00", 5 }, { "11:00", 8 }, { "12:00", 15 },
             { "13:00", 12 }, { "14:00", 9 }, { "15:00", 6 }
        };

            var pie4 = new Dictionary<string, int>
        {
            { "オリーブ", 40 }, { "化粧品", 25 }, { "乳製品", 35 }
        };
            var bar3 = new Dictionary<string, int>
        {
            { "オリーブ", 150 },
            { "オリーブケーキ", 230 },
            { "オリーブ化粧品", 180 }
        };

            var line3 = new Dictionary<string, int>
        {
             { "10:00", 5 }, { "11:00", 8 }, { "12:00", 15 },
             { "13:00", 12 }, { "14:00", 9 }, { "15:00", 6 }
        };

            var pie3 = new Dictionary<string, int>
        {
            { "オリーブ", 40 }, { "化粧品", 25 }, { "乳製品", 35 }
        };

            // 呼び出し例
            ChartHelper.SetChart(bar1, bar4, "売上", SeriesChartType.Column, "個", "商品名", "売上（個）", Color.DarkRed);
            ChartHelper.SetChart(line1, line4, "来客数", SeriesChartType.Line, "人", "時間", "来客数（人）", Color.DarkBlue);
            ChartHelper.SetChart(pie1, pie4, "分類", SeriesChartType.Pie, "個", "", "", Color.Black, true);

            ChartHelper.SetChart(bar2, bar3, "売上", SeriesChartType.Column, "個", "商品名", "売上（個）", Color.DarkRed);
            ChartHelper.SetChart(line2, line3, "来客数", SeriesChartType.Line, "人", "時間", "来客数（人）", Color.DarkBlue);
            ChartHelper.SetChart(pie2, pie3, "分類", SeriesChartType.Pie, "個", "", "", Color.Black, true);

            LoadProductData();
            //List<Product> products = new List<Product>
            //{
            //     new Product { Id = 1, Name = "オリーブオイル", Price = 1200, Description = "イタリア産の高品質オイル" },
            //     new Product { Id = 2, Name = "石鹸", Price = 500, Description = "オリーブから作った手作り石鹸" }
            //};

            //ProductData.DataSource = products;
            //ProductData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ProductData.ReadOnly = true;
            //ProductData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ProductData.CellClick += ProductData_CellClick;
        }


        private void LoadProductData()
        {
            var products = FallbackDataProvider.GetProductMaster();
            ProductData.DataSource = products;
            SetupProductGrid();
        }

        private void SetupProductGrid()
        {
            ProductData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductData.ReadOnly = true;
            ProductData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductData.CellClick -= ProductData_CellClick;
            ProductData.CellClick += ProductData_CellClick;

            // ヘッダー名の変更
            ProductData.Columns["Id"].HeaderText = "商品ID";
            ProductData.Columns["Name"].HeaderText = "商品名";
            ProductData.Columns["Price"].HeaderText = "販売価格";
            ProductData.Columns["Cost"].HeaderText = "原価";
            ProductData.Columns["Type"].HeaderText = "分類";
            ProductData.Columns["Desc"].HeaderText = "説明";
            ProductData.Columns["Supplier"].HeaderText = "発注業者";
            ProductData.Columns["OnSale"].HeaderText = "販売中か？";
            ProductData.Columns["Alert"].HeaderText = "警告在庫数";
        }

        private void ProductData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ヘッダークリックは無視

            var selectedRow = ProductData.Rows[e.RowIndex].DataBoundItem as Product;
            if (selectedRow != null)
            {
                ProductID.Text = $"商品ID 　{selectedRow.Id}";
                DataName.Text = $"商品名 　{selectedRow.Name}";
                ProductPrice.Text = $"販売価格 　{selectedRow.Price}円";
                ProductCost.Text = $"原価 　{selectedRow.Cost}円";
                ProductDesc.Text = $"説明 　{selectedRow.Desc}";
                ProductType.Text = $"商品分類 　{selectedRow.Type}";
                ProductSupplier.Text = $"発注業者名 　{selectedRow.Supplier}";
                ProductOnSale.Text = $"販売中か？ 　{selectedRow.OnSale}";
                ProductAlert.Text = $"傾向在庫数 {selectedRow.Alert}";
            }
        }
        private void LoadCustomerCards()
        {
            // 手作業で定義したダミーデータを使用
            List<CustomerOrderInfo> customerList = FallbackDataProvider.GetFallbackData();

            var creator = new CardcriCreate(this); // Form1に配置されている前提

            foreach (var customer in customerList)
            {
                Panel targetPanel = GetPanelByStatus(customer.Status);
                creator.CreateCustomerCard(targetPanel, customer, NewPanel, CompPanel, ShipPanel, InfoPanel);
            }

        }
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)//タブの山河の呼び出し
        {
            var tabControl = sender as TabControl;
            if (tabControl == null) return;

            // TabColorRenderer クラスの静的メソッドを呼び出す
            TabColorRenderer.DrawTab(tabControl, e);
        }

        private Panel GetPanelByStatus(string status)
        {

            if (status == "新規予約")
            {
                return NewPanel;
            }
            else if (status == "受注確定")
            {
                return CompPanel;
            }
            else if (status == "発送済み")
            {
                return ShipPanel;
            }
            else
            {
                return NewPanel; // 未定義のステータスはとりあえず panel1 に表示
            }
        }
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel == null) return;

            int count = panel.Controls.OfType<Panel>().Count();

            if (panel == NewPanel)
            {
                NewLabel.Text = $"新規予約のカード数: {count }\r在庫不足のカード数1\rCtrl+1";
            }
            else if (panel == CompPanel)
            {
                CompLabel.Text = $"受注予約のカード数: {count}\rCtrl+2";
            }
            else if (panel == ShipPanel)
            {
                ShipLabel.Text = $"発送済みのカード数: {count}\rCtrl+3";
            }

            using (Pen borderPen = new Pen(Color.LightGray, 2))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void NextTask_Click(object sender, EventArgs e)
        {
            SetoControl.SelectedIndex = 0;
            SetSelectedButtonColor(NextTask);
        }

        private void NextSanalysis_Click(object sender, EventArgs e)
        {
            SetoControl.SelectedIndex = 1;
            InfoControl.SelectedIndex = 0;
            SetSelectedButtonColor(NextSanalysis);
        }

        private void NextCanalysis_Click(object sender, EventArgs e)
        {
            SetoControl.SelectedIndex = 1;
            InfoControl.SelectedIndex = 1;
            SetSelectedButtonColor(NextCanalysis);
        }

        // ボタンの背景色を変更する共通メソッド
        private void SetSelectedButtonColor(Button selectedButton)
        {
            // すべての対象ボタンの背景色をリセット
            NextTask.BackColor = Color.Beige;
            NextSanalysis.BackColor = Color.Beige;
            NextCanalysis.BackColor = Color.Beige;

            NextTask.ForeColor = Color.DarkOliveGreen;
            NextSanalysis.ForeColor = Color.DarkOliveGreen;
            NextCanalysis.ForeColor = Color.DarkOliveGreen;

            // 選ばれたボタンだけSeaGreenに
            selectedButton.BackColor = Color.SeaGreen;
            selectedButton.ForeColor = Color.FloralWhite;
        }

       
    }

}
    

