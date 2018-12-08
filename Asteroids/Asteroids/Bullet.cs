using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidsGame
{
    /// <summary>
    /// Наследованный от BaseObject класс
    /// </summary>
    class Bullet :BaseObject
    {
        /// <summary>
        /// Конструктор с параметрами  точки, направления и размера для базового объекта
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Метод рисования снарядов
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Свой для этого класса перегруженный метод обновления
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }
    }
}
