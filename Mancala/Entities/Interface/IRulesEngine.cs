using Mancala.Entities.Interface;

namespace Mancala.Entities.Interface
{
    public interface IRulesEngine
    {
        string Name { get; }
        bool MoveIsLegal(IBoard board, ICup cup);
        bool GetToGoAgain(IBoard board, ICup landingCup);
        bool ShouldSowSeed(IBoard board, ICup cup);
        void HandleRemainingSeeds(IBoard board);
        void ApplyPostMoveRules(IBoard board, ICup cup);
    }
}