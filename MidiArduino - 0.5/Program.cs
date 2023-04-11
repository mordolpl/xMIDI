using System;
using System.Windows.Forms;

namespace MidiArduino
{
    static class Program
    {
        public static ArduinoMIDI arduinoMIDI;
        public static bool isStartup = false;

        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length != 0)
                isStartup = (args[0] == "autostart") ? true : false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            arduinoMIDI = new ArduinoMIDI();
            Application.Run(arduinoMIDI);
        }
    }
}
