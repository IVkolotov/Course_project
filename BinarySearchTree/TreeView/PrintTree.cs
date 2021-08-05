using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
    class Print
    {
        Bitmap bmp;
        Pen pen = new Pen(Color.Blue, 2);
        Graphics G;
        private PictureBox pictureBox1;

        public Print(PictureBox pictureBox1)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics.FromImage(bmp);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Pen p = new Pen(Color.Blue, 2);// цвет линии и ширина
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Rectangle Rect = new Rectangle(bmp.Width / 2 - 100, 20, 200, 100);
            G.DrawRectangle(p, Rect);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            G.DrawString("Текст по центру", new Font("Times", 15), Brushes.Black, Rect, sf);
            pictureBox1.Image = bmp;



            Point p1 = new Point(Rect.X + Rect.Height, Rect.Y + Rect.Width / 2);// первая точка
            Point p2 = new Point(100, 200);// вторая точка
            G.DrawLine(p, p1, p2);// рисуем линию
            G.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }

        internal Image Draw()
        {
            throw new NotImplementedException();
        }



    }
}
