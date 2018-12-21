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
            Console.SetWindowSize(180, 30);
            Sorter mySorter = new Sorter();
            mySorter.AddRandom(20);
            mySorter.Show();
            mySorter.SelectSort();
            
        }
    }
    public class Sorter
    {
        public bool isSorted {
            get {
                mydata.ForEach(i =>
               {
                   Console.Write("AAA");
               });
                return false;
            }
        }
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
        public void Show(bool showtime = false) {
            
            Console.Write("{0} Turn: [ ",turn);
            mydata.ForEach(i => {
                Console.Write("{0}\t", i);
                });
            Console.WriteLine("] ");
            if (!stopwatch.IsRunning && showtime==true) {
                Console.WriteLine("Stopwatch time: " + countingtime);
            }
        }
        public void AddRandom(int mcount) {
            int temp = 0;
            Random randomer = new Random();
            for(int i =0; i<mcount; i++) {
                temp = randomer.Next(0, mcount);
                this.mydata.Add(temp);
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
        public void AddPreCreated(int mod=0) {
            if (mod ==0) {
                this.Add(7);
                this.Add(0);
                this.Add(10);
                this.Add(11);
                this.Add(1);
                this.Add(6);
                this.Add(12);
                this.Add(9);
                this.Add(15);
                this.Add(19);
                this.Add(2);
                this.Add(8);
            }
            else if(mod == 1) {
                this.Add(10);
                this.Add(7);
                this.Add(11);
                this.Add(4);
                this.Add(19);
                this.Add(3);
                this.Add(2);
                this.Add(9);
                this.Add(6);
                this.Add(11);
                this.Add(2);
                this.Add(5);
                this.Add(3);
                this.Add(16);
                this.Add(9);
                this.Add(16);
                this.Add(11);
                this.Add(7);
                this.Add(9);
                this.Add(12);
            }
        }
        public void Clear() {
            this.mydata.Clear();
        }
        public int this[int i] {
            get { return mydata[i]; }
            set { this.mydata[i] = value; }
        }
        public static Sorter operator+(Sorter m, int a) {
            m.Add(a);
            return m;
        }
        public static Sorter operator+(Sorter m, Sorter b) {
            foreach (int i in b.mydata) {
                m.Add(i);
            }
            return m;
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
            Show(true);
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
            Show(true);
        }
        private void MergeSort(int lpivot, int rpivot){
            if(lpivot < rpivot) {
                int mid = (lpivot + rpivot) / 2;
                MergeSort(lpivot, mid);
                MergeSort(mid + 1, rpivot);
                Merge(lpivot, mid, rpivot);
            }
        }
        private void Merge( int lpivot,int midpivot, int rpivot) {
            turn++;
            //mydata[lpivot] to mydata[midpivot]까지 새로운 리스트 생성
            List<int> leftlist = new List<int>(midpivot - lpivot + 1);
            //mydata[midpivot+1]to mydata[rpivot]까지 새로운 리스트 생성
            List<int> rightlist = new List<int>(rpivot - midpivot);
            //좌리스트 우리스트 둘다 그 값까지 받기
            for(int i =lpivot; i<=midpivot; i++) {
                leftlist.Add(mydata[i]);
            }
            for (int i = midpivot+1; i <= rpivot; i++) {
                rightlist.Add(mydata[i]);
            }
            

            //그 다음 lpivot 부터 하나씩 작은거부터 넣으면 됨
            int llistidx = 0;
            int rlistidx = 0;
            int lmax = leftlist.Count-1;
            int rmax = rightlist.Count-1;
            for (int j = lpivot; j <=rpivot; j++) {
                if(llistidx> lmax ) {
                    mydata[j] = rightlist[rlistidx];
                    rlistidx++;
                } else if (rlistidx > rmax) {
                    mydata[j] = leftlist[llistidx];
                    llistidx++;
                } else if (leftlist[llistidx] < rightlist[rlistidx]) {
                    mydata[j] = leftlist[llistidx];
                    llistidx++;
                } else {
                    mydata[j] = rightlist[rlistidx];
                    rlistidx++;
                }
            }
        }
        /// <summary>
        /// Do Bubble Sort
        /// </summary>
        public void BubbleSort() {
            int temp = 0;
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = this.count - 1; i >= 0; i--) {
                turn++;
                for (int j = 0; j < i; j++) {
                    if (this[j + 1] < this[j]) {
                        temp = this[j + 1];
                        this[j + 1] = this[j];
                        this[j] = temp;
                    }
                    Show();
                }
            }
            stopwatch.Stop();
            Show(true);
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
                if (this[i] < this[i - 1]) {
                    for (int j = i - 1; j >= 0; j--) {
                        if (this[i] > this[j] ) {
                            mydata.Insert(j+1, mydata[i]);
                            mydata.RemoveAt(i+1);
                            break;
                        } else if(this[i]<=this[j] && j == 0) {
                            mydata.Insert(j, mydata[i]);
                            mydata.RemoveAt(i + 1);
                            break;
                        }
                    }
                }
            }
            stopwatch.Stop();
            Show(true);
        }

        public void SelectSort() {
            turn=0;
            stopwatch.Reset();
            stopwatch.Start();

            List<int> mylist = new List<int>(mydata);
            for(int i =0; i<mydata.Count; i++) {
                mydata[i] = mylist.Min<int>();
                mylist.Remove(mydata[i]);
            }



            stopwatch.Stop();
            Show(true);
        }
        public void HeapSort() {
            turn = 0;
            stopwatch.Reset();
            stopwatch.Start();






            stopwatch.Stop();
            Show(true);
        }
    }
}
