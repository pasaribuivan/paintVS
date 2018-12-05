using AplikasiGambarProject.DrawingObjectList;
using AplikasiGambarProject.Interface;
using AplikasiGambarProject.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject.Tools
{
    class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rect rectangle;

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

        public RectangleTool()
        {
            this.Name = "Rectangle tool";
            this.ToolTipText = "Rectangle tool";
            this.Text = "Kotak";
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle = new Rect(e.Location, e.Location);
                this.rectangle.ChangeState(PreviewState.GetInstance());
                this.canvas.AddDrawingObject(this.rectangle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.rectangle != null)
                {
                    this.rectangle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle != null)
            {
                this.rectangle.Endpoint = new System.Drawing.Point(e.X, e.Y);
                this.rectangle.ChangeState(StaticState.GetInstance());
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
