using AplikasiGambarProject.DrawingObjectList;
using AplikasiGambarProject.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject
{
    class Canvas : Control, ICanvas
    {
        private ITool activeTool;
        private List<DrawingObject> listObject;

        public Canvas()
        {
            init();
        }
        private void init()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.listObject = new List<DrawingObject>();
            this.Paint += Canvas_Paint;
            this.MouseDown += Canvas_MouseDown;
            this.MouseUp += Canvas_MouseUp;
            this.MouseMove += Canvas_MouseMove;

            this.KeyDown += Canvas_HotkeysDown;
            this.KeyUp += Canvas_HotkeysUp;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject obj in listObject)
            {
                obj.graphics = e.Graphics;
                obj.Draw();
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
            }
        }
        private void Canvas_HotkeysDown(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolHotKeysDown(sender, e);
            }
        }
        private void Canvas_HotkeysUp(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolHotKeysUp(sender, e);
            }
        }

        public ITool GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.listObject.Add(drawingObject);
        }
        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public List<DrawingObject> getListDrawingObject()
        {
            return listObject;
        }
    }
}
