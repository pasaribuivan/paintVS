using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject.DrawingObjectList
{
    class Rect : DrawingObject
    {

        public Rect(Point startPoints, Point endPoints)
        {
            this.Startpoint = startPoints;
            this.Endpoint = endPoints;
        }

        public override void DrawLogic()
        {
            if (Startpoint.X > Endpoint.X)
            {
                var temp = Startpoint.X;
                Startpoint.X = Endpoint.X;
                Endpoint.X = temp;
            }
            if (Startpoint.Y > Endpoint.Y)
            {
                var temp = Startpoint.Y;
                Startpoint.Y = Endpoint.Y;
                Endpoint.Y = temp;
            }
            Rectangle objek = new Rectangle(Startpoint.X, Startpoint.Y, Endpoint.X - Startpoint.X, Endpoint.Y - Startpoint.Y);
            this.graphics.DrawRectangle(pen, objek);
        }

        public override bool intersect(Point MousePosition)
        {
            if ((MousePosition.X >= Startpoint.X && MousePosition.X <= Startpoint.X + (Endpoint.X - Startpoint.X)) && (MousePosition.Y >= Startpoint.Y && MousePosition.Y <= Startpoint.Y + (Endpoint.Y - Startpoint.Y)))
            {
                return true;
            }
            return false;
        }
    }
}
