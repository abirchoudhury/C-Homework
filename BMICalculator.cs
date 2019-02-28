using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double KG_PER_LBS = 0.45;
        const double METER_PER_INCH = 0.0254;

        public double CalculateBMI(double lbs, int height, int inches)
        {
            //Converting LBS to KG
            double weightInKG = ConvertLbsToKg(lbs);

            //Converting Height to Inches
            int heightToInches = ConvertFtToInch(height);

            //Adding inches provided
            heightToInches += inches;

            //Converting height inches to meters.
            double heightToMeters = ConvertInchToMeters(heightToInches);

            //Squaring the meter
            double metersSquared = Math.Pow(heightToMeters, 2);

            //Calculating BMI
            double BMI = weightInKG / metersSquared;

            //Return BMI
            return BMI;
        }


        public int ConvertFtToInch(int ft)
        {
            return ft * 12;
        }

        public double ConvertInchToMeters(int inches)
        {
            return inches * METER_PER_INCH;
        }

        public double ConvertLbsToKg(double lbs)
        {
            return lbs * KG_PER_LBS;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Storing weight in lbs/
            double weightInLBS = 0;
            //Storing ft
            int height = 0;
            //Storing inches
            int inches = 0;
            //Storing raw bmi value
            double bmi = 0;

            //To hold rounded BMI 
            int bmiRounded = 0;

            //Variable to create the message for the user.
            string message = string.Empty;
            
            //Weight 
            try
            {
                double.TryParse(txtWeight.Text, out weightInLBS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtWeight.Clear();
                txtWeight.Focus();
            }

            //Height in Ft
            try
            {
                int.TryParse(txtFt.Text, out height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtFt.Clear();
                txtFt.Focus();
            }

            //Inches
            try
            {
                int.TryParse(txtInch.Text, out inches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtInch.Clear();
                txtInch.Focus();
            }

            //Calculate BMI 
            bmi = CalculateBMI(weightInLBS, height, inches);
            bmiRounded = Convert.ToInt32(Math.Round(bmi));

            message = "The BMI for a person who is " + height + " feet " + inches + " inches and weighs " + weightInLBS + " lbs is " + bmi.ToString("n3") + " or practically, " + bmiRounded + ".";

            MessageBox.Show(message);

        }
    }
}
