using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Random _rnd = new Random();
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs; 
        public static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new Star1(new Point(_rnd.Next(0, Game.Width), _rnd.Next(0, Game.Height)), new Point(1, 1), new Size(10, 10));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(_rnd.Next(0, Game.Width), _rnd.Next(0, Game.Height)), new Point(i, i), new Size(5, 5));
        }
        private static void Timer_Tick(object sender, EventArgs e) 
        {
            Draw();
            Update();
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
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) 
                obj.Draw();
            Buffer.Render(); 
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}
