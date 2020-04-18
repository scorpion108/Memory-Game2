using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        PictureBox[] allP;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            allP = new PictureBox[8];
            BuildArr();
            Mix();
            showBoard(2, 4);
        }

        public void Mix()
        {
            int num;
            PictureBox temp;
            for (int i = 0; i < allP.Length; i++)
            {
                num = rnd.Next(0, allP.Length);
                temp = allP[i];
                allP[i] = allP[num];
                allP[num] = temp;
            }
        }

        private void BuildArr()
        {
            for (int i = 0; i < allP.Length - 1; i += 2)
            {
                for (int j = i; j < i + 2; j++)
                {
                    allP[j] = new PictureBox();
                    allP[j].Image = Properties.Resources.lion;
                    allP[j].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("wolf" + (i + 1 ));
                    allP[j].Tag = i + 1 + "";
                    allP[j].SizeMode = PictureBoxSizeMode.StretchImage;
                    allP[j].BorderStyle = BorderStyle.FixedSingle;
                    allP[j].Size = new Size(80, 80);
                    allP[j].Click += allP_Click;
                }
            }
        }

        private void showBoard(int row, int col)
        {
            int x = 100, y = 100, place = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    allP[place].Location = new Point(x, y);
                    x += 85;
                    Controls.Add(allP[place++]);
                }
                y += 85;
                x = 100;

            }
        }

        

        

        public static void FlipPic(PictureBox picture)
        {
            Image img;
            img = picture.Image;
            picture.Image = picture.BackgroundImage;
            picture.BackgroundImage = img;
        }

        public bool Check(PictureBox[] arr)
        {
            if (arr[0].Tag.Equals(arr[1].Tag))
            {
                return true;
            }
            return false;
        }

        int p = 0;
        PictureBox[] temp = new PictureBox[2];

        private void allP_Click(object sender, EventArgs e)
        {
            PictureBox ClickedPic = (PictureBox)sender;

            Image img;
            img = ClickedPic.Image;
            ClickedPic.Image = ClickedPic.BackgroundImage;
            ClickedPic.BackgroundImage = img;

            if (p == 2)
            {
                p = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = null;
                }
            }

            temp[p] = ClickedPic;
            p++;

            if (temp[1] != null)
            { 
                if (!Check(temp))
                {
                    FlipPic(temp[0]);
                    FlipPic(temp[1]);
                }
            }
        }
    }//*****
    
}
