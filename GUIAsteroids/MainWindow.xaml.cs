using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game;
using Game.Maine;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace GUIAsteroids
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGame _game;
        private UInt64 Score = 0;

        private static List<SomeClass> str = new List<SomeClass>();

        public MainWindow()
        {
            InitializeComponent();
            MyGrid.Margin = new Thickness(13, 15, 33, 64);
            Polygon obj = new Polygon();
            obj.Points.Add(new Point(5, 5));
            obj.Points.Add(new Point(10, 5));
            obj.Points.Add(new Point(5, 10));
            obj.Fill = Brushes.Azure;

            MyGrid.Children.Add(obj);

            str.Add(new SomeClass("hello", new Point(15, 200), 15));
            str.Add(new SomeClass("World", new Point(124, 254), 30));
            str.Add(new SomeClass("how", new Point(5, 200), 45));
            str.Add(new SomeClass("are", new Point(560, 100), 115));
            str.Add(new SomeClass("you", new Point(1, 50), 15));

            foreach (var some in str)
            {
                TextBlock tb = new TextBlock();
                tb.Foreground = Brushes.White;
                tb.Margin = new Thickness(some.Pos.X, some.Pos.Y, some.Pos.X + 10, some.Pos.Y + 10);
                tb.RenderTransform = new RotateTransform(some.Angle);
                Hello.Children.Add(tb);
            }

            for (int i = 0; i <= 1000; i++)
            {
                foreach (var some in str)
                {
                    Point.Add(some.Pos, new Vector(1, 1));
                }
            }

            DataContext = str;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void NewGame()
        {
            _game = GameLoaderInjector.GetGame();
            _game.PlayerLoose += new EventHandler<LooseEventArgs>(OnPlayerLoose);
        }

        private void OnPlayerLoose(Object obj, LooseEventArgs e)
        {
            
        }

    }

    public class SomeClass
    {
        public string Text { get; set;}
        public Point Pos { get; set; }
        public double Angle { get; set; }

        public SomeClass(string text, Point pos, double angle)
        {
            Text = text;
            Pos = pos;
            Angle = angle;
        }
    }
}
