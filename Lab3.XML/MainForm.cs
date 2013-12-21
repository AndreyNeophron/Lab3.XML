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
            dataBase.LoadXmlDocument(xmlPath.Text);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string result = dataBase.GetResult();
            resultView.Clear();
            resultView.AppendText(result);
        }

        private void xmlPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataBase.LoadXmlDocument(xmlPath.Text);
            }
        }

        public void ChangeXmlPath(string path)
        {
            xmlPath.Text = path;
        }

        public void UpdateGenres(List<string> genres)
        {
            if (genres == null)
                return;
            this.genres.Items.Clear();
            this.genres.Items.Add("");
            foreach (var genre in genres)
                this.genres.Items.Add(genre);
        }

        public void UpdateCountries(List<string> countries)
        {
            if (countries == null)
                return;
            this.countries.Items.Clear();
            this.countries.Items.Add("");
            foreach (var country in countries)
                this.countries.Items.Add(country);
        }
    }
}
