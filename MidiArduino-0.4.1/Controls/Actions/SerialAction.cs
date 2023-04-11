using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class SerialAction : UserControl
    {
        public SerialAction()
        {
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames())
            {
                serialPortDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(port));
            }
        }
    }
}
