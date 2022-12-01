using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClonOSU
{
    public partial class Form1 : Form
    {
        public Bitmap HandlerTexure = Resource1.Handler;
        public Bitmap TargetTexure = Resource1.Target;
        private Point _targetPosition = new Point (300, 300);
        private Point _direction = Point.Empty;
        

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            var localposition = this.PointToClient(Cursor.Position);

            int _directionX = 10;
            _targetPosition.X += _directionX * 10;
            int _directionY = 10;
            _targetPosition.Y += _directionY * 10;
            
            var handlerRect  = new Rectangle(localposition.X - 50, localposition.Y - 50, 100, 100);
            var targetRect = new Rectangle(localposition.X - 50, localposition.Y - 50, 100, 100);
           
            g.DrawImage(HandlerTexure, handlerRect);
            g.DrawImage(TargetTexure, targetRect);
            
            if (_targetPosition.X < 0 || _targetPosition.X > 500);
            {
                _targetPosition.X = 200;
            }
            if (_targetPosition.Y > 0 || _targetPosition.Y < 500);
            {
                _targetPosition.Y = 200;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
             timer2.Interval = r.Next(25, 1000);
            _direction.X = r.Next(-1, 1);
            _direction.Y = r.Next(-1, 1);
        }
    }
}
