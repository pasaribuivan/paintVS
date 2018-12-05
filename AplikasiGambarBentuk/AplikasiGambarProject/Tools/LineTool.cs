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
    class LineTool : ToolStripButton, ITool
    {
        private ICanvas canvas;

        private Line lineSegment;

        public LineTool()
        {
            this.Name = "Line tool";
            this.ToolTipText = "Line tool";
            this.CheckOnClick = true;
            this.Text = "Garis";
        }

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

        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lineSegment = new Line(new System.Drawing.Point(e.X, e.Y));
                lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                this.lineSegment.ChangeState(PreviewState.GetInstance());
                canvas.AddDrawingObject(lineSegment);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    this.lineSegment.ChangeState(StaticState.GetInstance());
                }
            }

        }
        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
