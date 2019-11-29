using System.Collections.Generic;

namespace A8
{
    public class BracketStack<T>
    {
        public List<T> Stack { get; private set; }

        public BracketStack()
        {
            Stack = new List<T>();
        }

        /// <summary>
        /// Adds the new element to the top of the stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            Stack.Add(value);
        }
        
        /// <summary>
        /// Removes the top element and returns it
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T result = Stack[Stack.Count - 1];
            Stack.RemoveAt(Stack.Count - 1);
            return result;
        }

        public bool IsEmpty() =>
            Stack.Count == 0;

        /// <summary>
        /// Returns the top element of the stack without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek() =>
            Stack[Stack.Count - 1];

        /// <summary>
        /// Removes the top element in the stack
        /// </summary>
        public void Remove()
        {
            Stack.RemoveAt(Stack.Count - 1);
        }

        /// <summary>
        /// Returns the stack size
        /// </summary>
        /// <returns></returns>
        public int Size() => Stack.Count;
    }
}