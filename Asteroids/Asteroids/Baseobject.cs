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
    /// Абстрактный класс со своими методами и параметрами
    /// </summary>
    abstract class BaseObject :ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Конструктор с параметрами  точки, направления и размера для базового объекта
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Абстрактный метод рисования для абстрактного класса
        /// </summary>
        public abstract void Draw();
        //{
        //    Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);

        //}

        /// <summary>
        /// Метод обновления, оперирующий координатами точки и направления для отрисовки следующего кадра
        /// </summary>
        public abstract void Update();
        //{
        //    Pos.X = Pos.X + Dir.X;
        //    Pos.Y = Pos.Y + Dir.Y;
        //    if (Pos.X < 0) Dir.X = -Dir.X;
        //    if (Pos.X > Game.Width) Dir.X = -Dir.X;
        //    if (Pos.Y < 0) Dir.Y = -Dir.Y;
        //    if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        //}
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

    }
}
