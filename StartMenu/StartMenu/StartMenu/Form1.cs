using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StartMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void reload()
        {
            treeView1.Nodes.Clear();
            DirectoryInfo thefolder = new DirectoryInfo("F:/mine/StartMenu/Startlist");
            foreach (FileInfo nextfile in thefolder.GetFiles())
            {
                string name = System.Text.RegularExpressions.Regex.Replace(nextfile.Name, ".lnk", "");
                this.treeView1.Nodes.Add(name);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reload();
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string item = treeView1.SelectedNode.Text;
            string item_o = "F://mine//StartMenu//Startlist//" + item + ".lnk";
            try
            {
                System.Diagnostics.Process.Start(item_o);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch { }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void MoveLnk(string pathout)
        {
            FileInfo file = new FileInfo(pathout);
            string pathin = "F://mine//StartMenu//Startlist//" + file.Name + ".lnk";

            try
            {
                File.Copy(pathout, pathin);
                MessageBox.Show("Complete！");

            }
            catch
            {
                MessageBox.Show("Exist！");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog q = new OpenFileDialog
            {
                Filter = "快捷方式(lnk)|*.lnk",
                RestoreDirectory = true,
                Title = "Add Program",
            };
            string filePath = "";
            if (q.ShowDialog() == DialogResult.OK)
            {
                filePath = q.FileName;
            }
            if (filePath == "") return;
            //MessageBox.Show(filePath);
            MoveLnk(filePath);
            reload();
        }

        private void startlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "F://mine//StartMenu//Startlist//";
            System.Diagnostics.Process.Start(filePath);
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }
    }
}
