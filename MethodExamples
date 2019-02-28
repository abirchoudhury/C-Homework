using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to convert F to C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double F = double.Parse(txtTemp.Text);
            double result = ConvertToCelsius(F);
            string message = F.ToString("n2") + " degrees Fahrenheit is equal to " + result.ToString("n2") + " degree Celsius";
            MessageBox.Show(message);
        }

        /// <summary>
        /// Method to convert to Celsius
        /// </summary>
        /// <param name="farhenheit"></param>
        /// <returns></returns>
        public double ConvertToCelsius(double farhenheit)
        {
            double celsius = 0;
            //Using the formula provided on the instructions.
            celsius = (farhenheit - 32) * 5 / 9;
            return celsius;
        }

        /// <summary>
        /// Method to find if input year is leap year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int year = int.Parse(txtLeap.Text);
            //I know that the instructions 4a,4b,4c,4d provided on the assignment instructs
            //to create an algorithm to extract leap years.
            //However, .NET framework provides methods to already do this, that's why I chose to use it.
            if (DateTime.IsLeapYear(year))
            {
                MessageBox.Show("Year " + year + " is a leap year!");
            }
            else
            {
                MessageBox.Show("Year " + year + " is NOT a leap year!");
            }
        }

        /// <summary>
        /// Method to show how many leap years exist by N years.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //List to hold the leap years.
            List<int> leapYears = new List<int>();

            //List to hold the years from user input.
            List<int> yearsRange = new List<int>();

            //Adding the current year to the list.
            yearsRange.Add(DateTime.Now.Date.Year);

            //Converting the user input to an int.
            int yearRange = int.Parse(txtLeapN.Text);

            //Looping through yearRange to 
            for (int i = 1; i <= yearRange; i++)
            {
                yearsRange.Add(DateTime.Now.Date.Year + i);
            }

            //Looping through the yearsRange to extract leap years. 
            //If a leap year is found, the loop moves on(continue;) to the next element.
            foreach (var year in yearsRange)
            {
                //I know that the instructions 4a,4b,4c,4d provided on the assignment instructs
                //to create an algorithm to extract leap years.
                //However, .NET framework provides methods to already do this, that's why I chose to use it.
                if (DateTime.IsLeapYear(year))
                {
                    leapYears.Add(year);
                }
                else
                {
                    continue;
                }
            }

            //Preparing the output result to show in MessageBox.
            string message = "Leap years in the next " + yearRange + " years are: ";
            foreach (var year in leapYears)
            {
                message += year;
                message += ", ";
            }
            
            message = message.TrimEnd(' ').TrimEnd(',');
            MessageBox.Show(message);

        }

        /// <summary>
        /// Method to find divisors for the provided number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Getting the number from the user
            int num = int.Parse(txtDivisor.Text);

            //List to hold the divisors found.
            List<int> divisors = new List<int>();

            //Looping through the user input number and collecting divisors to the list.
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    divisors.Add(i);
                }
            }

            string result = string.Empty;
            //Adding all divisors to a string, separated by a comma.
            divisors.ForEach(a => result += a +", ");

            //Removing the last comma
            result = result.TrimEnd(' ').TrimEnd(',');

            //Displaying the result.
            MessageBox.Show("Divisors of " + num + " are: " + result);
        }


    }


}
