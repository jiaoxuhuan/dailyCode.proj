using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyConsoleApplication.LinearList线性表
{
    /// <summary>
    /// 顺序表
    /// </summary>
    public class SeqList<T> : IListDs<T>
    {
        private int _maxsize;//顺序表的容量
        private T[] data;//数组
        private int last;//指示顺序表的最后一个位置

        //索引器
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public int Last { get { return last; } }

        public int MaxSize
        {
            get { return _maxsize; }
            set { _maxsize = value; }
        }

        #region ctor
        public SeqList(int size)
        {
            data = new T[size];
            _maxsize = size;
            last = -1;
        }
        #endregion


        public int GetLength()
        {
            return last + 1;
        }

        public void Clear()
        {
            last = -1;
        }

        public bool IsEmpty()
        {
            if (last == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFull()
        {
            if (last == MaxSize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("the list is full");
                return;
            }
            //++last 以及last++区别在于（前为先加后赋值，后者为先赋值再加）
            data[last++] = item;
        }

        public void Insert(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("the list is full");
                return;
            }
            if (i < 1 || i > last + 2)
            {
                Console.WriteLine("position is error");
                return;
            }
            if (i == last + 2)
            {
                data[last + 1] = item;
            }
            else
            {
                for (int j = last; j >=i-1; j--)
                {
                    //元素移动
                    data[j + 1] = data[j];
                }
                data[i - 1] = item;//将空出的位置赋值为item
            }
            ++last;
        }

        public T Delete(int i)
        {
            T tmp = default(T);
            return tmp;
        }

        public T GetElem(int i)
        {
            throw new NotImplementedException();
        }

        public int Locate(T value)
        {
            throw new NotImplementedException();
        }
    }
}
