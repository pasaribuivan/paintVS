using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject.Interface
{
    public interface ITool
    {
        ICanvas TargetCanvas { get; set; }

        void ToolMouseDown(object sender, MouseEventArgs e);

        void ToolMouseUp(object sender, MouseEventArgs e);

        void ToolMouseMove(object sender, MouseEventArgs e);

        void ToolHotKeysDown(object sender, KeyEventArgs e);

        void ToolHotKeysUp(object sender, KeyEventArgs e);
    }
}
