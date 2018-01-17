using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class MainWindow : Form
    {
        // current window position/size
        private static int rgtBound;
        public const int topBound = 0;

        // current app size (start values)
        private const int startAppWidth = 300;
        private const int startAppHeigth = 600;
        private static int lastAppWidth;
        private static int appWidth;
        private static int appHeigth;

        // tree position
        private const int treeOffset_PosX = 0;
        private const int treeOffset_PosY = 0;

        // window hide/show
        private const int delayTime = 10;
        private const int deltaSize = 50;
        private static bool hidden = false;

        // instances
        private TreeView tree = new TreeView();
        private Calendar xml = new Calendar();

        // font
        private int size = 10;
        private string font = "Arial";
        private FontStyle style = FontStyle.Regular;

        NotifyIcon notifyIcon = new NotifyIcon();

        public MainWindow()
        {
            InitializeComponent();
            
            notifyIcon.Icon = FileStore.Resource.purpleMonster;
            notifyIcon.Visible = true;
            notifyIcon.Text = "ToDo";

            CreateXML();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // formular settings
            FormBorderStyle = FormBorderStyle.None;
            appWidth = startAppWidth;
            appHeigth = startAppHeigth;
            ResizeWindow(appWidth, appHeigth);

            // initialize controls
            Initialize_PanelNew();
            Initialize_PanelEdit();
            InitializeTreeView(appWidth, appHeigth);

            // get data
            ReadXML();
            FillTree();
        }


        #region initialize components

        private void CreateXML()
        {
            if (!File.Exists("ToDoList.xml"))
            {
                xml.Create();

                //MessageBox.Show("neues File wurde erzeugt");
            }
            //else
            //MessageBox.Show("File bereits vorhanden");
        }

        private void ResizeWindow(int appWidth, int appHeigth)
        {
            int scrWidth = Screen.PrimaryScreen.Bounds.Width;
            //int scrHeigth = Screen.PrimaryScreen.Bounds.Height; // not used so far

            // position applications rigth bound
            rgtBound = scrWidth - appWidth;

            // define windows position and size
            Location = new Point(rgtBound, topBound);
            Width = scrWidth - rgtBound;
            Height = appHeigth;
        }

        private void InitializeTreeView(int appWidth, int appHeigth)
        {
            // settings
            tree.Name = "Tree";
            tree.Location = new Point(treeOffset_PosX, MnuStrip.Height + treeOffset_PosY);
            tree.Size = new Size(appWidth, appHeigth - treeOffset_PosY);
            tree.BorderStyle = BorderStyle.FixedSingle;
            tree.Font = new Font(font, size, style);
            tree.BorderStyle = BorderStyle.None;
            tree.ShowPlusMinus = false;
            tree.ShowLines = false;


            Controls.Add(tree);

            // EventHandler calls method to hide MainWindow if mouse leaves TreeView            
            tree.MouseLeave += new EventHandler(HideWindow_MouseLeave);

            // Eventhandler for right click opens ContextMenu 
            tree.NodeMouseClick += Node_Click;
        }

        private void Initialize_PanelNew()
        {
            int distBoarder = 3, distElement = 10;

            // PanNew dynamic settings
            PanNew.Location = new Point(0, MnuStrip.Height + distBoarder);
            PanNew.Size = new Size(appWidth, PanNew_DateTimePicker.Height + PanNew_TextBox.Height + 3 * distBoarder);
            //
            // DateTimePicker
            //
            PanNew_DateTimePicker.Location = new Point(distBoarder, distBoarder);
            PanNew_DateTimePicker.Size = new Size(100, PanNew_DateTimePicker.Height);
            //
            // TextBox
            //
            PanNew_TextBox.Location = new Point(distBoarder, 2 * distBoarder + PanNew_DateTimePicker.Height);
            PanNew_TextBox.Size = new Size(appWidth - PanNew_BtnAdd.Width - distElement - distBoarder, PanNew_TextBox.Height);
            PanNew_TextBox.Text = string.Empty;
            //
            // BtnCancel
            //
            PanNew_BtnCancel.Location = new Point(appWidth - distBoarder - PanNew_BtnCancel.Width, distBoarder);
            PanNew_BtnCancel.Size = new Size(50, PanNew_BtnCancel.Height);
            PanNew_BtnCancel.Click += new EventHandler(Cancel_Click);
            //
            // BtnAdd
            //
            PanNew_BtnAdd.Location = new Point(appWidth - distBoarder - PanNew_BtnAdd.Width, 2 * distBoarder + PanNew_DateTimePicker.Height);
            PanNew_BtnAdd.Size = new Size(50, PanNew_BtnAdd.Height);
            PanNew_BtnAdd.Click += new EventHandler(Add_Click);

            // hide PanNew
            PanNew.Hide();
        }

        private void Initialize_PanelEdit()
        {
            int distBoarder = 3, distElement = 10;

            // PanEdit dynamic settings
            PanEdit.Location = new Point(0, MnuStrip.Height + distBoarder);
            PanEdit.Size = new Size(appWidth, PanEdit_DateTimePicker.Height + PanEdit_TextBox.Height + 3 * distBoarder);
            //
            // DateTimePicker
            //
            PanEdit_DateTimePicker.Location = new Point(distBoarder, distBoarder);
            PanEdit_DateTimePicker.Size = new Size(100, PanEdit_DateTimePicker.Height);
            //
            // TextBox
            //
            PanEdit_TextBox.Location = new Point(distBoarder, 2 * distBoarder + PanEdit_DateTimePicker.Height);
            PanEdit_TextBox.Size = new Size(appWidth - PanEdit_BtnEdit.Width - distElement - distBoarder, PanEdit_TextBox.Height);
            PanEdit_TextBox.Text = string.Empty;
            //
            // BtnCancel
            //
            PanEdit_BtnCancel.Location = new Point(appWidth - distBoarder - PanEdit_BtnCancel.Width, distBoarder);
            PanEdit_BtnCancel.Size = new Size(50, PanEdit_BtnCancel.Height);
            PanEdit_BtnCancel.Click += new EventHandler(Cancel_Click);
            //
            // BtnEdit
            //
            PanEdit_BtnEdit.Location = new Point(appWidth - distBoarder - PanEdit_BtnEdit.Width, 2 * distBoarder + PanEdit_DateTimePicker.Height);
            PanEdit_BtnEdit.Size = new Size(50, PanEdit_BtnEdit.Height);
            PanEdit_BtnEdit.Click += new EventHandler(Edit_Click);
            //
            // BtnMove
            //
            PanEdit_ChkMove.Location = new Point(2 * distBoarder + PanEdit_DateTimePicker.Width, distBoarder + PanEdit_DateTimePicker.Height / 2 - PanEdit_ChkMove.Height / 2);
            PanEdit_ChkMove.Size = new Size(50, PanEdit_ChkMove.Height);
            PanEdit_ChkMove.Click += new EventHandler(Move_CheckChanged);

            // hide PanEdit
            PanEdit.Hide();
        }

        #endregion


        #region get data

        private void ReadXML()
        {
            xml.Read();
            xml.calendar.Sort(new SortAscending());
        }

        private void FillTree()
        {
            // activate tree
            PanNew.Hide();
            tree.ForeColor = Color.Black;
            tree.Enabled = true;

            // get entries
            int index = 0;

            tree.BeginUpdate();
            tree.Nodes.Clear();

            foreach (Calendar day in xml.calendar)
            {
                tree.Nodes.Add(day.Date);

                foreach (string entry in day.Entries)
                {
                    tree.Nodes[index].Nodes.Add(entry);
                }

                index++;
            }

            tree.EndUpdate();
            tree.ExpandAll();

            // draw empty space
            DrawEmptySpace();
        }

        private void DrawEmptySpace()
        {
            // delete (all) previous Panel(s)
            if (tree.Controls != null)
            {
                foreach (Control ctrl in tree.Controls)
                {
                    if (ctrl.Name == "emptySpace")
                    {
                        ctrl.Dispose();
                        tree.Controls.Remove(ctrl);
                    }
                }
            }

            // draw new Panel
            if (tree.ItemHeight * tree.GetNodeCount(true) < tree.Height)
            {
                int posX, posY, width, heigth;
                Panel emptySpace = new Panel();

                posX = treeOffset_PosX;
                posY = tree.ItemHeight * tree.GetNodeCount(true);
                width = appWidth;
                heigth = appHeigth - posY;

                if (heigth > 0)
                {
                    emptySpace.Name = "emptySpace";
                    emptySpace.Location = new Point(posX, posY);
                    emptySpace.Size = new Size(width, heigth);
                    //emptySpace.BorderStyle = BorderStyle.FixedSingle;
                    //emptySpace.BackColor = Color.Green;
                    emptySpace.BackgroundImage = FileStore.Resource.Alien_tired;
                    emptySpace.BackgroundImageLayout = ImageLayout.Center;

                    tree.Controls.Add(emptySpace);
                }

                // add Eventhandler for right click
                emptySpace.MouseClick += EmptySpace_Click;

                // add Eventhandler for mouse is leaving Panel
                emptySpace.MouseLeave += HideWindow_MouseLeave;
            }
        }

        #endregion


        #region hide window

        private void HideWindow_MouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                lastAppWidth = appWidth;
                HideWin();
            }
        }

        private void HideWin()
        {
            do
            {
                appWidth -= deltaSize;
                ResizeWindow(appWidth, appHeigth);
                System.Threading.Thread.Sleep(delayTime);
            }
            while (appWidth > 0);

            appWidth = 0;
            hidden = !hidden;

            // hide window till button is pushed or entered
            HiddenWindow HiddenWindow = new HiddenWindow(this)
            {
                StartPosition = FormStartPosition.Manual
            };

            Hide();
            HiddenWindow.ShowDialog(this);

            Show();
            ShowWin();
        }

        private void ShowWin()
        {
            do
            {
                appWidth += deltaSize;
                ResizeWindow(appWidth, appHeigth);
                System.Threading.Thread.Sleep(delayTime);
            }
            while (appWidth < lastAppWidth - deltaSize);

            appWidth = lastAppWidth;
            ResizeWindow(appWidth, appHeigth);
            hidden = !hidden;
        }

        #endregion


        #region add/edit/delete entry        

        // TreeView

        private void Node_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            // open corresponding context menu per right click
            if (e.Button == MouseButtons.Right)
            {
                // set selected node and availability of delete-function
                if (e.Node.Parent == null)
                {
                    tree.SelectedNode = tree.Nodes[e.Node.Index];
                    ConMnuStrp.Items[0].Enabled = true;
                    ConMnuStrp.Items[1].Enabled = false;
                    ConMnuStrp.Items[3].Enabled = false;
                }
                else
                {
                    tree.SelectedNode = tree.Nodes[e.Node.Parent.Index].Nodes[e.Node.Index];
                    ConMnuStrp.Items[0].Enabled = true;
                    ConMnuStrp.Items[1].Enabled = true;
                    ConMnuStrp.Items[3].Enabled = true;
                }

                // open ContextMenu close to mouse position
                ConMnuStrp.Show();
                ConMnuStrp.Location = new Point(MousePosition.X, MousePosition.Y);
            }
        }

        private void EmptySpace_Click(object sender, MouseEventArgs e)
        {
            // right click opens context menu
            if (e.Button == MouseButtons.Right)
            {
                ConMnuStrp.Show();
                ConMnuStrp.Items[0].Enabled = true;
                ConMnuStrp.Items[1].Enabled = false;
                ConMnuStrp.Items[3].Enabled = false;
                ConMnuStrp.Location = new Point(MousePosition.X, MousePosition.Y);
            }
        }

        // Context Menu

        private void Context_New_Click(object sender, EventArgs e)
        {
            PanNew.Show();

            // settings
            PanNew_TextBox.Text = string.Empty;
            PanNew_DateTimePicker.Enabled = true;
            PanNew_DateTimePicker.Text = DateTime.Now.ToShortDateString().ToString();

            // deactivate tree
            tree.ForeColor = Color.LightGray;
            tree.Enabled = false;
        }

        private void Context_Edit_Click(object sender, EventArgs e)
        {
            PanEdit.Show();

            // settings
            PanEdit_ChkMove.Checked = false;
            PanEdit_DateTimePicker.Enabled = false;
            PanEdit_TextBox.Text = tree.SelectedNode.Text;
            PanEdit_DateTimePicker.Text = tree.SelectedNode.Parent.Text;

            // deactivate tree
            tree.ForeColor = Color.LightGray;
            tree.Enabled = false;
        }
        
        private void Context_Delete_Click(object sender, EventArgs e)
        {
            // delete selected node
            xml.Remove(tree.SelectedNode.Parent.Text, tree.SelectedNode.Text);

            // update view
            ReadXML();
            FillTree();
        }

        // Panel Controls

        private void Add_Click(object sender, EventArgs e)
        {
            if (PanNew_TextBox.Text != string.Empty)
            {
                if (xml.AddEntry(PanNew_DateTimePicker.Value.ToShortDateString(), PanNew_TextBox.Text))
                {
                    // update tree
                    ReadXML();
                    FillTree();
                }
                else
                    MessageBox.Show("Dublicate!");
            }
        }
        
        private void Edit_Click(object sender, EventArgs e)
        {
            if (PanNew_TextBox.Text != string.Empty)
            {
                // add edited entry
                if (xml.AddEntry(PanEdit_DateTimePicker.Value.ToShortDateString(), PanEdit_TextBox.Text))
                {
                    // if success: delete selected node
                    xml.Remove(tree.SelectedNode.Parent.Text, tree.SelectedNode.Text);

                    // update view
                    PanEdit.Hide();
                    ReadXML();
                    FillTree();
                }
                else
                    MessageBox.Show("Dublicate!");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            PanNew.Hide();
            PanEdit.Hide();

            // activate tree
            tree.ForeColor = Color.Black;
            tree.Enabled = true;
        }

        private void Move_CheckChanged(object sender, EventArgs e)
        {
                if (PanEdit_ChkMove.Checked)
                    PanEdit_DateTimePicker.Enabled = true;
                else
                {
                    PanEdit_DateTimePicker.Enabled = false;
                    PanEdit_DateTimePicker.Text = tree.SelectedNode.Parent.Text;
                }
        }

        #endregion


        #region Menu Controls

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
