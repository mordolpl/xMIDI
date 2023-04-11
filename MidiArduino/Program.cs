using System;
using System.Windows.Forms;

namespace xMidi
{
    static class Program
    {
        //Old name Arduino MIDI
        public static xMIDI arduinoMIDI;
        public static bool isStartup = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
                isStartup = (args[0] == "autostart") ? true : false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            arduinoMIDI = new xMIDI();
            Application.Run(arduinoMIDI);
        }
    }
}
