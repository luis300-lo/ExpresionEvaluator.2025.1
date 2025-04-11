using Evaluator.Logic;

namespace Evaluator.UI.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void b8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void b4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void b5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void b6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void b1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void b3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void b0_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void bp_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ".";
        }

        private void bdi_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "/";
        }

        private void bpow_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "^";
        }

        private void bmul_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "*";
        }

        private void bpa_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "(";
        }

        private void bclo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ")";
        }

        private void bplus_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "+";
        }

        private void bmi_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "-";
        }

        private void bequ_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += $"={FunctionEvaluator.Evalute(txtDisplay.Text)}";
        }

        private void bdel_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }

        private void bcle_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = string.Empty;
        }
    }
}
