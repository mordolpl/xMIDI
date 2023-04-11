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
                    if (MessageBox.Show("You don't have connected device for this configuration\nDo you really want to load this config?", "Arduino MIDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if(isConnected) Program.arduinoMIDI.midiInput.SelectedItem = Program.arduinoMIDI.midiInput.Items[deviceIndex];

                if(overwrite) Program.arduinoMIDI.midiList.Controls.Clear();
                for (int i = 0; i < settings.buttonsData.Count; i++)
                {
                    BindPropertiesData data = new BindPropertiesData()
                    {
                        id = i,
                        e = MidiEvent.FromRawMessage(settings.buttonsData[i].midiRawMessage),
                        isAsync = settings.buttonsData[i].bindPropertiesData.isAsync,
                        channelB = settings.buttonsData[i].bindPropertiesData.channelB,
                        eventB = settings.buttonsData[i].bindPropertiesData.eventB,
                        runOnStart = settings.buttonsData[i].bindPropertiesData.runOnStart,
                        fontColor = settings.buttonsData[i].bindPropertiesData.fontColor,
                        bgColor = settings.buttonsData[i].bindPropertiesData.bgColor,
                        hoverColor = settings.buttonsData[i].bindPropertiesData.hoverColor,
                        interactColor = settings.buttonsData[i].bindPropertiesData.interactColor

                    };
                    MIDIButton midiButton = new MIDIButton(data);
                    midiButton.buttonActiveCheck.Checked = settings.buttonsData[i].Checked;
                    midiButton.buttonCode.Text = settings.buttonsData[i].name;
                    Program.arduinoMIDI.midiList.Controls.Add(midiButton);

                    for (int j = 0; j < settings.buttonsData[i].actions.Count; j++)
                    {
                        midiButton.actionManager.actionList.Items.Add(new DarkUI.Controls.DarkListItem(settings.buttonsData[i].actions[j].name));
                        ActionControl actionControl = new ActionControl(i);
                        actionControl.delayNum.Value = settings.buttonsData[i].actions[j].delay;
                        actionControl.asyncCheck.Checked = settings.buttonsData[i].actions[j].asyns;

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

                        foreach (var action in actionControl.actionTypeList.Items)
                        {
                            if (action.Text == settings.buttonsData[i].actions[j].actionType) actionControl.actionTypeList.SelectedItem = action;
                        }

                        midiButton.actionManager.actionControls.Add(actionControl);
                        switch (settings.buttonsData[i].actions[j].actionType)
                        {
                            case "Key Shortcut":
                                {
                                    (actionControl.actionType.Controls[0] as KeyShortcutAction).KeyCode = (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).KeyCode;
                                    (actionControl.actionType.Controls[0] as KeyShortcutAction).Modifiers = (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).Modifiers;
                                    (actionControl.actionType.Controls[0] as KeyShortcutAction).keyShortcut.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).Modifiers
                                    + " + " + (settings.buttonsData[i].actions[j].actionTypesSettings as KeyShortcutSettings).KeyCode.ToString();
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
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).deviceControlDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).deviceControlDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).DeviceControl)
                                            (actionControl.actionType.Controls[0] as SerialAction).deviceControlDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).deviceControlDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).SerialPort)
                                            (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).serialPortDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as SerialAction).baudRateNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).BoundRate;
                                    (actionControl.actionType.Controls[0] as SerialAction).dataBitsNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).DataBits;
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).parityDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).parityDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).Parity)
                                            (actionControl.actionType.Controls[0] as SerialAction).parityDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).parityDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).stopBitsDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).stopBitsDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).StopBits)
                                            (actionControl.actionType.Controls[0] as SerialAction).stopBitsDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).stopBitsDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as SerialAction).handshakeDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as SerialAction).handshakeDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).Handshake)
                                            (actionControl.actionType.Controls[0] as SerialAction).handshakeDrop.SelectedItem = (actionControl.actionType.Controls[0] as SerialAction).handshakeDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as SerialAction).DtrEnable = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).DtrEnable;
                                    (actionControl.actionType.Controls[0] as SerialAction).RtsEnable = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).RtsEnable;
                                    (actionControl.actionType.Controls[0] as SerialAction).stringTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as SerialSettings).StringTxt;
                                    break;
                                }
                            case "Send DMX512":
                                {
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as DMXAction).deviceControlDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as DMXAction).deviceControlDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).DeviceControl)
                                            (actionControl.actionType.Controls[0] as DMXAction).deviceControlDrop.SelectedItem = (actionControl.actionType.Controls[0] as DMXAction).deviceControlDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as DMXAction).devicesDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as DMXAction).devicesDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).SerialPort)
                                            (actionControl.actionType.Controls[0] as DMXAction).devicesDrop.SelectedItem = (actionControl.actionType.Controls[0] as DMXAction).devicesDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as DMXAction).channelNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).ChannelNum;
                                    (actionControl.actionType.Controls[0] as DMXAction).channelTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).ChannelTxt;
                                    (actionControl.actionType.Controls[0] as DMXAction).value = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).SelValue;
                                    (actionControl.actionType.Controls[0] as DMXAction).setButton();
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as DMXAction).funcDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as DMXAction).funcDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).TimeFunction)
                                            (actionControl.actionType.Controls[0] as DMXAction).funcDrop.SelectedItem = (actionControl.actionType.Controls[0] as DMXAction).funcDrop.Items[k];
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as DMXAction).funcTypeDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as DMXAction).funcTypeDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).FunctionType)
                                            (actionControl.actionType.Controls[0] as DMXAction).funcTypeDrop.SelectedItem = (actionControl.actionType.Controls[0] as DMXAction).funcTypeDrop.Items[k];
                                    (actionControl.actionType.Controls[0] as DMXAction).bNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).bNum;
                                    (actionControl.actionType.Controls[0] as DMXAction).bTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).bTxt;
                                    (actionControl.actionType.Controls[0] as DMXAction).cNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).cNum;
                                    (actionControl.actionType.Controls[0] as DMXAction).cTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).cTxt;
                                    (actionControl.actionType.Controls[0] as DMXAction).dNum.Value = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).dNum;
                                    (actionControl.actionType.Controls[0] as DMXAction).dTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as DMXSettings).dTxt;
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
                            case "Send MIDI File":
                                {
                                    (actionControl.actionType.Controls[0] as MIDIFileAction).pathTxt.Text = (settings.buttonsData[i].actions[j].actionTypesSettings as MIDIFileSettings).Path;
                                    for (int k = 0; k < (actionControl.actionType.Controls[0] as MIDIFileAction).midiOutDrop.Items.Count; k++)
                                        if ((actionControl.actionType.Controls[0] as MIDIFileAction).midiOutDrop.Items[k].Text == (settings.buttonsData[i].actions[j].actionTypesSettings as MIDIFileSettings).MidiOut)
                                            (actionControl.actionType.Controls[0] as MIDIFileAction).midiOutDrop.SelectedItem = (actionControl.actionType.Controls[0] as MIDIFileAction).midiOutDrop.Items[k];
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
                        button.midiRawMessage = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).midiEvent.GetAsShortMessage();
                        button.bindPropertiesData = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).data;

                        List<ActionSettings> actions = new List<ActionSettings>();
                        for(int j = 0; j < (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionList.Items.Count; j++)
                        {
                            ActionSettings action = new ActionSettings();
                            action.name = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionList.Items[j].Text;
                            action.delay = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].delayNum.Value;
                            action.asyns = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].asyncCheck.Checked;
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

                            action.actionType = (Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionTypeList.SelectedItem.Text;

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
                                        serialSettings.DeviceControl = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).deviceControlDrop.SelectedItem.Text;
                                        if (((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem != null)
                                            serialSettings.SerialPort = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem.Text;
                                        serialSettings.BoundRate = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).baudRateNum.Value;
                                        serialSettings.Parity = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).parityDrop.SelectedItem.Text;
                                        serialSettings.DataBits = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).dataBitsNum.Value;
                                        serialSettings.StopBits = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).stopBitsDrop.SelectedItem.Text;
                                        serialSettings.Handshake = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).handshakeDrop.SelectedItem.Text;
                                        serialSettings.StringTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as SerialAction).stringTxt.Text;
                                        action.actionTypesSettings = serialSettings;
                                        break;
                                    }
                                case "Send DMX512":
                                    {
                                        DMXSettings dMXSettings = new DMXSettings();
                                        dMXSettings.DeviceControl = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).deviceControlDrop.SelectedItem.Text;
                                        if(((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).devicesDrop.SelectedItem != null)
                                            dMXSettings.SerialPort = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).devicesDrop.SelectedItem.Text;
                                        dMXSettings.ChannelNum = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).channelNum.Value;
                                        dMXSettings.ChannelTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).channelTxt.Text;
                                        dMXSettings.SelValue = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).value;
                                        dMXSettings.TimeFunction = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).funcDrop.SelectedItem.Text;
                                        dMXSettings.FunctionType = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).funcTypeDrop.SelectedItem.Text;
                                        dMXSettings.bNum = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).bNum.Value;
                                        dMXSettings.bTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).bTxt.Text;
                                        dMXSettings.cNum = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).cNum.Value;
                                        dMXSettings.cTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).cTxt.Text;
                                        dMXSettings.dNum = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).dNum.Value;
                                        dMXSettings.dTxt = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as DMXAction).dTxt.Text;
                                        action.actionTypesSettings = dMXSettings;
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
                                case "Send MIDI File":
                                    {
                                        MIDIFileSettings midiFileSettings = new MIDIFileSettings();
                                        midiFileSettings.MidiOut = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIFileAction).midiOutDrop.SelectedItem.Text;
                                        midiFileSettings.Path = ((Program.arduinoMIDI.midiList.Controls[i] as MIDIButton).actionManager.actionControls[j].actionType.Controls[0] as MIDIFileAction).pathTxt.Text;
                                        action.actionTypesSettings = midiFileSettings;
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

        [JsonProperty("BindPropertiesData")]
        public BindPropertiesData bindPropertiesData { get; set; }

        [JsonProperty("Checked")]
        public bool Checked { get; set; }

        [JsonProperty("MidiRawMessage")]
        public int midiRawMessage { get; set; }

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

        [JsonProperty("Async")]
        public bool asyns { get; set; }

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
