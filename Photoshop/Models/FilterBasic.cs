 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Photoshop.Models
{
    public class FilterBasic
    {
        public static double rgb_to_hsv(double r, double g, double b,double cmax,double cmin)
        {
            
            r = r / 255.0;
            g = g / 255.0;
            b = b / 255.0;
            double diff = cmax - cmin; 
            double h = 0, s = -1;
            
            if (cmax == cmin)
                h = 0;
            
            else if (cmax == r)
                h = (60 * ((g - b) / diff) + 360) % 360;
            
            else if (cmax == g)
                h = (60 * ((b - r) / diff) + 120) % 360;
            
            else if (cmax == b)
                h = (60 * ((r - g) / diff) + 240) % 360;

            return h;

        }
        public static bool Histogram(Bitmap b,Chart chart1, Chart chart2, Chart chart3, Chart chart4)
        {


            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);
            int[] array = new int[256];
            int[] hue = new int[361];
            int[] valup = new int[256];
            int[] saturation = new int[101];
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            int shift, scale;
            shift = 5;
            scale = 2;
            double cmax,cmin;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        array[p[0] = (byte)(((p[0] + shift) * scale) > 255 ? 255 : (p[0] + shift) * scale)]+=1;
                        array[p[1] = (byte)(((p[1] + shift) * scale) > 255 ? 255 : (p[1] + shift) * scale)]+=1;
                        array[p[2] = (byte)(((p[2] + shift) * scale) > 255 ? 255 : (p[2] + shift) * scale)]+=1;
                        cmin=Math.Min(p[0], Math.Min(p[1], p[2]));
                        valup[(int)(cmax=Math.Max(p[0], Math.Max(p[1],p[2])))] += 1;
                        saturation[(int)(cmax == 0 ? 0 : (((cmax - cmin) / cmax) * 100) % 100)] += 1;
                        hue[(int)(rgb_to_hsv(p[2], p[1],p[0], cmax,cmin))] += 1;
                        p += 3;
                    }
                    p += nOffset;
                }
            }
            chart1.Series.Clear();
            b.UnlockBits(bmData);
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "RGB",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline
            };
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Value",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline
            };
            var series3 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Saturation",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline
            };
            var series4 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Hue",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline
            };

            chart1.Series.Add(series1);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Pixels x[10^4]";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Value of pixel";
            chart1.Titles.Add("RGB");
            chart2.Series.Add(series2);
            chart2.Titles.Add("VALUE");
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Pixels x[10^4]";
            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Value of pixel";
            for (int i = 0; i < 256; i++)
            {
                series1.Points.AddXY(i, array[i] / 10000);
                series2.Points.AddXY(i, valup[i] / 10000);
            }
            chart3.Series.Add(series3);
            chart3.Titles.Add("SATURATION");
            chart3.ChartAreas["ChartArea1"].AxisX.Title = "Value of pixel";
            chart3.ChartAreas["ChartArea1"].AxisY.Title = "Pixels x[10^4]";
            for (int i = 0; i < 101; i++)
            {
                series3.Points.AddXY(i, saturation[i] / 10000);
            }
            chart4.Series.Add(series4);
            chart4.Titles.Add("HUE");
            chart4.ChartAreas["ChartArea1"].AxisX.Title = "Value of pixel";
            chart4.ChartAreas["ChartArea1"].AxisY.Title = "Pixels x[10^4]";
            for (int i = 0; i < 360; i++)
            {
                series4.Points.AddXY(i, hue[i] / 10000);
            }
            chart1.Invalidate();
            chart2.Invalidate();
            chart3.Invalidate();
            chart4.Invalidate();
            return true;
        }
        public static bool Hue(Bitmap b)
        {


            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);
            double M, m, C, H;
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
                        M = Math.Max(Math.Max(red, green), blue);
                        m = Math.Min(Math.Min(red, green), blue);
                        C = M - m;
                        if (C == 0)
                        {
                            H = 0;
                            p[2] = (byte)0;
                            p[1] = (byte)0;
                            p[0] = (byte)0;
                        }
                        else if (M == red)
                        {
                            H = 60 * (((green - blue) / C) % 6);
                            p[2] = (byte)(H / (360 / 255));
                            p[1] = (byte)0;
                            p[0] = (byte)0;
                        }
                        else if (M == green)
                        {
                            H = 60 * (((blue - red) / C) + 2);
                            p[2] = (byte)0;
                            p[1] = (byte)(H / (360 / 255));
                            p[0] = (byte)0;
                        }
                        else
                        {
                            H = 60 * (((red - green) / C) + 4);
                            p[2] = (byte)0;
                            p[1] = (byte)0;
                            p[0] = (byte)(H / (360 / 255));
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        public static bool ValueF(Bitmap b)
        {


            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);
            double M, m, C, H;
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
                        M = Math.Max(Math.Max(red, green), blue);
                        p[2] = (byte)M;
                        p[1] = (byte)M;
                        p[0] = (byte)M;



                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
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
                            p += 3;
                        }
                        else
                        {
                            int s = (int)((double)((double)(V - m) * 255 / V));
                            p[2] = (byte)s;
                            p[1] = (byte)s;
                            p[0] = (byte)s;
                            p += 3;
                        }
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        public static bool GrayScale(Bitmap b, double redR, double greenR, double blueR)
        {
            if (redR < -255 || redR > 255) return false;
            if (greenR < -255 || greenR > 255) return false;
            if (blueR < -255 || blueR > 255) return false;

            redR = (redR + 255.0) / 512.0;
            greenR = (greenR + 255.0) / 512.0;
            blueR = (blueR + 255.0) / 512.0;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);

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

                        //						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
                        p[0] = p[1] = p[2] = (byte)(redR * red + greenR * green + blueR * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;

        }
        public static bool GrayScale1(Bitmap b)
        {
            

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);

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

                        //						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
                        p[0] = p[1] = p[2] = (byte)((red + blue + green) / 3);
                        if (p[0] >= 255) p[0] = p[1] = p[2] = (byte)255;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        public static bool GrayScale2(Bitmap b)
        {
           

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);

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

                        //						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
                        p[0] = p[1] = p[2] = (byte)(Math.Max(red, Math.Max(green, blue)));
                        if (p[0] >= 255) p[0] = p[1] = p[2] = (byte)255;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        public static bool GrayScale3(Bitmap b)
        {
          

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);

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
                        Random rnd = new Random();
                        int r = rnd.Next(1, 4);
                        if (r == 1) p[0] = p[1] = p[2] = (byte)red;
                        else if (r == 2) p[0] = p[1] = p[2] = (byte)blue;
                        else p[0] = p[1] = p[2] = (byte)green;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        public static int normalizeColorByte(int colorByte)
        {
            if (colorByte < 0) return 0;
            if (colorByte > 255) return 255;

            return colorByte;
        }

        public static Color getFilteredColor(Bitmap b, int x, int y, double divisor, int errorRed, int errorGreen, int errorBlue)
        {
            int red = normalizeColorByte(b.GetPixel(x, y).R + (int)Math.Round(errorRed * divisor));
            int green = normalizeColorByte(b.GetPixel(x, y).G + (int)Math.Round(errorGreen * divisor));
            int blue = normalizeColorByte(b.GetPixel(x, y).B + (int)Math.Round(errorBlue * divisor));

            return System.Drawing.Color.FromArgb(red, green, blue);

        }
        public static bool CrossDomain(Bitmap b, double newSat, double newHue)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);// PixelFormat.Format24bppRgb);
            double cmax, cmin, C, H;
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int x = 0; x < b.Width; ++x)
                {
                    for (int y = 0; y < b.Height; ++y)
                    {   red = p[2];
                        blue = p[0];
                        green = p[1];
                        
                        cmax = Math.Max(Math.Max(red, green), blue);
                        cmin = Math.Min(Math.Min(red, green), blue);
                        double delta = cmax - cmin;
                        double h = newHue;
                        double s = newSat != 0 ? newSat : (cmax == 0) ? 0 : delta / cmax;
                        double v = cmax;
                        double Hi = Math.Floor(h + 1) % 6;
                        double f = (h + 1) - Math.Floor(h + 1);
                        double pp = v * (1 - s);
                        double q = v * (1 - f * s);
                        double t = v * (1 - (1 - f) * s);


                        switch (Hi)
                        {
                            case 0:
                                red = (byte)v;
                                green = (byte)t;
                                blue = (byte)pp;
                                break;
                            case 1:
                                red = (byte)q;
                                green = (byte)v;
                                blue = (byte)pp;
                                break;
                            case 2:
                                red = (byte)pp;
                                green = (byte)v;
                                blue = (byte)t;
                                break;
                            case 3:
                                red = (byte)pp;
                                green = (byte)q;
                                blue = (byte)v;
                                break;
                            case 4:
                                red = (byte)t;
                                green = (byte)pp;
                                blue = (byte)v;
                                break;
                            case 5:
                                red = (byte)v;
                                green = (byte)pp;
                                blue = (byte)q;
                                break;
                        }

                                p[0] = blue;
                                p[1] = green;
                                p[2] = red;
                                p += 3;
                        }
                        p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

       
        public int applyThreshold(int value)
        {
            return value < 128 ? 0 : 255;
        }
        public static void mutateIndexSafely(Bitmap b, int x, int y, double divisor, int errorRed, int errorGreen, int errorBlue)
        {
            if ((x < b.Width && x >= 0) && (y < b.Height && y >= 0))
            {
                Color color = getFilteredColor(b, x, y, divisor, errorRed, errorGreen, errorBlue);
                b.SetPixel(x, y, color);
            }
        }
        public static bool SierraDithering(Bitmap b)
        {


            for (int y = 0; y < b.Height; y++)
            {
                for (int x = 0; x < b.Width; x++)
                {
                    Color currentPixel = b.GetPixel(x, y);

                    int redOld = currentPixel.R;
                    int greenOld = currentPixel.G;
                    int blueOld = currentPixel.B;

                    int redNew = 0;
                    int greenNew = 0;
                    int blueNew = 0;


                    int gray = (int)(0.299 * currentPixel.R + 0.587 * currentPixel.G + 0.114 * currentPixel.B);
                    int newBit = gray < 128 ? 0 : 255;

                    redNew = newBit;
                    greenNew = newBit;
                    blueNew = newBit;

                    b.SetPixel(x, y, Color.FromArgb(redNew, greenNew, blueNew));

                    int redError = redOld - redNew;
                    int greenError = greenOld - greenNew;
                    int blueError = blueOld - blueNew;

                    mutateIndexSafely(b, x + 1, y, (double)5 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x + 2, y, (double)3 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x - 2, y + 1, (double)2 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x - 1, y + 1, (double)4 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x, y + 1, (double)5 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x + 1, y + 1, (double)4 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x + 2, y + 1, (double)2 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x - 1, y + 2, (double)2 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x, y + 2, (double)3 / (double)32, redError, greenError, blueError);
                    mutateIndexSafely(b, x + 1, y + 2, (double)2 / (double)32, redError, greenError, blueError);
                }
            }
            return true;
        }
        public static bool Colorr(Bitmap b, int red, int green, int blue)
        {
            if (red < -255 || red > 255) return false;
            if (green < -255 || green > 255) return false;
            if (blue < -255 || blue > 255) return false;

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nPixel;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        nPixel = p[2] + red;
                        nPixel = Math.Max(nPixel, 0);
                        p[2] = (byte)Math.Min(255, nPixel);

                        nPixel = p[1] + green;
                        nPixel = Math.Max(nPixel, 0);
                        p[1] = (byte)Math.Min(255, nPixel);

                        nPixel = p[0] + blue;
                        nPixel = Math.Max(nPixel, 0);
                        p[0] = (byte)Math.Min(255, nPixel);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
       
        public static bool SimpleColorize(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            double[,] matrica = new double[256, 4];
            for (int i = 0; i < 4; i++)
                matrica[0, i] = 0;
            for (int i = 1; i < 256; i++)
            {
                matrica[i, 0] = i;
                matrica[i, 1] = (i > 127) ? i*0.756 : i/ 2;
                matrica[i, 2] = (i > 127 )?i / 2 : i*0.263;
                matrica[i, 3] = (i> 127 )? i / 2 : i*0.124;
            }


            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nPixel;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        int gray = p[0];
                        p[2] = (byte)(matrica[gray, 3]);
                        p[1] = (byte)(matrica[gray, 2]);
                        p[0] = (byte)(matrica[gray, 1]);


                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
        
        public static double Sim(Color one,Color two)
        {
            return Math.Sqrt((one.R - two.R)* (one.R - two.R)+ (one.G - two.G)* (one.G - two.G)+ (one.B - two.B)* (one.B - two.B));
        }
        public static Bitmap KuwaharaFilter(Bitmap Image)
        {
            int Size = 4;
            System.Drawing.Bitmap TempBitmap = Image;
            System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(TempBitmap.Width, TempBitmap.Height);
            System.Drawing.Graphics NewGraphics = System.Drawing.Graphics.FromImage(NewBitmap);
            NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), System.Drawing.GraphicsUnit.Pixel);
            NewGraphics.Dispose();
            Random TempRandom = new Random();
            int[] ApetureMinX = { -(Size / 2), 0, -(Size / 2), 0 };
            int[] ApetureMaxX = { 0, (Size / 2), 0, (Size / 2) };
            int[] ApetureMinY = { -(Size / 2), -(Size / 2), 0, 0 };
            int[] ApetureMaxY = { 0, 0, (Size / 2), (Size / 2) };
            for (int x = 0; x < NewBitmap.Width; ++x)
            {
                for (int y = 0; y < NewBitmap.Height; ++y)
                {
                    int[] RValues = { 0, 0, 0, 0 };
                    int[] GValues = { 0, 0, 0, 0 };
                    int[] BValues = { 0, 0, 0, 0 };
                    int[] NumPixels = { 0, 0, 0, 0 };
                    int[] MaxRValue = { 0, 0, 0, 0 };
                    int[] MaxGValue = { 0, 0, 0, 0 };
                    int[] MaxBValue = { 0, 0, 0, 0 };
                    int[] MinRValue = { 255, 255, 255, 255 };
                    int[] MinGValue = { 255, 255, 255, 255 };
                    int[] MinBValue = { 255, 255, 255, 255 };
                    for (int i = 0; i < 4; ++i)
                    {
                        for (int x2 = ApetureMinX[i]; x2 < ApetureMaxX[i]; ++x2)
                        {
                            int TempX = x + x2;
                            if (TempX >= 0 && TempX < NewBitmap.Width)
                            {
                                for (int y2 = ApetureMinY[i]; y2 < ApetureMaxY[i]; ++y2)
                                {
                                    int TempY = y + y2;
                                    if (TempY >= 0 && TempY < NewBitmap.Height)
                                    {
                                        Color TempColor = TempBitmap.GetPixel(TempX, TempY);
                                        RValues[i] += TempColor.R;
                                        GValues[i] += TempColor.G;
                                        BValues[i] += TempColor.B;
                                        if (TempColor.R > MaxRValue[i])
                                        {
                                            MaxRValue[i] = TempColor.R;
                                        }
                                        else if (TempColor.R < MinRValue[i])
                                        {
                                            MinRValue[i] = TempColor.R;
                                        }

                                        if (TempColor.G > MaxGValue[i])
                                        {
                                            MaxGValue[i] = TempColor.G;
                                        }
                                        else if (TempColor.G < MinGValue[i])
                                        {
                                            MinGValue[i] = TempColor.G;
                                        }

                                        if (TempColor.B > MaxBValue[i])
                                        {
                                            MaxBValue[i] = TempColor.B;
                                        }
                                        else if (TempColor.B < MinBValue[i])
                                        {
                                            MinBValue[i] = TempColor.B;
                                        }
                                        ++NumPixels[i];
                                    }
                                }
                            }
                        }
                    }
                    int j = 0;
                    int MinDifference = 10000;
                    for (int i = 0; i < 4; ++i)
                    {
                        int CurrentDifference = (MaxRValue[i] - MinRValue[i]) + (MaxGValue[i] - MinGValue[i]) + (MaxBValue[i] - MinBValue[i]);
                        if (CurrentDifference < MinDifference && NumPixels[i] > 0)
                        {
                            j = i;
                            MinDifference = CurrentDifference;
                        }
                    }

                    Color MeanPixel = Color.FromArgb(RValues[j] / NumPixels[j],
                        GValues[j] / NumPixels[j],
                        BValues[j] / NumPixels[j]);
                    NewBitmap.SetPixel(x, y, MeanPixel);
                }
            }
            return NewBitmap;
        }
        public static bool OrderedDithering(Bitmap b)
        {
            int[,]bayer_pattern_3x3 = { { 181, 231, 131 }, { 50, 25, 100 }, { 156, 75, 206 } };
            int col, row = 0;
            int red, green, blue;
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nPixel,c;

                for (int y = 0; y < b.Height; ++y)
                {
                    row = y % 3;
                    for (int x = 0; x < b.Width; ++x)
                   
                    {
                        col = x % 3;
                        blue = p[2];
                        green = p[1];
                        red = p[0];
                        c = ((red + green + blue) / 3 < bayer_pattern_3x3[col,row] ? 0 : 255);
                        nPixel = p[0] + blue;
                        p[0]=(byte) c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

        
            return true;
        }
        
    }
}