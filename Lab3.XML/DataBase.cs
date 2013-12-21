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
        private XmlQuery dataBaseQuery = new XmlQuery();

        public DataBase(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        private void init(XDocument dataBase)
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
                _mainForm.ChangeXmlPath(_filePath == null ? "" : _filePath);
                //View LoadXmlDocumentError
                return;
            }
            try
            {
                var dataBase = XDocument.Load(path);
                _filePath = path;
                _mainForm.ChangeXmlPath(path);
                init(dataBase);
                dataBaseQuery.LoadXmlFile(path);
                dataBaseQuery.LinqToXmlQuery();                
            }
            catch (Exception)
            {
               _mainForm.ChangeXmlPath(_filePath == null ? "" : _filePath);
                //View LoadXmlDocumentError
            }
        }

        public string GetResult()
        {
            //return GetNodes(_studentDatabase.DocumentElement);
            return "";
        }

        string GetNodes(XmlNode node)
        {
            var result = new StringBuilder();
            GetNodes(node, 0, result);
            return result.ToString();
        }

        void GetNodes(XmlNode node, int level, StringBuilder result)
        {
            result.Append(node.Value);
            foreach (XmlNode n in node.ChildNodes)
            {
                GetNodes(n, level + 1, result);
            }
        }

        public void CreateNode()
        {
            //var node = _studentDatabase.SelectSingleNode("//rate");
            //node.Attributes["IMDB"].Value = "2";
            //var node = _studentDatabase.SelectSingleNode("//country");
            //node.FirstChild.Value = "Росія";
            //node.AppendChild(_studentDatabase.CreateTextNode("zskjfgkjzfskbgkbsfg"));
            //root.AppendChild(node);
            //_studentDatabase.Save(@"d:\Projects\UnivProjects\Lab3.XML\Lab3.XML\newBase.xml");
        }
    }
}
