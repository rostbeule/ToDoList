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
            LstDate.Items.Clear();
            ChkLstEntries.Items.Clear();

            // File einlesen
            XML.Read();

            // Einträge sortieren
            XML.calendar.Sort(new SortAscending());

            // Einträge ausgeben
            foreach (XML_Handler day in XML.calendar)
            {
                LstDate.Items.Add(day.Date);

                LblOut.Text += day.Date + Environment.NewLine;

                foreach (string entry in day.Entries)
                {
                    LblOut.Text += entry + Environment.NewLine;
                }

                LblOut.Text += Environment.NewLine;
            }
        }

        // Entrferne ausgewählten eintrag
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            // Mehrfachauswahl möglich, rückwärts löschen
            for (int i = ChkLstEntries.CheckedItems.Count - 1; i >= 0; i--)
            {
                XML.Remove(LstDate.SelectedItem.ToString(), ChkLstEntries.CheckedItems[i].ToString());                
            }
        }

        // Hole Einträge für ausgewähltes Datum
        private void LstDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkLstEntries.Items.Clear();

            foreach (string entry in XML.calendar[LstDate.SelectedIndex].Entries)
            {
                ChkLstEntries.Items.Add(entry);
            }
        }
    }
}
