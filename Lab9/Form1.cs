using Lab9.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            font1 = new Font(new FontFamily("Arial"), 16, FontStyle.Bold, GraphicsUnit.Pixel);
            font2 = new Font(new FontFamily("Times New Roman"), 20, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private void showOutput()
        {
            String readText = FileHelper.readFromFile();
            this.richTextBox1.Text = readText;
            FileHelper.clearFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstLab.start();
            this.showOutput();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThirdLab.start();
            this.showOutput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecondLab.start();
            this.showOutput();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FourthLab.start();
            this.showOutput();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String readText = FileHelper.readFromFile(@"..\..\files\Sherlock Holmes The Final Problem.txt");
            this.richTextBox1.Text = readText;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FileHelper.writeToFile("You've just clicked me");
            this.showOutput();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SixthLab.start();
            this.showOutput();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileHelper.writeToFile("Animal sounds");
            FileHelper.writeToFile("I'm a cat. Purr purr purr");
            FileHelper.writeToFile("I'm a dog. Bark bark bark");
            this.showOutput();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Font = this.font1;
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Font = this.font2;
        }
    }
}
