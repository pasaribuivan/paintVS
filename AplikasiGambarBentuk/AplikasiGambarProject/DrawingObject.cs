using System;
using System.Collections.Generic;
using System.Drawing;
using AplikasiGambarProject.State;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject
{
    public abstract class DrawingObject
    {
        public Graphics graphics;
        protected DrawingState state;
        public Point Startpoint;
        public Point Endpoint;
        public Pen pen = new Pen(Color.Black);

        public virtual void Draw()
        {
            this.state.Draw(this);
        }
        abstract public void DrawLogic();
        abstract public Boolean intersect(Point MousePosition);
        public virtual void move(int x, int y, int xAmount, int yAmount) {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }
        public virtual void ChangeState(DrawingState state)
        {
            this.state = state;
        }
        public void RenderOnPreview() {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            DrawLogic();
        }
        public void RenderOnEditingView() {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            DrawLogic();
        }
        public void RenderOnStaticView() {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            DrawLogic();
        }
    }
}
