using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiGambarProject.State
{
    class EditingState : DrawingState
    {
        private static DrawingState instance;

        public static DrawingState GetInstance()
        {
            if (instance == null)
            {
                instance = new EditingState();
            }
            return instance;
        }

        public override void Draw(DrawingObject obj)
        {
            obj.RenderOnEditingView();
        }
    }
}
