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
        }
    }
    public class Sorter
    {
        private int turn;
        private List<int> mydata = new List<int>();
        /// <summary>
        /// mydata의 count 값 리턴함
        /// </summary>
        public int count {
            get {
                return mydata.Count;
            }
            private set {

            }
        }
        /// <summary>
        /// Show All List Value in Data
        /// </summary>
        public void Show() {

            Console.Write("{0} Turn: [ ",turn);
            mydata.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("] ");
        }
        /// <summary>
        /// Quick Sort Every Elements in list
        /// </summary>
        public void QuickSort(){
            turn = 0;
            QuickSort(0, mydata.Count - 1);
        }
        private void QuickSort(int lpivot,int rpivot){
            turn++;
            List<int> copylist = new List<int>(mydata);
            int mlpivot = lpivot;
            int mrpivot = rpivot;
            for(int i =lpivot+1; i <= rpivot; i++)
            {
                //Console.WriteLine("lpviot: " + lpivot + " mlpivot: " + mlpivot + " copy[index]: " + copylist[lpivot] + " i: " + i + " copylist[i]: " + copylist[i] + "rpviot: " + rpivot + " mrpivot: " + mrpivot);
                if (copylist[lpivot] < copylist[i])
                {//피봇보다 더 크다면
                    mydata[mrpivot] = copylist[i];
                    mrpivot--;
                }
                else
                {
                    mydata[mlpivot] = copylist[i];
                    mlpivot++;
                }
            }
            mydata[mlpivot] = copylist[lpivot];
            mlpivot -= 1;
            mrpivot += 1;
            if (!(mlpivot-lpivot < 1))
            {
                QuickSort(lpivot, mlpivot);
            }
            if (!(rpivot - mrpivot < 1))
            {
                QuickSort(mrpivot, rpivot);
            }
            return;
        }

        public void MergeSort() {
            turn = 0;
            MergeSort(0, mydata.Count - 1);
        }
        private void MergeSort(int lpivot, int rpivot){
            
        }
        public void BubbleSort() {

        }
        public void InsertSort() {

        }
    }
}
