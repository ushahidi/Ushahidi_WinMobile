using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public partial class ScrollListBox : UserControl
    {
        public ScrollListBox()
        {
            InitializeComponent();
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
            KeyDown += EnhancedListBox_KeyDown;
            ScrollTimer.Tick += ScrollTick;
        }

        /// <summary>
        /// Odd Back Color
        /// </summary>
        public Color BackColorOdd
        {
            get { return _BackColorOdd; }
            set { _BackColorOdd = value; }
        }private Color _BackColorOdd = Color.White;

        /// <summary>
        /// Even Back Color
        /// </summary>
        public Color BackColorEven
        {
            get { return _BackColorEven; }
            set { _BackColorEven = value; }
        }private Color _BackColorEven = Color.White;

        /// <summary>
        /// Focus on list, if nothing currently selected, then select first item
        /// </summary>
        public new bool Focus()
        {
            if (ItemCount > 0 && SelectedIndex == -1 && SelectedItem == null)
            {
                SelectedIndex = 0;
                SelectedItem = Controls[0];
            }
            return base.Focus();
        }

        /// <summary>
        /// Clear all items
        /// </summary>
        public void ClearItems()
        {
            Controls.Clear();
            OnIndexChanged(-1);
            Refresh();
        }

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="control">item to add</param>
        public void AddItem(Control control)
        {
            AddItem(control, true);
        }

        /// <summary>
        /// Add new items
        /// </summary>
        /// <param name="control">item to add</param>
        /// <param name="refresh">should refresh list?</param>
        public void AddItem(Control control, bool refresh)
        {
            control.TabStop = false;
            control.Left = 0;
            control.Width = Width;
            control.Top = MaxBottom(Controls);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            control.Click += control_Click;
            control.DoubleClick += control_DoubleClick;

            SetItemColors(control);

            control.MouseDown += OnMouseDown;
            control.MouseUp += OnMouseUp;
            control.MouseMove += OnMouseMove;

            Controls.Add(control);
            if (refresh)
            {
                Refresh();
            }
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="control">list box item to remove</param>
        public void RemoveItem(Control control)
        {
            if (Controls.Contains(control))
            {
                using (new WaitCursor())
                {
                    control.MouseDown -= OnMouseDown;
                    control.MouseUp -= OnMouseUp;
                    control.MouseMove -= OnMouseMove;

                    Controls.Remove(control);
                    foreach (Control ctrl in Controls)
                    {
                        SetItemColors(ctrl);
                    }
                }
                OnIndexChanged(-1);
                Refresh();
            }
        }

        /// <summary>
        /// Set the various item colors
        /// </summary>
        /// <param name="control">lsit box item</param>
        private void SetItemColors(Control control)
        {
            if (control == null) return;
            control.BackColor = Controls.Count % 2 == 0 ? BackColorEven : BackColorOdd;
            control.ForeColor = ForeColor;
        }

        /// <summary>
        /// The number of items
        /// </summary>
        public int ItemCount { get { return Controls.Count; } }

        /// <summary>
        /// The selected index
        /// </summary>
        public int SelectedIndex { get; private set; }

        /// <summary>
        /// The selected item
        /// </summary>
        public Control SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != null)
                {
                    _SelectedItem.Tag = false;
                    _SelectedItem.Refresh();
                }
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    _SelectedItem.Tag = true;
                    _SelectedItem.Refresh();
                    OnIndexChanged(value);
                }
            }
        }private Control _SelectedItem;

        /// <summary>
        /// Item action delegate
        /// </summary>
        /// <param name="control">control</param>
        public delegate void ItemHandler(Control control);

        /// <summary>
        /// Index changed event
        /// </summary>
        public event ItemHandler IndexChanged;

        /// <summary>
        /// Fire OnIndexChanged event, if handler is registered
        /// </summary>
        /// <param name="item">selected item</param>
        private void OnIndexChanged(Control item)
        {
            if (item != null)
            {
                SelectedIndex = GetSelectedIndex(item);
                _SelectedItem = item;
                
                int scrollPosition = Math.Abs(AutoScrollPosition.Y);
                if (item.Bottom + 1 > Height)
                {
                    AutoScrollPosition = new Point(0, scrollPosition + item.Height);
                }
                else if (item.Top + 1 < 0)
                {
                    AutoScrollPosition = new Point(0, scrollPosition - item.Height);
                }
            }
            else
            {
                SelectedItem = null;
                SelectedIndex = -1;
            }
            if (IndexChanged != null)
            {
                IndexChanged(item);
            }
            Focus();
        }

        /// <summary>
        /// Fire OnIndexChanged event, if handler is registered
        /// </summary>
        /// <param name="index">selected index</param>
        private void OnIndexChanged(int index)
        {
            if (index >= 0 && ItemCount > index)
            {
                OnIndexChanged(Controls[index]);
            }
            else
            {
                OnIndexChanged(null);
            }
        }

        /// <summary>
        /// Item selected event
        /// </summary>
        public event ItemHandler ItemSelected;

        /// <summary>
        /// Fire ItemSelected event, if handler is registered
        /// </summary>
        /// <param name="item">selected item</param>
        private void OnItemSelected(Control item)
        {
            if (item == null) return;
            SelectedIndex = Controls.GetChildIndex(item);
            SelectedItem = item;
            if (ItemSelected != null)
            {
                ItemSelected(item);
            }
            Focus();
        }

        /// <summary>
        /// Get the selected index
        /// </summary>
        /// <param name="item">control</param>
        /// <returns>selected index</returns>
        private int GetSelectedIndex(Control item)
        {
            try
            {
                return Controls.GetChildIndex(item);
            }
            catch
            {
                for (int index = 0; index < Controls.Count; index++)
                {
                    if (item == Controls[index])
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// ScrollTick distance
        /// </summary>
        private int ScrollDistance = 0;

        /// <summary>
        /// The Y position when mouse was down
        /// </summary>
        private int PreviousY = 0;

        /// <summary>
        /// ScrollTick timer
        /// </summary>
        private readonly Timer ScrollTimer = new Timer { Enabled = true, Interval = 50 };

        /// <summary>
        /// MouseDown Handler
        /// </summary>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            PreviousY = GetAbsoluteY(e.Y, sender as Control, this);
        }

        /// <summary>
        /// MouseMove Handler
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int mouseDownY = GetAbsoluteY(e.Y, sender as Control, this);
            ScrollDistance += mouseDownY - PreviousY;
            PreviousY = mouseDownY;
        }

        /// <summary>
        /// MouseUp Handler
        /// </summary>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ScrollDistance = 0;
        }

        /// <summary>
        /// Scroll timer tick
        /// </summary>
        private void ScrollTick(object sender, EventArgs e)
        {
            if (ScrollDistance == 0) return;
            AutoScrollPosition = new Point(Math.Abs(AutoScrollPosition.X), Math.Abs(AutoScrollPosition.Y) + ScrollDistance);
        }

        /// <summary>
        /// Get the absolute Y position
        /// </summary>
        /// <param name="y">the mouse Y</param>
        /// <param name="source">source control</param>
        /// <param name="root">root control</param>
        /// <returns>the absolute Y</returns>
        public static int GetAbsoluteY(int y, Control source, Control root)
        {
            int tempY = y;
            for (Control iterator = source; iterator != root; iterator = iterator.Parent)
            {
                tempY += iterator.Top;
            }
            return tempY;
        }

        /// <summary>
        /// Handle KeyDown of list box
        /// </summary>
        private void EnhancedListBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    int indexDown = Controls.GetChildIndex(SelectedItem) + 1;
                    if (indexDown > -1 && ItemCount > indexDown)
                    {
                        OnIndexChanged(indexDown);
                    }
                    break;
                case Keys.Up:
                    int indexUp = Controls.GetChildIndex(SelectedItem) - 1;
                    if (indexUp > -1 && ItemCount > indexUp)
                    {
                        OnIndexChanged(indexUp);
                    }
                    break;
                case Keys.PageUp:
                case Keys.Home:
                    OnIndexChanged(0);
                    break;
                case Keys.PageDown:
                case Keys.End:
                    OnIndexChanged(Controls.Count - 1);
                    break;
                case Keys.Enter:
                case Keys.Space:
                case Keys.LButton:
                case Keys.MButton:
                    OnItemSelected(SelectedItem);
                    break;
                case Keys.Tab:
                    SelectNextControl(this, true, true, true, true);
                    break;
            }
        }

        /// <summary>
        /// Upon single click, fire IndexChanged event
        /// </summary>
        private void control_Click(object sender, EventArgs e)
        {
            OnIndexChanged(sender as Control);
        }

        /// <summary>
        /// Upon DoubleClick, fire ItemSelected event
        /// </summary>
        private void control_DoubleClick(object sender, EventArgs e)
        {
            OnItemSelected(sender as Control);
        }

        /// <summary>
        /// Get the maximum bottom position of lowest control
        /// </summary>
        /// <param name="controls">control collection</param>
        /// <returns>lowest bottom</returns>
        private static int MaxBottom(ControlCollection controls)
        {
            return controls.Count > 0 ? controls.All().Max(c => c.Bottom) : 0;
        }

        /// <summary>
        /// Dispose of resources
        /// </summary>
        public new void Dispose()
        {
            if (ScrollTimer != null)
            {
                ScrollTimer.Enabled = false;
                ScrollTimer.Dispose();
            }
            if (Controls.Count > 0)
            {
                for (int i = Controls.Count - 1; i < 0; i--)
                {
                    Controls[i].Dispose();
                }
            }
            base.Dispose();
        }

        /// <summary>
        /// Refresh the controls
        /// </summary>
        public new void Refresh()
        {
            foreach (Control control in Controls)
            {
                control.Refresh();
            }
            base.Refresh();
        }

    }
}
