using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinarySearchTree;
using MetroFramework.Forms;

namespace TreeView
{
    public partial class BinTreeForm : MetroForm
    {
        public BinTreeForm()
        {
            InitializeComponent(); 
        }
        BinTree<int> tree = new BinTree<int>();
        AVLTree<int> avltree = new AVLTree<int>();
        RedBlackTree<int> RBtree = new RedBlackTree<int>();

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            string[] array = textBox1.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                tree.Add(Convert.ToInt32(item));
            }
            pictureBox1.Image = tree.Print(pictureBox1);
            textBox1.Clear();
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tree.Clear();
            pictureBox1.Image = tree.Print(pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] array = textBox1.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                tree.Remove(Convert.ToInt32(item));
            }
            pictureBox1.Image = tree.Print(pictureBox1);
            textBox2.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] array = textBox2.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                avltree.Add(Convert.ToInt32(item));
            }
            pictureBox2.Image = avltree.Print(pictureBox2);
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] array = textBox2.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                avltree.Remove(Convert.ToInt32(item));
            }
            pictureBox2.Image = avltree.Print(pictureBox2);
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            avltree.Clear();
            pictureBox2.Image = avltree.Print(pictureBox2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] array = textBox3.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                RBtree.Add(Convert.ToInt32(item));
            }
            pictureBox3.Image = RBtree.Print(pictureBox3);
            textBox3.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] array = textBox3.Text.Trim().Split(' ');
            foreach (var item in array)
            {
                RBtree.Remove(Convert.ToInt32(item));
            }
            pictureBox3.Image = RBtree.Print(pictureBox3);
            textBox3.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RBtree.Clear();
            pictureBox3.Image = RBtree.Print(pictureBox3);
        }
    }
}
