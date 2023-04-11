using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MidiArduino.Controls;
using MidiArduino.Controls.Actions;
using NAudio.Midi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MidiArduino
{
    public static class Settings
    {
        public static void loadConfig(string path)
        {
            try
            {

                bool overwrite = true;

                if (Program.arduinoMIDI.isStarted) { MessageBox.Show("You must click stop button first!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (Program.arduinoMIDI.midiList.Controls.Count > 0)
                    if (MessageBox.Show("You have unsaved changes!\nDo you want to add new data to this?", "Arduino MIDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        overwrite = false;
                    else
                        overwrite = true;


                string configData = "";

                using(StreamReader streamReader = new StreamReader(path))
                {
                    configData = streamReader.ReadToEnd();
                    streamReader.Close();
                    streamReader.Dispose();
                }

                JsonSerializerSettings jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                SettingsStructure settings = JsonConvert.DeserializeObject<SettingsStructure>(configData, jsonSettings);

                bool isConnected = false;
                int deviceIndex = 0;
                for (int i = 0; i < Program.arduinoMIDI.midiInput.Items.Count; i++)
                    if (Program.arduinoMIDI.midiInput.Items[i].Text == settings.midiInputDevice) { isConnected = true; deviceIndex = i; }
                if (!isConnected)
                    if (MessageBox.Show("You don't have connected device for this configuration\rDo you really want to load this config?", "Arduino MIDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if(isConnected) Program.arduinoMIDI.midiInput.SelectedItem = Program.arduinoMIDI.midiInput.Items[deviceIndex];

                if(overwrite) Program.arduinoMIDI.midiList.Controls.Clear();
                for (int i = 0; i < settings.buttonsData.Count; i++)
                {
                    MIDIButton midiButton = new MIDIButton(MidiEvent.FromRawMessage(settings.buttonsData[i].midiRawMessange), i);
                    midiButton.buttonActiveCheck.Checked = settings.buttonsData[i].Checked;
                    midiButton.buttonCode.Text = settings.buttonsData[i].name;
                    Program.arduinoMIDI.midiList.Controls.Add(midiButton);

                    for (int j = 0; j < settings.buttonsData[i].actions.Count; j++)
                    {
                        midiButton.actionManager.actionList.Items.Add(new DarkUI.Controls.DarkListItem(settings.buttonsData[i].actions[j].name));
                        ActionControl actionControl = new ActionControl(i);
                        actionControl.delayNum.Value = settings.buttonsData[i].actions[j].delay;

                        switch (settings.buttonsData[i].actions[j].actionIgniter.condition)
                        {
                            case "Every (default)":
                                {
                                    actionControl.actionIgniter.conditionalDrop.SelectedItem = actionControl.actionIgniter.conditionalDrop.Items[0];
                                    break;
                                }
                            case "Specific":
                                {
                                    actionControl.actionIgniter.conditionalDrop.SelectedItem = actionControl.actionIgniter.conditionalDrop.Items[1];
                                    break;
                                }
                            case "Custom condition":
                                {
                                    actionControl.actionIgniter.conditionalDrop.SelectedItem = actionControl.actionIgniter.conditionalDrop.Items[2];
                                    break;
                                }
                        }
                        actionControl.actionIgniter.specificNum.Value = settings.buttonsData[i].actions[j].actionIgniter.specific;
                        actionControl.actionIgniter.conTxt.Text = settings.buttonsData[i].actions[j].actionIgniter.customCondition;

                        actionControl.actionCombo.SelectedItem = settings.buttonsData[i].actions[j].actionType;
                        midiButton.actionManager.actionControls.Add(actionControl);
                        actionControl.actionCombo.Focus();
                        switch (settings.buttonsData[i].actions[j].actionType)
                        {
                            case "Key Shortcut":
                                {
                                    (actionControl.actionType.Controls[0] as KeyShortcutAction).KeyCode = (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).KeyCode;
                                    (actionControl.actionType.Controls[0] as KeyShortcutAction).Modifiers = (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).Modifiers;
                                    break;
                                }
                            case "Run Application":
                                {
                                    (actionControl.actionType.Controls[0] as RunAction).pathTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as RunSettings).Path;
                                    (actionControl.actionType.Controls[0] as RunAction).argumentsTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as RunSettings).Arguments;
                                    break;
                                }
                            case "Send Shell Command":
                                {
                                    (actionControl.actionType.Controls[0] as ShellAction).stringTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as ShellSettings).ShellCommand;
                                    break;
                                }
                            case "Send Serial Data":
                                {
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).SerialPort)
                                            (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as SerialAction).baudRateNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).BoundRate;
                                    (actionControl.actionType.Controls[0] as SerialAction).stringTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).StringTxt;
                                    break;
                                }
                            case "Send MIDI Data":
                                {
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as MIDIAction).midiOutDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as MIDIAction).midiOutDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).MidiOut)
                                            (actionControl.actionType.Controls[0] as MIDIAction).midiOutDrop.SelectedItem = (actionControl.actionType.Controls[0] as MIDIAction).midiOutDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as MIDIAction).midiEventDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as MIDIAction).midiEventDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).MidiEvent)
                                            (actionControl.actionType.Controls[0] as MIDIAction).midiEventDrop.SelectedItem = (actionControl.actionType.Controls[0] as MIDIAction).midiEventDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as MIDIAction).channelNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).Channel;
                                    (actionControl.actionType.Controls[0] as MIDIAction).nameValue.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).Name;
                                    (actionControl.actionType.Controls[0] as MIDIAction).valueNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).ValueNum;
                                    (actionControl.actionType.Controls[0] as MIDIAction).valueTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).ValueTxt;
                                    (actionControl.actionType.Controls[0] as MIDIAction).value = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDISettings).SelValue;
                                    (actionControl.actionType.Controls[0] as MIDIAction).setButton();
                                    break;
                                }
                            case "Templates":
                                {
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as TemplatesAction).templatesDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as TemplatesAction).templatesDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as TemplateSettings).Template)
                                            (actionControl.actionType.Controls[0] as TemplatesAction).templatesDrop.SelectedItem = (actionControl.actionType.Controls[0] as TemplatesAction).templatesDrop.Items[k];
                                    break;
                                }
                        }
                    }
                }

                if(SettingsForm.ActiveForm != null) SettingsForm.ActiveForm.Close();


            }
            catch(IOException e)
            {
                MessageBox.Show(e.InnerException + " throwed on config loading!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void saveConfig(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    SettingsStructure settings = new SettingsStructure();
                    List<ButtonSettings> buttons = new List<ButtonSettings>();
                    for(int i = 0; i < Program.arduinoMIDI.midiList.Controls.Count; i++)
                    {
                        ButtonSettings button = new ButtonSettings();
                        button.name = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).buttonCode.Text;
                        button.Checked = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).buttonActiveCheck.Checked;
                        button.midiRawMessange = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).midiEvent.GetAsShortMessage();

                        List<ActionSettings> actions = new List<ActionSettings>();
                        for(int j = 0; j < (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionList.Items.Count; j++)
                        {
                            ActionSettings action = new ActionSettings();
                            action.name = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionList.Items[j].Text;
                            action.delay = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].delayNum.Value;
                            action.actionIgniter = new ActionIgniterSettings();
                            action.actionIgniter.condition = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionIgniter.conditionalDrop.SelectedItem.Text;

                            switch (action.actionIgniter.condition)
                            {
                                case "Specific":
                                    {
                                        action.actionIgniter.specific = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton)
                                            .actionManager.actionControls[j].actionIgniter.specificNum.Value;
                                        break;
                                    }
                                case "Custom condition":
                                    {
                                        action.actionIgniter.customCondition = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton)
                                            .actionManager.actionControls[j].actionIgniter.conTxt.Text;
                                        break;
                                    }
                            }

                            if ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionCombo.SelectedItem != null)
                                action.actionType = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionCombo.SelectedItem.ToString();
                            else action.actionType = null;

                            switch (action.actionType)
                            {
                                case "Key Shortcut":
                                    {
                                        KeyShortcutSettings keyShortcutSettings = new KeyShortcutSettings();
                                        keyShortcutSettings.KeyCode = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as KeyShortcutAction).KeyCode;
                                        keyShortcutSettings.Modifiers = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as KeyShortcutAction).Modifiers;
                                        action.actionTypesSettings = keyShortcutSettings;
                                        break;
                                    }
                                case "Run Application":
                                    {
                                        RunSettings runSettings = new RunSettings();
                                        runSettings.Path = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as RunAction).pathTxt.Text;
                                        runSettings.Arguments = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as RunAction).argumentsTxt.Text;
                                        action.actionTypesSettings = runSettings;
                                        break;
                                    }
                                case "Send Shell Command":
                                    {
                                        ShellSettings shellSettings = new ShellSettings();
                                        shellSettings.ShellCommand = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as ShellAction).stringTxt.Text;                          
                                        action.actionTypesSettings = shellSettings;
                                        break;
                                    }
                                case "Send Serial Data":
                                    {
                                        SerialSettings serialSettings = new SerialSettings();
                                        serialSettings.SerialPort = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem.Text;
                                        serialSettings.BoundRate = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).baudRateNum.Value;
                                        serialSettings.StringTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).stringTxt.Text;
                                        action.actionTypesSettings = serialSettings;
                                        break;
                                    }
                                case "Send MIDI Data":
                                    {
                                        MIDISettings midiSettings = new MIDISettings();
                                        midiSettings.MidiOut = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).midiOutDrop.SelectedItem.Text;
                                        midiSettings.MidiEvent = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).midiEventDrop.SelectedItem.Text;
                                        midiSettings.Channel = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).channelNum.Value;
                                        midiSettings.Name = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).nameValue.Value;
                                        midiSettings.ValueNum = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).valueNum.Value;
                                        midiSettings.ValueTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).valueTxt.Text;
                                        midiSettings.SelValue = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIAction).value;
                                        action.actionTypesSettings = midiSettings;
                                        break;
                                    }
                                case "Templates":
                                    {
                                        TemplateSettings templateSettings = new TemplateSettings();
                                        templateSettings.Template = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as TemplatesAction).templatesDrop.SelectedItem.Text;
                                        action.actionTypesSettings = templateSettings;
                                        break;
                                    }
                            }

                            actions.Add(action);
                        }

                        button.actions = actions;
                        buttons.Add(button);
                    }
                    settings.buttonsData = buttons;
                    settings.midiInputDevice = Program.arduinoMIDI.midiInput.SelectedItem.Text;

                    JsonSerializerSettings jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                    string json = JsonConvert.SerializeObject(settings, Formatting.Indented, jsonSettings);

                    streamWriter.Write(json);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.InnerException + " throwed on config saving!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class SettingsStructure
    {
        [JsonProperty("ButtonsData")]
        public List<ButtonSettings> buttonsData { get; set; }
        [JsonProperty("MidiInputDevice")]
        public string midiInputDevice { get; set; }
    }

    public class ButtonSettings
    {
        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("Checked")]
        public bool Checked { get; set; }

        [JsonProperty("MidiRawMessange")]
        public int midiRawMessange { get; set; }

        [JsonProperty("Actions")]
        public List<ActionSettings> actions { get; set; }
    }

    public class ActionSettings
    {
        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("Delay")]
        public decimal delay { get; set; }

        [JsonProperty("ActionIgniter")]
        public ActionIgniterSettings actionIgniter { get; set; }

        [JsonProperty("ActionType")]
        public string actionType { get; set; }

        [JsonProperty("actionTypesSettings")]
        public ActionTypesSettings actionTypesSettings { get; set; }
    }

    public class ActionIgniterSettings
    {
        [JsonProperty("Condition")]
        public string condition { get; set; }

        [JsonProperty("Specific")]
        public decimal specific { get; set; }

        [JsonProperty("CustomCondition")]
        public string customCondition { get; set; }
    }
}
