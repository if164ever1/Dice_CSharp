using System;
using System.Drawing;
using System.Windows.Forms;


namespace Dice
{
    public delegate void DelegateShow(int a, int b);
    public partial class Form1 : Form
    {
        Dice dice1;
        Dice dice2;
        Dice dice3;

        public Form1()
        {
            InitializeComponent();
        }

        public void InitDice()
        {
            DelegateShow show;
            show = ShowBox;
            show += ShowDice;
            show += ShowSum;
            
            dice1 = new Dice(ShowDice);
            dice2 = new Dice(ShowBox);
            dice3 = new Dice(ShowSum);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            dice1.Start();
            dice2.Start();
            dice3.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDice();
        }

        private void ShowDice(int a, int b)
        {
            if (InvokeRequired)
            {
                Invoke(new DelegateShow(ShowDice), a, b);
                return;
            }
            textBoxDices.Text = (dice1.diceA + " : " + dice1.diceB).ToString();
        }
        private void ShowSum(int a, int b)
        {
            if (InvokeRequired)
            {
                Invoke(new DelegateShow(ShowSum), a, b);
                return;
            }
            int sum = dice3.diceA + dice3.diceB;
            labelSum.Text = sum.ToString();

        }
        private void ShowBox(int a, int b)
        {
            if (InvokeRequired)
            {
                Invoke(new DelegateShow(ShowBox), a, b);
                return;
            }
            pictureBox1.Image = getImg(a);
            pictureBox2.Image = getImg(b);
        }

        private Image getImg(int img)
        {
            switch (img)
            {
                case 1: return Properties.Resources._1;
                case 2: return Properties.Resources._2;
                case 3: return Properties.Resources._3;
                case 4: return Properties.Resources._4;
                case 5: return Properties.Resources._5;
                case 6: return Properties.Resources._6;
            }
            return null;
        }
    }
}
