using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XoGame.Properties;

namespace XoGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void errorMessage(string title,string message)
        {
            MessageBox.Show(message,title , MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private string[,] bored = new string[3, 3];
        
        bool FillArray(string mark,int num1,int num2)
        {
           

            if (bored[num1, num2] != null)
            {
                return false;
            }
            bored[num1, num2] = mark;
            return true;
        }

        bool ifFristrowWinner()
        {
            if (!string.IsNullOrEmpty(bored[0, 0]) &&
         bored[0, 0] == bored[0, 1] &&
         bored[0, 1] == bored[0, 2])
            {
                return true;
            }
            return false;
        }
        bool ifsecondrowlWinner()
        {
            if (!string.IsNullOrEmpty(bored[1, 0]) &&
         bored[1, 0] == bored[1, 1] &&
         bored[1, 1] == bored[1, 2])
            {
                return true;
            }

            return false;
        }
        bool ifthiredrowWinner()
        {
            if (!string.IsNullOrEmpty(bored[2, 0]) &&
         bored[2, 0] == bored[2, 1] &&
         bored[2, 1] == bored[2, 2])
            {
                return true;
            }
            return false;
        }
        bool ifside1rowWinner()
        {
            if (!string.IsNullOrEmpty(bored[0, 0]) &&
         bored[0, 0] == bored[1, 1] &&
         bored[1, 1] == bored[2, 2])
            {
                return true;
            }
            return false;
        }
        bool ifside2rowWinner()
        {
            if (!string.IsNullOrEmpty(bored[0, 2]) &&
         bored[0, 2] == bored[1, 1] &&
         bored[1, 1] == bored[2, 0])
            {
                return true;
            }
            return false;
        }
        bool ifcol1Winner()
        {
            if (!string.IsNullOrEmpty(bored[0, 0]) &&
         bored[0, 0] == bored[1, 0] &&
         bored[1, 0] == bored[2, 0])
            {
                return true;
            }
            return false;
        }
        bool ifcol2Winner()
        {
            if (!string.IsNullOrEmpty(bored[0, 1]) &&
         bored[0, 1] == bored[1, 1] &&
         bored[1, 1] == bored[2, 1])
            {
                return true;
            }
            return false;
        }
        bool ifcol3Winner()
        {
            if (!string.IsNullOrEmpty(bored[0, 2]) &&
         bored[0, 2] == bored[1, 2] &&
         bored[1, 2] == bored[2, 2])
            {
                return true;
            }
            return false;
        }
        bool ifWinner()
        {
            if (ifFristrowWinner())
            {
                return true;
            }
            if (ifsecondrowlWinner())
            {
                return true;

            }
            if (ifthiredrowWinner())
            {
                return true;

            }
            if (ifside1rowWinner())
            {
                return true;

            }
            if (ifside2rowWinner())
            {
                return true;

            }
            if (ifcol1Winner())
            {
                return true;

            }
            if (ifcol2Winner())
            {
                return true;

            }
            if (ifcol3Winner())
            {
                return true;

                }
                return false;
        }
        bool ifDraw()
        {
            for (int i = 0; i < 3; i++)  // عدد الصفوف
            {
                for (int j = 0; j < 3; j++)  // عدد الأعمدة
                {
                    if (bored[i, j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        void FinishGame()
        {
            if (ifWinner())
            {
                MessageBox.Show("You Are Winner","Contrate",MessageBoxButtons.OK,MessageBoxIcon.Information);
                label4.Text = label2.Text;


                return;
            }
            if (ifDraw())
            {
                MessageBox.Show("Game Over", "Game Over!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label4.Text = "Draw";

            }
        }
        void ChangePlayer()
        {
            if (label2.Text == "Player1")
            {
                label2.Text = "Player2";
            }
            else
            {
                label2.Text = "Player1";

            }
          
        }


        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Cursor = Cursors.Hand; // تغيير المؤشر إلى شكل اليد
        }

        void BoxFuntion(GroupBox groupBox,PictureBox pic)
        {
            if (groupBox.Tag == "X")
            {
                if (FillArray("o", Convert.ToInt32(pic.Name[3].ToString()), Convert.ToInt32(pic.Name[4].ToString())))
                {
                    pic.Image = Resources.o;
                    groupBox.Tag = "o";
                    FinishGame();
                    ChangePlayer();

                }
                else
                {
                    errorMessage("Error", "it's not empty");
                }
            }
            else
            {

                if (FillArray("X", Convert.ToInt32(pic.Name[3].ToString()), Convert.ToInt32(pic.Name[4].ToString())))
                {
                    pic.Image = Resources.x;
                    groupBox.Tag = "X";
                    FinishGame();
                    ChangePlayer();
                }
                else
                {
                    errorMessage("Error", "it's not empty");
                }

            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            BoxFuntion(groupBox1, pic00);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic01);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic02);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic10);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic11);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic12);


        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic20);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic21);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BoxFuntion(groupBox1, pic22);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)  // عدد الصفوف
            {
                for (int j = 0; j < 3; j++)  // عدد الأعمدة
                {
                    bored[i,j] = null;
                }
            }
            groupBox1.Tag = "";
            pic00.Image = Resources.qu;
            pic01.Image = Resources.qu;
            pic02.Image = Resources.qu;
            pic10.Image = Resources.qu;
            pic11.Image = Resources.qu;
            pic12.Image = Resources.qu;
            pic20.Image = Resources.qu;
            pic21.Image = Resources.qu;
            pic22.Image = Resources.qu;
            label2.Text = "Player1";
            label4.Text = "in Progrees";
        }
    }
}
