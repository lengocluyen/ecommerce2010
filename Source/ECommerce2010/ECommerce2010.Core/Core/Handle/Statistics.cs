using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ECommerce2010.Core
{
    public class Statistics
    {

        #region Properties
        string _docLink;

        public string DocLink
        {
            get { return _docLink; }
            set { _docLink = value; }
        }
        XmlDocument _docStastics;

        public XmlDocument DocStastics
        {
            get { return _docStastics; }
            set { _docStastics = value; }
        }
        #endregion

        #region Contructions
        public Statistics(string url)
        {
            _docLink = url;
            _docStastics = new XmlDocument();
        }
        public void ReadXml()
        {
            _docStastics.Load(_docLink);
        }
        public void WriteXml()
        {
            _docStastics.Save(_docLink);
        }
        #endregion

        #region Reading and writing 
        public int ReadField(string field)
        {
            try
            {
                ReadXml();
                XmlNode getField = _docStastics.GetElementsByTagName(field)[0];
                return Convert.ToInt32(getField.InnerText);
            }
            catch { return 0; }
        }
       
        public void WriteField(string field, int value)
        {
            ReadXml();
            XmlNode node = _docStastics.GetElementsByTagName(field)[0];
            node.InnerText = value.ToString();
           // _docStastics.GetElementsByTagName(field)[0].Value = value.ToString();
            WriteXml();
        }
        public int GetVisiterInDay()
        {
            XmlNode node = _docStastics.GetElementsByTagName("totalvisitsday")[0];
            int total = Convert.ToInt32(node.InnerText) + 1;
            if (Convert.ToInt32(node.Attributes[0].InnerText) == DateTime.Now.Day)
                node.InnerText = total.ToString();
            else
            {
                node.InnerText = "1";
                node.Attributes[0].InnerText = DateTime.Now.Day.ToString();
            }
            _docStastics.Save(_docLink);
            return total;
        }
        public int GetVisiterInMonth()
        {
            XmlNode node = _docStastics.GetElementsByTagName("totalvisitmoth")[0];
            int total = Convert.ToInt32(node.InnerText) + 1;
            if (Convert.ToInt32(node.Attributes[0].InnerText) == DateTime.Now.Month)
                node.InnerText = total.ToString();
            else
            {
                node.InnerText = "1";
                node.Attributes[0].InnerText = DateTime.Now.Month.ToString();
            }
            _docStastics.Save(_docLink);
            return total;
        }
        public int GetVisiterInWeek()
        {
            XmlNode node = _docStastics.GetElementsByTagName("totalvisitsweek")[0];
            int total = Convert.ToInt32(node.InnerText) + 1;
            if (Convert.ToInt32(node.Attributes[0].InnerText) == 1 || Convert.ToInt32(node.Attributes[0].InnerText) == 7 || Convert.ToInt32(node.Attributes[0].InnerText) == 21 || Convert.ToInt32(node.Attributes[0].InnerText) == 14)
                node.InnerText = "1";
            else node.InnerText = total.ToString();
           
             node.Attributes[0].InnerText = DateTime.Now.Day.ToString();
            _docStastics.Save(_docLink);
            return total;
        }
        public int Ramdom(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        #endregion
    }
     
}
