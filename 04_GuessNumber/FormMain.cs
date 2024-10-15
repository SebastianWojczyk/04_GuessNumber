using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_GuessNumber
{
    public partial class FormMain : Form
    {
        private int MinValue;
        private int MaxValue;
        private int CurrentValue;
        public FormMain()
        {
            InitializeComponent();
            PrepareNewGame();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Again?",
                                     $"Your number is {CurrentValue}.",
                                     MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                PrepareNewGame();
            }
            else if(result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void ButtonLess_Click(object sender, EventArgs e)
        {
            MaxValue = CurrentValue - 1;
            PrepareNextStep();
        }

        private void ButtonMore_Click(object sender, EventArgs e)
        {
            MinValue = CurrentValue + 1;
            PrepareNextStep();
        }

        private void PrepareNewGame()
        {
            MinValue = 1;
            MaxValue = 100;

            buttonLess.Enabled = true;
            buttonMore.Enabled = true;

            PrepareNextStep();
        }

        private void PrepareNextStep()
        {
            CurrentValue = (MinValue + MaxValue)/ 2;

            if(CurrentValue<= MinValue)
            {
                buttonLess.Enabled = false;
            }
            if (CurrentValue >= MaxValue)
            {
                buttonMore.Enabled = false;
            }

            labelNumber.Text = CurrentValue.ToString();
            labelInfo.Text = $"Value from range [{MinValue}, {MaxValue}]";
        }
    }
}
