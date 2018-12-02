using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidsGame
{
    class Planet:BaseObject
    {
        float startAngle;
        float sweepAngle;
      
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
           startAngle = -26;
           sweepAngle = 232;
        }
        public override void Draw()
        {
      
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawArc(Pens.White, Pos.X- Size.Width/2, Pos.Y+ Size.Height/3, Size.Width*2, Size.Height/2, startAngle, sweepAngle);

        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
        
    
}
