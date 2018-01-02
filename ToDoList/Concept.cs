using System;
using System.IO;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Concept : Form
    {
        private XML_Handler XML = new XML_Handler();

        public Concept()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TransparencyKey = BackColor;
        }
        
        // Erzeuge neue XML Datei
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!File.Exists("ToDoList.xml"))
            {
                XML.Create();

                MessageBox.Show("neues File wurde erzeugt");
            }
            else
                MessageBox.Show("File bereits vorhanden");
        }        

        // Neuer Kalendereintrag
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            XML.AddEntry(DtpCalendar.Value.ToShortDateString(), TxtCalendar.Text);
        }

        // Lese Einträge aus XML Datei
        private void BtnRead_Click(object sender, EventArgs e)
        {
            // Zurücksetzen
            LblOut.Text = string.Empty;
            
            // File einlesen
            XML.Read();

            // Einträge sortieren
            XML.calendar.Sort(new SortAscending());

            // Einträge ausgeben
            foreach (XML_Handler Day in XML.calendar)
            {
                LblOut.Text += Day.Date + Environment.NewLine;

                foreach(string entry in Day.Entries)
                {
                    LblOut.Text += entry + Environment.NewLine;
                }

                LblOut.Text += Environment.NewLine;
            }           
        }

        // todo...
        private void BtnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
