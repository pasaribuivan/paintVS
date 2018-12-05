using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikasiGambarProject.Interface;
using AplikasiGambarProject.Tools;

namespace AplikasiGambarProject
{
    public partial class MainWindow : Form
    {

        private IToolbox toolbox;

        private ICanvas Canvas;

        public MainWindow()
        {
            InitializeComponent();
            initToolbox();
        }

        private void initToolbox()
        {
            this.Canvas = new Canvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.Canvas);

            this.toolbox = new Toolbox();

            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new RectangleTool());
            this.toolbox.AddTool(new CircleTool());
            this.toolbox.AddTool(new SelectTool());
            this.toolbox.AddTool(new ConnectorTool());

            this.toolbox.ToolSelected += Toolbox_ToolSelected;
        }
        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.Canvas != null)
            {
                this.Canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.Canvas;
            }
        }

    }
}
