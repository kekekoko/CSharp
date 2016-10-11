using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitherImage
{
    class ImageProcessor
    {
        public static string dither(string inputFilePath)
        {
            Bitmap image = readImage(inputFilePath);
            Bitmap BWimage = convertToBW(image);
            string newFileName = inputFilePath.Insert(inputFilePath.LastIndexOf('.'), "BW");
            BWimage.Save(newFileName);
            return newFileName;
        }

        private static Bitmap readImage(string inputFilePath)
        {
            Bitmap image = new Bitmap(inputFilePath);
            return image;
        }

        private static Bitmap convertToBW(Bitmap originalImage)
        {
            Bitmap newImage = originalImage;
            int width = newImage.Width;
            int height = newImage.Height;
            float[,] currentPixels = new float[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    currentPixels[x, y] += newImage.GetPixel(x, y).ToArgb();
                    if (currentPixels[x, y] >= -8388607)
                    {
                        setNeighbors(x, y, true, ref currentPixels);
                        newImage.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        setNeighbors(x, y, false, ref currentPixels);
                        newImage.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return newImage;
        }

        private static void setNeighbors(int x, int y, bool isWhite, ref float[,] currentPixels)
        {
            int width = currentPixels.GetLength(0);
            int height = currentPixels.GetLength(1);
            
            float error;
            float currentPixelColor = currentPixels[x, y];
            if (isWhite)
            {
                error = currentPixelColor + 1;
            }
            else
            {
                error = currentPixelColor + 16777216;
            }

            if (x + 1 < width)
            {
                if (y + 1 < height)
                {
                    currentPixels[x + 1, y + 1] += error * 1 / 16;
                }
                currentPixels[x + 1, y] += error * 7 / 16;
            }
            if (y + 1 < height)
            {
                if (x - 1 >= 0)
                {
                    currentPixels[x - 1, y + 1] += error * 3 / 16;
                }
                currentPixels[x, y + 1] += error * 5 / 16;
            }
        }
    }
}


