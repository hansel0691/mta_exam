using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructures.UI
{

    public class Screening
    { 
        public static int[] GradingStudents(int[] grades)
        {
            var result = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                int nextMultiplier = ((int)(grades[i] / 5) + 1) * 5;
                result[i] = grades[i] < 38 || nextMultiplier - grades[i] >= 3 ? grades[i] : nextMultiplier;
            }
            return result;
        }

        public static string OrganizingContainers(int[][] containers)
        {
            for (int type = 0; type < containers.Length; type++)
            {
                //how many type balls are located in the wrong container
                //long wrongBalls = containers[type].Sum() - containers[type][type];
                long wrongBalls = 0;
                for (int column = 0; column < containers[type].Length; column++)
                    if (column != type)
                        wrongBalls += containers[type][column];

                //how many non type balls are in the container type 
                long outsideContainer = 0;
                for (int container = 0; container < containers[type].Length; container++)
                    if (container != type)
                        outsideContainer += containers[container][type];

                if (wrongBalls != outsideContainer)
                    return "Impossible";
            }

            return "Possible";

        }

        public static int MultiplicationExceptIndex(int[] numbers, int index)
        {
            int result = 1;
            int zeroAt = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                    if (zeroAt != -1)
                        return 0;
                    else
                        zeroAt = i;
                else
                    result *= numbers[i];
            }

            return index == zeroAt ? result : zeroAt != -1 ? 0 : result;
        }

        public static List<int> GirlScoutCookies(int[] first, int[] second)
        {
            var result = new List<int>();
            int i = 0, j = 0;

            while (i < first.Length && j < second.Length)
            {
                if (first[i] < second[j])
                    result.Add(first[i++]);
                else
                    result.Add(second[j++]);
            }

            if (i < first.Length)
                for (; i < first.Length; i++)
                    result.Add(first[i]);
            else if (j < second.Length)
                for (; j < second.Length; j++)
                    result.Add(second[j]);

            return result;
        }

        public static bool ContainsCycle(LinkedNode<int> node)
        {
            var fastRunner = node;
            var runner = node;

            while (fastRunner.Next != null && fastRunner.Next.Next != null)
            {
                if (runner.Next == fastRunner.Next.Next)
                    return true;

                runner = runner.Next;
                fastRunner = fastRunner.Next.Next;
            }

            return false;

            //var seen = new Dictionary<LinkedNode<int>, int>();

            //while(node.Next != null)
            //{
            //    if (seen.ContainsKey(node))
            //        return true;
            //    else
            //        seen.Add(node, 1);

            //    node = node.Next;
            //}

            //return false;
        }

        public static string BinaryRepresentation(int n)
        {
            throw new NotImplementedException();
        }


        //Check null values
        public static LinkedNode<int> AddLinkedList(LinkedNode<int> first, LinkedNode<int> second)
        {
            if (first.Next == null && second.Next == null)
                return new LinkedNode<int>(first.Value + second.Value);

            var tail = AddLinkedList(first?.Next, second?.Next);

            var result = new LinkedNode<int>(first.Value + second.Value + tail.Value / 10);
            tail.Value = tail.Value % 10;

            result.Next = tail;
            return result;
        }

        public static void DeleteNode(LinkedNode<int> node)
        {
            if (node.Next == null)
                throw new NotImplementedException();

            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
            node.Next = null;
            node.Value = 0;
        }

        public static void Sort(int[] elements)
        {
            int low = 0;
            int high = elements.Length - 1;

            Action<int[], int, int> swap = (arr, from, to) =>
            {
                var temp = arr[from];
                arr[from] = arr[to];
                arr[to] = temp;
            };

            for (int i = 0; i <= high; i++)
                if (elements[i] == 0)
                    swap(elements, low++, i);
                else if (elements[i] == 2)
                    swap(elements, i--, high--);
        }

        public static void PrintPattern(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine(n);
                return;
            }

            Console.WriteLine(n);

            PrintPattern(n - 5);

            Console.WriteLine(n);
        }

        public static int AppearsOnce(int[] elements, int times)
        {
            int result = 0;
            int INT_SIZE = 32;

            for (int i = 0; i < INT_SIZE; i++)
            {
                int sum = 0;
                var x = (1 << i);
                foreach (int number in elements)
                {
                    if ((number & x) == 0)
                        sum++;
                }

                if (sum % 3 == 0)
                    result |= x;
            }

            return result;
        }

        public static int QueenAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            var wClosest = new[] { r_q, 0 };
            var nClosest = new[] { n + 1, c_q };
            var eClosest = new[] { r_q, n + 1 };
            var sClosest = new[] { 0, c_q };
            var nwClosest = new[] { r_q + Math.Min(c_q - 1, n - r_q) + 1, c_q - Math.Min(c_q - 1, n - r_q) - 1 };
            var neClosest = new[] { r_q + Math.Min(n - r_q, n - c_q) + 1, c_q + Math.Min(n - r_q, n - c_q) + 1 };
            var seClosest = new[] { r_q - Math.Min(r_q - 1, n - c_q) - 1, c_q + Math.Min(r_q - 1, n - c_q) + 1 };
            var swClosest = new[] { r_q - Math.Min(r_q - 1, c_q - 1) - 1, c_q - Math.Min(r_q - 1, c_q - 1) - 1 };

            foreach (var obstacle in obstacles)
            {
                if (obstacle[0] == r_q)
                    if (obstacle[1] < c_q)
                        wClosest[1] = Math.Max(wClosest[1], obstacle[1]);
                    else
                        eClosest[1] = Math.Min(eClosest[1], obstacle[1]);
                else if (obstacle[1] == c_q)
                    if (obstacle[0] > r_q)
                        nClosest[0] = Math.Min(nClosest[0], obstacle[0]);
                    else
                        sClosest[0] = Math.Max(sClosest[0], obstacle[0]);

                else if (Math.Abs(obstacle[0] - r_q) == Math.Abs(obstacle[1] - c_q))
                {
                    if (obstacle[0] > r_q && obstacle[1] < c_q)
                        nwClosest = new[] { Math.Min(nwClosest[0], obstacle[0]), Math.Max(nwClosest[1], obstacle[1]) };
                    else if (obstacle[0] > r_q && obstacle[1] > c_q)
                        neClosest = new[] { Math.Min(neClosest[0], obstacle[0]), Math.Min(neClosest[1], obstacle[1]) };
                    else if (obstacle[0] < r_q && obstacle[1] > c_q)
                        seClosest = new[] { Math.Max(seClosest[0], obstacle[0]), Math.Min(seClosest[1], obstacle[1]) };
                    else
                        swClosest = new[] { Math.Max(swClosest[0], obstacle[0]), Math.Max(swClosest[1], obstacle[1]) };
                }
            }

            return (c_q - wClosest[1] - 1) + (eClosest[1] - c_q - 1) + (nClosest[0] - r_q - 1) + (r_q - sClosest[0] - 1)
                + (nwClosest[0] - r_q - 1) + (neClosest[0] - r_q - 1) + (r_q - seClosest[0] - 1) + (r_q - swClosest[0] - 1);

        }

        public static int ElectronicShop(int budget, int[] keyboards, int[] usbs)
        {
            Array.Sort(keyboards);
            Array.Sort(usbs);

            var bestMatch = -1;

            for (int i = 0, j = 0; i < keyboards.Length; i++)
                for (; j < usbs.Length && usbs[j] <= budget - keyboards[keyboards.Length - i - 1]; j++)
                    bestMatch = Math.Max(bestMatch, keyboards[keyboards.Length - i - 1] + usbs[j]);

            return bestMatch;

        }

        public static string GridSearch(string[] grid, string[] pattern)
        {
            //var rowsChecked = 0;
            //var indexes = new Dictionary<int, int>();
            ////ColumnIndex - Consecutive rows

            //for (int i = 0; i < grid.Length; i++)
            //{
            //    var matches = Regex.Matches(grid[i], $"({pattern[rowsChecked]})");
            //    if (matches.Count > 0)
            //    {
            //        if (++rowsChecked == pattern.Length)
            //            return "YES";

            //    }
            //    else
            //    {
            //        rowsChecked = 0;
            //    }
            //}

            throw new NotImplementedException();
        }

        public static string SherlockValidString(string s)
        {
            var ocurrences = new Dictionary<char, int>();
            foreach (var letter in s)
            {
                if (ocurrences.ContainsKey(letter))
                    ocurrences[letter]++;
                else
                    ocurrences.Add(letter, 1);
            }

            var counts = new Dictionary<int, int>();
            foreach (var number in ocurrences.Values)
            {
                if (counts.ContainsKey(number))
                    counts[number]++;
                else
                    counts.Add(number, 1);
            }

            if (counts.Count() > 2)
                return "NO";

            var minKey = counts.Keys.Min();
            var maxKey = counts.Keys.Max();

            if (counts.Count() == 1 || (minKey == 1 && counts[minKey] == 1) || (maxKey - minKey == 1 && counts[maxKey] == 1))
                return "YES";

            return "NO";
        }

        public static void Staircase(int n)
        {
            Func<string, int, string> stringBuilder = (pattern, count) =>
            {
                var builder = new StringBuilder();
                while (count-- > 0)
                {
                    builder.Append(pattern);
                }

                return builder.ToString();
            };

            for (int i = 1; i <= n; i++)
                Console.WriteLine(stringBuilder(" ", n - i) + stringBuilder("#", i));

        }

        public static string BiggerIsGreater(string w)
        {
            Func<string, int, int> nextBiggerIndex = (word, index) =>
            {
                var current = -1;
                for (int i = word.Length - 1; i > index; i--)
                {
                    if (word[index] < word[i])
                        if (current == -1 || word[i] < word[current])
                            current = i;
                }
                return current;
            };

            for (int pivot = w.Length - 2; pivot >= 0; pivot--)
            {
                if (w[pivot] <= w[pivot + 1])
                {
                    var s = new StringBuilder(w.Substring(0, pivot));
                    var index = nextBiggerIndex(w, pivot);

                    if (index == -1)
                        continue;

                    s.Append(w[index]);

                    char[] tail = w.Substring(pivot + 1, w.Length - pivot - 1).ToCharArray();
                    tail[index - pivot - 1] = w[pivot];
                    Array.Sort(tail);

                    s.Append(String.Join("", tail));

                    return s.ToString();
                }
            }

            return "no answer";
        }

        public static string TimeConversion(string docenFormat)
        {
            var pattern = @"^(\d{2}):(\d{2}):(\d{2})([AP]M)";
            MatchCollection matches = Regex.Matches(docenFormat, pattern);

            foreach (Match match in matches)
            {
                var groups = match.Groups;

                string hour = groups[1].Value;
                string minutes = groups[2].Value;
                string seconds = groups[3].Value;
                string period = groups[4].Value;

                if (hour == "12")
                    hour = "00";

                var military = int.Parse(hour) + (period == "PM" ? 12 : 0);

                return $"{military.ToString("0#")}:{minutes}:{seconds}";

            }

            throw new NotImplementedException();
        }

        public static bool CheckPalindromeCombination(string word)
        {
            var dict = new Dictionary<char, int>();

            foreach (var letter in word)
                if (dict.ContainsKey(letter))
                    dict[letter] += 1;
                else
                    dict.Add(letter, 1);


            return dict.Values.Count(x => x % 2 != 0) <= 1;
        }

        public static bool IsBinarySearchTree<T>(BinaryTreeNode<T> tree) where T : IComparable
        {
            Stack<T> stack = new Stack<T>();

            Func<BinaryTreeNode<T>, Stack<T>, bool> sortedDepthFirstSearch = null;
            sortedDepthFirstSearch = (node, elements) =>
            {
                if (node.Left != null && !sortedDepthFirstSearch(node.Left, elements))
                    return false;

                if (elements.Count != 0 && elements.Peek().CompareTo(node.Value) > 0)
                    return false;

                elements.Push(node.Value);

                if (node.Right != null && sortedDepthFirstSearch(node.Right, elements))
                    return false;

                return true;
            };

            return sortedDepthFirstSearch(tree, stack);
        }

        public static bool IsSuperBalanced<T>(BinaryTreeNode<T> tree) where T : IComparable
        {
            Func<BinaryTreeNode<T>, int> depth = null;
            depth = (node) =>
            {
                var leftDepth = node.Left != null ? depth(node.Left) : 0;
                var rightDepth = node.Right != null ? depth(node.Right) : 0;

                return 1 + Math.Max(leftDepth, rightDepth);
            };

            return Math.Abs(depth(tree.Left) - depth(tree.Right)) <= 1;
        }

        public static BigInteger LargeFactorial(int input)
        {
            var dict = new Dictionary<int, BigInteger>();

            Func<int, Dictionary<int, BigInteger>, BigInteger> largeFactorial = null;
            largeFactorial = (number, calculated) =>
            {
                if (calculated.ContainsKey(number))
                    return calculated[number];


                var result = (number > 1) ? number * largeFactorial(number - 1, calculated) : 1;
                calculated.Add(number, result);

                return result;
            };

            return largeFactorial(input, dict);
        }

        public static List<int> NonDivisionalSubset(int[] numbers, int k)
        {
            var visited = new bool[k];
            var mods = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            foreach (var n in numbers)
            {
                if (mods.ContainsKey(n % k))
                    mods[n % k].Add(n);
                else
                    mods.Add(n % k, new List<int> { n });
            }

            foreach (var key in mods.Keys)
            {
                if (visited[key])
                    continue;

                if (key == 0 || 2 * key == k)
                {
                    result.Add(mods[key].First());
                    continue;
                }


                if (!mods.ContainsKey(k - key) || mods[key].Count() > mods[k - key].Count())
                {
                    result.AddRange(mods[key]);
                    visited[key] = true;
                }
                else
                {
                    result.AddRange(mods[k - key]);
                    visited[k - key] = true;
                }
            }

            return result;
        }

    }

    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }

    //public class DoubleStackQueue<T> where T: IComparable
    //{
    //    private Stack<T> reverse;
    //    private Stack<T> fordward;

    //    public DoubleStackQueue()
    //    {
    //        this.reverse = new Stack<T>();
    //        this.fordward = new Stack<T>();
    //    }

    //    public void Enqueue(T element)
    //    {
    //        this.reverse.Push(element);
    //    }

    //    public T Peek()
    //    {
    //        if (this.fordward.Count == 0)
    //            if (this.reverse.Count == 0)
    //                throw new InvalidOperationException();
    //            else
    //                this.Requeue();

    //        return this.fordward.Peek();
    //    }

    //    public T Dequeue()
    //    {
    //        if (this.fordward.Count == 0)
    //            if (this.reverse.Count == 0)
    //                throw new InvalidOperationException();
    //            else
    //                this.Requeue();

    //        return this.fordward.Pop();
    //    }

    //    private void Requeue()
    //    {
    //        while (this.reverse.Count > 0)
    //            this.fordward.Push(this.reverse.Pop());
    //    }
    //}

    public class LinkedNode<T>
    {
        public LinkedNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public LinkedNode<T> Next { get; set; }
    }

    public class CheckLinkedNode<T> : LinkedNode<T>
    {
        public CheckLinkedNode(T value) : base(value)
        {
        }

        public CheckLinkedNode(LinkedNode<T> linkedNode) : base(linkedNode.Value)
        {
            this.Next = new CheckLinkedNode<T>(linkedNode.Next);
        }

        public bool Checked { get; set; }
    }

}
