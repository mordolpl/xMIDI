using MidiArduino.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MidiArduino.Forms
{
    public partial class ActionManager : Form
    {
        public List<ActionControl> actionControls = new List<ActionControl>();
        private int Index;
        public ActionManager(int index)
        {
            InitializeComponent();
            Index = index;
        }

        #region buttonEvents

        private void addActionBtn_Click(object sender, EventArgs e)
        {
            int index = actionList.Items.Count + 1;
            actionList.Items.Add(new DarkUI.Controls.DarkListItem("Action" + index));
            actionControls.Add(new ActionControl(Index));
        }

        private void removeActionBtn_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndices.Count == 0 || actionList.SelectedIndices[0] > actionList.Items.Count - 1) return;
            actionPanel.Controls.Remove(actionControls[actionList.SelectedIndices[0]]);
            actionControls.RemoveAt(actionList.SelectedIndices[0]);
            actionList.Items.RemoveAt(actionList.SelectedIndices[0]);
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndices.Count == 0 || actionList.SelectedIndices[0] == 0) return;
            swapElement(true);
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndices.Count == 0 || actionList.SelectedIndices[0] == actionList.Items.Count - 1) return;
            swapElement(false);
        }

        #endregion

        #region Events

        private void actionList_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.D) duplicate();
            /*else*/ if (e.KeyCode == Keys.Delete)
            {
                if (actionList.SelectedIndices.Count == 0 || actionList.SelectedIndices[0] > actionList.Items.Count - 1) return;
                actionPanel.Controls.Remove(actionControls[actionList.SelectedIndices[0]]);
                actionControls.RemoveAt(actionList.SelectedIndices[0]);
                actionList.Items.RemoveAt(actionList.SelectedIndices[0]);
            }
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            if (actionList.SelectedIndices.Count == 0) return;
            actionList.Items[actionList.SelectedIndices[0]].Text = nameTxt.Text;
        }

        private void actionList_SelectedIndicesChanged(object sender, EventArgs e)
        {
            if (actionList.SelectedIndices.Count == 0)
            {
                nameTxt.Enabled = false;
                return;
            }
            nameTxt.Enabled = true;
            actionPanel.Controls.Clear();
            actionPanel.Controls.Add(actionControls[actionList.SelectedIndices[0]]);
            nameTxt.Text = actionList.Items[actionList.SelectedIndices[0]].Text;
        }

        #endregion

        #region functions

        private void swapElement(bool up)
        {
            int x = (up) ? 1 : -1;
            actionList.Focus();
            var tmp = actionList.Items[actionList.SelectedIndices[0]];
            actionList.Items[actionList.SelectedIndices[0]] = actionList.Items[actionList.SelectedIndices[0] - x];
            actionList.Items[actionList.SelectedIndices[0] - x] = tmp;
            var tmp2 = actionControls[actionList.SelectedIndices[0]];
            actionControls[actionList.SelectedIndices[0]] = actionControls[actionList.SelectedIndices[0] - x];
            actionControls[actionList.SelectedIndices[0] - x] = tmp2;
            actionPanel.Controls.Clear();
            actionPanel.Controls.Add(actionControls[actionList.SelectedIndices[0] - x]);
            actionList.SelectItem(actionList.SelectedIndices[0] - x);
        }

        /*private void duplicate()
        {
            if (actionList.SelectedIndices.Count == 0 || actionList.SelectedIndices[0] > actionList.Items.Count - 1) return;
            int index = actionList.Items.Count + 1;
            actionList.Items.Add(new DarkUI.Controls.DarkListItem(actionList.Items[actionList.SelectedIndices[0]].Text + "-copy"));
            actionControls.Add(Helper.CreateDeepCopy(actionControls[actionList.SelectedIndices[0]]));
        }*/
        
        public void updateIndex(int index)
        {
            foreach(var control in actionControls)
            {
                control.Index = index;
            }
            Index = index;
        }

        #endregion

    }
}
