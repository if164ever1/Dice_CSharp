using System;
using System.Threading;

namespace Dice
{
    public class Dice
    {
        public int diceA, diceB;
        static Random rand = new Random();
        DelegateShow Show;
        Thread thread;
        public Dice(DelegateShow show) 
        {
            this.Show = show;
            thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Start() 
        {
            diceA = rand.Next(1, 7);
            diceB = rand.Next(1, 7);
            Show(diceA, diceB);
        }

        public void Run()
        {
            while (true)
            {
                Start();
                Thread.Sleep(1000);
            }
        }
    }
}
