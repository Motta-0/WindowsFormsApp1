using System;
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
    enum Floor { F1, F2, F3, F4, F5, F6, F7, F8 };
    enum Direct { STOP, UP, DOWN };
    enum Most { LOWER, UPPER };
    enum Door { CLOSE, OPEN};
    public partial class Form1 : Form
    {
        Image closeImage = null;
        Image openImage = null;
        int[] insideReq = new int[8];
        int[] upReq = new int[8];
        int[] downReq = new int[8];

        String[] strFloor = new string[8] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" };
        Floor nowFloor = Floor.F1; //posição inicial
        const int QUESIZE = 22; //prioridade no chamar do elevador
        int[] insQue = new int[QUESIZE];
        int reqFloor = 0; //sem nenhum chamado
        Direct direct = Direct.STOP;
        int passCtr = 0;
        Door door = Door.CLOSE;

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
            outUp.Rows[0].Visible = true;

            //externo_desce
            outDown.RowTemplate.Height = 40;
            outDown.Rows.Add(8);
            for (int n = 0; n < 8; n++)
            {
                outDown[0, n].Value = string.Format("{0}", 8 - n);
            }
            outDown.Rows[7].Visible = true;
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

            //zerando os andares 
            for (int n = 0; n < QUESIZE; n++)
            {
                insQue[n] = 0;
            }

            //estado inicial
            nowFloor = Floor.F1;
            reqFloor = 0;
            direct = Direct.STOP;
            door = Door.CLOSE;
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
            //mover o elevador quando o botao for apertado
            for(int n=0;n<8;n++)
            {
                int req = insideReq[n];
                int pos = (int)nowFloor;

                if(req !=0)// alguem chamou
                {
                    if(n!=pos)//não é o andar
                    {
                        cageGrid1[0, 7 - pos].Value = null;

                        if(n>pos)//subir
                        {
                            pos++;
                            cageGrid1[0, 7 - pos].Value = closeImage;
                            nowFloor++;
                        }
                        else if(n<pos)//desce
                        {
                            pos--;
                            cageGrid1[0, 7 - pos].Value = closeImage;
                            nowFloor--;
                        }
                    }
                    else //é o andar certo
                    {
                        cageGrid1[0, 7 - pos].Value = closeImage;
                        insideReq[n] = 0;
                        inside1.Rows[7 - pos].DefaultCellStyle.BackColor = Color.White;
                    }
                    break;
                }
            }

            int now = (int)nowFloor;
            if (reqFloor == 0)
                reqFloor = popQue();

            if (reqFloor > 0)
            {
                int req = reqFloor - 1; //andar que foi chamado
                if(req!=now)//se o andar for diferente do que foi chamado
                {
                    cageGrid1[0, 7 - now].Value = null;
                    if (req > now)//sobe
                    {
                        now++;
                        cageGrid1[0, 7- now].Value = closeImage;
                        nowFloor++;
                    }
                    else //desce
                    {
                        now--;
                        cageGrid1[0, 7 - now].Value = closeImage;
                        nowFloor--;
                    }
                }
                else
                {
                    cageGrid1[0, 7 - now].Value = closeImage;
                    insideReq[req] = 0;
                    inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
                    reqFloor = 0; //sem chamados
                }
            }

            if(passCtr >0)
            {
                passCtr--;
                return;
            }
            switch(direct)
            {
                case Direct.STOP:
                    CageStart();
                break;
                case Direct.UP:
                    CageUp();
                break;
                case Direct.DOWN:
                    CageDown();
                break;

            }
        }

        //botão interno
        private void inside1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = inside1.CurrentRow.Index;
            insideReq[7 - row] = 7 - row + 1;
            // teste dos botoes string str = String.Format("Inside1 Click {0}", strFloor[7 - row]);
            inside1.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            // teste dos botoes MessageBox.Show(str);
            inside1.Rows[row].DefaultCellStyle.BackColor = Color.White;

            int req = 7 - row + 1;
            insideReq[7 - row] = req;
            pushQue(req);
            inside1.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
        }

        private void outUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = outUp.CurrentRow.Index;
            int req = 7 - row + 11;
            upReq[7 - row] = req;
            pushQue(req);
            ShowInsQue(req);
            outUp.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            ShowUpReq(req);

            outUp.Rows[row].DefaultCellStyle.BackColor = Color.White;

            ShowUpReq(req);
            
   
        }

        private void outDown_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = outDown.CurrentRow.Index;
            int req = 7 - row + 21;
            downReq[7 - row] = req;
            pushQue(req);
            ShowInsQue(req);
            // teste dos botoesstring str = String.Format("Down Click {0}", strFloor[7 - row]);
            outDown.Rows[row].DefaultCellStyle.BackColor = Color.Orange;
            ShowDownReq(req);
            // teste dos botoes MessageBox.Show(str);
           // outDown.Rows[row].DefaultCellStyle.BackColor = Color.White;
            ShowDownReq(req);
        }

        private void pushQue(int p)
        {
            for (int n=0;n<QUESIZE;n++)
            {
                if(insQue[n]==0)
                {
                    insQue[n] = p;
                    break;
                }
            }
        }

        private int popQue()
        {
            int ret = insQue[0];
            int n;
            for(n=1;n<QUESIZE;n++)
            {
                insQue[n - 1] = insQue[n];
            }
            insQue[n - 1] = 0;
            return ret;
        }

        private void CageStart()
        {
            int now = (int)nowFloor;
            if (reqFloor == 0)
                reqFloor = popQue();
            if(reqFloor>0)
            {
                int req = (reqFloor % 10) - 1;
                //chamado em outro andar
                if(req!=now)
                {
                    if (req > now)//sobe
                    {
                        MoveUp1();
                        direct = Direct.UP;
                    }
                    else //DOwn
                    {
                        MoveDown1();
                        direct = Direct.DOWN;
                    }
                }
                else //no mesmo andar
                {
                    DoorClose1();
                }
            }

            if (door == Door.CLOSE)
            {
                if (reqFloor == 0)
                    reqFloor = popQue();
                if (reqFloor > 0)
                {
                     now  = (int)nowFloor;
                    int req = (reqFloor % 10) - 1;
                    if (req != now)
                    {
                        if (req > now)
                        {
                            MoveUp1();
                            direct = Direct.UP;
                        }
                        else
                        {
                            MoveDown1();
                            direct = Direct.DOWN;
                        }
                    }
                    else
                    {
                        DoorOpen1();
                        door = Door.OPEN;
                    }
                }
            }
            else
            {
                DoorClose1();
                door = Door.CLOSE;
            }
        }

        private void MoveUp1()
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = null;
            inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            string str1 = string.Format("MOve Up from {0}", nowFloor);
            ShowListBox_1(str1);
            now++;
            cageGrid1[0, 7 - now].Value = closeImage;
            nowFloor++;
        }

        private void MoveDown1()
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = null;
            inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            string str1 = string.Format("Move down from {0}", nowFloor);
            ShowListBox_1(str1);
            now--;
            cageGrid1[0, 7 - now].Value = closeImage;
            nowFloor--;
        }

        private void DoorOpen1()
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = openImage;
            passCtr = 3;
            string str1 = string.Format("> Door Open at {0}", nowFloor);
            ShowListBox_1(str1);
            clearQue(now + 1);
            clearQueUp(now + 1);
            clearQueDown(now + 1);

        }

        private void DoorClose1()
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = closeImage;
            inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            insideReq[now] = 0;
            reqFloor = 0; //sem chamado
            string str1 = string.Format("< Door Close at {0}", nowFloor);
            ShowListBox_1(str1);
            inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            if (upReq[now] == 0)
                outUp.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            if(downReq[now] == 0)
                outDown.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            str1 = string.Format("< Door Close at {0}", nowFloor);

        }

        private void CageUp()
        {
            int now = (int)nowFloor;
            int req = insideReq[now];

            /*if(req==0) // porta fechada ou passou
            {
                if (IsUpper1() == true)
                {
                    MoveUp1();
                    direct = Direct.UP;
                }
                else
                {
                    EndWork(Most.UPPER);
                    direct = Direct.STOP;
                }
            }
            else
            {
                StopFloor1();
            }
            else
            {
                DoorClose1();
                door = Door.CLOSE;
            }
            */
            if (door == Door.CLOSE)
            {
                // now = (int)nowFloor;
                // req = insideReq[now];
                if (req == 0)// porta fechada ou passou
                {
                    if (IsUpper1() == true)
                    {
                        MoveUp1();
                        direct = Direct.UP;
                    }
                    else
                    {
                        EndWork(Most.UPPER);
                        direct = Direct.STOP;
                    }
                }
                else
                {
                    StopFloor1();
                    door = Door.OPEN;
                }
            }
            else
            {
                DoorClose1();
                door = Door.CLOSE;
            }

            if (door == Door.CLOSE)
            {
                if (IsUpStop() == true)
                {
                    StopFloor1();
                    door = Door.OPEN;
                }
                else
                {
                    if(IsUpper1() == true)
                    {
                        MoveUp1();
                        direct = Direct.UP;
                    }
                    else if(IsUpperDown()==true)
                    {
                        StopFloor1();
                        door = Door.OPEN;
                    }
                    else
                    {
                        EndWork(Most.UPPER);
                        direct = Direct.STOP;
                    }
                }
            }
           
            
        }

        private void StopFloor1()
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = openImage;
            insideReq[now] = 0;
            clearQue(now + 1);
            reqFloor = 0;
            passCtr = 3;
            string str1 = string.Format("> Door Open at {0}", nowFloor);
            ShowListBox_1(str1);

            if (now==0)
            {
                if(reqFloor==upReq[now])
                {
                    reqFloor = 0;
                    upReq[now] = 0;
                    clearQueUp(now + 1);
                }
                else if(now==7)
                {
                    if (reqFloor == downReq[now])
                        reqFloor = 0;
                    downReq[now] = 0;
                    clearQueDown(now + 1);
                }
                passCtr = 3;
            }
        }

        private bool IsUpper1()
        {
            int now = (int)nowFloor;
            bool flag = false;
            for(int n = now+1;n<8;n++)
            {
                if(insideReq[n] >0)
                {
                    flag = true;
                    break;
                }
            }
            for(int n=now+1;n<8;n++)
            {
                if(insideReq[n]>0)
                {
                    flag = true;
                    break;
                }
            }

            if(flag==false)
            {
                for (int n=now+1;n<7;n++)
                {
                    if(upReq[n] > 0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if(flag==false)
            {
                for (int n=now+1;n<8;n++)
                {
                    if(downReq[n]>0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        private void EndWork(Most end)
        {
            int now = (int)nowFloor;
            cageGrid1[0, 7 - now].Value = closeImage;
            inside1.Rows[7 - now].DefaultCellStyle.BackColor = Color.White;
            string str3 = string.Format("{0}", (end == Most.LOWER)?"Lower":"Upper");
            string str4 = string.Format("=={0} End at {1}", str3, nowFloor);
            ShowListBox_1(str4);
        }

        private void CageDown()
        {
            int now = (int)nowFloor;
            int req = insideReq[now];
            /*if (req == 0)
            {
                if (IsLower1() ==  true)
                {
                    MoveDown1();
                    direct = Direct.DOWN;
                }
                else
                {
                    EndWork(Most.LOWER);
                    direct = Direct.STOP;
                }
            }
            else
            {
                StopFloor1();
            }
            */
            if (door == Door.CLOSE)
            {
                //now = (int)nowFloor;
                //req = insideReq[now];
                if (req == 0)
                {
                    if (IsLower1() == true)
                    {
                        MoveDown1();
                        direct = Direct.DOWN;
                    }
                    else
                    {
                        EndWork(Most.LOWER);
                        direct = Direct.STOP;
                    }
                }
                else
                {
                    StopFloor1();
                    door = Door.OPEN;
                }
            }
            else
            {
                DoorClose1();
                door = Door.CLOSE;
            }

            if (door == Door.CLOSE)
            {

                if (IsDownStop() == true)
                {
                    StopFloor1();
                    door = Door.OPEN;
                }
                else
                {
                    if (IsLower1() == true)
                    {
                        MoveDown1();
                        direct = Direct.DOWN;
                    }
                    else if (IsLowerUp() == true)
                    {
                        StopFloor1();
                        door = Door.OPEN;
                    }
                    else
                    {
                        EndWork(Most.LOWER);
                        direct = Direct.STOP;
                    }
                }

            }
        }

        private bool IsLower1()
        {
            int now = (int)nowFloor;
            bool flag = false;
            for(int n=now-1; n>=0; n--)
            {
                if (insideReq[n] > 0)
                {
                    flag = true;
                    break;
                }
            }
            if(flag ==true)
            {
                for(int n=now-1;n>0;n--)
                {
                    if(downReq[n] > 0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag == false)
            {
                for(int n=now-1;n>=0;n--)
                {
                    if(upReq[n]>0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
        return flag;
        }

        private void clearQue(int p)
        {
            for(int n=0; n<QUESIZE; n++)
            {
                if(insQue[n] == p)
                {
                    for(n++;n<QUESIZE;n++)
                    {
                        insQue[n - 1] = insQue[n];
                    }
                    insQue[n - 1] = 0;
                    break;
                }
            }
             if (p == reqFloor)
                reqFloor = 0;
        }

        private void ShowListBox_1(string str1)
        {
            listBox1.Items.Add(str1);
            while(listBox1.Items.Count>50)
            {
                listBox1.Items.RemoveAt(0);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private bool IsUpperDown()
        {
            int now = (int)nowFloor;
            bool flag = false;
            for(int n=7;n>=now;n--)
            {
                if(downReq[n]>0)
                {
                    if(n==now)
                    {
                        if(reqFloor==downReq[now])
                            reqFloor = 0;
                        downReq[now] = 0;
                        clearQueDown(now + 1);
                        ShowDownReq(-(now + 21));
                        flag = true;
                    }
                    break;
                }
            }
            return flag;
        }

        private bool IsUpStop()
        {
            int now = (int)nowFloor;
            bool flag = false;
            if((insideReq[now]>0)||(upReq[now]>0))
            {
                insideReq[now] = 0;
                clearQue(now + 1);
                upReq[now] = 0;
                clearQueUp(now + 1);
                ShowUpReq(-(now + 11));
                flag = true;
            }
            return flag; 

        }

        private bool IsLowerUp()
        {
            int now = (int)nowFloor;
            bool flag = false;
            for(int i=0;i<=now;i++)
            {
                if(upReq[i]>0)
                {
                    if(i==now)
                    {
                        if (reqFloor == upReq[now])
                            reqFloor = 0;
                        upReq[now] = 0;
                        clearQueUp(now+1);
                        ShowUpReq(-(now + 11));
                        flag = true;
                    }
                    break;
                }
            }
            return flag;
        }

        private bool IsDownStop()
        {
            int now = (int)nowFloor;
            bool flag = false;
            if((insideReq[now]>0)||(downReq[now]>0))
            {
                insideReq[now] = 0;
                clearQue(now + 1);
                downReq[now] = 0;
                clearQueDown(now + 1);
                ShowDownReq(-(now + 21));
                flag = true;
            }
            return flag;
        }

        private void ShowUpReq(int req)
        {
            string str1 = string.Format("U=*{0}*", req);
            string str2 = "";
            for (int i=0; i<8; i++)
            {
                str2 = upReq[i].ToString();
                str1 += "," + str2;
            }
            ShowListBox_1(str1);
        }

        private void ShowDownReq(int req)
        {
            string str1 = string.Format("D=*{0}*", req);
            string str2 = "";
            for (int i = 0; i < 8; i++)
            {
                str2 = downReq[i].ToString();
                str1 += "," + str2;
            }
            ShowListBox_1(str1);
        }

        private void ShowInsQue(int req)
        {
            string str1 = string.Format("<< == Push {0}=*", req);
            string str2 = "";
            for (int i = 0; i < 8; i++)
            {
                str1 += "," + str2;
                str2 = insQue[i].ToString();
            }
            ShowListBox_1(str1);
        }

        private void clearQueUp(int p)
        {
            p += 10;
            for (int n=0; n<QUESIZE;n++)
            {
                if(insQue[n] == p)
                {
                    for(n++;n<QUESIZE; n++)
                    {
                        insQue[n -1] = insQue[n];
                    }
                    insQue[n - 1] = 0;
                    break;
                }
            }
            if (p == reqFloor)
                reqFloor = 0;
        }

        private void clearQueDown(int p)
        {
            p += 20;
            for (int n = 0; n < QUESIZE; n++)
            {
                if (insQue[n] == p)
                {
                    for (n++; n < QUESIZE; n++)
                    {
                        insQue[n - 1] = insQue[n];
                    }
                    insQue[n - 1] = 0;
                    break;
                }
            }
            if (p == reqFloor)
                reqFloor = 0;
        }

    }
}
