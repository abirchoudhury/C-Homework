using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealCostCalculator
{
    public partial class Form1 : Form
    {
        //Dictionary to hold the items on the list box and their corresponding values.
        Dictionary<string, double> _dicTipRates = new Dictionary<string, double>();

        public Form1()
        {
            InitializeComponent();

            _dicTipRates.Add("None", 0);
            _dicTipRates.Add("10%", 0.1);
            _dicTipRates.Add("15%", 0.15);
            _dicTipRates.Add("20%", 0.20);
            _dicTipRates.Add("25%", 0.25);
            _dicTipRates.Add("30%", 0.30);
        }

        const double TAX_RATE = 0.076;
        const double EXTRA_DISCOUNT = 0.1;

        double _mealCost;
        double _tax;
        double _tipRate;
        double _totalCost;


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal.Text) || double.TryParse(txtTotal.Text, out double t) == false)
            {
                MessageBox.Show("Entry Invalid", "Please re-enter a valid cost for the meal.", MessageBoxButtons.OKCancel);
            }
            else
            {
                _mealCost = t;
            }

            double currentDiscount = 0;

            if (checkBox1.Checked)
            {
                currentDiscount += EXTRA_DISCOUNT;
            }
            if (checkBox2.Checked)
            {
                currentDiscount += EXTRA_DISCOUNT;
            }
            if (checkBox3.Checked)
            {
                currentDiscount += EXTRA_DISCOUNT;
            }

            //Calculate the discounted amount
            double discounts = 0;
            discounts = _mealCost * currentDiscount;

            //Calculate mealcost by subtracting discounts
            _mealCost = _mealCost - discounts;

            //Calculate tax to be charged on the calcualted meal cost.
            _tax = _mealCost * TAX_RATE;

            //Get the tip selection item from the list
            var selectedItem = tipItemsListBox.SelectedItem;

            double selectedTipRate = (from tipRate in _dicTipRates where tipRate.Key == selectedItem.ToString() select tipRate.Value).First();
            _tipRate = selectedTipRate;



            //Calculate total cost
            double tipAmount = _mealCost * _tipRate;
            _totalCost = _mealCost + tipAmount + _tax;

            MessageBox.Show("Your total meal cost is " + _totalCost.ToString("c"), "Total Cost", MessageBoxButtons.OKCancel);
            
            

        }

        //6 or less
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tipItemsListBox.Items.Clear();            
            foreach (var tr in _dicTipRates)
            {
                tipItemsListBox.Items.Add(tr.Key);
            }
        }

        //6 or more
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tipItemsListBox.Items.Clear();
            foreach (var tr in _dicTipRates.Where(a => a.Value >= 0.15))
            {
                tipItemsListBox.Items.Add(tr.Key);
            }
        }

        private void tipItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {
                button1.Enabled = true;
            }
        }
    }


}

