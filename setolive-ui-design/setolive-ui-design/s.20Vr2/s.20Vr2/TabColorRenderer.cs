using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s._20Vr2
{
    internal class TabColorRenderer
    {
        public static void DrawTab(TabControl tabContorl, DrawItemEventArgs e)//TabControlで対象のタブコントロール 
        {
            var tab = tabContorl.TabPages[e.Index];//e.Indexで今書こうとしてるタブの番号 tabその番号のタブページ
            var rect = tabContorl.GetTabRect(e.Index);//その他部が画面上に書かれている位置と大きさ
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;//今のタブが選ばれているか確かめている

            Color backColor;
            
            switch (tabContorl.Name)
            {
                case "SetoControl":
                    backColor = selected ? Color.SeaGreen : Color.Beige;
                    break;
                case "tabControlBn":
                    backColor = selected ? Color.DarkOliveGreen : Color.OliveDrab;
                    break;
                default:
                    backColor = selected ? Color.SeaGreen : Color.Beige;
                    break;
            }
            Brush textBrush = selected ? Brushes.White : Brushes.DarkGreen; // ★文字の色を選択状態で変える
            var font = new Font("Meiryo", 15F, selected ? FontStyle.Bold : FontStyle.Regular);
            var sf = new StringFormat//文字の位置を中央ぞろえにしている
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.FillRectangle(new SolidBrush(backColor), rect);//そのタブの色を塗範囲
            e.Graphics.DrawString(tab.Text, font, textBrush, rect, sf);//タブ文字の描画
        }
    }
}
