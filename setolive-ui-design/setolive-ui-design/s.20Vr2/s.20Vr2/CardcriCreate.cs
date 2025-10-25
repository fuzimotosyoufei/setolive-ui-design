using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace s._20Vr2
{
    
    public class CustomerCardInfo
    {
        public string CustomerID { get; set; }
        public string OrderData { get; set; }
        public int TotalAmout { get; set; }
        public string CustomerName { get; set; }
        public Label StatusLabel { get; set; }
        public int SyCount { get; set; }
        public String Address { get; set; }
        public String PostalCode { get; set; }
        public String Phone { get; set; }
        public String Payment {  get; set; } 
        public List<ProductInfo> Products { get; set; }

    }
    internal class CardcriCreate
    {
        
        private readonly Form form;

        public const int Columns = 2;
        private const int Margin = 5;
       public const int PanelMargin = 2;

       

        public CardcriCreate(Form form )
        {
            
            this.form = form;
        }

        public void CreateCustomerCard(Panel parentPanel, CustomerOrderInfo customer,Panel NewPanel,Panel CompPanel,Panel ShipPanel,Panel InfoPanel)
        {
            int panelWidth = parentPanel.ClientSize.Width;
            int panelHeight = parentPanel.ClientSize.Height;
            int cardHeight = panelHeight / 6;
            int rowCount = 5;
            int rowHeight = cardHeight / rowCount;

            int cardWidth = (panelWidth - PanelMargin * (Columns + 1)) / Columns;
            int index = parentPanel.Controls.Count;

            int x = PanelMargin + (index % Columns) * (cardWidth + PanelMargin);
            int y = PanelMargin + (index / Columns) * (cardHeight + PanelMargin);

            Panel card = new Panel
            {
                Size = new Size(cardWidth, cardHeight),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = customer.Status
            };

            // 状態ごとのスタイル設定
            var panelStyles = new Dictionary<string, (Color Color, string Label)>//koko
        {
            { "NewPanel", (Color.DarkSeaGreen, "状態: 新規予約") },
            { "CompPanel", (Color.Khaki, "状態: 受注確定") },
            { "ShopPanel", (Color.SkyBlue, "状態: 発送済み") },
           
        };

            var lblStatus = CreateLabel("状態: " + customer.Status, new Point(0, rowHeight * 0 + Margin), new Size((cardWidth ) / 2, rowHeight - Margin * 2));
            lblStatus.Name = "lblStatus";

            if (panelStyles.TryGetValue(parentPanel.Name, out var style))
            {
                card.BackColor = style.Color;
                lblStatus.Text = style.Label;
            }

            
            var lblId = CreateLabel("顧客ID: " + customer.CustomerId, new Point(0, rowHeight * 1 + Margin), new Size((cardWidth - 10) / 2, rowHeight - Margin * 2));
            lblId.Name = "lblId";

            var lblName = CreateLabel("顧客名: " + customer.CustomerName, new Point(lblId.Right + 10, rowHeight * 1 + Margin), lblId.Size);
            var lblPhone = CreateLabel("電話番号: " + customer.Phone, new Point(0, rowHeight * 2 + Margin), new Size(cardWidth - 20, rowHeight - Margin * 2));
            var lblSyCount = CreateLabel("商品総個数: " + customer.Quantity, new Point(0, rowHeight * 3 + Margin), new Size((cardWidth ) / 2, rowHeight - Margin * 2));

            var txtMessage = new TextBox
            {
                Size = new Size(cardWidth - 95, rowHeight - Margin * 2),
                Location = new Point(1, rowHeight * 4 + Margin)
            };

            var btnSend = CreateButton("送信", new Point(cardWidth - 90, rowHeight * 4 + Margin - 2), new Size(45, rowHeight - Margin * 2 + 9));
            var btnSendAI = CreateButton("AI", new Point(cardWidth - 45, rowHeight * 4 + Margin - 2), new Size(45, rowHeight - Margin * 2 + 9));

            btnSend.Click += (s, e) => MessageBox.Show($"{customer.CustomerName} にメッセージ送信: {txtMessage.Text}", "送信完了");
            btnSendAI.Click += (s, e) => MessageBox.Show($"{customer.CustomerName} にAIがメッセージを作成: {txtMessage.Text}", "送信完了");



            card.Tag = new CustomerCardInfo
            {
                CustomerID = customer.CustomerId,
                OrderData = customer.Orderdate,
                TotalAmout = customer.TotalAmount,
                CustomerName = customer.CustomerName,
                StatusLabel = lblStatus,
                SyCount = customer.Quantity,
                Address = customer.Address,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Payment = customer.payment,
                Products = customer.Products
            };


            CardEventHandler cardEvent = new CardEventHandler(NewPanel, CompPanel, ShipPanel,InfoPanel);

            card.MouseDown += (s, e) => cardEvent.MouseDown(s, e);
            card.MouseMove += (s, e) => cardEvent.MouseMove(s, e);
            card.MouseUp += (s, e) => cardEvent.MouseUp(s, e);
            card.MouseEnter += (s, e) => cardEvent.OnMouseEnter(s, e);
           
            card.Controls.AddRange(new Control[]
            {
            lblStatus, lblId,lblName, lblPhone,
            txtMessage, btnSend, btnSendAI, lblSyCount
            });

            parentPanel.Controls.Add(card);
        }

        private Label CreateLabel(string text, Point location, Size size)
        {
            return new Label
            {
                Text = text,
                Location = location,
                Size = size,
                AutoSize = false
            };
        }

        private Button CreateButton(string text, Point location, Size size)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = size
            };
        }

    
    }
}
