using System.ComponentModel;

namespace Mancala.Entities
{
    public class Cup : ICup
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsGoal { get; set; }
        public Player Owner { get; set; }
        private int seeds;
        public int Seeds
        {
            get { return seeds; }
            set { seeds = value; }
        }
    }
}