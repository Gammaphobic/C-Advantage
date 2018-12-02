using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace AsteroidsGame
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw(); Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
                    
        }
        public static void Update()
        {
            foreach( BaseObject obj in _objs)
            {
                obj.Update();
            }
        }
        public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[50];

            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(i*3, i * 12), new Point(-i, 0), new Size(2, 2));
            for (int i = 1; i < 2; i++)
                _objs[i] = new Planet(new Point(i, i * 20), new Point(-i, 0), new Size(20, 20));
            for (int i = 16; i < 17; i++)
                _objs[i] = new Asteroid(new Point(i*2, i * 25), new Point(-i, 0), new Size(6, 3));
            for (int i = 3; i <4; i++)
                _objs[i] = new Asteroid(new Point(i, i * 20), new Point(-i, 0), new Size(10, 10));
        }
    }
}
