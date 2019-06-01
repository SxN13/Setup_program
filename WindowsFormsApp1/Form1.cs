using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string PATH = "lnk\\";
        List<string> category = new List<string>(0);
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            foreach (string d in Directory.GetDirectories(PATH))
            {
                TreeNode treeNode = new TreeNode(d);
                treeNode.Text = Path.GetFileName(d);
                treeNode.Tag = d;
                treeView1.Nodes.Add(treeNode);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selected = e.Node.Tag.ToString();
            ImageList imageList = new ImageList();
            ListViewItem listItem;
            List<string> tmp = new List<string>(0);
            List<string> name = new List<string>(0);

            listView1.Clear();
            foreach (string element in Directory.GetFiles(selected))
            {
                tmp.Add(element);
                name.Add(Path.GetFileName(element));
                imageList.Images.Add(Icon.ExtractAssociatedIcon(element));
            }
            for(int i = 0; i < imageList.Images.Count; i++)
            {
                listItem = new ListViewItem();
                listItem.Tag = tmp[i];
                listItem.Text = name[i];
                listItem.ImageIndex = i;
                listView1.Items.Add(listItem);
            }
            listView1.SmallImageList = imageList;
        }
        string selected_list_element = "";
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selected_list_element = listView1.SelectedItems[0].Tag.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selected_list_element != "")
            {
                System.Diagnostics.Process.Start(selected_list_element);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
