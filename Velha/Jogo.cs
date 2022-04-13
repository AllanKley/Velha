using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Velha
{
    public partial class Jogo : Form
    {
        int player = 1;
        char[] arr = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
    
        public Jogo(int modo)
        { 
            InitializeComponent();
            label7.Text = modo.ToString();
            PnlVitoria.Hide();
        }
       
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Desenha O e X
        public void DrawCircle(PictureBox Pb)
        {
            int raio = 100;

            Bitmap bmp = new Bitmap(Pb.Width, Pb.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.FromArgb(123, 158, 135), 20);


            g.DrawEllipse(pen, (Pb.Height/2)-(raio/2), (Pb.Width/2)-(raio/2), raio, raio);

            Pb.Image = bmp;

            player *= -1;
        }

        public void DrawX(PictureBox Pb)
        {
            int borda = 25;
            Pen pen = new Pen(Color.FromArgb(123, 158, 135), 20);
            Bitmap bmp = new Bitmap(Pb.Width, Pb.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawLine(pen, borda, borda, Pb.Height-borda, Pb.Width-borda);
            g.DrawLine(pen, borda, Pb.Height-borda, Pb.Width-borda, borda);

            Pb.Image = bmp;

            player *= -1;
        }
        #endregion

        #region Check Clicks
        private void P1_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            int index = int.Parse(pb.Name.Substring(1)) - 1;
            if (player>0)
            {
                DrawX(pb);
                arr[index] = 'X';
            }
            else
            {
                DrawCircle(pb);
                arr[index] = 'O';
            }

            pb.Click -= P1_Click;

            CheckWin();
        }
        #endregion

        public void CheckWin()
        {
            int vitoria;
            
            #region Horizontal Winning Condition
            //Winning Condition For First Row
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                vitoria = 1;
            }
            //Winning Condition For Second Row
            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                vitoria = 1;
            }
            //Winning Condition For Third Row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                vitoria = 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                vitoria = 1;
            }
            //Winning Condition For Second Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                vitoria = 1;
            }
            //Winning Condition For Third Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                vitoria = 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                vitoria = 1;
            }
            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                vitoria = 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (arr[0] != '1' && arr[1] != '2' && arr[2] != '3' && arr[3] != '4' && arr[4] != '5' && arr[5] != '6' && arr[6] != '7' && arr[7] != '8' && arr[8] != '9')
            {
                vitoria = -1;
            }
            #endregion

            else
            {
                vitoria = 0;
            }

            #region Declaração de Vitória
            if (vitoria == 1)
            {
                PnlVitoria.Show();

                PGame.Hide();
                if ((player*-1)== 1)
                {
                    LblVitoria.Text = $"Vitória jogador 1";
                }
                else
                {
                    LblVitoria.Text = $"Vitória jogador 2";
                }    
            }
            #endregion

            #region Declaração de Empate
            else if (vitoria == -1)
            {
                PGame.Hide();

                PnlVitoria.Show();
                LblVitoria.Text = "Empate";
            }
            #endregion
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {

        }

        private void LblVitoria_Click(object sender, EventArgs e)
        {

        }

        private void BtnJogarNovamente_Click(object sender, EventArgs e)
        {
            Jogo jogo = new Jogo(1);
            this.Hide();
            jogo.Show();

        }
    }
}
