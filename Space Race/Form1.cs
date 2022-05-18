using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Space_Race
{
    public partial class Form1 : Form
    {
        Rectangle p1 = new Rectangle(190, 450, 20, 50);
        Rectangle p2 = new Rectangle(290, 450, 20, 50);
        Rectangle timer = new Rectangle(245, 0, 10, 500);
        List<Rectangle> Lefts = new List<Rectangle>();
        List<Rectangle> Rights = new List<Rectangle>();
        List<String> ColoursL = new List<String>();
        List<String> ColoursR = new List<String>();

        bool upDown = false;
        bool downDown = false;
        bool wDown = false;
        bool sDown = false;
        bool power1 = false;
        bool power2 = false;

        int pSpeed = 5;
        int p1Score = 0;
        int p2Score = 0;
        int Speed = 10;
        int Counter = 0;
        int timerSpeed = 1;
        int timerCounter = 0;
        int pw1Counter = 0;
        int pw2Counter = 0;
        int asteroidl;
        int asteroidr;

        string gamestate = "waiting";

        Random rnd = new Random();

        Brush whiteBrush = new SolidBrush(Color.White);
        Brush goldBrush = new SolidBrush(Color.Gold);

        SoundPlayer bong = new SoundPlayer(Properties.Resources.TacoBell);
        SoundPlayer boom = new SoundPlayer(Properties.Resources.Boom);
        SoundPlayer smash = new SoundPlayer(Properties.Resources.Smash);

        Image ship = Properties.Resources.whiterocket;

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            //start the game
            titlelabel.Text = "";
            subtitlelabel.Text = "";

            gametimer.Enabled = true;
            gamestate = "running";
            Lefts.Clear();
            Rights.Clear();
            p1label.Visible = true;
            p2label.Visible = true;
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            //timer count down
            if (gamestate == "running")
            {
                timerCounter++;
            }

            if (timerCounter == 2)
            {
                timer.Y += timerSpeed;
                timerCounter = 0;
            }

            //check if score is equal
            if (timer.Y > 500)
            {
                if (p1Score != p2Score)
                {
                    gamestate = "over";
                }
                else
                {
                    pSpeed = 8;
                    titlelabel.Text = "OVERTIME!";
                }
            }

            //check if the game is over
            if (gamestate == "over")
            {
                //check if either player wins
                if (p1Score > p2Score)
                {
                    titlelabel.Text = "PLAYER 1 WINS!";
                }

                if (p2Score > p1Score)
                {
                    titlelabel.Text = "PLAYER 2 WINS";
                }
                gametimer.Enabled = false;
                p1label.Visible = false;
                p2label.Visible = false;
                subtitlelabel.Text = "Press space to restart or escape to exit";
                p1Score = 0;
                p2Score = 0;
                p1.X = 190;
                p1.Y = 450;
                p2.X = 290;
                p2.Y = 450;
                timer.Y = 0;
                Lefts.Clear();
                Rights.Clear();
            }
            
            //move players
            if (upDown == true)
            {
                p2.Y -= pSpeed;
            }
            if (downDown == true && p2.Y < this.Height - p2.Height)
            {
                p2.Y += pSpeed;
            }

            if (wDown == true)
            {
                p1.Y -= pSpeed;
            }
            if (sDown == true && p1.Y < this.Height - p1.Height)
            {
                p1.Y += pSpeed;
            }

            //create asteroids on a timer
            Counter++;

            if (Counter == 8)
            {
                Lefts.Add(new Rectangle(0, rnd.Next(0,420), 4, 4));
                asteroidl = rnd.Next(0, 10);
                if (asteroidl == 1)
                {
                    ColoursL.Add("gold");
                }
                else
                {
                    ColoursL.Add("white");
                }
                Rights.Add(new Rectangle(500, rnd.Next(0, 420), 4, 4));
                asteroidr = rnd.Next(0, 10);
                if (asteroidr == 1)
                {
                    ColoursR.Add("gold");
                }
                else
                {
                    ColoursR.Add("white");
                }
                Counter = 0;
            }

            //move asteroids
            for (int i = 0; i < Lefts.Count; i++)
            {
                int leftx = Lefts[i].X + Speed;
                Lefts[i] = new Rectangle(leftx, Lefts[i].Y, 4, 4);
            }

            for (int i = 0; i < Rights.Count; i++)
            {
                int rightx = Rights[i].X - Speed;
                Rights[i] = new Rectangle(rightx, Rights[i].Y, 4, 4);
            }

            //check if players intersects with rectangle
            for (int i = 0; i < Rights.Count; i++)
            {
                if (p2.IntersectsWith(Rights[i]))
                {
                    if (ColoursR[i] == "white")
                    {
                        if (power2 == true)
                        {
                            smash.Play();
                        }
                        else
                        {
                            p2.X = 290;
                            p2.Y = 450;
                            bong.Play();
                        }
                    }
                    else if (ColoursR[i] == "gold")
                    {
                        power2 = true;
                        pw2Counter = 0;
                    }
                }
            }

            for (int i = 0; i < Lefts.Count; i++)
            {
                if (p2.IntersectsWith(Lefts[i]))
                {
                    if (ColoursR[i] == "white")
                    {
                        if (power2 == true)
                        {
                            smash.Play();
                        }
                        else
                        {
                            p2.X = 290;
                            p2.Y = 450;
                            bong.Play();
                        }
                    }
                    else if (ColoursR[i] == "gold")
                    {
                        power2 = true;
                        pw2Counter = 0;
                    }
                }
            }

            for (int i = 0; i < Rights.Count; i++)
            {
                if (p1.IntersectsWith(Rights[i]))
                {
                    if (ColoursR[i] == "white")
                    {
                        if (power1 == true)
                        {
                            smash.Play();
                        }
                        else
                        {
                            p1.X = 190;
                            p1.Y = 450;
                            bong.Play();
                        }
                    }
                    else if (ColoursR[i] == "gold")
                    {
                        power1 = true;
                        pw1Counter = 0;
                    }
                }
            }

            for (int i = 0; i < Lefts.Count; i++)
            {
                if (p1.IntersectsWith(Lefts[i]))
                {
                    if (ColoursR[i] == "white")
                    {
                        if (power1 == true)
                        {
                            smash.Play();
                        }
                        else
                        {
                            p1.X = 190;
                            p1.Y = 450;
                            bong.Play();
                        }
                    }
                    else if (ColoursR[i] == "gold")
                    {
                        power1 = true;
                        pw1Counter = 0;
                    }
                }
            }

            //check powerup
            if (power1 == true)
            {
                pw1Counter++;
            }

            if (pw1Counter == 40)
            {
                power1 = false;
                pw1Counter = 0;
            }

            if (power2 == true)
            {
                pw2Counter++;
            }

            if (pw2Counter == 40)
            {
                power2 = false;
                pw2Counter = 0;
            }

            //check if either player hits finish
            if (p1.Y < 0)
            {
                boom.Play();
                p1Score++;
                p1label.Text = $"{p1Score}";

                p1.X = 190;
                p1.Y = 450;

                if (titlelabel.Text == "OVERTIME!")
                {
                    gamestate = "over";
                }
            }
            if (p2.Y < 0)
            {
                boom.Play();
                p2Score++;
                p2label.Text = $"{p2Score}";

                p2.X = 290;
                p2.Y = 450;

                if (titlelabel.Text == "OVERTIME!")
                {
                    gamestate = "over";
                }
            }

            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (gamestate == "waiting" || gamestate == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gamestate == "waiting" || gamestate == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gamestate == "running")
            {
                if (power1 == true)
                {
                    e.Graphics.FillRectangle(goldBrush, p1);
                }
                else
                {
                    e.Graphics.FillRectangle(whiteBrush, p1);
                }
                if (power2 == true)
                {
                    e.Graphics.FillRectangle(goldBrush, p2);
                }
                else
                {
                    e.Graphics.FillRectangle(whiteBrush, p2);
                }
                
                e.Graphics.FillRectangle(whiteBrush, timer);

                for (int i = 0; i < Lefts.Count; i++)
                {
                    if (ColoursL[i] == "gold")
                    {
                        e.Graphics.FillRectangle(goldBrush, Lefts[i]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(whiteBrush, Lefts[i]);
                    }
                }
                for (int i = 0; i < Rights.Count; i++)
                {
                    if (ColoursR[i] == "gold")
                    {
                        e.Graphics.FillRectangle(goldBrush, Rights[i]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(whiteBrush, Rights[i]);
                    }
                }
            }
        }
    }
}
