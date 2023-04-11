using BrunoDPO.DMX;
using System.Collections.Generic;
using System.IO.Ports;

namespace xMidi.Utils
{
    public static class Helper
    {
        public static List<DMXCommunicator> dMXCommunicators = new List<DMXCommunicator>();
        public static List<SerialPort> serialPorts = new List<SerialPort>();
        public static List<string> storage = new List<string>();
    }
}
