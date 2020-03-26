using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            allP = new PictureBox[16];
            BuildArr(2);
            Mix();
            showBoard(4, 4);
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

        private void BuildArr(int size)
        {
            for (int i = 0; i < allP.Length - 1; i += 2)
            {
                for (int j = i; j < i + 2; j++)
                {
                    allP[j] = new PictureBox();
                    allP[j].Image = Properties.Resources.lion;
                    allP[j].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("wolf" + i);
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

        public bool Check(PictureBox p1, PictureBox p2)
        {
            if (p1.Tag == p2.Tag)
            {
                return true;
            }
            return false;
        }

        int p = 0;
        PictureBox[] temp = new PictureBox[2];

        public static void FlipPic(PictureBox picture)
        {
            Image img;
            img = picture.Image;
            picture.Image = picture.BackgroundImage;
            picture.BackgroundImage = img;
        }

        private void allP_Click(object sender, EventArgs e)
        {
            PictureBox ClickedPic = (PictureBox)sender;

            FlipPic(ClickedPic);
            
            if (p < 2)
            {
                temp[p] = ClickedPic;
                p++;
            }
            else 
                p = 0;

            if (temp[1] != null)
            {
                if (!temp[0].Tag.Equals(temp[1].Tag))        //Check if the Pictures match each other
                {
                    FlipPic(temp[1]);
                    FlipPic(temp[0]);
                }

                for (int i = 0; i < 2; i++)
                {
                    temp[i] = null;
                }
            }
        }
    }
    
}
