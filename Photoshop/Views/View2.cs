using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoshop.Views
{
   public class View2
    {
        public static void OnPaint(Form1 formica)
        {
            if (formica.histogr == false) { 
            formica.chart1.Visible = false;
            formica.chart2.Visible = false;
            formica.chart3.Visible = false;
            formica.chart4.Visible = false;
            Graphics g = formica.CreateGraphics();
            g.DrawImage(formica.m_Bitmap, new Rectangle(formica.AutoScrollPosition.X, formica.AutoScrollPosition.Y, (int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom)));
            g.DrawImage(formica.mv_Bitmap, new Rectangle(formica.AutoScrollPosition.X, (int)(formica.m_Bitmap.Height * formica.Zoom), (int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom)));
            g.DrawImage(formica.mh_Bitmap, new Rectangle((int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom), (int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom)));
            g.DrawImage(formica.ms_Bitmap, new Rectangle((int)(formica.m_Bitmap.Width * formica.Zoom), formica.AutoScrollPosition.Y, (int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom)));
            }
            else
            {
            var gg = formica.CreateGraphics();
            gg.Clear(Color.Black);
            formica.chart1.Visible = true;
            formica.chart2.Visible = true;
            formica.chart3.Visible = true;
            formica.chart4.Visible = true;
            formica.histogr = false;
            }
        }
    }
}
