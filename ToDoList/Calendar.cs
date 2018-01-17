using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ToDoList
{
    public class Calendar
    {
        public List<Calendar> calendar = new List<Calendar>();

        private string date;
        private string[] entries;

        public Calendar()
        {

        }

        private Calendar(string date, string[] entries)
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

        public bool AddEntry(string date, string entry)
        {
            // check for dublicates (better performance with hash-table?)
            foreach (Calendar day in calendar)            
                if (day.Date == date)                
                    foreach (string dateEntry in day.Entries)                    
                        if (dateEntry == entry)                        
                            return false;

            try
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
                    // Unterknoten (Eintrag) erzeugen
                    XmlElement newEntry = doc.CreateElement("entry");
                    newEntry.SetAttribute("note", entry);

                    // Knoten anhängen
                    node.AppendChild(newEntry);
                }

                // wenn Knoten noch nicht vorhanden
                else
                {
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

                return true;
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        public void Read()
        {
            // vorherige Einträge löschen
            calendar.Clear();

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
                        Calendar Day = new Calendar(date, entries);
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

        public void Remove(string dateNode, string entryAttribute)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("todolist.xml");

            // select node in XML document
            XmlNode node = doc.SelectSingleNode("//day" + dateNode);

            // delete parent node
            if(node.ChildNodes.Count == 1)
            {
                node.ParentNode.RemoveChild(node);
            }

            // delete child node
            if (node.ChildNodes.Count >= 2)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    foreach (XmlAttribute attr in child.Attributes)
                        if (attr.Value == entryAttribute)
                            node.RemoveChild(child);
                }
            }

            doc.Save("todolist.xml");
        }
    }
}
