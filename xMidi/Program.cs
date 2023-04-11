using System;
using System.Windows.Forms;

namespace xMidi
{
    static class Program
    {
        //Old name Arduino MIDI
        public static xMIDI xMIDI;
        public static bool isStartup = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
                isStartup = (args[0] == "autostart") ? true : false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            xMIDI = new xMIDI();
            Application.Run(xMIDI);
        }
    }
}
