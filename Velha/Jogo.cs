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





        PointF c1, c2, c3, c4; // coordenadas cantos 
        // c1 c2
        // c3 c4

        float tempoAnim = 200; // duração animação
        float tempoPassos = 10; // quanto menor mais suave a animação
        private int passos = 0; // contador passos
        float step; // ?
        


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
            int borda = 25;
            float ang=0;
            Pen pen = new Pen(Color.FromArgb(123, 158, 135), 30);
            SolidBrush brush = new SolidBrush(SystemColors.Control);
            SolidBrush brush2 = new SolidBrush(Color.Red);


            Rectangle rec = new Rectangle(borda,borda,Pb.Width-borda*2,Pb.Height-borda*2);
            Rectangle rec2 = new Rectangle(borda+10, borda+10, Pb.Width-(borda*2)-20, Pb.Height-(borda*2)-20);

            
            var g = Pb.CreateGraphics();

            g.FillRectangle(brush2, rec);
            g.DrawPie(pen, rec, 0, 200);

            //step = 360 / (tempoAnim / tempoPassos);

            //var tm = new System.Windows.Forms.Timer();

            //tm.Tick += delegate
            //{
            //    g.Clear(SystemColors.Control);
            //    ang += passos + step;
            //    if (ang > 360)
            //        ang = 360;


            //    g.DrawPie(pen, rec, 0, ang);
            //    g.FillEllipse(brush, rec2);

            //    if (ang >= 360)
            //    {
            //        tm.Stop();
            //    }

            //};

            //tm.Interval = (int)tempoPassos;
            //tm.Start();


            player *= -1;
            
        }

        public void DrawX(PictureBox Pb)
        {
            int borda = 25;
            Pen pen = new Pen(Color.FromArgb(123, 158, 135), 20);

            c1 = new PointF(borda, borda);
            c2 = new PointF(Pb.Width-borda, borda);
            c3 = new PointF(borda, Pb.Height - borda);
            c4 = new PointF(Pb.Width-borda, Pb.Height - borda);
            // c1 c2
            // c3 c4


            step = (c4.X - c1.X) / (tempoAnim / tempoPassos);

            var tm = new System.Windows.Forms.Timer();

            tm.Tick += delegate
            {
                passos++;

                float x = c1.X + (passos * step);
                float y = x;
                float z = c2.X - (passos * step);
     
                Pb.CreateGraphics().DrawLine(pen, c1, new PointF(x, y));
                Pb.CreateGraphics().DrawLine(pen, c2, new PointF(z, y));

                if (passos * tempoPassos > tempoAnim)
                {
                    passos = 0;
                    tm.Stop();
                }
            };

            tm.Interval = (int)tempoPassos;
            tm.Start();

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
                DrawCircle(pb);
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
