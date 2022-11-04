using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;

namespace Photoshop.Views
{
    public class View1
    {
       public static void OnPaint(Form1 formica)
        {
            formica.chart1.Visible = false;
            formica.chart2.Visible = false;
            formica.chart3.Visible = false;
            formica.chart4.Visible = false;
            Graphics g = formica.CreateGraphics();
            
                g.DrawImage(formica.m_Bitmap, new Rectangle(formica.AutoScrollPosition.X, formica.AutoScrollPosition.Y, (int)(formica.m_Bitmap.Width * formica.Zoom), (int)(formica.m_Bitmap.Height * formica.Zoom)));
            

        }
    }
}
