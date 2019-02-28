using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayFunctions
{
    public partial class Form1 : Form
    {
        List<int> _numList;
        public Form1()
        {
            InitializeComponent();
            _numList = new List<int>
            {
                5, 4, 7, 2, 6, 9, 7, 3
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int elementToFind = 7;
            int resultIndex = FirstIndexOf(_numList, elementToFind);

            MessageBox.Show("The first occurence of " + elementToFind + " is at position where index is " + resultIndex);

        }

        public int FirstIndexOf(List<int> array, int element)
        {
            //int index = 0;
            //if (array.Contains(element))
            //{
            //    for (int i = 0; i < array.Count; i++)
            //    {

            //        if (element == array[i])
            //        {
            //            index = i;
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //}
            //else
            //{
            //    index = -1;
            //}
            //return index;

            //Un-comment the above block of code to run it. 
            //The code line below and commented code block are the same.

            return array.IndexOf(element);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_numList.Reverse();
            //string result = "Array Reversed: ";
            //foreach (var n in _numList)
            //{
            //    result += n;
            //    result += " ";
            //    if (_numList.Last() == n)
            //    {
            //        result.TrimEnd(',');
            //    }
            //}
            //MessageBox.Show(result);
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            //Above code uses the Array.Reverse() method which is provided by .NET Framework.

            //Below code uses a reverse for loop to count backwards and add each element to a new list.
            //Both blocks provide same result.

            List<int> reverseList = new List<int>();
            //Reverse for loop to count backwards from the int array, and add each item to reverseList.
            for (int i = _numList.Count; i > 0; i--)
            {
                reverseList.Add(i);
            }

            //Formatting the output to show for the user.
            string result = "Array Reversed: ";
            foreach (int n in reverseList)
            {
                result += n;
                result += ", ";                
            }
            //Removing the last comma and blank space that appears at the end of the string.
            result = result.TrimEnd(',', ' ');
            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insert(_numList, 3, 6);
            string newItem = "New Element Added to the list: ";
            foreach (var n in _numList)
            {
                newItem += n;
                newItem += " ";
                if (_numList.Last() == n)
                {
                    newItem.TrimEnd();
                }
            }
            MessageBox.Show(newItem);
        }

        public void Insert(List<int> array, int toBeInserted, int targetIndex)
        {
            array.Insert(targetIndex, toBeInserted);            
        }
    }
}
