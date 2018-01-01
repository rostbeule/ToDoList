using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        private XML_Handler XML = new XML_Handler();

        public Form1()
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
            // aktuell unsortiert...
            LblOut.Text = "unsortiert...\n\n";

            XML.Read();

            foreach(XML_Handler Day in XML.calendar)
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
