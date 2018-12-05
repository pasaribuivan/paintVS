using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiGambarProject.Interface
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolbox
    {
        void AddTool(ITool tool);

        event ToolSelectedEventHandler ToolSelected;
    }
}
