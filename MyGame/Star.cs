using System.Drawing;

namespace MyGame
{
    
    class Star: BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) 
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.IndianRed, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.LemonChiffon, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width) Pos.X =  Size.Width;
        }
    }
}
