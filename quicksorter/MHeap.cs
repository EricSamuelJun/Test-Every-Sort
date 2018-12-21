using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quicksorter {
    class MHeap {
        public Mnode header;
        public virtual void Add() {

        }
        public virtual int Pop() {
            return 0;
        }
    }
    class MaxHeap : MHeap {
        public override void Add() {

        }
        public override int Pop() {
            return 0;
        }

    }
    class MinHeap :MHeap{
        public override void Add() {

        }
        public override int Pop() {
            return 0;
        }

    }
    class Mnode {
        public Mnode LNode;
        public Mnode RNode;
        public Mnode MNode;
        public int data;
    }
}
