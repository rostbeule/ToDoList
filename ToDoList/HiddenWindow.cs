using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class HiddenWindow : Form
    {
        private const int panWidth = 200;
        private const int panHeigth = 200;

        private MainWindow mainWindow;

        public HiddenWindow(MainWindow caller)
        {
            mainWindow = caller;
            InitializeComponent();
        }

        private void HiddenWindow_Load(object sender, EventArgs e)
        {
            // HiddenWindow
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - panWidth + 15, MainWindow.topBound);
            this.Size = new Size(panWidth, panHeigth + 50);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;

            // PanelButton
            Panel button = new Panel()
            {
                Location = new Point(0, 0),
                Size = new Size(panWidth - 15, panHeigth),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = FileStore.Resource.Alien_displeased
            };
            button.MouseEnter += new EventHandler(Button_MouseEnter);
            this.Controls.Add(button);   
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Close();
        }
    }
}
