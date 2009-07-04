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
            set
            {
                seeds = value;
                NotifyPropertyChanged("Seeds");
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}: {2}",
                                 Owner,
                                 IsGoal ? "end" : "reg",
                                 Seeds);
        }
    }
}