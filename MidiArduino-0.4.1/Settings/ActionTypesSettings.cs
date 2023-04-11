using Newtonsoft.Json;

namespace MidiArduino
{
    public class ActionTypesSettings { }

    public class KeyShortcutSettings : ActionTypesSettings
    {
        [JsonProperty("Modifiers")]
        public string Modifiers { get; set; }

        [JsonProperty("KeyCode")]
        public string KeyCode { get; set; }
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

    public class RunSettings : ActionTypesSettings
    {
        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("Argument")]
        public string Arguments { get; set; }
    }

    public class SerialSettings : ActionTypesSettings
    {
        [JsonProperty("SerialPort")]
        public string SerialPort { get; set; }

        [JsonProperty("BoundRate")]
        public decimal BoundRate { get; set; }

        [JsonProperty("StringTxt")]
        public string StringTxt { get; set; }
    }

    public class ShellSettings : ActionTypesSettings
    {
        [JsonProperty("ShellCommand")]
        public string ShellCommand { get; set; }
    }

    public class TemplateSettings : ActionTypesSettings
    {
        [JsonProperty("Template")]
        public string Template { get; set; }
    }
}
