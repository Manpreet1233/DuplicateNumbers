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

//Manpreet Rajpal 
//September 29, 2017
//This program displays the array of numbers and than shows the duplicate of the array without the repeated numbers
namespace Duplicates
{
    public partial class Form1 : Form
    {
        //global variables
        int[] Numbers;
        //int Counter;

        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            //create fileDialog in memory and than show it
            //checks to see if any file is seleted "DialogResult.Ok"
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //open the file to read the numbers (data) 
                //allows us to read the content of a txt file 
                StreamReader sr = new StreamReader(fd.OpenFile());

                int OpenedFile = int.Parse(sr.ReadLine());
                Numbers = new int[OpenedFile];

                //insert marks into array
                //records stores how many times you have to read in 
                for (int i = 0; i < OpenedFile; i++)
                {
                    Numbers[i] = int.Parse(sr.ReadLine());
                }

                MessageBox.Show("File loaded Sucessfully!");
            }
        }

        private void mnuFileDisplay_Click(object sender, EventArgs e)
        {
            //display each mark stored in array
            string Output = String.Empty; //same as ""

            for (int i = 0; i < Numbers.Length; i++)
            {
                Output = Output + Numbers[i] + "\n";
            }

            lblDisplay.Text = Output;
            lblDisplay.Visible = true;
            btnDuplicate.Visible = true;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            //closes the program when pressing exit
            //Application.Exit();

            if (MessageBox.Show("Do you really want to Exit?", "WinMarks", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //closes the program when pressing exit
                Application.Exit();
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            //create Duplicate array to copy the original numbers into without repeated numbers
           
            //inserts a negative to the numbers that are getting repeated 
            for (int i = 0; i < Numbers.Length; i++)
            {
                for (int j = i + 1; j < Numbers.Length; j++)
                {
                    if (Numbers[i] == Numbers[j])
                    {
                        Numbers[j] = -1;
                    }
                }
            }
            //counts the number of -1's and subtracts it from array length
            int Counter = 0;
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] == -1) 
                {
                    Counter++;
                }
            }
            int[] Duplicate = new int[Numbers.Length - Counter];

            int InsertIndex = 0;

            //copying the values over to the Duplicate array
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] != -1)
                {
                    Duplicate[InsertIndex] = Numbers[i];
                    InsertIndex++;
                }
            }
            //displays duplicate array
            string Output = String.Empty; //same as ""

            for (int i = 0; i < Duplicate.Length; i++)
            {
                Output = Output + Duplicate[i] + "\n";
            }

            lblDuplicate.Text = Output;
            lblDuplicate.Visible = true; 
        }
    }
}
