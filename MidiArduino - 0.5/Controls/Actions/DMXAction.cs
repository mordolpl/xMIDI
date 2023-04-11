using BrunoDPO.DMX;
using MidiArduino.Utils;
using NAudio.Midi;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class DMXAction : UserControl
    {
        private int time = 0;
        private int incrementor = 1;
        private bool isRunning = true;
        public bool value = true;
        private MidiEvent midiEvent;
        private int channel;
        private double b, c, d;
        private Stopwatch watch = new Stopwatch();
        private DMXCommunicator communicator;

        public DMXAction()
        {
            InitializeComponent();

            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Linear"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Quadratic"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Cubic"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Quartic"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Quintic"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Sinusoidal"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Exponential"));
            funcDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Circular"));

            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send DMX"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Connect"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Disconnect"));
            deviceControlDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Signal"));

            foreach(string port in DMXCommunicator.GetValidSerialPorts())
            {
                devicesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(port));
            }
        }
        private void funcDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            if(funcDrop.SelectedItem.Text == "Linear")
            {
                funcTypeDrop.Items.Clear();
                funcTypeDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("In"));
            }
            else
            {
                funcTypeDrop.Items.Clear();
                funcTypeDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("In"));
                funcTypeDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Out"));
                funcTypeDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("In/Out"));
            }
        }
        private void deviceControlDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            if (deviceControlDrop.SelectedItem.Text == "Connect" || deviceControlDrop.SelectedItem.Text == "Disconnect")
            {
                channelNum.Enabled = false;
                channelTxt.Enabled = false;
                switchBtn.Enabled = false;
                funcDrop.Enabled = false;
                funcTypeDrop.Enabled = false;
                bNum.Enabled = false;
                cNum.Enabled = false;
                dNum.Enabled = false;
                bTxt.Enabled = false;
                cTxt.Enabled = false;
                dTxt.Enabled = false;
            }
            else
            {
                setButton();
                switchBtn.Enabled = true;
                funcDrop.Enabled = true;
                funcTypeDrop.Enabled = true;
                bNum.Enabled = true;
                cNum.Enabled = true;
                dNum.Enabled = true;
                bTxt.Enabled = true;
                cTxt.Enabled = true;
                dTxt.Enabled = true;
            }
        }
        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (value)
            {
                channelTxt.Enabled = true;
                channelNum.Enabled = false;
                switchBtn.Text = "->";
                value = !value;
            }
            else
            {
                channelTxt.Enabled = false;
                channelNum.Enabled = true;
                switchBtn.Text = "<-";
                value = !value;
            }
        }
        public void setButton()
        {
            if (!value)
            {
                channelTxt.Enabled = true;
                channelNum.Enabled = false;
                switchBtn.Text = "->";
            }
            else
            {
                channelTxt.Enabled = false;
                channelNum.Enabled = true;
                switchBtn.Text = "<-";
            }
        }
        private void deviceRefresh_Tick(object sender, EventArgs e)
        {
            if (devicesDrop.Items.Count < DMXCommunicator.GetValidSerialPorts().Count)
            {
                foreach (string port in DMXCommunicator.GetValidSerialPorts())
                {
                    if (!devicesDrop.Items.Contains(new DarkUI.Controls.DarkDropdownItem(port)))
                        devicesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(port));
                }
            }
            else if (devicesDrop.Items.Count > DMXCommunicator.GetValidSerialPorts().Count)
            {
                var ports = DMXCommunicator.GetValidSerialPorts();
                foreach (var port in devicesDrop.Items)
                {
                    if (!ports.Contains(port.Text))
                    {
                        if (devicesDrop.SelectedItem.Equals(port))
                        {
                            devicesDrop.SelectedItem = null;
                        }
                        devicesDrop.Items.Remove(port);
                    }
                }
            }
        }
        private double selectedFunc(double b, double c, double d)
        {
            switch (funcDrop.SelectedItem.Text)
            {
                case "Linear":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                            {
                                case "In":
                                    return TimeFunctions.linearIn(time, b, c, d);
                            }
                        break;
                    }
                case "Quadratic":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.quadraticIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.quadraticOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.quadraticInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Cubic":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.cubicIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.cubicOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.cubicInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Quartic":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.quarticIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.quarticOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.quarticInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Quintic":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.quinticIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.quinticOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.quinticInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Sinusoidal":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.sinusoidalIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.sinusoidalOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.sinusoidalInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Exponential":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.exponentialIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.exponentialOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.exponentialInOut(time, b, c, d);
                        }
                        break;
                    }
                case "Circular":
                    {
                        switch (funcTypeDrop.SelectedItem.Text)
                        {
                            case "In":
                                return TimeFunctions.circularIn(time, b, c, d);
                            case "Out":
                                return TimeFunctions.circularOut(time, b, c, d);
                            case "InOut":
                                return TimeFunctions.circularInOut(time, b, c, d);
                        }
                        break;
                    }
            }

            return 0d;
        }
        private void sendDMX(int channel, double value)
        {
            communicator.SetByte(channel - 1, (byte)value);
        }
        public void startDMX(MidiEvent e, bool async)
        {
            if (async) System.Threading.Tasks.Task.Factory.StartNew(() => { startDMX(e); });
            else startDMX(e);
        }
        public void startDMX(MidiEvent e)
        {
            midiEvent = e;
            isRunning = true;

            channel = channelNum.Enabled ? (int)channelNum.Value : Convert.ToInt32(MIDIButton.replaceAliases(channelTxt.Text, midiEvent));
            b = string.IsNullOrEmpty(bTxt.Text) ? (double)bNum.Value : Convert.ToDouble(MIDIButton.replaceAliases(bTxt.Text, midiEvent));
            c = string.IsNullOrEmpty(cTxt.Text) ? (double)cNum.Value : Convert.ToDouble(MIDIButton.replaceAliases(cTxt.Text, midiEvent));
            d = string.IsNullOrEmpty(dTxt.Text) ? (double)dNum.Value : Convert.ToDouble(MIDIButton.replaceAliases(dTxt.Text, midiEvent));

            if (b < c) { incrementor = 1; time = 0; }
            else if (b > c) { incrementor = -1; time = (int)d; var w = b; b = c; c = w; }

            #region ControlType

            if (devicesDrop.Items.Count < 1) return;

            if (deviceControlDrop.SelectedItem.Text == "Connect")
            {
                Helper.dMXCommunicators.Add(new DMXCommunicator(devicesDrop.SelectedItem.Text));
                Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text).Start();
                return;
            }
            else if(deviceControlDrop.SelectedItem.Text == "Disconnect")
            {
                Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text).Stop();
                Helper.dMXCommunicators.Remove(Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text));
                return;
            }
            else if(deviceControlDrop.SelectedItem.Text == "Signal")
            {
                communicator = new DMXCommunicator(devicesDrop.SelectedItem.Text);
                communicator.Start();
            }
            else
            {
                if (!Helper.dMXCommunicators.Exists(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text)) return;
                communicator = Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text);
            }

            #endregion

            microTimer.Enabled = true;
            microTimer.Start();

            while (isRunning) { }
        }
        public void stopDMX()
        {
            if(microTimer != null)
                if (microTimer.Enabled) microTimer.Enabled = false;

            if (communicator != null && communicator.IsActive && deviceControlDrop.SelectedItem.Text == "Signal")
                communicator.Stop();

            isRunning = false;
        }
        public void disconnect()
        {
            if (communicator != null && communicator.IsActive)
            {
                communicator.Stop();
                Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text).Stop();
                Helper.dMXCommunicators.Remove(Helper.dMXCommunicators.Find(x => x.serialPort.PortName == devicesDrop.SelectedItem.Text));
            }
        }
        private void OnTimedEvent(object sender, MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            sendDMX(channel, selectedFunc(b, c, d));
            if (incrementor == 1 && time == d) stopDMX();
            if (incrementor == -1 && time == 0) stopDMX();
            time += incrementor;
        }
    }
}
