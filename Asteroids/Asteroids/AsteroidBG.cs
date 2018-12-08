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
    class AsteroidBG : BaseObject 
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
        public AsteroidBG (Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
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
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}

