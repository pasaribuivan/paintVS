using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiGambarProject.Interface
{
    public interface ICanvas
    {
        ITool GetActiveTool();

        void SetActiveTool(ITool tool);

        void AddDrawingObject(DrawingObject drawingObject);

        List<DrawingObject> getListDrawingObject();

        void Repaint();
    }
}
