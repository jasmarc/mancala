using System.ComponentModel;
using Mancala.Entities.Interface;

namespace Mancala.Entities.Impl
{
    public abstract class BaseCup : ICup
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        public abstract void Reset();

        public ICup MemberwiseClone()
        {
            return (ICup) base.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("{0} reg: {1}",
                                 Owner,
                                 Seeds);
        }
    }

    class GoalCup : BaseCup
    {
        public GoalCup(Player owner)
        {
            Owner = owner;
            Seeds = 0;
        }

        public override void Reset()
        {
            Seeds = 0;
        }
    }

    class Cup : BaseCup
    {
        public Cup(Player owner)
        {
            Owner = owner;
            Seeds = 4;
        }

        public override void Reset()
        {
            Seeds = 4;
        }
    }
}