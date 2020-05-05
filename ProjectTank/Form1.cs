using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTank
{
    public partial class Form1 : Form
    {
        GameStatus gameStatus = GameStatus.stop;
        const int n = 17;
        Field field = new Field();
        PlayerTank playerTank;
        WarTank warTank1;
        WarTank warTank2;
        WarTank warTank3;
        WarTank warTank4;
        Thread thread1;
        Thread thread2;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            playerTank = new PlayerTank(600, 600);
            warTank1 = new WarTank(600, 300);
            warTank2 = new WarTank(500, 200);
            warTank3 = new WarTank(400, 100);
            warTank4 = new WarTank(300, 0);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            field.Draw(g);
            if (gameStatus == GameStatus.start)
            {
                playerTank.Draw(g);
                playerTank.DrawLife(g);
                warTank1.Draw(g);
                warTank2.Draw(g);
                warTank3.Draw(g);
                warTank4.Draw(g);
                playerTank.DrawBoom(g);
                warTank1.DrawBoom(g);
                warTank2.DrawBoom(g);
                warTank3.DrawBoom(g);
                warTank4.DrawBoom(g);
            }
            if (gameStatus == GameStatus.win)
                g.DrawImage(Properties.Resources.win, 50, 150, 500, 300);
            if (gameStatus == GameStatus.gameover)
                g.DrawImage(Properties.Resources.gameover, 50, 150, 500, 300);
        }

        private void Control(object sender, KeyPressEventArgs e)
        {
            playerTank.ControlPlayer(e);
        }

        private void Update(object sender, EventArgs e)
        {
            Invalidate();
            if (gameStatus == GameStatus.start)
            {
                thread1 = new Thread(() =>
                {
                    if (!warTank1.dead)
                        warTank1.ControlWar();
                    if (!warTank2.dead)
                        warTank2.ControlWar();
                    if (!warTank3.dead)
                        warTank3.ControlWar();
                    if (!warTank4.dead)
                        warTank4.ControlWar();
                });
                thread1.Start();

                textBox1.Text = Convert.ToString(playerTank.kills);
            }
        }

        private void Kill()
        {
            if (Math.Abs(warTank1.x - playerTank._x) < n && Math.Abs(warTank1.y - playerTank._y) < n)
            {
                warTank1.health--;
                playerTank.kills++;
            }
            if (Math.Abs(playerTank.x - warTank1._x) < n && Math.Abs(playerTank.y - warTank1._y) < n)
            {
                playerTank.health--;
            }
            if (Math.Abs(warTank2.x - playerTank._x) < n && Math.Abs(warTank2.y - playerTank._y) < n)
            {
                warTank2.health--;
                playerTank.kills++;
            }
            if (Math.Abs(playerTank.x - warTank2._x) < n && Math.Abs(playerTank.y - warTank2._y) < n)
            {
                playerTank.health--;
            }
            if (Math.Abs(warTank3.x - playerTank._x) < n && Math.Abs(warTank3.y - playerTank._y) < n)
            {
                warTank3.health--;
                playerTank.kills++;
            }
            if (Math.Abs(playerTank.x - warTank3._x) < n && Math.Abs(playerTank.y - warTank3._y) < n)
            {
                playerTank.health--;
            }
            if (Math.Abs(warTank4.x - playerTank._x) < n && Math.Abs(warTank4.y - playerTank._y) < n)
            {
                warTank4.health--;
                playerTank.kills++;
            }
            if (Math.Abs(playerTank.x - warTank4._x) < n && Math.Abs(playerTank.y - warTank4._y) < n)
            {
                playerTank.health--;
            }
        }

        private void Update2(object sender, EventArgs e)
        {
            Kill();
            if (warTank1.health == 0 && warTank2.health == 0 && warTank3.health == 0 && warTank4.health == 0)
                gameStatus = GameStatus.win;
            if (playerTank.health == 0)
                gameStatus = GameStatus.gameover;
        }

        private void RunGame()
        {
            if (gameStatus == GameStatus.start)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameStatus == GameStatus.start)
            {
                gameStatus = GameStatus.stop;
                RunGame();
            }
            else if (gameStatus == GameStatus.stop)
            {
                gameStatus = GameStatus.start;
                RunGame();
            }
            else
            {
                gameStatus = GameStatus.start;
                Init();
                RunGame();
            }   
        }
    }
}
