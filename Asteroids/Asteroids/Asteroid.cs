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
    /// Наследованный от BaseObject класс
    /// </summary>
    class Asteroid : BaseObject, ICloneable
    {
        /// <summary>
        /// Свойство по умолчанию
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Конструктор на основе конструктора базового класса
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            asteroid.Power = Power;
            return asteroid;
        }

        /// <summary>
        /// Свой для этого класса перегруженный метод обновления 
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        /// <summary>
        /// Свой для этого класса перегруженный метод рисования 
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
