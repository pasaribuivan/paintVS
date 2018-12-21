using System;
using System.Collections.Generic;
using AplikasiGambarProject.State;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace AplikasiGambarProject.DrawingObjectList
{
    class GroupShape : DrawingObject
    {
        private List<DrawingObject> memberGroup = new List<DrawingObject>();
        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.ChangeState(state);
            }
            this.state = state;
        }
        public override void DrawLogic()
        {
            foreach(DrawingObject obj in memberGroup)
            {
                obj.Draw();
            }
        }

        public override bool intersect(Point MousePosition)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                if (obj.intersect(MousePosition)){
                    return true;
                }
            }
            return false;
        }
        /*
        public void objIntersect()
        {
            System.Diagnostics.Debug.WriteLine(memberGroup[0]);
            Rect r1 = (memberGroup[0] as Rect);
            Rect r2 = (memberGroup[1] as Rect);

            int leftX = Math.Max(r1.Startpoint.X, r2.Startpoint.X);
            int rightX = Math.Min(r1.Startpoint.X + (r1.Endpoint.X - r1.Startpoint.X), r2.Startpoint.X + (r2.Endpoint.X - r2.Startpoint.X));
            int topY = Math.Max(r1.Startpoint.Y, r2.Startpoint.Y);
            int bottomY = Math.Min(r1.Startpoint.Y + (r1.Endpoint.Y - r1.Startpoint.Y), r2.Startpoint.Y + (r2.Endpoint.Y - r2.Startpoint.Y));

            Point startPoint = new Point(leftX, topY);
            Point endPoint = new Point(rightX, bottomY);
            Rect intersectionRect = new Rect(startPoint, endPoint);
            //intersectionRect.
            memberGroup.Add(intersectionRect);
           
        }
        */
        public override void move(int x, int y, int xAmount, int yAmount)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.move(x,y,xAmount,yAmount);
            }
        }
        public void addMember(DrawingObject obj)
        {
            this.memberGroup.Add(obj);
        }
        public void removeMember(DrawingObject obj)
        {
            //this.memberGroup.Remove(obj);
        }
    }
}
