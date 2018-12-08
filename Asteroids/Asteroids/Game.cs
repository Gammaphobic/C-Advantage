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
    class Game
    {
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Planet _planet;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

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
            foreach (Asteroid obj in _asteroids)
            {
                obj.Draw();
            }
            _planet.Draw();
            _bullet.Draw();
            Buffer.Render();
                    
        }

        /// <summary>
        /// Метод, обновляющий каждый объект
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); }
            }
            _bullet.Update();
        
            _planet.Update();
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
            _planet = new Planet(new Point(1000, 60), new Point(-2, 0), new Size(20, 20)); 
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r/5, r), new Size(r, r));
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
        }
    }
}
