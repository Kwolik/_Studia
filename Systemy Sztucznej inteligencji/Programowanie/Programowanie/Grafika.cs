using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Programowanie
{
    class Grafika
    {
        Bitmap btmp;

        public int[,,] Macierz(string input)
        {
            Console.WriteLine("Matrix");

            List<string> lista = new List<string>();

            btmp = new Bitmap(input);
            int[,,] matrix = new int[btmp.Width, btmp.Height, 3];
            
            for (int x = 0; x < btmp.Width; x++)
            {
                for (int y = 0; y < btmp.Height; y++)
                {
                    Color pixelColor = btmp.GetPixel(x, y);
                    matrix[x, y, 0] = pixelColor.R;
                    matrix[x, y, 1] = pixelColor.G;
                    matrix[x, y, 2] = pixelColor.B;
                    //Console.Write("[{0},{0},{0}]", matrix[x, y, 0], matrix[x, y, 1], matrix[x, y, 2]);
                    //lista.Add(String.Format("{0}{0}{0}", matrix[x, y, 0], matrix[x, y, 1], matrix[x, y, 2]));

                }
                //Console.WriteLine();
                //lista.Add("\n");
            }

            //using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter("gaus.txt"))
            //{
            //    foreach (string line in lista)
            //    {

            //     file.Write(line);
                    
            //    }
            //}


            return matrix;
        }

        public int [,] Filtr_Gauss()
        {
            int[,] g = new int[5, 5] {
                { 1, 1, 2, 1, 1 },
                { 1, 2, 4, 2, 1 },
                { 2, 4, 8, 4, 2 },
                { 1, 2, 4, 2, 1 },
                { 1, 1, 2, 1, 1 }
            };
            return g;
        }
        public int[,] Filtr_Sharp()
        {
            int[,] g = new int[3, 3] {
                { 0, -1, 0 },
                {-1, 5, -1 },
                { 0, -1, 0 }
            };
            return g;
        }
        public int[,] Filtr_Blur()
        {
            int[,] g = new int[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            return g;
        }


        public void Filtr(int[,,] matrix, int [,] g, string name)
        {
            Console.WriteLine(name + " Filtr");
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);

            int[,,] newMatrix = new int[x, y, 3];

            int Sum = 0;
            for (int i = 0; i < g.GetLength(0); i++)
                for (int j = 0; j < g.GetLength(1); j++)
                    Sum += g[i, j];

            int xlen = g.GetLength(0);
            int ylen = g.GetLength(1);

            for (int i = xlen -2 ; i < x - (xlen - 2); i++)
            {
                for (int j = ylen - 2; j < y - (ylen - 2); j++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        for (int k = 0; k < xlen; k++)
                        {
                            for (int l = 0; l < ylen; l++)
                            {
                                newMatrix[i,j,c] += g[k, l] * matrix[i + xlen - 2 - k, j + ylen - 2 - l, c] / Sum;
                            }
                        }
                        //newMatrix[i, j, c] %= 255;
                        if (newMatrix[i, j, c] < 0)
                            newMatrix[i, j, c] = 0;
                        if (newMatrix[i, j, c] > 255)
                            newMatrix[i, j, c] = 255;

                    }
                    btmp.SetPixel(i, j, Color.FromArgb(newMatrix[i, j, 0], newMatrix[i, j, 1], newMatrix[i, j, 2]));
                }
            }
            //Console.WriteLine("\n\n\n");
            //for (int i = 0; i < x; i++)
            //{
            //    for (int j = 0; j < y; j++)
            //    {
            //        Console.Write("[" + newMatrix[i, j, 0] + "," + newMatrix[i, j, 1] + "," + newMatrix[i, j, 2] + "]");
            //    }
            //    Console.WriteLine();
            //}
            
            name = Path.GetFileNameWithoutExtension(name);
            btmp.Save(name + ".png");
            
        }
    }
}
