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
            string title = titleCheck.Checked ? this.title.Text : "";
            string genre = genreCheck.Checked ? this.genres.SelectedItem.ToString() : "";
            int fromYear = yearCheck.Checked ? this.fromYear.Value.Year : -1;
            int toYear = yearCheck.Checked ? this.toYear.Value.Year : -1;
            string country = countryCheck.Checked ? this.countries.SelectedItem.ToString() : "";
            string director = directorCheck.Checked ? this.director.Text : "";
            string actor = directorCheck.Checked ? this.director.Text : "";
            int imdbRate;
            try
            {
                imdbRate = imdbRateCheck.Checked ? Convert.ToInt32(this.imdbRate.Text) : -1;
            }
            catch (System.FormatException)
            {
                imdbRate = -1;
                this.imdbRate.Text = "";
                //imdbRateFormatError
            }
            catch (System.OverflowException)
            {
                imdbRate = -1;
                this.imdbRate.Text = "";
                //imdbRateFormatError
            }
            if (imdbRate < 0)
            {
                imdbRate = -1;
                this.imdbRate.Text = "";
            }
            double kinopoiskRate;
            try
            {
                kinopoiskRate = kinopoiskRateCheck.Checked ? Convert.ToDouble(this.kinopoiskRate.Text) : -1;
            }
            catch (System.FormatException)
            {
                kinopoiskRate = -1;
                this.kinopoiskRate.Text = "";
                //kinopoiskRateFormatError
            }
            catch (System.OverflowException)
            {
                kinopoiskRate = -1;
                this.kinopoiskRate.Text = "";
                //kinpoiskRateFormatError
            }
            if (kinopoiskRate < 0)
            {
                kinopoiskRate = -1;
                this.kinopoiskRate.Text = "";
            }
            string anotation = anotationCheck.Checked ? this.anotation.Text : "";
            int length;
            try
            {
                length = lengthCheck.Checked ? Convert.ToInt32(this.length.Text) : -1;
            }
            catch (System.FormatException)
            {
                length = -1;
                this.length.Text = "";
                //lengthFormatError
            }
            catch (System.OverflowException)
            {
                length = -1;
                this.length.Text = "";
                //lengthFormatError
            }
            if (length < 0)
            {
                length = -1;
                this.length.Text = "";
            }
            string result = dataBase.GetResult(title, genre, fromYear, toYear, country, director, actor, imdbRate,
                kinopoiskRate, anotation, length);
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
