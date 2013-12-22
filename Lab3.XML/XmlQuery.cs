using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Lab3.XML
{
    class XmlQuery
    {
        XDocument _linqDataBase = null;
        XmlDocument _domDataBase = new XmlDocument();
        XmlReader _saxDataBase = null;

        string _title;
        string _genre;
        int _fromYear, _toYear;
        string _country;
        string _director;
        string _actor;
        int _imdbRate;
        double _kinopoiskRate;
        string _anotation;
        int _length;

        public string Title
        {
            get { return _title; }
            set { _title = value ?? ""; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value ?? ""; }
        }

        public int FromYear
        {
            get { return _fromYear; }
            set { _fromYear = value >= 0 ? value : -1; }
        }

        public int ToYear
        {
            get { return _toYear; }
            set { _toYear = value >= 0 ? value : -1; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value ?? ""; }
        }

        public string Director
        {
            get { return _director; }
            set { _director = value ?? ""; }
        }

        public string Actor
        {
            get { return _actor; }
            set { _actor = value ?? ""; }
        }

        public int ImdbRate
        {
            get { return _imdbRate; }
            set { _imdbRate = value > 0 ? value : -1; }
        }

        public double KinopoiskRate
        {
            get { return _kinopoiskRate; }
            set { _kinopoiskRate = value > -1e-6 ? value : -1; }
        }

        public string Anotation
        {
            get { return _anotation; }
            set { _anotation = value ?? ""; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value > 0 ? value : -1; }
        }

        public XmlQuery()
        {
            ClearQuery();
        }

        public void ClearQuery()
        {
            _title = "";
            _genre = "";
            _fromYear = -1;
            _toYear = -1;
            _country = "";
            _director = "";
            _actor = "";
            _imdbRate = -1;
            _kinopoiskRate = -1;
            _anotation = "";
            _length = -1;
        }

        public bool LoadXmlFile(string path)
        {
            if (String.IsNullOrEmpty(path))
                return false;
            try
            {            
                _linqDataBase = XDocument.Load(path);
                _domDataBase.Load(path);
                _saxDataBase = new XmlTextReader(path);
                ClearQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string LinqToXmlQuery()
        {
            if (_linqDataBase == null)
                return "";
            var result = (from film in _linqDataBase.Descendants("film")
                          where (
                            film.Descendants("title").FirstOrDefault().FirstNode.ToString().Contains(_title) &&
                            (_genre == "" || film.Descendants("genre").ToList().Exists(a => (a.FirstNode.ToString() == _genre))) &&
                            (_fromYear == -1 || (Convert.ToInt32(film.Descendants("year").FirstOrDefault().FirstNode.ToString()) >= _fromYear || Convert.ToInt32(film.Descendants("year").FirstOrDefault().FirstNode.ToString()) <= _toYear)) &&
                            (_country == "" || film.Descendants("country").ToList().Exists(a => a.FirstNode.ToString() == _country)) &&
                            film.Descendants("director").ToList().Exists(a => a.FirstNode.ToString().Contains(_director)) &&
                            film.Descendants("character").ToList().Exists(a => a.FirstNode.ToString().Contains(_actor)) &&
                            (_imdbRate == -1 || (int)film.Descendants("rate").FirstOrDefault().Attribute("IMDB") >= _imdbRate) &&
                            (Math.Abs(_kinopoiskRate + 1) < 1e-6 || (double)film.Descendants("rate").FirstOrDefault().Attribute("kinopoisk") >= _kinopoiskRate - 1e-6) &&
                            film.Descendants("anotation").FirstOrDefault().FirstNode.ToString().Contains(_anotation) &&
                            (_length == -1 || Convert.ToInt32(film.Descendants("length").FirstOrDefault().FirstNode.ToString()) >= _length)
                          )
                          select new
                          {
                              title = film.Descendants("title").FirstOrDefault().FirstNode.ToString(),
                              genres = (from genre in film.Descendants("genre")
                                       select genre.FirstNode.ToString()).ToList(),
                              year = Convert.ToInt32(film.Descendants("year").FirstOrDefault().FirstNode.ToString()),
                              countries = (from country in film.Descendants("country")
                                         select country.FirstNode.ToString()).ToList(),
                              directors = (from director in film.Descendants("director")
                                          select director.FirstNode.ToString()).ToList(),
                              actors = (from actor in film.Descendants("character")
                                       select actor.FirstNode.ToString()).ToList(),
                              imdbRate = (int)film.Descendants("rate").FirstOrDefault().Attribute("IMDB"),
                              kinopoiskRate = (double)film.Descendants("rate").FirstOrDefault().Attribute("kinopoisk"),
                              anotation = film.Descendants("anotation").FirstOrDefault().FirstNode.ToString(),
                              length = Convert.ToInt32(film.Descendants("length").FirstOrDefault().FirstNode.ToString())
                          }).ToList();
            var resultString = new StringBuilder();
            resultString.AppendLine("Кількість результатів: " + result.Count + "\n");
            foreach (var item in result)
            {
                resultString.AppendLine("Назва: " + item.title);
                for (int i = 0; i < item.genres.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Жанри: " + item.genres[i]);
                    else
                        resultString.Append(", " + item.genres[i]); 
                }
                resultString.AppendLine();
                resultString.AppendLine("Рік: " + item.year);
                for (int i = 0; i < item.countries.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Країни: " + item.countries[i]);
                    else
                        resultString.Append(", " + item.countries[i]);
                }
                resultString.AppendLine();
                for (int i = 0; i < item.directors.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Режисери: " + item.directors[i]);
                    else
                        resultString.Append(", " + item.directors[i]);
                }
                resultString.AppendLine();
                for (int i = 0; i < item.actors.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Актори: " + item.actors[i]);
                    else
                        resultString.Append(", " + item.actors[i]);
                }
                resultString.AppendLine();
                resultString.AppendLine("Рейтинг IMDB: " + item.imdbRate);
                resultString.AppendLine("Рейтинг Кінопошуку: " + item.kinopoiskRate);
                resultString.AppendLine("Час: " + item.length + " хв");
                resultString.AppendLine("Анотація:\n" + item.anotation);
                resultString.AppendLine();
            }
            return resultString.ToString();
        }

        public string XPathQuery()
        {
            XmlDocument resultDocument = (XmlDocument)_domDataBase.CloneNode(true), tempDocument = (XmlDocument)_domDataBase.CloneNode(true);
            XmlNodeList resultNodes;
            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[contains(title, '" + _title + "')]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument) tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film['" + _genre + "'='' or ./genre[child::text()='" + _genre + "']]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[" + _fromYear + "=-1 or (year>=" + _fromYear + " and year<=" + _toYear + ")]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film['" + _country + "'='' or ./country[child::text()='" + _country + "']]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[./director[contains(., '" + _director + "')]]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[./character[contains(., '" + _actor + "')]]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[" + _imdbRate + "=-1 or rate[@IMDB>=" + _imdbRate + "]]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[" + Convert.ToDouble(_kinopoiskRate).ToString("G", CultureInfo.InvariantCulture) + "=-1 or rate[@kinopoisk>=" + (Convert.ToDouble(_kinopoiskRate) - 1e-6).ToString("G", CultureInfo.InvariantCulture) + "]]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[" + _length + "=-1 or length>=" + _length + "]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            resultNodes = resultDocument.SelectNodes("/mediaDatabase/film[contains(anotation, '" + _anotation + "')]");
            tempDocument.SelectSingleNode("mediaDatabase").RemoveAll();
            foreach (XmlNode item in resultNodes)
                tempDocument.SelectSingleNode("mediaDatabase").AppendChild(tempDocument.ImportNode(item, true));
            resultDocument = (XmlDocument)tempDocument.CloneNode(true);

            var resultString = new StringBuilder();
            resultString.AppendLine("Кількість результатів: " +
                                    resultDocument.SelectSingleNode("mediaDatabase").ChildNodes.Count + "\n");
            foreach (XmlNode item in resultDocument.SelectSingleNode("mediaDatabase").ChildNodes)
            {
                resultString.AppendLine("Назва: " + item.SelectSingleNode("title").FirstChild.Value);
                for (int i = 0; i < item.SelectNodes("genre").Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Жанри: " + item.SelectNodes("genre")[i].FirstChild.Value);
                    else
                        resultString.Append(", " + item.SelectNodes("genre")[i].FirstChild.Value);
                }
                resultString.AppendLine();
                resultString.AppendLine("Рік: " + item.SelectSingleNode("year").FirstChild.Value);
                for (int i = 0; i < item.SelectNodes("country").Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Країни: " + item.SelectNodes("country")[i].FirstChild.Value);
                    else
                        resultString.Append(", " + item.SelectNodes("country")[i].FirstChild.Value);
                }
                resultString.AppendLine();
                for (int i = 0; i < item.SelectNodes("director").Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Режисери: " + item.SelectNodes("director")[i].FirstChild.Value);
                    else
                        resultString.Append(", " + item.SelectNodes("director")[i].FirstChild.Value);
                }
                resultString.AppendLine();
                for (int i = 0; i < item.SelectNodes("character").Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Актори: " + item.SelectNodes("character")[i].FirstChild.Value);
                    else
                        resultString.Append(", " + item.SelectNodes("character")[i].FirstChild.Value);
                }
                resultString.AppendLine();
                resultString.AppendLine("Рейтинг IMDB: " + item.SelectSingleNode("rate").Attributes["IMDB"].Value);
                resultString.AppendLine("Рейтинг Кінопошуку: " + item.SelectSingleNode("rate").Attributes["kinopoisk"].Value);
                resultString.AppendLine("Час: " + item.SelectSingleNode("length").FirstChild.Value + " хв");
                resultString.AppendLine("Анотація:\n" + item.SelectSingleNode("anotation").FirstChild.Value);
                resultString.AppendLine();
            }
            return resultString.ToString();
        }

        public string SaxQuery()
        {
            if (_saxDataBase == null)
                return "";
            bool isAddFilm = false,
                isGenreOk = false,
                isCountryOk = false,
                isDirectorOk = false,
                isActorOk = false;
            var filmDate = new StringBuilder();
            var resultString = new StringBuilder();
            int resultCount = 0;
            while (_saxDataBase.Read())
            {
                switch (_saxDataBase.NodeType)
                {
                    case XmlNodeType.Element:
                        if (_saxDataBase.Name == "film")
                        {
                            if (isAddFilm && isGenreOk && isCountryOk && isDirectorOk && isActorOk)
                            {
                                resultString.AppendLine(filmDate.ToString());
                                resultCount++;
                            }
                            filmDate = new StringBuilder();
                            isAddFilm = true;
                            isGenreOk = false;
                            isCountryOk = false;
                            isDirectorOk = false;
                            isActorOk = false;
                        }
                        else if (isAddFilm)
                        {
                            if (_saxDataBase.Name == "title")
                            {
                                _saxDataBase.Read();
                                if (_saxDataBase.Value.Contains(_title))
                                    filmDate.AppendLine("Назва: " + _saxDataBase.Value);
                                else
                                    isAddFilm = false;
                            }
                            else if (_saxDataBase.Name == "genre")
                            {
                                _saxDataBase.Read();
                                if (_genre == "" || _saxDataBase.Value ==_genre)
                                    isGenreOk = true;
                                filmDate.AppendLine("Жанр: " + _saxDataBase.Value);
                            }
                            else if (_saxDataBase.Name == "year")
                            {
                                _saxDataBase.Read();
                                if (_fromYear == -1 || (Convert.ToInt32(_saxDataBase.Value) >= _fromYear && Convert.ToInt32(_saxDataBase.Value) <= _toYear))
                                    filmDate.AppendLine("Рік: " + _saxDataBase.Value);
                                else
                                    isAddFilm = false;
                            }
                            else if (_saxDataBase.Name == "country")
                            {
                                _saxDataBase.Read();
                                if (_country == "" || _saxDataBase.Value == _country)
                                    isCountryOk = true;
                                filmDate.AppendLine("Країна: " + _saxDataBase.Value);
                            }
                            else if (_saxDataBase.Name == "director")
                            {
                                _saxDataBase.Read();
                                if (_director == "" || _saxDataBase.Value.Contains(_director))
                                    isDirectorOk = true;
                                filmDate.AppendLine("Режисер: " + _saxDataBase.Value);
                            }
                            else if (_saxDataBase.Name == "character")
                            {
                                _saxDataBase.Read();
                                if (_actor == "" || _saxDataBase.Value.Contains(_actor))
                                    isActorOk = true;
                                filmDate.AppendLine("Актор: " + _saxDataBase.Value);
                            }
                            else if (_saxDataBase.Name == "rate")
                            {
                                while (_saxDataBase.MoveToNextAttribute())
                                {
                                    if (_saxDataBase.Name == "IMDB")
                                    {
                                        if (_imdbRate == -1 || Convert.ToInt32(_saxDataBase.Value) >= _imdbRate)
                                            filmDate.AppendLine("Рейтинг IMDB: " + _saxDataBase.Value);
                                        else
                                            isAddFilm = false;
                                    }
                                    else if (_saxDataBase.Name == "kinopoisk")
                                    {
                                        var provider = new NumberFormatInfo();
                                        provider.NumberDecimalSeparator = ".";
                                        if (Math.Abs(_kinopoiskRate + 1) < 1e-6 || Convert.ToDouble(_saxDataBase.Value, provider) >= _kinopoiskRate - 1e-6)
                                            filmDate.AppendLine("Рейтинг Кінопошуку: " + _saxDataBase.Value);
                                        else
                                            isAddFilm = false;
                                    }
                                }
                            }
                            else if (_saxDataBase.Name == "length")
                            {
                                _saxDataBase.Read();
                                if (_length == -1 || Convert.ToInt32(_saxDataBase.Value) >= _length)
                                    filmDate.AppendLine("Час: " + _saxDataBase.Value);
                                else
                                    isAddFilm = false;
                            }
                            else if (_saxDataBase.Name == "anotation")
                            {
                                _saxDataBase.Read();
                                if (_saxDataBase.Value.Contains(_anotation))
                                    filmDate.AppendLine("Анотація:\n" + _saxDataBase.Value);
                                else
                                    isAddFilm = false;
                            }
                        }
                        break;
                }
            }
            if (isAddFilm && isGenreOk && isCountryOk && isDirectorOk && isActorOk)
            {
                resultString.AppendLine(filmDate.ToString());
                resultCount++;
            }
            resultString.Insert(0, "Кількість результатів: " + resultCount + "\n\n");
            return resultString.ToString();
        }
    }
}
