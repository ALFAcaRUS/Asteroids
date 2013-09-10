using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Asteroids.GraphicConstructors;
using Game;
using Game.Maine;

namespace Asteroids
{
    public sealed partial class Asteroids : Form
    {
        private bool forward = false;
        private bool back = false;
        private bool right = false;
        private bool left = false;
        private bool[] weaponShut = new bool[2];
        private IGame Game;
        AGraphicConstructor grCons;
        private SpritGraphicConstructor spriteConst = new SpritGraphicConstructor();
        private PoligonGraphicConstructor polGrap = new PoligonGraphicConstructor();
        private Image backGround = Image.FromFile(@"Source/Sprits/BackGround.jpg");

        public Asteroids()
        {
            InitializeComponent();
            grCons = polGrap;
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
            weaponShut[0] = false;
            weaponShut[1] = false;
            Game = GameLoaderInjector.GetGame();
            Game.PlayerLoose += new EventHandler<LooseEventArgs>(OnPlayerLoose);
            timer1.Enabled = true;
        }


        public void Drawing(List<ViewObject> objects)
        {

            Image buf = new Bitmap(Wall.Width, Wall.Height);
            Graphics grap = Graphics.FromImage(buf);
            Brush backGroundBrush = new TextureBrush(backGround);
            //Brush backGroundBrush = Brushes.Black;

            grap.FillRectangle(backGroundBrush, 0, 0, Width, Height);

            backGroundBrush.Dispose();


            grCons.Init(Width, Height);

            foreach (var obj in objects)
            {
                grCons.GetImage(obj, grap);
            }

            //Font scoreFont = new Font("");

            polGrap.Init(Wall.Width, Wall.Height);

            Graphics wallGraphics = Wall.CreateGraphics();
            wallGraphics.DrawImage(buf, 0,0);


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

        private void Asteroids_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'g')
            {
                if (grCons.GetType() == spriteConst.GetType())
                {
                    grCons = polGrap;
                }
                else
                {
                    grCons = spriteConst;
                }
            }
        }




    }
}

            /*Bitmap ship2 = new Bitmap(32, 32);
            Graphics shipGraphics2 = Graphics.FromImage(ship2);

            Rectangle shipRectangle2 = new Rectangle(0, 0, 32, 32);
            Brush shipBrush2 = new TextureBrush(shipImage);
            

            float angle = (float) rectangle.Angle.Angle;

            //shipGraphics2.TranslateTransform(50, 50);

            //shipGraphics2.RotateTransform(angle);

            shipGraphics2.FillRectangle(shipBrush2, shipRectangle2);

            //shipGraphics2.FillPolygon(shipBrush2, rectangle.GetPoints());

           // shipGraphics2.ResetTransform();

            grap.DrawImage(ship2, rectangle.GetPoints());*/
