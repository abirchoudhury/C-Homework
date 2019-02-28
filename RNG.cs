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

namespace RandomNumberGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Field level list created, allowing access to all members of the class.
        static List<int> _numbers;

        /// <summary>
        /// Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _numbers = new List<int>();
            if (int.TryParse(textBox1.Text, out int ok))
            {
                //Get the random numbers based on user's count.
                _numbers = GetRandomNumbers(ok);

                //create the text file and save
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "RandomNumbers.txt";
                save.Filter = "Text File | *.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    foreach (int n in _numbers)
                    {
                        writer.WriteLine(n.ToString());
                    }
                    writer.Dispose();
                    writer.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
                textBox1.Clear();
                textBox1.Focus();
            }

        }

        /// <summary>
        /// Open File button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            //Int list to hold the converted lines into numbers from the text file.
            List<int> retrievedNums = new List<int>();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader r = new StreamReader(openFileDialog1.FileName))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        //Converting the string numbers to int and adding them to a list.
                        retrievedNums.Add(int.Parse(line));
                    }
                }
            }

            //Calling the method to categorize the numbers retrieved, and show them in a message box.
            ShowCategorizedNumbers(retrievedNums);
            
        }

        /// <summary>
        /// Method to show the numbers from the text file, categorize it, and show it back to the user
        /// using MessageBox class
        /// </summary>
        /// <param name="numbers"></param>
        public void ShowCategorizedNumbers(List<int> numbers)
        {
            //Variables to hold the count of numbers that fall within ranges.
            int zeroToNineteen;
            int twentyToThirtyNine;
            int fourtyToFiftyNine;
            int sixtyToSeventyNine;
            int eightyToNinetyNine;

            //Assigning the nubmer of randoms generated in their corresponding ranges. 
            zeroToNineteen = numbers.Where(a => a >= 0 && a <= 19).Count();
            twentyToThirtyNine = numbers.Where(a => a >= 20 && a <= 39).Count();
            fourtyToFiftyNine = numbers.Where(a => a >= 40 && a <= 59).Count();
            sixtyToSeventyNine = numbers.Where(a => a >= 60 && a <= 79).Count();
            eightyToNinetyNine = numbers.Where(a => a >= 80 && a <= 99).Count();


            string test = zeroToNineteen.ToString();
            
            //Using stringbuilder to format the output to show on message box.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("00-19 : " + zeroToNineteen);
            sb.AppendLine("20-39 : " + twentyToThirtyNine);
            sb.AppendLine("40-59 : " + fourtyToFiftyNine);
            sb.AppendLine("60-79 : " + sixtyToSeventyNine);
            sb.AppendLine("80-99 : " + eightyToNinetyNine);

            MessageBox.Show(sb.ToString());

        }

        /// <summary>
        /// Returns a list of randomly generated numbers
        /// </summary>
        /// <param name="count">Number of numbers to generate</param>
        /// <returns></returns>
        public List<int> GetRandomNumbers(int count)
        {
            Random r = new Random();
            var lst = new List<int>(count);
            for (int i = 0; i <= count; i++)
            {
                lst.Add(r.Next(0, 99));
            }
            return lst;
        }
    }
}
