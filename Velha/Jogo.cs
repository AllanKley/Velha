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

namespace Velha
{
    public partial class Jogo : Form
    {
        int player = 1;
        char[] arr = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        int ModoJogo;
        Random rnd = new Random();
        int jogadas=0;





        PointF p1; // ponto inicial linha
        PointF p2; // ponto final linha

        PointF p11; // ponto inicial linha
        PointF p22; // ponto final linha

        float durationMS = 1000; // duração animação
        float stepMS = 20; // quanto menor mais suave a animação

        float stepWidthX;
        float k;
        float d;
        private int stepCounter = 0;


        public Jogo(int modo)
        { 
            InitializeComponent();
            PnlVitoria.Hide();

            ModoJogo = modo;
            switch (ModoJogo)
            {
                case 1:
                    Modo.Text = "PvP";
                    break;
                case 3:
                    Modo.Text = "PvE";
                    break;
            }






            

        }


        #region jogo
        
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




            p1 = new PointF(borda, borda);
            p2 = new PointF(Pb.Height-borda, Pb.Width-borda);

            p11 = new PointF(borda, Pb.Height - borda);
            p22 = new PointF(Pb.Width - borda, borda);

            stepWidthX = (p2.X - p1.X) / (durationMS / stepMS);

            k = (p2.Y - p1.Y) / (p2.X - p1.X);
            d = (p2.X * p1.Y - p1.X * p2.Y) / (p2.X - p1.X);


            timer1.Tick += delegate
            {
                stepCounter++;

                float x = p1.X + stepCounter * stepWidthX;
                float y = k * x + d;

                Pb.CreateGraphics().DrawLine(pen, p1, new PointF(x, y));
                //Pb.CreateGraphics().DrawLine(pen, p11, new PointF(x, y));

                if (stepCounter * stepMS > durationMS)
                {
                    stepCounter = 0;
                    timer1.Stop();
                    Pb.CreateGraphics().DrawLine(pen, p1, p2);
                    Pb.CreateGraphics().DrawLine(pen, p11, p22);
                }
            };

            timer1.Interval = (int)stepMS;
            timer1.Start();



            //for(int i = borda; i < Pb.Height - borda; i++)
            //{
            //    g.DrawLine(pen, borda, borda, i, i);
            //    //g.DrawLine(pen, borda, i, i, borda);
            //    Pb.Image = bmp;
            //    Task.Delay(2).Wait();

            //}


            //g.DrawLine(pen, borda, borda, Pb.Height - borda, Pb.Width - borda);
            //g.DrawLine(pen, borda, Pb.Height - borda, Pb.Width - borda, borda);



            player *= -1;
            
        }
        #endregion


        #region Check Clicks
        private void P1_Click(object sender, EventArgs e)
        {
            jogadas++;
            var pb = sender as PictureBox;
            int index = int.Parse(pb.Name.Substring(1)) - 1;
            bool jogou = false;
            int jogada;
            string posicao;

            #region PvE
            if (ModoJogo == 3)
            {
                DrawX(pb);
                arr[index] = 'X';
                pb.Click -= P1_Click;
                CheckWin();

                Task.Delay(500).Wait();


                if (jogadas != 9)
                {
                    while (!jogou)
                    {
                        jogada = rnd.Next(1, 10);
                        posicao = 'P' + jogada.ToString();

                        foreach (PictureBox Pb in PGame.Controls.OfType<PictureBox>())
                        {
                            if (Pb.Name == posicao)
                            {
                                if ((arr[jogada - 1] != 'X') && (arr[jogada - 1] != 'O'))
                                {
                                    player *= -1;
                                    jogadas++;
                                    DrawCircle(Pb);
                                    arr[jogada - 1] = 'O';
                                    Pb.Click -= P1_Click;
                                    jogou = true;

                                    CheckWin();
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region PvP
            else if (ModoJogo == 1)
            {
                if(player == 1)
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

        #endregion





        
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Escolha escolha = new Escolha();
            this.Hide();
            escolha.Show();
        }
    }
}
