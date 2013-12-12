using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3.XML
{
    public partial class MainForm : Form
    {
        private DataBase dataBase;

        public MainForm()
        {
            InitializeComponent();
            dataBase = new DataBase(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = dataBase.GetNodes();
            richTextBox1.Clear();
            richTextBox1.AppendText(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBase.CreateNode();
        }
    }
}
