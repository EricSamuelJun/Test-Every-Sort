using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace quicksorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter mySorter = new Sorter();
            mySorter.AddRandom(20);
            mySorter.BubbleSort();
        }
    }
    public class Sorter
    {
        private Stopwatch stopwatch = new Stopwatch();
        public string countingtime {
            get { return stopwatch.ElapsedMilliseconds.ToString() + "ms"; }
        }
        private int turn;
        private List<int> mydata = new List<int>();
        /// <summary>
        /// mydata의 count 값 리턴함
        /// </summary>
        public int count {
            get {
                return mydata.Count;
            }
        }
        /// <summary>
        /// Show All List Value in Data
        /// </summary>
        public void Show() {

            Console.Write("{0} Turn: [ ",turn);
            mydata.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("] ");
            if (!stopwatch.IsRunning && turn!=0) {
                Console.WriteLine("Stopwatch time: " + countingtime);
            }
        }
        public void AddRandom(int mcount) {
            Random randomer = new Random();
            for(int i =0; i<mcount; i++) {
                mydata.Add(randomer.Next(0,mcount));
            }
            
        }
        public void AddAscend(int mcount,int min=0) {
            mydata.Clear();
            for(int i=min;i<mcount; i++) {
                mydata.Add(i);
            }
        }
        public void AddDescend(int mcount,int min =0) {
            mydata.Clear();
            for (int i = min; i < mcount; i++) {
                mydata.Add(mcount-i);
            }
        }
        public void Add(int a) {
            mydata.Add(a);
        }
        public void Clear() {
            this.mydata.Clear();
        }
        public int this[int i] {
            get { return mydata[i]; }
            set { this.mydata[i] = value; }
        }
        /// <summary>
        /// Quick Sort Every Elements in list
        /// </summary>
        public void QuickSort(){
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();
            QuickSort(0, mydata.Count - 1);
            stopwatch.Stop();
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
            Show();
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
        /// <summary>
        /// Merge Sort With Reculsive Method
        /// </summary>
        public void MergeSort() {
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();
            MergeSort(0, mydata.Count - 1);
            stopwatch.Stop();
        }
        private void MergeSort(int lpivot, int rpivot){
            
        }
        /// <summary>
        /// Do Bubble Sort
        /// </summary>
        public void BubbleSort() {
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();

            stopwatch.Stop();
        }
        /// <summary>
        /// 
        /// </summary>
        public void InsertSort() {
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();
            for (int i=1; i<count; i++) {
                turn++;
                int temp = this[i];
                for (int j = i; j >= 0; j--) {
                    if(temp < this[j]) {
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
                Show();
            }
            stopwatch.Stop();
        }

        public void SelectSort() {
            turn=0;
            stopwatch.Reset();
            stopwatch.Start();

            stopwatch.Stop();
        }
        public void HeapSort() {
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();

            stopwatch.Stop();
        }
    }
}
