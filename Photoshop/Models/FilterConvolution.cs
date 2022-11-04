using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Photoshop.Models
{
    public class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 5;
        public int Offset = 10;
        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }
    public class FilterConvolution
    {
        public const short EDGE_DETECT_KIRSH = 1;
        public const short EDGE_DETECT_PREWITT = 2;
        public const short EDGE_DETECT_SOBEL = 3;

        public static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;


            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((p[2] * m.TopLeft) + (p[5] * m.TopMid) + (p[8] * m.TopRight) +
                            (p[2 + stride] * m.MidLeft) + (p[5 + stride] * m.Pixel) + (p[8 + stride] * m.MidRight) +
                            (p[2 + stride2] * m.BottomLeft) + (p[5 + stride2] * m.BottomMid) + (p[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((p[1] * m.TopLeft) + (p[4] * m.TopMid) + (p[7] * m.TopRight) +
                            (p[1 + stride] * m.MidLeft) + (p[4 + stride] * m.Pixel) + (p[7 + stride] * m.MidRight) +
                            (p[1 + stride2] * m.BottomLeft) + (p[4 + stride2] * m.BottomMid) + (p[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((p[0] * m.TopLeft) + (p[3] * m.TopMid) + (p[6] * m.TopRight) +
                            (p[0 + stride] * m.MidLeft) + (p[3 + stride] * m.Pixel) + (p[6 + stride] * m.MidRight) +
                            (p[0 + stride2] * m.BottomLeft) + (p[3 + stride2] * m.BottomMid) + (p[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            return true;
        }
        public static bool Conv3x3Inplace(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
        public static bool Conv5x5Inplace(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopLeft) + (pSrc[8] * m.TopMid) + (pSrc[11] * m.TopMid) + (pSrc[14] * m.TopRight) +
                            (pSrc[2 + stride] * m.TopLeft) + (pSrc[5+stride] * m.TopLeft) + (pSrc[8+stride] * m.TopMid) + (pSrc[11+stride] * m.TopRight) + (pSrc[14+stride] * m.TopRight) +
                            (pSrc[2 + stride2] * m.MidLeft) + (pSrc[5 + stride2] * m.MidLeft) + (pSrc[8 + stride2] * m.Pixel) + (pSrc[11 + stride2] * m.MidRight) + (pSrc[14 + stride2] * m.MidRight) +
                            (pSrc[2 + stride3] * m.BottomLeft) + (pSrc[5 + stride3] * m.BottomLeft) + (pSrc[8 + stride3] * m.BottomMid) + (pSrc[11 + stride3] * m.BottomRight) + (pSrc[14 + stride3] * m.MidRight) +
                            (pSrc[2 + stride4] * m.BottomLeft) + (pSrc[5 + stride4] * m.BottomMid) + (pSrc[8 + stride4] * m.BottomMid) + (pSrc[11 + stride4] * m.BottomRight) + (pSrc[14 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[8 + stride2] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopLeft) + (pSrc[7] * m.TopMid) + (pSrc[10] * m.TopMid) + (pSrc[13] * m.TopRight) +
                           (pSrc[1 + stride] * m.TopLeft) + (pSrc[4 + stride] * m.TopLeft) + (pSrc[7 + stride] * m.TopMid) + (pSrc[10 + stride] * m.TopRight) + (pSrc[13 + stride] * m.TopRight) +
                           (pSrc[1 + stride2] * m.MidLeft) + (pSrc[4 + stride2] * m.MidLeft) + (pSrc[7 + stride2] * m.Pixel) + (pSrc[10 + stride2] * m.MidRight) + (pSrc[13 + stride2] * m.MidRight) +
                           (pSrc[1 + stride3] * m.BottomLeft) + (pSrc[4 + stride3] * m.BottomLeft) + (pSrc[7 + stride3] * m.BottomMid) + (pSrc[10 + stride3] * m.BottomRight) + (pSrc[13 + stride3] * m.MidRight) +
                           (pSrc[1 + stride4] * m.BottomLeft) + (pSrc[4 + stride4] * m.BottomMid) + (pSrc[7 + stride4] * m.BottomMid) + (pSrc[10 + stride4] * m.BottomRight) + (pSrc[13 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);
                        
                       

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[7 + stride2] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopLeft) + (pSrc[6] * m.TopMid) + (pSrc[9] * m.TopMid) + (pSrc[12] * m.TopRight) +
                           (pSrc[0 + stride] * m.TopLeft) + (pSrc[3 + stride] * m.TopLeft) + (pSrc[6 + stride] * m.TopMid) + (pSrc[9+ stride] * m.TopRight) + (pSrc[12 + stride] * m.TopRight) +
                           (pSrc[0 + stride2] * m.MidLeft) + (pSrc[3 + stride2] * m.MidLeft) + (pSrc[6 + stride2] * m.Pixel) + (pSrc[9 + stride2] * m.MidRight) + (pSrc[12 + stride2] * m.MidRight) +
                           (pSrc[0 + stride3] * m.BottomLeft) + (pSrc[3 + stride3] * m.BottomLeft) + (pSrc[6 + stride3] * m.BottomMid) + (pSrc[9 + stride3] * m.BottomRight) + (pSrc[12 + stride3] * m.MidRight) +
                           (pSrc[0 + stride4] * m.BottomLeft) + (pSrc[3 + stride4] * m.BottomMid) + (pSrc[6 + stride4] * m.BottomMid) + (pSrc[9+ stride4] * m.BottomRight) + (pSrc[12 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);
                      
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[6 + stride2] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
        public static bool Conv5x5(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((p[2] * m.TopLeft) + (p[5] * m.TopLeft) + (p[8] * m.TopMid) + (p[11] * m.TopMid) + (p[14] * m.TopRight) +
                            (p[2 + stride] * m.TopLeft) + (p[5 + stride] * m.TopLeft) + (p[8 + stride] * m.TopMid) + (p[11 + stride] * m.TopRight) + (p[14 + stride] * m.TopRight) +
                            (p[2 + stride2] * m.MidLeft) + (p[5 + stride2] * m.MidLeft) + (p[8 + stride2] * m.Pixel) + (p[11 + stride2] * m.MidRight) + (p[14 + stride2] * m.MidRight) +
                            (p[2 + stride3] * m.BottomLeft) + (p[5 + stride3] * m.BottomLeft) + (p[8 + stride3] * m.BottomMid) + (p[11 + stride3] * m.BottomRight) + (p[14 + stride3] * m.MidRight) +
                            (p[2 + stride4] * m.BottomLeft) + (p[5 + stride4] * m.BottomMid) + (p[8 + stride4] * m.BottomMid) + (p[11 + stride4] * m.BottomRight) + (p[14 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[8 + stride2] = (byte)nPixel;

                        nPixel = ((((p[1] * m.TopLeft) + (p[4] * m.TopLeft) + (p[7] * m.TopMid) + (p[10] * m.TopMid) + (p[13] * m.TopRight) +
                           (p[1 + stride] * m.TopLeft) + (p[4 + stride] * m.TopLeft) + (p[7 + stride] * m.TopMid) + (p[10 + stride] * m.TopRight) + (p[13 + stride] * m.TopRight) +
                           (p[1 + stride2] * m.MidLeft) + (p[4 + stride2] * m.MidLeft) + (p[7 + stride2] * m.Pixel) + (p[10 + stride2] * m.MidRight) + (p[13 + stride2] * m.MidRight) +
                           (p[1 + stride3] * m.BottomLeft) + (p[4 + stride3] * m.BottomLeft) + (p[7 + stride3] * m.BottomMid) + (p[10 + stride3] * m.BottomRight) + (p[13 + stride3] * m.MidRight) +
                           (p[1 + stride4] * m.BottomLeft) + (p[4 + stride4] * m.BottomMid) + (p[7 + stride4] * m.BottomMid) + (p[10 + stride4] * m.BottomRight) + (p[13 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[7 + stride2] = (byte)nPixel;

                        nPixel = ((((p[0] * m.TopLeft) + (p[3] * m.TopLeft) + (p[6] * m.TopMid) + (p[9] * m.TopMid) + (p[12] * m.TopRight) +
                           (p[0 + stride] * m.TopLeft) + (p[3 + stride] * m.TopLeft) + (p[6 + stride] * m.TopMid) + (p[9 + stride] * m.TopRight) + (p[12 + stride] * m.TopRight) +
                           (p[0 + stride2] * m.MidLeft) + (p[3 + stride2] * m.MidLeft) + (p[6 + stride2] * m.Pixel) + (p[9 + stride2] * m.MidRight) + (p[12 + stride2] * m.MidRight) +
                           (p[0 + stride3] * m.BottomLeft)  + (p[3 + stride3] * m.BottomLeft) + (p[6 + stride3] * m.BottomMid) + (p[9 + stride3] * m.BottomRight) + (p[12 + stride3] * m.MidRight) +
                           (p[0 + stride4] * m.BottomLeft) + (p[3 + stride4] * m.BottomMid) + (p[6 + stride4] * m.BottomMid) + (p[9 + stride4] * m.BottomRight) + (p[12 + stride4] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[6 + stride2] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
        public static bool Conv7x7Inplace(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            int stride5 = stride * 4;
            int stride6 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopLeft) + (pSrc[8] * 0) + (pSrc[11] * m.TopMid) + (pSrc[14] * m.TopMid) + (pSrc[17] * 0) + (pSrc[20] * m.TopRight) +
                            (pSrc[2 + stride] * 0) + (pSrc[5 + stride] * m.TopLeft) + (pSrc[8 + stride] * m.TopLeft) + (pSrc[11 + stride] * m.TopMid) + (pSrc[14 + stride] * m.TopMid) + (pSrc[17+stride] * m.TopRight) + (pSrc[20+stride] * m.TopRight) +
                            (pSrc[2 + stride2] * m.MidLeft) + (pSrc[5 + stride2] * m.MidLeft) + (pSrc[8 + stride2] * m.TopLeft) + (pSrc[11 + stride2] * m.TopMid) + (pSrc[14 + stride2] * m.TopRight) + (pSrc[17+stride2] * m.TopRight) + (pSrc[20+stride2] * 0) +
                            (pSrc[2 + stride3] * m.MidLeft) + (pSrc[5 + stride3] * m.MidLeft) + (pSrc[8 + stride3] * m.MidLeft) + (pSrc[11 + stride3] * m.Pixel) + (pSrc[14 + stride3] * m.MidRight) + (pSrc[17 + stride3] * m.MidRight) + (pSrc[20 + stride3] * m.MidRight) +
                            (pSrc[2 + stride4] * 0) + (pSrc[5 + stride4] * m.BottomLeft) + (pSrc[8 + stride4] * m.BottomLeft) + (pSrc[11 + stride4] * m.BottomMid) + (pSrc[14 + stride4] * m.BottomRight) + (pSrc[17 + stride4] * m.BottomRight) + (pSrc[20 + stride4] * m.BottomRight) +
                            (pSrc[2 + stride5] * m.BottomLeft) + (pSrc[5 + stride5] * m.BottomLeft) + (pSrc[8 + stride5] * m.BottomMid) + (pSrc[11 + stride5] * m.BottomMid) + (pSrc[14 + stride5] * m.BottomRight) + (pSrc[17 + stride5] * m.BottomRight) + (pSrc[20 + stride5] *0) +
                            (pSrc[2 + stride6] * m.BottomLeft) + (pSrc[5 + stride6] * 0) + (pSrc[8 + stride6] * m.BottomMid) + (pSrc[11 + stride6] * m.BottomMid) + (pSrc[14 + stride6] * 0) + (pSrc[17 + stride6] * m.BottomRight) + (pSrc[20 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[11 + stride3] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopLeft) + (pSrc[7] * 0) + (pSrc[10] * m.TopMid) + (pSrc[13] * m.TopMid) + (pSrc[16] * 0) + (pSrc[19] * m.TopRight) +
                                                  (pSrc[1 + stride] * 0) + (pSrc[4 + stride] * m.TopLeft) + (pSrc[7 + stride] * m.TopLeft) + (pSrc[10 + stride] * m.TopMid) + (pSrc[13 + stride] * m.TopMid) + (pSrc[16+ stride] * m.TopRight) + (pSrc[19 + stride] * m.TopRight) +
                                                  (pSrc[1 + stride2] * m.MidLeft) + (pSrc[4 + stride2] * m.MidLeft) + (pSrc[7 + stride2] * m.TopLeft) + (pSrc[10 + stride2] * m.TopMid) + (pSrc[13 + stride2] * m.TopRight) + (pSrc[16 + stride2] * m.TopRight) + (pSrc[19 + stride2] * 0) +
                                                  (pSrc[1 + stride3] * m.MidLeft) + (pSrc[4 + stride3] * m.MidLeft) + (pSrc[7 + stride3] * m.MidLeft) + (pSrc[10 + stride3] * m.Pixel) + (pSrc[13 + stride3] * m.MidRight) + (pSrc[16 + stride3] * m.MidRight) + (pSrc[19 + stride3] * m.MidRight) +
                                                  (pSrc[1 + stride4] * 0) + (pSrc[4 + stride4] * m.BottomLeft) + (pSrc[7 + stride4] * m.BottomLeft) + (pSrc[10 + stride4] * m.BottomMid) + (pSrc[13 + stride4] * m.BottomRight) + (pSrc[16 + stride4] * m.BottomRight) + (pSrc[19 + stride4] * m.BottomRight) +
                                                  (pSrc[1 + stride5] * m.BottomLeft) + (pSrc[4 + stride5] * m.BottomLeft) + (pSrc[7 + stride5] * m.BottomMid) + (pSrc[10 + stride5] * m.BottomMid) + (pSrc[13 + stride5] * m.BottomRight) + (pSrc[16 + stride5] * m.BottomRight) + (pSrc[19 + stride5] * 0) +
                                                  (pSrc[1 + stride6] * m.BottomLeft) + (pSrc[4 + stride6] * 0) + (pSrc[7 + stride6] * m.BottomMid) + (pSrc[10 + stride6] * m.BottomMid) + (pSrc[13 + stride6] * 0) + (pSrc[16 + stride6] * m.BottomRight) + (pSrc[19 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[10 + stride3] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopLeft) + (pSrc[6] * 0) + (pSrc[9] * m.TopMid) + (pSrc[12] * m.TopMid) + (pSrc[15] * 0) + (pSrc[18] * m.TopRight) +
                            (pSrc[0 + stride] * 0) + (pSrc[3 + stride] * m.TopLeft) + (pSrc[6 + stride] * m.TopLeft) + (pSrc[9 + stride] * m.TopMid) + (pSrc[12 + stride] * m.TopMid) + (pSrc[15 + stride] * m.TopRight) + (pSrc[18 + stride] * m.TopRight) +
                            (pSrc[0 + stride2] * m.MidLeft) + (pSrc[3 + stride2] * m.MidLeft) + (pSrc[6 + stride2] * m.TopLeft) + (pSrc[9 + stride2] * m.TopMid) + (pSrc[12 + stride2] * m.TopRight) + (pSrc[15 + stride2] * m.TopRight) + (pSrc[18 + stride2] * 0) +
                            (pSrc[0 + stride3] * m.MidLeft) + (pSrc[3 + stride3] * m.MidLeft) + (pSrc[6 + stride3] * m.MidLeft) + (pSrc[9 + stride3] * m.Pixel) + (pSrc[12 + stride3] * m.MidRight) + (pSrc[15 + stride3] * m.MidRight) + (pSrc[18 + stride3] * m.MidRight) +
                            (pSrc[0 + stride4] * 0) + (pSrc[3 + stride4] * m.BottomLeft) + (pSrc[6 + stride4] * m.BottomLeft) + (pSrc[9 + stride4] * m.BottomMid) + (pSrc[12 + stride4] * m.BottomRight) + (pSrc[15 + stride4] * m.BottomRight) + (pSrc[18 + stride4] * m.BottomRight) +
                            (pSrc[0 + stride5] * m.BottomLeft) + (pSrc[3 + stride5] * m.BottomLeft) + (pSrc[6 + stride5] * m.BottomMid) + (pSrc[9 + stride5] * m.BottomMid) + (pSrc[12 + stride5] * m.BottomRight) + (pSrc[15 + stride5] * m.BottomRight) + (pSrc[18 + stride5] * 0) +
                            (pSrc[0 + stride6] * m.BottomLeft) + (pSrc[3 + stride6] * 0) + (pSrc[6 + stride6] * m.BottomMid) + (pSrc[9 + stride6] * m.BottomMid) + (pSrc[12 + stride6] * 0) + (pSrc[15 + stride6] * m.BottomRight) + (pSrc[18 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[9 + stride3] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
        public static bool Conv7x7(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            int stride3 = stride * 3;
            int stride4 = stride * 4;
            int stride5 = stride * 4;
            int stride6 = stride * 4;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((p[2] * m.TopLeft) + (p[5] * m.TopLeft) + (p[8] * 0) + (p[11] * m.TopMid) + (p[14] * m.TopMid) + (p[17] * 0) + (p[20] * m.TopRight) +
                            (p[2 + stride] * 0) + (p[5 + stride] * m.TopLeft) + (p[8 + stride] * m.TopLeft) + (p[11 + stride] * m.TopMid) + (p[14 + stride] * m.TopMid) + (p[17 + stride] * m.TopRight) + (p[20 + stride] * m.TopRight) +
                            (p[2 + stride2] * m.MidLeft) + (p[5 + stride2] * m.MidLeft) + (p[8 + stride2] * m.TopLeft) + (p[11 + stride2] * m.TopMid) + (p[14 + stride2] * m.TopRight) + (p[17 + stride2] * m.TopRight) + (p[20 + stride2] * 0) +
                            (p[2 + stride3] * m.MidLeft) + (p[5 + stride3] * m.MidLeft) + (p[8 + stride3] * m.MidLeft) + (p[11 + stride3] * m.Pixel) + (p[14 + stride3] * m.MidRight) + (p[17 + stride3] * m.MidRight) + (p[20 + stride3] * m.MidRight) +
                            (p[2 + stride4] * 0) + (p[5 + stride4] * m.BottomLeft) + (p[8 + stride4] * m.BottomLeft) + (p[11 + stride4] * m.BottomMid) + (p[14 + stride4] * m.BottomRight) + (p[17 + stride4] * m.BottomRight) + (p[20 + stride4] * m.BottomRight) +
                            (p[2 + stride5] * m.BottomLeft) + (p[5 + stride5] * m.BottomLeft) + (p[8 + stride5] * m.BottomMid) + (p[11 + stride5] * m.BottomMid) + (p[14 + stride5] * m.BottomRight) + (p[17 + stride5] * m.BottomRight) + (p[20 + stride5] * 0) +
                            (p[2 + stride6] * m.BottomLeft) + (p[5 + stride6] * 0) + (p[8 + stride6] * m.BottomMid) + (p[11 + stride6] * m.BottomMid) + (p[14 + stride6] * 0) + (p[17 + stride6] * m.BottomRight) + (p[20 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[11 + stride3] = (byte)nPixel;

                        nPixel = ((((p[1] * m.TopLeft) + (p[4] * m.TopLeft) + (p[7] * 0) + (p[10] * m.TopMid) + (p[13] * m.TopMid) + (p[16] * 0) + (p[19] * m.TopRight) +
                                                  (p[1 + stride] * 0) + (p[4 + stride] * m.TopLeft) + (p[7 + stride] * m.TopLeft) + (p[10 + stride] * m.TopMid) + (p[13 + stride] * m.TopMid) + (p[16 + stride] * m.TopRight) + (p[19 + stride] * m.TopRight) +
                                                  (p[1 + stride2] * m.MidLeft) + (p[4 + stride2] * m.MidLeft) + (p[7 + stride2] * m.TopLeft) + (p[10 + stride2] * m.TopMid) + (p[13 + stride2] * m.TopRight) + (p[16 + stride2] * m.TopRight) + (p[19 + stride2] * 0) +
                                                  (p[1 + stride3] * m.MidLeft) + (p[4 + stride3] * m.MidLeft) + (p[7 + stride3] * m.MidLeft) + (p[10 + stride3] * m.Pixel) + (p[13 + stride3] * m.MidRight) + (p[16 + stride3] * m.MidRight) + (p[19 + stride3] * m.MidRight) +
                                                  (p[1 + stride4] * 0) + (p[4 + stride4] * m.BottomLeft) + (p[7 + stride4] * m.BottomLeft) + (p[10 + stride4] * m.BottomMid) + (p[13 + stride4] * m.BottomRight) + (p[16 + stride4] * m.BottomRight) + (p[19 + stride4] * m.BottomRight) +
                                                  (p[1 + stride5] * m.BottomLeft) + (p[4 + stride5] * m.BottomLeft) + (p[7 + stride5] * m.BottomMid) + (p[10 + stride5] * m.BottomMid) + (p[13 + stride5] * m.BottomRight) + (p[16 + stride5] * m.BottomRight) + (p[19 + stride5] * 0) +
                                                  (p[1 + stride6] * m.BottomLeft) + (p[4 + stride6] * 0) + (p[7 + stride6] * m.BottomMid) + (p[10 + stride6] * m.BottomMid) + (p[13 + stride6] * 0) + (p[16 + stride6] * m.BottomRight) + (p[19 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);



                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[10 + stride3] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopLeft) + (pSrc[6] * 0) + (pSrc[9] * m.TopMid) + (pSrc[12] * m.TopMid) + (pSrc[15] * 0) + (pSrc[18] * m.TopRight) +
                            (pSrc[0 + stride] * 0) + (pSrc[3 + stride] * m.TopLeft) + (pSrc[6 + stride] * m.TopLeft) + (pSrc[9 + stride] * m.TopMid) + (pSrc[12 + stride] * m.TopMid) + (pSrc[15 + stride] * m.TopRight) + (pSrc[18 + stride] * m.TopRight) +
                            (pSrc[0 + stride2] * m.MidLeft) + (pSrc[3 + stride2] * m.MidLeft) + (pSrc[6 + stride2] * m.TopLeft) + (pSrc[9 + stride2] * m.TopMid) + (pSrc[12 + stride2] * m.TopRight) + (pSrc[15 + stride2] * m.TopRight) + (pSrc[18 + stride2] * 0) +
                            (pSrc[0 + stride3] * m.MidLeft) + (pSrc[3 + stride3] * m.MidLeft) + (pSrc[6 + stride3] * m.MidLeft) + (pSrc[9 + stride3] * m.Pixel) + (pSrc[12 + stride3] * m.MidRight) + (pSrc[15 + stride3] * m.MidRight) + (pSrc[18 + stride3] * m.MidRight) +
                            (pSrc[0 + stride4] * 0) + (pSrc[3 + stride4] * m.BottomLeft) + (pSrc[6 + stride4] * m.BottomLeft) + (pSrc[9 + stride4] * m.BottomMid) + (pSrc[12 + stride4] * m.BottomRight) + (pSrc[15 + stride4] * m.BottomRight) + (pSrc[18 + stride4] * m.BottomRight) +
                            (pSrc[0 + stride5] * m.BottomLeft) + (pSrc[3 + stride5] * m.BottomLeft) + (pSrc[6 + stride5] * m.BottomMid) + (pSrc[9 + stride5] * m.BottomMid) + (pSrc[12 + stride5] * m.BottomRight) + (pSrc[15 + stride5] * m.BottomRight) + (pSrc[18 + stride5] * 0) +
                            (pSrc[0 + stride6] * m.BottomLeft) + (pSrc[3 + stride6] * 0) + (pSrc[6 + stride6] * m.BottomMid) + (pSrc[9 + stride6] * m.BottomMid) + (pSrc[12 + stride6] * 0) + (pSrc[15 + stride6] * m.BottomRight) + (pSrc[18 + stride6] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[9 + stride3] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }
        public static bool Smooth(Bitmap b1,Bitmap b2,Bitmap b3, int nWeight,bool k)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;
            if (k)
            {
                FilterConvolution.Conv3x3(b1, m);
                FilterConvolution.Conv5x5(b2, m);
                return FilterConvolution.Conv7x7(b3, m);
            }
            else {
                FilterConvolution.Conv3x3Inplace(b1, m);
                FilterConvolution.Conv5x5Inplace(b2, m);
                return FilterConvolution.Conv7x7Inplace(b3, m); }
        }
        public static bool EdgeDetectVertical(Bitmap b)
        {
            Bitmap bmTemp = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmData2 = bmTemp.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr Scan02 = bmData2.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* p2 = (byte*)(void*)Scan02;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                int nPixel = 0;

                int nStride2 = stride * 2;
                int nStride3 = stride * 3;

                p += nStride3;
                p2 += nStride3;

                for (int y = 3; y < b.Height - 3; ++y)
                {
                    p += 3;
                    p2 += 3;

                    for (int x = 3; x < nWidth - 3; ++x)
                    {
                        nPixel = ((p2 + nStride3 + 3)[0] +
                            (p2 + nStride2 + 3)[0] +
                            (p2 + stride + 3)[0] +
                            (p2 + 3)[0] +
                            (p2 - stride + 3)[0] +
                            (p2 - nStride2 + 3)[0] +
                            (p2 - nStride3 + 3)[0] -
                            (p2 + nStride3 - 3)[0] -
                            (p2 + nStride2 - 3)[0] -
                            (p2 + stride - 3)[0] -
                            (p2 - 3)[0] -
                            (p2 - stride - 3)[0] -
                            (p2 - nStride2 - 3)[0] -
                            (p2 - nStride3 - 3)[0]);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[0] = (byte)nPixel;

                        ++p;
                        ++p2;
                    }

                    p += 3 + nOffset;
                    p2 += 3 + nOffset;
                }
            }

            b.UnlockBits(bmData);
            bmTemp.UnlockBits(bmData2);

            return true;
        }
    }
}
