using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace AsteroidsGame
{
    /// <summary>
    /// Класс, описывающий логику игры
    /// </summary>
    static class Game
    {
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Planet _planet;
        private static AsteroidBG _asteroidBG;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();

        // Свойства
        // Ширина ивысота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Статический конструктор класса
        /// </summary>
        static Game()
        {
        }

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой              
            // Запоминаем размеры формы                           
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;


        }


        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

            /// <summary>
            /// Счётчик обновления кадров
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw(); Update();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            _planet.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            _asteroidBG.Draw();
            if (_ship != null)
            Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();

        }

        /// <summary>
        /// Метод, обновляющий каждый объект
        /// </summary>
        public static void Update()
        {
            var rnd1 = new Random();
            int r1 = rnd1.Next(5, 50);
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
            foreach (Asteroid obj in _asteroids)
            {
                obj.Update();
                if (obj.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();

                }
                _planet.Update();
                _bullet?.Update();
                _asteroidBG.Update();
            }
        }

        /// <summary>
        /// Массив объектов
        /// </summary>
        public static BaseObject[] _objs;

        /// <summary>
        /// Создание экземпляров классов
        /// </summary>
        public static void Load()
        {

            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[5];
            _planet = new Planet(new Point(2000, 60), new Point(-1, 0), new Size(40, 40));
            
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(2000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(10, 50);
                _asteroids[i] = new Asteroid(new Point(2000, rnd.Next(0, Game.Height)), new Point(-r/4, r), new Size(r, 200));
                _asteroidBG = new AsteroidBG(new Point(2000, rnd.Next(0, Game.Height)), new Point(-4, 1), new Size(8, 8));
            }
            //for (int i = 0; i < _objs.Length; i++)
            //{

            //    _objs[i] = new Planet(new Point(i, i * 20), new Point(-i, 0), new Size(20, 20));
            //}


            //for (int i = 16; i < 17; i++)
            //    _objs[i] = new AsteroidBG(new Point(i * 2, i * 25), new Point(-i, 0), new Size(8, 4));
            //for (int i = 3; i < 4; i++)
            //    _objs[i] = new AsteroidBG(new Point(i, i * 20), new Point(-i, 0), new Size(10, 10));
            //for (int i = 18; i < 19; i++)
            //    _objs[i] = new AsteroidBG(new Point(i * 2, i * 25), new Point(-2 * i, 0), new Size(8, 4));

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                { System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null; _bullet = null;
                    continue;
                } if (!_ship.Collision(_asteroids[i]))
                    continue;
                var rnd1 = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}
