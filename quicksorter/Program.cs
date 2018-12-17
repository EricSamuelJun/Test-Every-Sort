using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quicksorter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> mlist = new List<int>();
            mlist.Add(14);
            mlist.Add(18);
            mlist.Add(7);
            mlist.Add(8);
            mlist.Add(20);
            mlist.Add(6);
            mlist.Add(11);
            mlist.Add(15);
            mlist.Add(09);
            mlist.Add(17);
            mlist.Add(22);
            mlist.Add(0);
            Console.Write("[ ");
            mlist.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("] ");
            Sorter.QuickSort(ref mlist, 0, mlist.Count-1);
            Console.Write("[ ");
            mlist.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("] ");
        }
    }
    public class Sorter
    {
        public static void QuickSort(ref List<int> list)
        {
            QuickSort(ref list, 0, list.Count - 1);
        }
        public static void QuickSort(ref List<int> list,int lpivot,int rpivot)
        {
            
            List<int> copylist = new List<int>(list);
            int mlpivot = lpivot;
            int mrpivot = rpivot;
            for(int i =lpivot+1; i <= rpivot; i++)
            {
                //Console.WriteLine("lpviot: " + lpivot + " mlpivot: " + mlpivot + " copy[index]: " + copylist[lpivot] + " i: " + i + " copylist[i]: " + copylist[i] + "rpviot: " + rpivot + " mrpivot: " + mrpivot);
                if (copylist[lpivot] < copylist[i])
                {//피봇보다 더 크다면
                    list[mrpivot] = copylist[i];
                    mrpivot--;
                }
                else
                {
                    list[mlpivot] = copylist[i];
                    mlpivot++;
                }
            }
            list[mlpivot] = copylist[lpivot];
            mlpivot -= 1;
            mrpivot += 1;
            //list.ForEach(i => Console.Write("{0}\t", i));
            //Console.WriteLine();
            //Console.WriteLine("*****All Clean\t[ mlpivot / lpivot: {0}/{1} \t mrpivot / rpivot {2}/{3} ]",mlpivot,lpivot,mrpivot,rpivot);
            //Console.ReadKey(true);
            if (!(mlpivot-lpivot < 1))
            {
                QuickSort(ref list, lpivot, mlpivot);
            }
            if (!(rpivot - mrpivot < 1))
            {
                QuickSort(ref list, mrpivot, rpivot);
            }
            return;
        }
        public static void MergeSort(ref List<int> list, int lpivot, int rpivot)
        {
            
        }
    }
}
