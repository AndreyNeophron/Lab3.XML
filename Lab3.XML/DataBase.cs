using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Lab3.XML
{
    class DataBase
    {
        private MainForm _mainForm;
        private string _filePath = null;
        private XmlQuery _dataBaseQuery = new XmlQuery();

        public DataBase(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        private void Init(XDocument dataBase)
        {
            try
            {
                var genres = (from film in dataBase.Descendants("genre")
                              select film.Nodes().FirstOrDefault().ToString()).ToList();
                genres = genres.Distinct().ToList();
                _mainForm.UpdateGenres(genres);
                var countries = (from film in dataBase.Descendants("country")
                               select film.Nodes().FirstOrDefault().ToString()).ToList();
                countries = countries.Distinct().ToList();
                _mainForm.UpdateCountries(countries);
            }
            catch (Exception)
            {
                //View xmlFileInitError
            }
        }

        public void LoadXmlDocument(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                _mainForm.ChangeXmlPath(_filePath ?? "");
                //View LoadXmlDocumentError
                return;
            }
            try
            {
                var dataBase = XDocument.Load(path);
                _filePath = path;
                _mainForm.ChangeXmlPath(path);
                Init(dataBase);
                _dataBaseQuery.LoadXmlFile(path);
                _dataBaseQuery.LinqToXmlQuery();                
            }
            catch (Exception)
            {
               _mainForm.ChangeXmlPath(_filePath ?? "");
                //View LoadXmlDocumentError
            }
        }

        /*
         * queryMethod:
         * 1 - LinqToXml
         * 2 - XPath (Dom)
         * 3 - Simple (Sax)
         */
        public void GetResult(string title, string genre, int fromYear, int toYear, string country, string director,
            string actor, int imdbRate, double kinopoiskRate, string anotation, int length, int queryMethod)
        {
            _dataBaseQuery.Title = title;
            _dataBaseQuery.Genre = genre;
            _dataBaseQuery.FromYear = fromYear;
            _dataBaseQuery.ToYear = toYear;
            _dataBaseQuery.Country = country;
            _dataBaseQuery.Director = director;
            _dataBaseQuery.Actor = actor;
            _dataBaseQuery.ImdbRate = imdbRate;
            _dataBaseQuery.KinopoiskRate = kinopoiskRate;
            _dataBaseQuery.Anotation = anotation;
            _dataBaseQuery.Length = length;
            switch (queryMethod)
            {
                case 1:
                    _mainForm.ViewResult(_dataBaseQuery.LinqToXmlQuery());
                    break;
                case 2:
                    _mainForm.ViewResult(_dataBaseQuery.XPathQuery());
                    break;
            }
        }

        public void MakeXslTransform()
        {
            
        }

        //public void CreateNode()
        //{
        //    var node = _studentDatabase.SelectSingleNode("//rate");
        //    node.Attributes["IMDB"].Value = "2";
        //    var node = _studentDatabase.SelectSingleNode("//country");
        //    node.FirstChild.Value = "Росія";
        //    node.AppendChild(_studentDatabase.CreateTextNode("zskjfgkjzfskbgkbsfg"));
        //    root.AppendChild(node);
        //    _studentDatabase.Save(@"d:\Projects\UnivProjects\Lab3.XML\Lab3.XML\newBase.xml");
        //}
    }
}
