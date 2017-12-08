using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeParams = GetTreeParameters();
           
            SetTheMood();

            DrawTheTree(treeParams.Leaf, treeParams.Stump, treeParams.Bauble, treeParams.Height);

            Console.ReadLine();
        }

        private static TreeParameters GetTreeParameters()
        {
            Console.WriteLine("Press the key you'd like to represent a leaf:");
            var leafChar = Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Press the key you'd like to represent the stump:");
            var stumpChar = Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Press the key you'd like to represent the shape of your baubles:");
            var baubleChar = Console.ReadKey();
            Console.Clear();
            Console.WriteLine("How big should the tree be? (type a number and hit enter)");
            var treeHeight = Console.ReadLine();
            Console.Clear();

            return new TreeParameters(leafChar.KeyChar, stumpChar.KeyChar, baubleChar.KeyChar, Convert.ToInt32(treeHeight));
        }

        private static void SetTheMood()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sp = new SoundPlayer();
            sp.SoundLocation = Environment.CurrentDirectory + "\\notxmasmusic.wav";
            sp.Play();
        }

        private static void DrawTheTree(char leafChar, char baubleChar, char stumpChar, int treeHeight)
        {
            var startRow = treeHeight;
            var largestLeafRowSize = (treeHeight - 1) * 2 - 1;
            var startColumn = largestLeafRowSize / 2 - 1;
            int leafLinesPrinted = 0;

            Console.SetCursorPosition(startColumn, startRow + 5);
            for (int i = startColumn; i < startColumn + 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(20);
                Console.Write(stumpChar);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Random rnd = new Random();
            for (int i = 0; i < treeHeight; i++)
            {
                Console.SetCursorPosition(leafLinesPrinted, Console.CursorTop - 1);
                leafLinesPrinted++;
                for (int j = largestLeafRowSize; j > 0; j--)
                {
                    Thread.Sleep(20);
                    int randomNo = rnd.Next(1, 15);
                    if (randomNo == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(baubleChar);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(leafChar);
                    }

                }
                largestLeafRowSize -= 2;
            }
        }
    }
}
