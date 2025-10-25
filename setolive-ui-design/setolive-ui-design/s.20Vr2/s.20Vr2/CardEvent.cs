using s._20Vr2;
using System;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public class CardEventHandler
{
    private bool isDragging = false;
    private Point clickOffset;
    private Panel originalParent;
    private Point originalLocation;
    private Color originalBackColor;
    private string originalStatus;
    public const int Columns = 2;
public const int PanelMargin = 2;

    private Panel NewPanel,CompPanel, ShipPanel;
    private Panel InfoPanel;
   
    public CardEventHandler(Panel p1, Panel p2, Panel p3 ,Panel show)
    {
        NewPanel = p1;
        CompPanel = p2;
        ShipPanel = p3;
        InfoPanel = show;
    }

    public void MouseDown(object sender, MouseEventArgs e)
    {
       

        Panel card = sender as Panel;
        if (card == null) return;
        isDragging = true;
        clickOffset = e.Location;
        originalParent = card.Parent as Panel;
        originalLocation = card.Location;
        originalBackColor = card.BackColor;

        if (card.Tag is CustomerCardInfo info && info.StatusLabel != null)
        {
            originalStatus = info.StatusLabel.Text;
        }

        // 親をFormに一時的に変更
        Form form = card.FindForm();
        if (form == null) return;

        Point screenLocation = card.PointToScreen(Point.Empty);
        Point formLocation = form.PointToClient(screenLocation);

        form.Controls.Add(card);
        card.Location = formLocation;
        card.BringToFront();
    }

    public void MouseMove(object sender, MouseEventArgs e)
    {

        if (!isDragging) return;

        Panel card = sender as Panel;
        if (card == null) return;

        // スクリーン座標からドラッグ位置を補正
        Point screenPos = card.PointToScreen(e.Location);
        Point parentPos = card.Parent.PointToClient(screenPos);

        // マウスのオフセットを補正してカードを移動
        card.Location = new Point(parentPos.X - clickOffset.X, parentPos.Y - clickOffset.Y);

        Point center = card.PointToScreen(new Point(card.Width / 2, card.Height / 2));

        
        var info = card.Tag as CustomerCardInfo;
        if (NewPanel.RectangleToScreen(NewPanel.ClientRectangle).Contains(center))
        {
            
            card.BackColor = Color.DarkSeaGreen;
            if (info?.StatusLabel != null) info.StatusLabel.Text = "状態: 新規予約";
        }
        else if (CompPanel.RectangleToScreen(CompPanel.ClientRectangle).Contains(center))
        {
            card.BackColor = Color.Khaki;
            if (info?.StatusLabel != null) info.StatusLabel.Text = "状態: 受注確定";
        }
        else if (ShipPanel.RectangleToScreen(ShipPanel.ClientRectangle).Contains(center))
        {
            card.BackColor = Color.LightBlue;
            if (info?.StatusLabel != null) info.StatusLabel.Text = "状態: 発送済み";
        }
        else
        {
            card.BackColor = originalBackColor;
            if (info?.StatusLabel != null) info.StatusLabel.Text = originalStatus;
        }
    }

    public void MouseUp(object sender, MouseEventArgs e)
    {
        if (!isDragging)
            return;

        Panel card = sender as Panel;
        if (card == null)
            return;
        isDragging = false;

        Point center = card.PointToScreen(new Point(card.Width / 2, card.Height / 2));
        Panel[] zones = { NewPanel, CompPanel, ShipPanel };

        foreach (var zone in zones)
        {
            if (zone.RectangleToScreen(zone.ClientRectangle).Contains(center))
            {
                MoveToPanel(card, zone);
                return;
            }
        }

        // 元に戻す
        originalParent.Controls.Add(card);
        card.Location = originalLocation;
        card.BackColor = originalBackColor;

        if (card.Tag is CustomerCardInfo info && info.StatusLabel != null)
        {
            info.StatusLabel.Text = originalStatus;
        }
    }

    private void MoveToPanel(Panel card, Panel newZone)
    {
        newZone.Controls.Add(card);

        int index = newZone.Controls.Count - 1;
        int panelWidth = newZone.ClientSize.Width;
        int panelHeight = newZone.ClientSize.Height;
        int cardHeight = panelHeight / 6;
        int cardWidth = (panelWidth - CardcriCreate.PanelMargin * (CardcriCreate.Columns + 1)) / CardcriCreate.Columns;

        int x = CardcriCreate.PanelMargin + (index % CardcriCreate.Columns) * (cardWidth + CardcriCreate.PanelMargin);
        int y = CardcriCreate.PanelMargin + (index / CardcriCreate.Columns) * (cardHeight + CardcriCreate.PanelMargin);

        card.Size = new Size(cardWidth, cardHeight);
        card.Location = new Point(x, y);
    }


    public void OnMouseEnter(object sender, EventArgs e)
    {
        Panel card = sender as Panel;
        if (card == null)
            return;

        CustomerCardInfo info = card.Tag as CustomerCardInfo;
        if (info == null)
            return;


        InfoPanel.Controls.Clear();

        int columnCount = 5;  // 1列に5個まで
        int labelCount = 0;   // 何個目のラベルか
        void Add(string text, Color? color = null)
        {
            var lbl = new Label
            {
                Text = text,
                AutoSize = true,
                ForeColor = color ?? Color.DarkOliveGreen
            };

            int col = labelCount / columnCount;
            int row = labelCount % columnCount;

            lbl.Location = new Point(10 + col * 200, 10 + row * 25);
            InfoPanel.Controls.Add(lbl);
            labelCount++;
        }


        Add("顧客ID: " + info.CustomerID);
        Add("受注日" + info.Payment);
        Add("合計金額" + info.TotalAmout);
        Add("顧客名: " + info.CustomerName);
        Add("住所: " + info.Address);
        Add("電話番号: " + info.Phone);
        Add("郵便番号: " + info.PostalCode);
        Add("支払方法"+info.Phone);
        Add("状態: " + info.StatusLabel?.Text.Replace("状態: ", ""));
        Add("商品合計数: " + info.SyCount);


        // 商品一覧の前に行位置を調整して、次の列に縦に並べる
        // 商品一覧ラベルとその下の商品を同じ色で表示
        Color productColor = Color.DarkCyan;

        // 商品一覧の前に行を揃える（列変えない！）
        labelCount += (columnCount - (labelCount % columnCount+5));

        Add("商品一覧:", productColor);

        foreach (var product in info.Products)
        {
            Add("商品名: " + product.Name + ", 数量: " + product.Quantity + ", 金額: " + product.Amount, productColor);
        }



    }

}
