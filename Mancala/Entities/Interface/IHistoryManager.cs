namespace Mancala.Entities.Interface
{
    public interface IHistoryManager<T>
    {
        void Clear();
        void Add(T item);
        T Undo();
        T Redo();
        bool CanUndo();
        bool CanRedo();
    }
}
