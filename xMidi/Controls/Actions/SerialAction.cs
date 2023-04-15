using NAudio.Midi;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using xMidi.Utils;

namespace xMidi.Controls.Actions
{
    public partial class SerialAction : UserControl
    {
        public bool DtrEnable = false;
        public bool RtsEnable = false;
        public SerialAction()
        {
            InitializeComponent();

            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send Serial"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Connect"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Disconnect"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Signal"));

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                parityDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(s));
            }
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                if (s != "None") stopBitsDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(s));
            }
            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                handshakeDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(s));
            }
            foreach (string port in SerialPort.GetPortNames())
            {
                serialPortDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(port));
            }

            stopBitsDrop.SelectedItem = stopBitsDrop.Items[0];
        }

        public void serialData(MidiEvent e, bool async)
        {
            if (async) new Thread(() => { serialData(e); }).Start();
            else serialData(e);
        }
        public void serialData(MidiEvent e)
        {
            try
            {
                #region ControlType

                if (serialPortDrop.Items.Count < 1) return;

                if (deviceControlDrop.SelectedItem.Text == "Connect")
                {
                    SerialPort port = new SerialPort();
                    port.PortName = serialPortDrop.SelectedItem.Text;
                    port.BaudRate = (int)baudRateNum.Value;
                    port.Parity = (Parity)parityDrop.Items.IndexOf(parityDrop.SelectedItem);
                    port.DataBits = (int)dataBitsNum.Value;
                    port.StopBits = (StopBits)stopBitsDrop.Items.IndexOf(stopBitsDrop.SelectedItem) + 1;
                    port.Handshake = (Handshake)handshakeDrop.Items.IndexOf(handshakeDrop.SelectedItem);

                    port.DtrEnable = DtrEnable;
                    port.RtsEnable = RtsEnable;

                    Helper.serialPorts.Add(port);
                    if (!port.IsOpen) port.Open();
                    return;
                }
                else if (deviceControlDrop.SelectedItem.Text == "Disconnect")
                {
                    if (Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text) != null)
                    {
                        Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text).Close();
                        Helper.serialPorts.Remove(Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text));
                    }
                    return;
                }
                else if (deviceControlDrop.SelectedItem.Text == "Signal")
                {
                    if (Helper.serialPorts.Exists(x => x.PortName == serialPortDrop.SelectedItem.Text)) return;

                    SerialPort port = new SerialPort();
                    port.PortName = serialPortDrop.SelectedItem.Text;
                    port.BaudRate = (int)baudRateNum.Value;
                    port.Parity = (Parity)parityDrop.Items.IndexOf(parityDrop.SelectedItem);
                    port.DataBits = (int)dataBitsNum.Value;
                    port.StopBits = (StopBits)stopBitsDrop.Items.IndexOf(stopBitsDrop.SelectedItem) + 1;
                    port.Handshake = (Handshake)handshakeDrop.Items.IndexOf(handshakeDrop.SelectedItem);

                    port.DtrEnable = DtrEnable;
                    port.RtsEnable = RtsEnable;

                    if (!port.IsOpen) port.Open();
                    if (port.IsOpen) port.Write(MIDIButton.replaceAliases(stringTxt.Text, e));
                    if (port.IsOpen) port.Close();
                    port.Dispose();
                }
                else
                {
                    if (!Helper.serialPorts.Exists(x => x.PortName == serialPortDrop.SelectedItem.Text)) return;
                    Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text).Write(MIDIButton.replaceAliases(stringTxt.Text, e));
                }

                #endregion
            }
            catch (System.UnauthorizedAccessException) { }
        }
        private void deviceControlDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            if (deviceControlDrop.SelectedItem.Text == "Connect")
            {
                baudRateNum.Enabled = true;
                parityDrop.Enabled = true;
                dataBitsNum.Enabled = true;
                stopBitsDrop.Enabled = true;
                handshakeDrop.Enabled = true;
                stringTxt.Enabled = false;
            }
            else if (deviceControlDrop.SelectedItem.Text == "Disconnect")
            {
                baudRateNum.Enabled = false;
                parityDrop.Enabled = false;
                dataBitsNum.Enabled = false;
                stopBitsDrop.Enabled = false;
                handshakeDrop.Enabled = false;
                stringTxt.Enabled = false;
            }
            else if (deviceControlDrop.SelectedItem.Text == "Signal")
            {
                baudRateNum.Enabled = true;
                parityDrop.Enabled = true;
                dataBitsNum.Enabled = true;
                stopBitsDrop.Enabled = true;
                handshakeDrop.Enabled = true;
                stringTxt.Enabled = true;
            }
            else
            {
                baudRateNum.Enabled = false;
                parityDrop.Enabled = false;
                dataBitsNum.Enabled = false;
                stopBitsDrop.Enabled = false;
                handshakeDrop.Enabled = false;
                stringTxt.Enabled = true;
            }
        }
        public void disconnect()
        {
            if (Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text) != null)
            {
                Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text).Close();
                Helper.serialPorts.Remove(Helper.serialPorts.Find(x => x.PortName == serialPortDrop.SelectedItem.Text));
            }
        }
    }
}
