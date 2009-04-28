using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Custom scroll lsit box
    /// </summary>
    public partial class ScrollListBox : UserControl
    {
        /// <summary>
        /// Scroll list box
        /// </summary>
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
        /// Selected back color
        /// </summary>
        public Color BackSelectedColor
        {
            get { return _BackSelectedColor; }
            set { _BackSelectedColor = value; }
        }private Color _BackSelectedColor = Color.Black;

        /// <summary>
        /// Focus on list, if nothing currently selected, then select first item
        /// </summary>
        public new bool Focus()
        {
            if (Count > 0 && SelectedIndex == -1 && SelectedItem == null)
            {
                SelectedIndex = 0;
                SelectedItem = Controls[0] as ScrollListBoxItem;
            }
            return base.Focus();
        }

        public void AdjustHeight()
        {
            Height = MaxBottom(Controls);
        }

        public int Count
        {
            get { return Controls.Count; }
        }
        /// <summary>
        /// Clear all items
        /// </summary>
        public void Clear()
        {
            Controls.Clear();
            SelectedIndex = -1;
            Refresh();
        }

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="control">item to add</param>
        public void Add(ScrollListBoxItem control)
        {
            Add(control, true);
        }

        /// <summary>
        /// Add new items
        /// </summary>
        /// <param name="control">item to add</param>
        /// <param name="refresh">should refresh list?</param>
        public void Add(ScrollListBoxItem control, bool refresh)
        {
            control.Index = Controls.Count;
            control.TabStop = false;
            control.Left = 0;
            control.Width = Width;
            control.Top = MaxBottom(Controls);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            control.BackColor = (control.Index % 2 == 0) ? BackColorEven : BackColorOdd;

            control.Click += control_Click;
            control.DoubleClick += control_DoubleClick;
            control.MouseDown += OnMouseDown;
            control.MouseUp += OnMouseUp;
            control.MouseMove += OnMouseMove;

            Controls.Add(control);
            if (refresh)
            {
                control.Refresh();
            }
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="control">list box item to remove</param>
        public void Remove(ScrollListBoxItem control)
        {
            if (Controls.Contains(control))
            {
                using (new WaitCursor())
                {
                    control.MouseDown -= OnMouseDown;
                    control.MouseUp -= OnMouseUp;
                    control.MouseMove -= OnMouseMove;

                    Controls.Remove(control);
                    for (int index = 0; index < Controls.Count; index++)
                    {
                        ScrollListBoxItem item = Controls[index] as ScrollListBoxItem;
                        if (item != null)
                        {
                            item.Index = index;
                            item.BackColor = (index%2 == 0) ? BackColorEven : BackColorOdd;
                        }
                    }
                }
                SelectedIndex = -1;
                Refresh();
            }
        }

        /// <summary>
        /// The selected index
        /// </summary>
        public int SelectedIndex
        {
            get{ return _SelectedIndex; }
            set
            {
                if (value >= 0 && Count > value)
                {
                    SelectedItem = Controls[value] as ScrollListBoxItem;
                    _SelectedIndex = value;
                }
                else
                {
                    SelectedItem = null;
                    _SelectedIndex = -1;
                }
            }
        }private int _SelectedIndex = -1;

        /// <summary>
        /// The selected item
        /// </summary>
        public ScrollListBoxItem SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != null)
                {
                    _SelectedItem.BackColor = (_SelectedItem.Index % 2 == 0) ? BackColorEven : BackColorOdd;
                    _SelectedItem.IsSelected = false;
                }
                _SelectedItem = value;
                if (value != null)
                {
                    value.IsSelected = true;
                    value.BackColor = BackSelectedColor;
                    _SelectedIndex = GetSelectedIndex(value);
                    int scrollPosition = Math.Abs(AutoScrollPosition.Y);
                    if (value.Bottom > ClientRectangle.Height)
                    {
                        int difference = Math.Abs(ClientRectangle.Bottom - value.Bottom);
                        AutoScrollPosition = new Point(0, scrollPosition + difference);
                    }
                    else if (value.Top < 0)
                    {
                        int difference = Math.Abs(value.Top);
                        AutoScrollPosition = new Point(0, scrollPosition - difference);
                    }
                    Focus();
                }
                else
                {
                    _SelectedIndex = -1;
                }
                if (IndexChanged != null)
                {
                    IndexChanged(value);
                }
            }
        }private ScrollListBoxItem _SelectedItem;

        /// <summary>
        /// Item action delegate
        /// </summary>
        /// <param name="control">control</param>
        public delegate void ItemHandler(ScrollListBoxItem control);

        /// <summary>
        /// Index changed event
        /// </summary>
        public event ItemHandler IndexChanged;

        /// <summary>
        /// Item selected event
        /// </summary>
        public event ItemHandler ItemSelected;

        /// <summary>
        /// Fire ItemSelected event, if handler is registered
        /// </summary>
        /// <param name="item">selected item</param>
        private void OnItemSelected(ScrollListBoxItem item)
        {
            if (item == null) return;
            SelectedIndex = Controls.GetChildIndex(item);
            SelectedItem = item;
            if (ItemSelected != null)
            {
                ItemSelected(item);
            }
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
            catch (Exception ex)
            {
                Log.Exception("ScrollListBox.GetSelectedIndex", "Exception={0}", ex);
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
                    if (SelectedItem != null)
                    {
                        int indexDown = Controls.GetChildIndex(SelectedItem) + 1;
                        if (indexDown > -1 && Count > indexDown)
                        {
                            SelectedIndex = indexDown;
                        }
                    }
                    else if (Count > 0)
                    {
                        SelectedIndex = 0;
                    }
                    break;
                case Keys.Up:
                    if (SelectedItem != null)
                    {
                        int indexUp = Controls.GetChildIndex(SelectedItem) - 1;
                        if (indexUp > -1 && Count > indexUp)
                        {
                            SelectedIndex = indexUp;
                        }
                    }
                    else
                    {
                        SelectedIndex = Count - 1;
                    }
                    break;
                case Keys.PageUp:
                case Keys.Home:
                    SelectedIndex = 0;
                    break;
                case Keys.PageDown:
                case Keys.End:
                    SelectedIndex = Controls.Count - 1;
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
            SelectedItem = sender as ScrollListBoxItem;
        }

        /// <summary>
        /// Upon DoubleClick, fire ItemSelected event
        /// </summary>
        private void control_DoubleClick(object sender, EventArgs e)
        {
            OnItemSelected(sender as ScrollListBoxItem);
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
