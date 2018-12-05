using AplikasiGambarProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiGambarProject
{
    class Toolbar : ToolStrip, IToolbar
    {
        public Toolbar()
        {
            this.Dock = DockStyle.Top;
        }

        public void addToolbarItem(IToolbarItem toolbarItem)
        {
            this.Items.Add((ToolStripItem)toolbarItem);
        }
    }
}
