using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }
        // close the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // when Go! button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
        // set up actions to be carried out when navigating to a webpage.
        private void NavigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);
            toolStripStatusLabel1.Text = "Loading...";

        }
        // wait for a specific key to be pressed which should be enter.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter) {
                NavigateToPage();
                e.Handled = true;
            }
        }
        // when the browser has finished loading the webpage, run this function.
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Done.";
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            // make sure that the progress bar doesn't do anything unless current progress AND maximum progress is greater than 0
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {

                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // do nothing because nothing.
        }
        private void goHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // my workaround for the homepage button.
            // set url of homepage
            textBox1.Text = "https://encrypted.google.com";
            // go to homepage.
            NavigateToPage();
        }
        private void catsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement image in webBrowser1.Document.Images) {
                image.SetAttribute("src", "https://i.ytimg.com/vi/icqDxNab3Do/maxresdefault.jpg");
            }
        }

        private void kimJongMemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //do nothing because nothing.
        }

        private void dogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement image in webBrowser1.Document.Images)
            {
                image.SetAttribute("src", "http://designbump.com/wp-content/uploads/2014/07/funny-dog-91_1.jpg");
            }
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement image in webBrowser1.Document.Images)
            {
                image.SetAttribute("src", "http://images.complex.com/complex/image/upload/t_article_image/fltnuazwwpoh8eat1j3k.jpg");
            }
        }

        private void randomShitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement image in webBrowser1.Document.Images)
            {
                image.SetAttribute("src", "http://img.memecdn.com/rmx-oh-shit_o_813170.jpg");
            } 
        }
    }
}
