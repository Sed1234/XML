using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Lesson2408.Nodes;

namespace Lesson2408
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            XmlDeclaration prolog = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
            doc.AppendChild(prolog);
            XmlElement root = doc.CreateElement("newses");

            foreach (News test in Exmpl02())
            {
                Console.WriteLine(test);
                root.AppendChild(Exmpl03(test, doc));
            }
            doc.AppendChild(root);
            doc.Save("habNews.xml");

        }

        static void Exmpl01()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration prolog = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
            doc.AppendChild(prolog);
            XmlElement root = doc.CreateElement("users");
            XmlElement user = doc.CreateElement("user");
            XmlAttribute attr = doc.CreateAttribute("id");
            attr.InnerText = "151";
            user.Attributes.Append(attr);
            XmlElement fName = doc.CreateElement("fname");
            fName.InnerText = "Lynda";
            user.AppendChild(fName);
            XmlElement sName = doc.CreateElement("sname");
            sName.InnerText = "Stiven";
            user.AppendChild(sName);
            XmlElement eMail = doc.CreateElement("eMail");
            eMail.InnerText = "SLynda@google.com";
            user.AppendChild(eMail);
            root.AppendChild(user);
            doc.AppendChild(root);
            doc.Save("Blond.xml");
        }

        static List<News> Exmpl02()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://habrahabr.ru/rss/interesting");

            var items = doc.SelectNodes("rss/channel/item");
            List<News> New = new List<News>();

            foreach(XmlNode item in items)
            {
                News b = new News();
                b.Title = item.SelectSingleNode("title").InnerText;
                b.Link = item.SelectSingleNode("link").InnerText;
                b.Description = item.SelectSingleNode("description").InnerText;
                string str = item.SelectSingleNode("pubDate").InnerText;
                DateTime time;
                DateTime.TryParse(str, out time);
                b.pubDate = time;
                New.Add(b);

                XmlNode title = item.SelectSingleNode("title");
               // Console.WriteLine(title.InnerText);

                //XmlNode link = item.SelectSingleNode("link");
                //Console.WriteLine(link.InnerText);
                //XmlNode description = item.SelectSingleNode("description");
                //Console.WriteLine(description.InnerText);
            }
            

            return New;

            //return;
            //XmlElement root = doc.DocumentElement;
            //foreach(XmlNode channel in root.ChildNodes)
            //{
            //    foreach (XmlNode element in channel.ChildNodes)
            //    {
            //        Console.WriteLine(element.Name);
            //        if (element.Name == "item")
            //        {
            //            foreach (XmlNode element_item in element.ChildNodes)
            //            {
            //                if (element_item.Name=="title" || element_item.Name == "link" || element_item.Name == "description" || element_item.Name == "pubDate")
            //                Console.WriteLine(element_item.InnerText);
            //            }
            //        }
            //        Console.WriteLine("======================");
            //    }

            //}
        }

        static XmlElement Exmpl03(News news, XmlDocument doc)
        {
            XmlElement root = doc.CreateElement("news");

            XmlElement title = doc.CreateElement("TITLE");
            XmlElement link = doc.CreateElement("LINK");
            XmlElement fName = doc.CreateElement("DESCRIPTION");
            XmlElement pDate = doc.CreateElement("PUBDATE");

            title.InnerText = news.Title;
            link.InnerText = news.Link;
            fName.InnerText = news.Description;
            pDate.InnerText = news.pubDate.ToString();

            root.AppendChild(title);
            root.AppendChild(link);
            root.AppendChild(fName);
            root.AppendChild(pDate);

            return root;
        }


    }


}
