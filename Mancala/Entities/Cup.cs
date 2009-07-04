using System.ComponentModel;

namespace Mancala.Entities
{
    public class Cup : ICup
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsGoal { get; set; }
        public Player Owner { get; set; }
        public int Seeds { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}: {2}",
                                 Owner,
                                 IsGoal ? "end" : "reg",
                                 Seeds);
        }
    }
}