using Newtonsoft.Json;
using System.Windows.Forms;

namespace MidiArduino
{
    public class ActionTypesSettings { }

    public class KeyShortcutSettings : ActionTypesSettings
    {
        [JsonProperty("Modifiers")]
        public string Modifiers { get; set; }

        [JsonProperty("KeyCode")]
        public Keys KeyCode { get; set; }
    }

    public class RunSettings : ActionTypesSettings
    {
        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("Argument")]
        public string Arguments { get; set; }
    }

    public class ShellSettings : ActionTypesSettings
    {
        [JsonProperty("ShellCommand")]
        public string ShellCommand { get; set; }
    }

    public class SerialSettings : ActionTypesSettings
    {
        [JsonProperty("DeviceControl")]
        public string DeviceControl { get; set; }

        [JsonProperty("SerialPort")]
        public string SerialPort { get; set; }

        [JsonProperty("BoundRate")]
        public decimal BoundRate { get; set; }

        [JsonProperty("Parity")]
        public string Parity { get; set; }

        [JsonProperty("DataBits")]
        public decimal DataBits { get; set; }

        [JsonProperty("StopBits")]
        public string StopBits { get; set; }

        [JsonProperty("Handshake")]
        public string Handshake { get; set; }

        [JsonProperty("StringTxt")]
        public string StringTxt { get; set; }

        [JsonProperty("DtrEnable")]
        public bool DtrEnable { get; set; }

        [JsonProperty("RtsEnable")]
        public bool RtsEnable { get; set; }
    }

    public class DMXSettings : ActionTypesSettings
    {
        [JsonProperty("DeviceControl")]
        public string DeviceControl { get; set; }

        [JsonProperty("SerialPort")]
        public string SerialPort { get; set; }

        [JsonProperty("ChannelNum")]
        public decimal ChannelNum { get; set; }

        [JsonProperty("ChannelTxt")]
        public string ChannelTxt { get; set; }

        [JsonProperty("SelValue")]
        public bool SelValue { get; set; }

        [JsonProperty("TimeFunction")]
        public string TimeFunction { get; set; }

        [JsonProperty("FunctionType")]
        public string FunctionType { get; set; }

        [JsonProperty("bNum")]
        public decimal bNum { get; set; }

        [JsonProperty("bTxt")]
        public string bTxt { get; set; }

        [JsonProperty("cNum")]
        public decimal cNum { get; set; }

        [JsonProperty("cTxt")]
        public string cTxt { get; set; }

        [JsonProperty("dNum")]
        public decimal dNum { get; set; }

        [JsonProperty("dTxt")]
        public string dTxt { get; set; }
    }

    public class MIDISettings : ActionTypesSettings
    {
        [JsonProperty("MidiOut")]
        public string MidiOut { get; set; }

        [JsonProperty("MidiEvent")]
        public string MidiEvent { get; set; }

        [JsonProperty("Channel")]
        public decimal Channel { get; set; }

        [JsonProperty("Name")]
        public decimal Name { get; set; }

        [JsonProperty("ValueNum")]
        public decimal ValueNum { get; set; }

        [JsonProperty("ValueTxt")]
        public string ValueTxt { get; set; }

        [JsonProperty("SelValue")]
        public bool SelValue { get; set; }
    }

    public class MIDIFileSettings : ActionTypesSettings
    {
        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("MidiOut")]
        public string MidiOut { get; set; }
    }

    public class TemplateSettings : ActionTypesSettings
    {
        [JsonProperty("Template")]
        public string Template { get; set; }
    }
}
