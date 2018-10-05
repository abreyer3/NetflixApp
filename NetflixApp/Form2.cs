/*
 * Netflix Database Application using N-Tier Design.
 * 
 * Allen Breyer III
 * U. of Illinois, Chicago
 * CS341, Spring 2018
 * Project 08
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NetflixApp
{
    // This Form is used to ask for user input regarding Top-N Movies by Average Rating
    public partial class Form2 : Form
    {
        public int userInput { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i;
            // Test to see if the user input is an integer
            bool success = int.TryParse(this.textBox1.Text, out i);

            if (success == true)
            {
                userInput = System.Int32.Parse(this.textBox1.Text);
            }
            else
            {
                userInput = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
