using AplikasiGambarProject.Interface;
using AplikasiGambarProject.State;
using AplikasiGambarProject.DrawingObjectList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AplikasiGambarProject.Tools
{
    class SelectTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private int xInitial;
        private int yInitial;
        private DrawingObject currentObject = null;

        private Boolean multiselectProcess = false;


        private List<DrawingObject> memberGroup = new List<DrawingObject>();
        
        public SelectTool()
        {
            this.Name = "Select tool";
            this.ToolTipText = "Select tool";
            this.CheckOnClick = true;
            this.Text = "Select";
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
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;
            if (currentObject != null && !multiselectProcess) currentObject.ChangeState(StaticState.GetInstance());
            foreach (DrawingObject obj in this.canvas.getListDrawingObject().Reverse<DrawingObject>())
            {
                if (obj.intersect(e.Location))
                {
                    if (!multiselectProcess) memberGroup.Clear();
                    else
                    {
                        if (!memberGroup.Any() && this.currentObject != null) memberGroup.Add(this.currentObject);
                        memberGroup.Add(obj);
                    }
                    this.currentObject = obj;
                    obj.ChangeState(EditingState.GetInstance());
                    break;
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.currentObject != null)
            {
                int xAmount = e.X - xInitial;
                int yAmount = e.Y - yInitial;
                xInitial = e.X;
                yInitial = e.Y;
                currentObject.move(e.X, e.Y, xAmount, yAmount);
            }
        }
        public void ToolMouseUp(object sender, MouseEventArgs e)
        {


        }
        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = true;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.G)
            {
                if (memberGroup.Count() > 0)
                {
                    this.objIntersect();
                    GroupShape groupObject = new GroupShape();
                    foreach (DrawingObject obj in memberGroup)
                    {
                        groupObject.addMember(obj);
                    }

                    groupObject.ChangeState(EditingState.GetInstance());
                    this.canvas.AddDrawingObject(groupObject);
                    this.currentObject = groupObject;
                }
            }
            
        }

        public void objIntersect()
        {
            //System.Diagnostics.Debug.WriteLine(memberGroup[0]);
            Rect r1 = (memberGroup[0] as Rect);
            Rect r2 = (memberGroup[1] as Rect);

            int leftX = Math.Max(r1.Startpoint.X, r2.Startpoint.X);
            int rightX = Math.Min(r1.Startpoint.X + (r1.Endpoint.X - r1.Startpoint.X), r2.Startpoint.X + (r2.Endpoint.X - r2.Startpoint.X));
            int topY = Math.Max(r1.Startpoint.Y, r2.Startpoint.Y);
            int bottomY = Math.Min(r1.Startpoint.Y + (r1.Endpoint.Y - r1.Startpoint.Y), r2.Startpoint.Y + (r2.Endpoint.Y - r2.Startpoint.Y));

            Point startPoint = new Point(leftX, topY);
            Point endPoint = new Point(rightX, bottomY);
            Rect intersectionRect = new Rect(startPoint, endPoint);
            
            intersectionRect.ChangeState(IntersectState.GetInstance());
            
            this.canvas.AddDrawingObject(intersectionRect);
            //memberGroup.Add(intersectionRect);

        }

        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = false;
            }
        }
    }
}