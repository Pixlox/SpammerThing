using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixloxSpammer
{
    public partial class Form1 : Form
    {
        string spamText;
        int tInverval; // timer interval variable

        public Form1()
        {
           InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // start button
        {
            if(spamtextbox.Text == "")
            {
                MessageBox.Show("Please input spam text.");
            }
            else if(timerintervalbox.Text == "")
            {
                MessageBox.Show("Please input a timer interval.");
                // System.formatException
            }
            try
                {
                    spamText = spamtextbox.Text.ToString();
                    tInverval = Convert.ToInt32(timerintervalbox.Text); // grab whatevers inside timer interval tb, then convert it into an integer, and put it into tInterval.
                    timer1.Interval = tInverval; // set the interval to whatevers inside tInverval, which is the text inside.
                    timer1.Start(); // start the timer (spam
                } catch(System.FormatException) 
                {
                MessageBox.Show("Please input a valid number in the timer interval box.");
                }

        }
        private void button2_Click(object sender, EventArgs e) // stop button
        {
            timer1.Stop(); // stop the timer
            spamText = "";
            timer1.Interval = 1; // reset timer interval to 1.  
            tInverval = 1; // reset tInterval to 1.
            MessageBox.Show("Spam stopped."); 
        }

        private void timer1_Tick(object sender, EventArgs e) // timer
        {
            spamText = spamtextbox.Text.ToString();
            SendKeys.Send(spamText); // send whatever is inside every 'tick'. which is every [insert tInterval here] ms.
            SendKeys.Send("{Enter}"); // send Enter Key.

            if(atCheckbox.Checked)
            {
                SendKeys.Send("{Enter}"); // sends enter to complete @ send when checked
            }
            else
            {

            } 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/Pixlox/PixloxSpammerThing");
        }
    }
}
