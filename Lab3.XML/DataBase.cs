using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Lab3.XML
{
    class DataBase
    {
        private XmlDocument _studentDatabase;
        private MainForm _mainForm;
        private const string FilePath = @"d:\Projects\UnivProjects\Lab3.XML\Lab3.XML\Base.xml";

        public DataBase(MainForm mainForm)
        {
            this._mainForm = mainForm;
            LoadXmlDocument(FilePath);
        }

        void LoadXmlDocument(string path)
        {
            if (_studentDatabase == null)
                _studentDatabase = new XmlDocument();
            _studentDatabase.Load(path);
        }

        public string GetNodes()
        {
            return GetNodes(_studentDatabase.DocumentElement);
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
            _studentDatabase.Save(@"d:\Projects\UnivProjects\Lab3.XML\Lab3.XML\newBase.xml");
        }
    }
}
