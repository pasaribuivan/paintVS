using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiGambarProject.Interface
{
    public interface IMenuItem
    {
        string MenuItemName { get; set; }

        void addCommand(ICommand command);
    }
}
