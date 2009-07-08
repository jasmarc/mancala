using System;
using System.Collections;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public class HistoryManager<T> : IHistoryManager<T>
    {
        private ArrayList history;
        private int current;

        public HistoryManager(T initial)
        {
            Clear();
            Add(initial);
        }
        
        public HistoryManager()
        {
            Clear();
        }

        public void Clear()
        {
            history = new ArrayList();
            current = 0;
        }

        public void Add(T item)
        {
            if (history.Count > current)
            {
                history.RemoveRange(current, history.Count - current);
            }
            history.Add(item);
            current++;
        }

        public T Undo()
        {
            if (CanUndo())
                current--;
            else
                throw new ApplicationException("unable to undo");

            return (T) history[current - 1];
        }

        public T Redo()
        {
            if (CanRedo())
                current++;
            else
                throw new ApplicationException("unable to redo");

            return (T)history[current - 1];
        }

        public bool CanUndo()
        {
            return current > 1;
        }

        public bool CanRedo()
        {
            return current < history.Count;
        }
    }
}