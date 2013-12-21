using System;
using System.Collections.Generic;
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
            _genre = "кримінал";
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
                            (Math.Abs(_kinopoiskRate + 1) < 1e-6 || (double)film.Descendants("rate").FirstOrDefault().Attribute("kinopoisk") >= _kinopoiskRate) &&
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
            foreach (var item in result)
            {
                resultString.Append("Назва: " + item.title);
                resultString.AppendLine();
                for (int i = 0; i < item.genres.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Жанри: " + item.genres[i]);
                    else
                        resultString.Append(", " + item.genres[i]); 
                }
                resultString.AppendLine();
                resultString.Append("Рік: " + item.year);
                resultString.AppendLine();
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
                resultString.Append("Рейтинг IMDB: " + item.imdbRate);
                resultString.AppendLine();
                resultString.Append("Рейтинг Кінопошуку: " + item.kinopoiskRate);
                resultString.AppendLine();
                resultString.Append("Час: " + item.length + " хв");
                resultString.AppendLine();
                resultString.Append("Анотація:\n" + item.anotation);
                resultString.AppendLine();
                resultString.AppendLine();
            }
            return resultString.ToString();
        }

        public string XPathQuery()
        {
            if (_domDataBase == null)
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
                            (Math.Abs(_kinopoiskRate + 1) < 1e-6 || (double)film.Descendants("rate").FirstOrDefault().Attribute("kinopoisk") >= _kinopoiskRate) &&
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
            foreach (var item in result)
            {
                resultString.Append("Назва: " + item.title);
                resultString.AppendLine();
                for (int i = 0; i < item.genres.Count; i++)
                {
                    if (i == 0)
                        resultString.Append("Жанри: " + item.genres[i]);
                    else
                        resultString.Append(", " + item.genres[i]);
                }
                resultString.AppendLine();
                resultString.Append("Рік: " + item.year);
                resultString.AppendLine();
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
                resultString.Append("Рейтинг IMDB: " + item.imdbRate);
                resultString.AppendLine();
                resultString.Append("Рейтинг Кінопошуку: " + item.kinopoiskRate);
                resultString.AppendLine();
                resultString.Append("Час: " + item.length + " хв");
                resultString.AppendLine();
                resultString.Append("Анотація:\n" + item.anotation);
                resultString.AppendLine();
                resultString.AppendLine();
            }
            return resultString.ToString();
        }
    }
}
