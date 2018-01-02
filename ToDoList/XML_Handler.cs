using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ToDoList
{
    public class XML_Handler
    {
        public List<XML_Handler> calendar = new List<XML_Handler>();

        private string date;
        private string[] entries;

        public XML_Handler()
        {

        }

        private XML_Handler(string date, string[] entries)
        {
            this.date = date;
            this.entries = entries;
        }

        public string Date
        {
            get { return date; }

            set
            {
                if (string.IsNullOrEmpty(date))
                    date = value;
            }
        }

        public string[] Entries
        {
            get { return entries; }

            set
            {
                if (entries == null)
                    entries = value;
            }
        }

        public void Create()
        {
            XmlTextWriter newFile = new XmlTextWriter("todolist.xml", new UnicodeEncoding());

            newFile.WriteStartDocument();
            newFile.WriteStartElement("Calendar");
            newFile.WriteEndElement();
            newFile.Close();
        }

        public void AddEntry(string date, string entry)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("todolist.xml");

            // Wurzelknoten abfragen -> nur einer pro XML erlaubt
            XmlNode root = doc.DocumentElement;

            // Prüfe ob Knoten (Datum) bereits vorhanden
            XmlNode node = doc.SelectSingleNode("//day" + date);

            // wenn Knoten bereits vorhanden
            if (node != null)
            {
                MessageBox.Show(date + " bereits vorhanden");

                // Unterknoten (Eintrag) erzeugen
                XmlElement newEntry = doc.CreateElement("entry");
                newEntry.SetAttribute("note", entry);

                // Knoten anhängen
                node.AppendChild(newEntry);
            }

            // wenn Knoten noch nicht vorhanden
            else
            {
                MessageBox.Show(date + " noch nicht vorhanden");

                // Neuen Knoten (Datum) erzeugen
                XmlElement newNode = doc.CreateElement("day" + date);

                // Unterknoten (Eintrag) erzeugen
                XmlElement newEntry = doc.CreateElement("entry");
                newEntry.SetAttribute("note", entry);

                // Knoten anhängen
                newNode.AppendChild(newEntry);
                root.AppendChild(newNode);
            }

            doc.Save("todolist.xml");
        }

        public void Read()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("todolist.xml");

            XmlNode root = doc.DocumentElement;
            GetNodes(root);
        }

        private void GetNodes(XmlNode node)
        {
            switch (node.NodeType)
            {
                case XmlNodeType.Element:

                    // Erfasse Tages-Ereignisse in Array und übergebe an Obj
                    if (node.HasChildNodes && node.Name != "Calendar")
                    {
                        int index = 0;
                        string date = node.Name.Substring(3);
                        string[] entries = new string[node.ChildNodes.Count];
                        
                        // Ereignisse
                        foreach (XmlNode child in node.ChildNodes)                        
                            foreach (XmlAttribute attr in child.Attributes)
                            {
                                entries[index] = attr.InnerText;
                                index++;
                            }

                        // Füge Objekt (Tag) Liste hinzu
                        XML_Handler Day = new XML_Handler(date, entries);                        
                        calendar.Add(Day);
                    }

                    // rekursiver Methodenaufruf, wenn Unterknoten keine Attribute besitzt
                    if (node.HasChildNodes)
                        foreach (XmlNode child in node.ChildNodes)
                            if (child.Attributes.Count == 0)
                                GetNodes(child);

                    break;

                case XmlNodeType.Text:
                    MessageBox.Show(node.Value);
                    break;
            }
        }                        
    }
}
