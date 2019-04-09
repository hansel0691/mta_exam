using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Data;

namespace DataStructures.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(screening.GetColumnName(729));
            //Console.WriteLine(CheckPalindromeCombination("civil"));

            //var tree = new BinaryTreeNode<int>(8, new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(1), new BinaryTreeNode<int>(6, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(7))), new BinaryTreeNode<int>(10, null, new BinaryTreeNode<int>(14, new BinaryTreeNode<int>(13))));
            //var tree = new BinaryTreeNode<int>(0, new BinaryTreeNode<int>(-1, new BinaryTreeNode<int>(-2, new BinaryTreeNode<int>(-3), null), null), new BinaryTreeNode<int>(1, new BinaryTreeNode<int>(2, null, new BinaryTreeNode<int>(0))));
            //Console.WriteLine(IsSuperBalanced(tree));
            //Console.WriteLine(LargeFactorial(100));

            //Console.WriteLine(String.Join("\n", NonDivisionalSubset(new[] { 1, 7, 2, 4 }, 3)));

            //Console.WriteLine(TimeConversion("11:17:20PM"));
            //var a = "baknxginokekuemgb";
            //Console.WriteLine(a);
            //foreach (var m in a)
            //{
            //    Console.Write($"{(int)m} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(BiggerIsGreater("gqesmwwfyyuraiwzhdkyvtzprhxzfaocdyxryzpqyewfufkspwvpgyscviersewdcgudhjxnfximarbkgduam"));

            //var input = new System.IO.StreamReader(@"c:\input");
            //var output = new System.IO.StreamReader(@"c:\output");
            //string line;

            //Console.WriteLine(input.ReadLine());
            //while ((line = input.ReadLine()) != null)
            //{
            //    if (BiggerIsGreater(line) != output.ReadLine())
            //        Console.WriteLine(line);
            //}


            //Console.WriteLine(ElectronicShop(7, new[] { 5}, new[] { 5, 2, 8}));

            //Console.WriteLine(QueenAttack(5, 8, 3, 3, new []{ new[] { 5, 1}, new[] { 5, 3}, new[] { 5, 5}, new[] { 3, 5 }, new[] { 1, 5 }, new[] { 1, 3 }, new[] { 1, 1 }}));



            /*Console.WriteLine(OrganizingContainers(new int[][]{
                new int[] {850352964, 977596446, 949048147, 948864413, 583894071, 690057713, 997747480, 989967717},
                new int[] {989808562, 768213277, 465807106, 806209383, 997601076, 726063750, 886274860, 999745463},
                new int[] {999716184, 614327240, 646233100, 701848586, 996640233, 637114525, 979053522, 973751653},
                new int[] {729579413, 623758391, 789451199, 998061161, 915515002, 887943421, 667982910, 663066401},
                new int[] {625660022, 983861176, 747822232, 924237583, 765182731, 879961473, 915988053, 973592376},
                new int[] {978486425, 911982749, 995853966, 373364101, 706580937, 995621049, 869416897, 906988203},
                new int[] {996021364, 982486194, 880450667, 971761433, 779568692, 990258135, 985311146, 547004947},
                new int[] {963237644, 954080173, 997900896, 551011238, 803702301, 931274261, 685754083, 585606717}
            }));*/

            //Console.WriteLine(AppearsOnce(new[] { 10,2, 3, 4,4, 3, 2,2, 3, 4}, 3));

            //var a = new LinkedNode<int>(1);
            //a.Next = new LinkedNode<int>(2) { Next = new LinkedNode<int>(3) { Next = a}  };
            //Console.WriteLine(ContainsCycle(a));


            //var a = GirlScoutCookies(new[] { 3, 4, 6, 10, 11, 15 }, new[] { 1, 5, 8, 12, 14, 19 });
            //Console.WriteLine(String.Join(" ", a));


            //var sum = AddLinkedList(new LinkedNode<int>(5) { Next = new LinkedNode<int>(6) { Next = new LinkedNode<int>(3) } },
            //                        new LinkedNode<int>(8) { Next = new LinkedNode<int>(4) { Next = new LinkedNode<int>(2) } });
            //while (sum.Next != null)
            //{
            //    Console.WriteLine(sum.Value);
            //    sum.Next = sum.Next.Next;
            //}

            // var a = new[] { 73, 67, 38, 33 };
            // var result = GradingStudents(a);
            // Console.WriteLine(string.Join(" ", result));


            // var list = new List<int>() { 1, 2, 3, 4};
            // var result = ArrangeSet<int>.QuickSort(list);

            // Console.WriteLine(String.Join(" ", result));

            var rectangle = new Rectangle(10, 5);
            rectangle.Changed += (r, e) => {
                Rectangle rect = r as Rectangle;
                Console.WriteLine($"Value Changed: Length = {rect.Length}" );
            };
            rectangle.Length = 5;
        }

        public delegate void RectangleHandler(Rectangle r);

        public class Rectangle
        {
            private double length;
            
            public Rectangle(double length, double width)
            {
                this.length = length;
                this.Width = width;
            }

            public double Length { 
                get {return this.length;} 
                set
                { 
                    if (value >= 0 && value != this.length)
                    {
                        this.length = value;
                        this.Changed(this, EventArgs.Empty);
                    }
                } 
            }
            public event EventHandler Changed;
            public double Width { get; set; }

        }
    }
}
