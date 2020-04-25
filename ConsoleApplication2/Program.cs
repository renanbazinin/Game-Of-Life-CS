using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
      
        public static bool CellNextGenAlive(Cell[,] arrayCells,Cell nowCell){

            int Heigth = arrayCells.GetLength(0);
            int Width = arrayCells.GetLength(1);
            
            int x = nowCell.GetRow();
            int y = nowCell.GetCol();

            int counter = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width)) && !(i==x && j== y))
                    {
                        if (arrayCells[i, j].IsAlive())
                            counter++;
                    }
                }
            }

            if (nowCell.IsAlive())
            {
                if (counter < 2 || counter > 3)
                    return false;
                else
                    return true;
            }

            if (!nowCell.IsAlive())
                if (counter == 3)
                    return true;

            return false;
        }

        public static Cell[,] CopyArray(Cell[,] arrayCells)
        {
            Cell[,] copyArray = new Cell[arrayCells.GetLength(0), arrayCells.GetLength(1)];
            for (int i = 0; i < arrayCells.GetLength(0); i++)
                for (int j = 0; j < arrayCells.GetLength(1); j++)
                    copyArray[i,j] = new Cell(arrayCells[i,j].IsAlive(), i, j);


            return copyArray;
        }

        public static Cell[,] RunningGen(Cell[,] arrayCells)
        {
            Cell[,] nextGenArray = CopyArray(arrayCells);
            
            for (int i = 0; i < arrayCells.GetLength(0); i++)
            {
                for (int j = 0; j < arrayCells.GetLength(1); j++)
                {
                    nextGenArray[i,j].SetNewStatus(CellNextGenAlive(arrayCells, arrayCells[i,j])); // Making the next gen stattus
                    if (!arrayCells[i, j].IsAlive()) // Making currnet gen
                        Console.Write("■");
                    else
                        Console.Write("X");

                }
                Console.Write("\n");
            }

            return nextGenArray;
        }


      
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("What is the number of rows that you want?");
            int Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the number of colmuns that you want?");
            int Width = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Cell[,] arrayCells = new Cell[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {

                    arrayCells[i, j] = new Cell(false, i, j);
                }

            }


            bool flag = true;
            int rowDead;
            int colDead;

            while (flag)
            {
                Console.WriteLine("Row of Alive cell ?");
                rowDead = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Col of Alive cell ?");
                colDead = Convert.ToInt32(Console.ReadLine());
                arrayCells[rowDead-1, colDead-1].Resurrect();
                Console.WriteLine("do you finish ?  y/n");
                str = Console.ReadLine(); 
                if (str == "y" || str == "yes")
                    flag = false;
                
            }

            Console.Clear();



            //running for 100 gens
            for (int i = 0; i < 100; i++)
            {

                arrayCells=RunningGen(arrayCells); // running the next gen and returning new cell arrays
                Thread.Sleep(750);
                Console.Clear();
            }





            Console.SetCursorPosition(Width + 2, Height + 2);
            Console.Write("\n"); // Press any key to contiue annoy me
            
        }
    }
}
