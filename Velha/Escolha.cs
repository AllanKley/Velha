﻿using System;
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
    public partial class Escolha : Form
    {
        public Escolha()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNormalLocal_Click(object sender, EventArgs e)
        {
            Jogo jogo = new Jogo();
            this.Hide();
            jogo.Show();
        }
    }
}
