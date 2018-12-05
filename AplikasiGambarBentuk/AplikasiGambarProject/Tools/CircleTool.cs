using AplikasiGambarProject.DrawingObjectList;
using AplikasiGambarProject.Interface;
using AplikasiGambarProject.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject.Tools
{
    class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }


        public CircleTool()
        {
            this.Name = "Circle tool";
            this.ToolTipText = "Circle tool";
            this.CheckOnClick = true;
            this.Text = "Lingkaran";
        }


        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.Location, e.Location);
                this.circle.ChangeState(PreviewState.GetInstance());
                this.canvas.AddDrawingObject(this.circle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.circle != null)
                {
                    this.circle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (circle != null)
            {
                this.circle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                this.circle.ChangeState(StaticState.GetInstance());
            }
        }

        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
