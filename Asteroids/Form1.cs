using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Game;
using Game.Maine;

namespace Asteroids
{
    public sealed partial class Form1 : Form
    {
        private bool forward = false;
        private bool back = false;
        private bool right = false;
        private bool left = false;
        private bool[] weaponShut = new bool[2];
        private IGame Game;

        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        public void OnPlayerLoose(object obj,LooseEventArgs e)
        {
            timer1.Enabled = false;
            string text = "Вы проиграли! Ваш счет: " + e.Score + ". Начать новую игру?";
            var Resum = MessageBox.Show(text, "Loose", MessageBoxButtons.YesNo);
            if (Resum == DialogResult.Yes)
            {
                NewGame();
            }
            else
            {
                Application.Exit();
            }

        }

        private void NewGame()
        {

            forward = false;
            back = false;
            right = false;
            left = false;
            Game = GameLoaderInjector.GetGame();
            Game.PlayerLoose += new EventHandler<LooseEventArgs>(OnPlayerLoose);
            timer1.Enabled = true;
        }


        public void Drawing(List<ViewObject> objects)
        {
            Graphics grap = Wall.CreateGraphics();

            CoupleDouble scale = new CoupleDouble(Width/200.0, Height/200.0);
            CoupleDouble offset = scale * new CoupleDouble(100, 100);

            grap.FillRectangle(Brushes.Black, 0, 0, Width, Height);

            foreach (var obj in objects)
            {
                switch(obj.Name)
                {
                    case "Asteroid 1":
                    {
                        CoupleDouble point = obj.Pos*scale + offset;
                        CoupleDouble objSize = new CoupleDouble(3, 3);

                        Point location = new Point((int) Math.Round(point.X), (int) Math.Round(point.Y));
                        Size scaledSize = new Size((int) Math.Round(objSize.X), (int) Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Gray, rec);
                    }
                    break;
                    case "Asteroid 2":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(5, 5);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.White, rec);
                    }
                    break;
                    case "Ufo":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(5, 5);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Blue, rec);
                    }
                    break;
                    case "ShipPos":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(5, 5);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Green, rec);
                    }
                    break;
                    case "ShipRot":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(5, 5);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Violet, rec);
                    }
                    break;
                    case "GunBullet":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(2, 2);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Gray, rec);
                    }
                    break;
                    case "LaserBulet":
                    {
                        CoupleDouble point = obj.Pos * scale + offset;
                        CoupleDouble objSize = new CoupleDouble(5, 5);

                        Point location = new Point((int)Math.Round(point.X), (int)Math.Round(point.Y));
                        Size scaledSize = new Size((int)Math.Round(objSize.X), (int)Math.Round(objSize.Y));

                        Rectangle rec = new Rectangle(location, scaledSize);
                        grap.FillEllipse(Brushes.Red, rec);
                    }
                    break;

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<UserAction> actions = new List<UserAction>();
            if (forward) actions.Add(new UserAction(UserActionType.Forward, 1));
            if (back) actions.Add(new UserAction(UserActionType.Back, 1));
            if (left) actions.Add(new UserAction(UserActionType.LeftShift, 1));
            if (right) actions.Add(new UserAction(UserActionType.RightShift, 1));
            if (weaponShut[0]) actions.Add(new UserAction(UserActionType.Shoot, 0));
            if (weaponShut[1]) actions.Add(new UserAction(UserActionType.Shoot, 1));    
            Drawing(Game.Tick(actions));
        }



        // I know, it's wery long functions, but they wery simple.
        // Nothing better occurred to me
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                {
                    forward = true;
                    back = false;
                }
                    break;
                case Keys.Down:
                {
                    forward = false;
                    back = true;
                }
                    break;
                case Keys.Left:
                {
                    left = true;
                    right = false;
                }
                    break;
                case Keys.Right:
                {
                    left = false;
                    right = true;
                }
                    break;

                case Keys.Space:
                {
                    weaponShut[0] = true;
                }
                    break;

                case Keys.W:
                {
                    weaponShut[1] = true;
                }
                    break;
                case Keys.Escape:
                {
                    timer1.Enabled = false;
                    string message = "Вы уверены, что хотите выйти из игры?";
                    var canResum = MessageBox.Show(message, "Quit", MessageBoxButtons.YesNo);
                    if (canResum == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        timer1.Enabled = true;
                    }
                }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        forward = false;
                    }
                    break;
                case Keys.Down:
                    {
                        back = false;
                    }
                    break;
                case Keys.Left:
                    {
                        left = false;
                    }
                    break;
                case Keys.Right:
                    {
                        right = false;
                    }
                    break;

                case Keys.Space:
                    {
                        weaponShut[0] = false;
                    }
                    break;

                case Keys.W:
                    {
                        weaponShut[1] = false;
                    }
                    break;
            }

        }




    }
}
