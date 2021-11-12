﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elevator
{
    public partial class Form1 : Form
    {
        Image closeImage = null;
        Image openImage = null;

        public Form1()
        {
            InitializeComponent();

            //interno
            inside1.RowTemplate.Height = 40;
            inside1.Rows.Add(8);
            for (int n=0;n<8;n++)
            {
                inside1[0, n].Value = string.Format("{0}", 8 - n);
            }

            //elevador
            cageGrid1.RowTemplate.Height = 40;
            cageGrid1.Rows.Add(8);

            //externo_sobe
            outUp.RowTemplate.Height = 40;
            outUp.Rows.Add(8);
            for(int n=0;n<8;n++)
            {
                outUp[0, n].Value = string.Format("{0}", 8 - n);
            }
            outUp.Rows[0].Visible = false;

            //externo_desce
            outDown.RowTemplate.Height = 40;
            outDown.Rows.Add(8);
            for (int n = 0; n < 7; n++)
            {
                outDown[0, n].Value = string.Format("{0}", 8 - n);
            }
            outDown.Rows[7].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //definindo e abrindo a imagem
            closeImage = new Bitmap("elevClose.gif");
            openImage = new Bitmap("elevOpen.gif");
            DataGridViewImageColumn imageColumn1 = (DataGridViewImageColumn)cageGrid1.Columns["Column1"];
            imageColumn1.DefaultCellStyle.NullValue = null;
            cageGrid1[0, 7].Value = closeImage;

            //inicializando o tempo
            timer1.Interval = 500;
            timer1.Start();

            //zerando os botoes das colunas
            for (int n = 0; n < 8; n++)
            {
                insideReq[n] = 0;
                upReq[n] = 0;
                downReq[n] = 0;

            }
        }

        private void inside1_SelectionChanged(object sender, EventArgs e)
        {
            inside1.Rows[inside1.CurrentCell.RowIndex].Selected = false;
        }

        private void cageGrid1_SelectionChanged(object sender, EventArgs e)
        {
            cageGrid1.Rows[cageGrid1.CurrentCell.RowIndex].Selected = false;
        }

        private void outUp_SelectionChanged(object sender, EventArgs e)
        {
            outUp.Rows[outUp.CurrentCell.RowIndex].Selected = false;
        }

        private void outDown_SelectionChanged(object sender, EventArgs e)
        {
            outDown.Rows[outDown.CurrentCell.RowIndex].Selected = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        
        int[] insideReq = new int[8];
        int[] upReq = new int[8];
        int[] downReq = new int[8];

        String[] strFloor = new string[8] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" };
        enum Floor { F1,F2,F3,F4,F5,F6,F7,F8};
        Floor nowFloor = Floor.F1; //posição inicial
        //botão interno
        private void inside1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = inside1.CurrentRow.Index;
            insideReq[7 - row] = 7 - row + 1;
            string str = String.Format("Inside1 Click {0}", strFloor[7 - row]);
            inside1.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            MessageBox.Show(str);
            inside1.Rows[row].DefaultCellStyle.BackColor = Color.White;
        }

        private void outUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = outUp.CurrentRow.Index;
            upReq[7 - row] = 7 - row + 1;
            string str = String.Format("Up Click {0}", strFloor[7 - row]);
            outUp.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            MessageBox.Show(str);
            outUp.Rows[row].DefaultCellStyle.BackColor = Color.White;
        }

        private void outDown_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = outDown.CurrentRow.Index;
            downReq[7 - row] = 7 - row + 1;
            string str = String.Format("Down Click {0}", strFloor[7 - row]);
            outDown.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            MessageBox.Show(str);
            outDown.Rows[row].DefaultCellStyle.BackColor = Color.White;
        }
    }
}