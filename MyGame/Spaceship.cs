using System.Drawing;

namespace MyGame
{
    class SpaceShip : BaseObject
    {
        public SpaceShip(Point pos, Size size) : base(pos, new Point(), size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Properties.Resources.planetExpress, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            
        }
    }
}
