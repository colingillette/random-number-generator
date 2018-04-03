using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gillette_a5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile;
            Random ran = new Random();


            int.TryParse(numberTextBox.Text, out int iterations);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFile = File.CreateText(saveFileDialog1.FileName);
                for (int i = 0; i < iterations; i++)
                {
                    outputFile.WriteLine(ran.Next(0, 100).ToString());
                }

                MessageBox.Show("File Saved");
                outputFile.Close();
            }
            else
            {
                MessageBox.Show("Save canceled.");
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            StreamReader inputFile;
            int reader;
            int zeroToNineteen = 0, twentyToThirtyNine = 0, fourtyToFiftyNine = 0,
                sixtyToSeventyNine = 0, eightyToNinetyNine = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFileDialog1.FileName);

                try
                {
                    while (!inputFile.EndOfStream)
                    {
                        reader = int.Parse(inputFile.ReadLine());
                        if (reader < 20)
                        {
                            zeroToNineteen += 1;
                        }
                        else if (reader < 40)
                        {
                            twentyToThirtyNine += 1;
                        }
                        else if (reader < 60)
                        {
                            fourtyToFiftyNine += 1;
                        }
                        else if (reader < 80)
                        {
                            sixtyToSeventyNine += 1;
                        }
                        else
                        {
                            eightyToNinetyNine += 1;
                        }
                    }

                    MessageBox.Show($"{zeroToNineteen}, {twentyToThirtyNine}, {fourtyToFiftyNine}, " +
                        $"{sixtyToSeventyNine}, {eightyToNinetyNine}");
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }
    }
}
