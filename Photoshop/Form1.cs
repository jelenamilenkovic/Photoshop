using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Photoshop.Views;
using Photoshop.Models;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace Photoshop
{
    public partial class Form1 : Form
    {
        private LinkedList<Bitmap> undo=new LinkedList<Bitmap>();
        private LinkedList<Bitmap> redo = new LinkedList<Bitmap>();
        public System.Drawing.Bitmap m_Bitmap;
        public System.Drawing.Bitmap mh_Bitmap;
        public System.Drawing.Bitmap ms_Bitmap;
        public System.Drawing.Bitmap mv_Bitmap;
        private bool f = false;
        public bool histogr = false;
        private float memn;
        private float temp;
        public double sat = 0;
        public double hue = 0;
        public double Zoom = 1.0;
        public Color Xcolor;
        private bool Fleg = false;
        private System.Drawing.Bitmap m_Undo;
        
        public Form1()
        {
            InitializeComponent();
            memn = 2;
            temp = 0;
            m_Bitmap = new Bitmap(4, 4);
            mh_Bitmap= new Bitmap(4, 4);
            ms_Bitmap = new Bitmap(4, 4);
            mv_Bitmap = new Bitmap(4, 4);
            int k = m_Bitmap.Height;
            int l = m_Bitmap.Width;
            hue = 0;
            btnRedo.Enabled = false;
            btnUndo.Enabled = false;
        }
        
       

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Fleg)
            {
                View2.OnPaint(this);
                
            }
            else
                View1.OnPaint(this);
             
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void File_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                byte[] b= (byte[])TypeDescriptor.GetConverter(m_Bitmap).ConvertTo(m_Bitmap, typeof(byte[]));
                float ff = b.Length/1024/1024;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                this.Invalidate();
            }
        }

        private void File_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                m_Bitmap.Save(saveFileDialog.FileName);
            }
        }

        private void File_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kanalskeSlikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Fleg = !Fleg;
            mh_Bitmap = (Bitmap)m_Bitmap.Clone();
            ms_Bitmap = (Bitmap)m_Bitmap.Clone();
            mv_Bitmap = (Bitmap)m_Bitmap.Clone();
        
            FilterBasic.Hue(mh_Bitmap);
            FilterBasic.Saturation(ms_Bitmap);
            FilterBasic.ValueF(mv_Bitmap);
            textBox.Text = "Channel separation";
            this.Invalidate();
        }

        private void Zoom25_Click(object sender, EventArgs e)
        {
            Zoom = .25;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom50_Click(object sender, EventArgs e)
        {
            Zoom = .5;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom100_Click(object sender, EventArgs e)
        {
            Zoom = 1.0;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Filter_Grayscale_Click(object sender, EventArgs e)
        {

            ColorInput dlg = new ColorInput();
            dlg.red = dlg.green = dlg.blue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                call_undo((Bitmap)m_Bitmap.Clone());
                textBox.Text = "Unsafe code in C#";
                if (FilterBasic.GrayScale(m_Bitmap, dlg.red, dlg.green, dlg.blue))
                    this.Invalidate();
            }

        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorInput dlg = new ColorInput();
            dlg.red = dlg.green = dlg.blue = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                call_undo((Bitmap)m_Bitmap.Clone());
                textBox.Text = "Unsafe code in C#";
                if (FilterBasic.Colorr(m_Bitmap, dlg.red,dlg.green,dlg.blue))
                    this.Invalidate();
            }      
        }

        private void Filter_Swirl_Click(object sender, EventArgs e)
        {
            
            call_undo((Bitmap)m_Bitmap.Clone());
            textBox.Text = "Unsafe code in C#";
            if (FilterDisplacement.Swirl(m_Bitmap, 15, true))
                this.Invalidate();
        }

        private void EdgeDetectVertical_Click(object sender, EventArgs e)
        {
            textBox.Text = "Unsafe code in C#";
            call_undo((Bitmap)m_Bitmap.Clone());
            if (FilterConvolution.EdgeDetectVertical(m_Bitmap))
                this.Invalidate();
        }

        private void Smooth_Click(object sender, EventArgs e)
        {
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            btnRedo.Enabled = true;
            if (undo.Count > 0) { 
            Bitmap t = (Bitmap)m_Bitmap.Clone();
            redo.AddLast(t);
            if (redo.Count != 0) btnRedo.Enabled = true;
            m_Bitmap = undo.Last();
            temp-= (((byte[])TypeDescriptor.GetConverter(m_Bitmap).ConvertTo(m_Bitmap, typeof(byte[])))).Length / 1024 / 1024;
            undo.RemoveLast();}
            this.Invalidate();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redo.Count > 0) {
            Bitmap t = (Bitmap)m_Bitmap.Clone();
            call_undo(t);
            
                m_Bitmap = redo.Last();
                redo.RemoveLast();
                if (redo.Count == 0) btnRedo.Enabled = false;
            }
            else
            {
                btnRedo.Enabled = false;
            }
            this.Invalidate();
        }
       
       
        public static bool Saturation(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);
            double V, m, C, H;
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];
                        V = Math.Max(Math.Max(red, green), blue);
                        m = Math.Min(Math.Min(red, green), blue);
                        if (V <= 0)
                        {
                            p[2] = (byte)0;
                            p[1] = (byte)0;
                            p[0] = (byte)0;
                        }
                        else
                        {
                            p[2] = (byte)((V - m) * 255 / V);
                            p[1] = (byte)((V - m) * 255 / V);
                            p[0] = (byte)((V - m) * 255 / V);
                        }


                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;

        }
        private void maxValueOfMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemValue dlg = new MemValue();
            dlg.Memval=0;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                memn = dlg.Memval;
            }
        }

        private void call_undo(Bitmap b) {
            btnUndo.Enabled = true;
            float g = (((byte[])TypeDescriptor.GetConverter(b).ConvertTo(b, typeof(byte[])))).Length / 1024 / 1024;
           if (memn >=temp+g)
            {
                temp += g;
                undo.AddLast(b);

            }
            else if (memn > temp+g)
            {
                Bitmap z = undo.First();
                undo.RemoveFirst();
                temp-= (((byte[])TypeDescriptor.GetConverter(m_Bitmap).ConvertTo(m_Bitmap, typeof(byte[])))).Length/1024/1024;
                call_undo(b);
            }
        }

        private void btn_histogram_Click(object sender, EventArgs e)
        {
            FilterBasic.Histogram(m_Bitmap,chart1,chart2,chart3,chart4);
            histogr = true;
            
        }

        private void btn_sierraDithering_Click(object sender, EventArgs e)
        {
            textBox.Text = "Safe code in C#";
            FilterBasic.SierraDithering(m_Bitmap);
            this.Invalidate();
        }

        private void btn_inplace_Click(object sender, EventArgs e)
        {
            mh_Bitmap = (Bitmap)m_Bitmap.Clone();
            ms_Bitmap = (Bitmap)m_Bitmap.Clone();
            mv_Bitmap = (Bitmap)m_Bitmap.Clone();
            textBox.Text = "Previous estimated pixel value does not affect the new calculation";
            call_undo((Bitmap)m_Bitmap.Clone());
            Fleg = true;
            if (FilterConvolution.Smooth(mh_Bitmap, mv_Bitmap, ms_Bitmap, 1025, false))
                this.Invalidate();
        }

        private void btn_simplysmooth_Click(object sender, EventArgs e)
        {
            mh_Bitmap = (Bitmap)m_Bitmap.Clone();
            ms_Bitmap = (Bitmap)m_Bitmap.Clone();
            mv_Bitmap = (Bitmap)m_Bitmap.Clone();
            textBox.Text = "Previous estimated pixel value affects the new calculation";
            call_undo((Bitmap)m_Bitmap.Clone());
            Fleg = true;
            if (FilterConvolution.Smooth(mh_Bitmap,mv_Bitmap, ms_Bitmap,1025, true))
                this.Invalidate();
        }

        private void btn_crossdomain_Click(object sender, EventArgs e)
        {
            HSV dialoghsv = new HSV();
            dialoghsv.hue = 0;
            dialoghsv.sat = 0;
            textBox.Text = "Unsafe code in C#";
            if (DialogResult.OK == dialoghsv.ShowDialog())
            {
                hue =(double) dialoghsv.hue;
                sat =(double)dialoghsv.sat;
                call_undo((Bitmap)m_Bitmap.Clone());
                if (FilterBasic.CrossDomain(m_Bitmap, sat,hue))
                    this.Invalidate();
            }

        }

        private void btn_orderedDithering_Click(object sender, EventArgs e)
        {
            textBox.Text = "Unsafe code in C#";
            call_undo((Bitmap)m_Bitmap.Clone());
            if (FilterBasic.OrderedDithering(m_Bitmap))
                this.Invalidate();
        }

        private void btn_kuwahara_Click(object sender, EventArgs e)
        {
            textBox.Text = "Safe code in C#";
            call_undo((Bitmap)m_Bitmap.Clone());
            m_Bitmap = FilterBasic.KuwaharaFilter(m_Bitmap);
             this.Invalidate();
        
        }

        private void btn_unificationOfColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            textBox.Text = "Unsafe code in C#";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string str = null;
                str = dlg.Color.Name;
                Xcolor = dlg.Color;
                f = true;
            }
            

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f) {
            var Tx =e.Location.X;
            var Ty = e.Location.Y;
            if (Tx > 0 && Tx<m_Bitmap.Width*Zoom && Ty>0 && Ty<m_Bitmap.Height*Zoom) { 
            Color c = m_Bitmap.GetPixel(Tx, Ty);
            int r= m_Bitmap.GetPixel(Tx, Ty).R;
            int b = m_Bitmap.GetPixel(Tx, Ty).B;
            int g = m_Bitmap.GetPixel(Tx, Ty).G;
            int S=5;
            m_Bitmap.SetPixel(Tx, Ty, Xcolor);
            for (int i = Tx - 1; i <= Tx + 1; i++)
                for (int j = Ty - 1; j <= Ty + 1; j++)
                    if (j >= 0 || i >= 0)
                         if (S <= FilterBasic.Sim(Xcolor, c))
                            m_Bitmap.SetPixel(i, j, Xcolor);}
            f=!f;
            textBox.Text = "Safe code in C#";
            }
                        
        }

        private void btn_simpleColorize_Click(object sender, EventArgs e)
        {
            call_undo((Bitmap)m_Bitmap.Clone());
            textBox.Text = "Unsafe code in C#";
            if (FilterBasic.SimpleColorize(m_Bitmap))
                this.Invalidate();
        }

        private void btn_compression_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btn_xGray_Click(object sender, EventArgs e)
        {
            mh_Bitmap = (Bitmap)m_Bitmap.Clone();
            ms_Bitmap = (Bitmap)m_Bitmap.Clone();
            mv_Bitmap = (Bitmap)m_Bitmap.Clone();
            textBox.Text = "Unsafe code in C#";
            call_undo((Bitmap)m_Bitmap.Clone());
            Fleg = true;
            FilterBasic.GrayScale1(mv_Bitmap);
            FilterBasic.GrayScale2(ms_Bitmap);
            FilterBasic.GrayScale3(mh_Bitmap);
            this.Invalidate();
        }
    }
}

