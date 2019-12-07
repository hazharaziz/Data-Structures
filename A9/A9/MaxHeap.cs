namespace A9
{
    public class MaxHeap
    {
        public long Size { get; set; }
        public long MaxSize { get; set; }
        public FoodStop[] Heap { get; set; }
        
        public MaxHeap(long maxSize)
        {
            MaxSize = maxSize;
            Heap = new FoodStop[maxSize];
            Size = 0;
        }

        public long Parent(long index) => (index - 1) / 2;
        public long RightChild(long index) => (2 * index) + 2;
        public long LeftChild(long index) => (2 * index) + 1;

        public long ExtractMax()
        {
            long result = Heap[0].Food;
            Heap[0] = Heap[Size - 1];
            Size--;
            SiftDown(0);
            return result;
        }

        public void Insert(FoodStop p)
        {
            if (Size < MaxSize)
            {
                Heap[Size] = p;
                SiftUp(Size);
                Size++;
            }
        }
        public void SiftUp(long i)
        {
            while (i > 0 && (Heap[Parent(i)].Food < Heap[i].Food))
            {
                (Heap[Parent(i)], Heap[i]) = (Heap[i], Heap[Parent(i)]);
                i = Parent(i);
            }
        }
        public void SiftDown(long i)
        {
            long maxIndex = i;
            long left = LeftChild(i);
            if (left < Size && (Heap[left].Food > Heap[maxIndex].Food))
                maxIndex = left;
            long right = RightChild(i);
            if (right < Size && (Heap[right].Food > Heap[maxIndex].Food))
                maxIndex = right;
            if (i != maxIndex)
            {
                (Heap[i], Heap[maxIndex]) = (Heap[maxIndex], Heap[i]);
                SiftDown(maxIndex);
            }
        }


    }
}