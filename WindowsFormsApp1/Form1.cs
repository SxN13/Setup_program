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
        AutoCompleteStringCollection search_array = new AutoCompleteStringCollection();
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
            radioButton1.Checked = true;
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            comboBox1.Text = "";
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
                search_array.Add(name[i]);
                comboBox1.Items.Add(name[i]);
            }
            listView1.SmallImageList = imageList;
            listView1.LargeImageList = imageList;
            comboBox1.AutoCompleteCustomSource = search_array;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                listView1.View = View.Tile;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                listView1.View = View.LargeIcon;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                listView1.View = View.SmallIcon;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (selected_list_element != "")
            {
                System.Diagnostics.Process.Start(selected_list_element);
            }
        }
    }
}
