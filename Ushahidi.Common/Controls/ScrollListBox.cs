using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Scroll List Box
    /// </summary>
    public partial class ScrollListBox : UserControl
    {
        /// <summary>
        /// Scroll List Box
        /// </summary>
        public ScrollListBox()
        {
            InitializeComponent();
            KeyDown += EnhancedListBox_KeyDown;
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
        /// Selected back color
        /// </summary>
        public Color ForeSelectedColor
        {
            get { return _ForeSelectedColor; }
            set { _ForeSelectedColor = value; }
        }private Color _ForeSelectedColor = Color.White;

        /// <summary>
        /// Focus on list, if nothing currently selected, then select first item
        /// </summary>
        public new bool Focus()
        {
            if (Count > 0 && SelectedIndex == -1 && SelectedItem == null)
            {
                SelectedIndex = 0;
                SelectedItem = Controls[0];
            }
            return base.Focus();
        }

        /// <summary>
        /// Adjust height of list box to fit bottom of last item
        /// </summary>
        public void AdjustHeight()
        {
            Height = MaxBottom(Controls);
        }

        /// <summary>
        /// Number of controls
        /// </summary>
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
        public void Add(Control control)
        {
            Add(control, true);
        }

        /// <summary>
        /// Add new items
        /// </summary>
        /// <param name="control">item to add</param>
        /// <param name="refresh">should refresh list?</param>
        public void Add(Control control, bool refresh)
        {
            control.TabStop = false;
            control.Left = 0;
            control.Width = ClientRectangle.Width;
            control.Top = MaxBottom(Controls);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            control.BackColor = (Controls.Count % 2 == 0) ? BackColorEven : BackColorOdd;

            control.Click += OnItemClick;
            control.DoubleClick += OnItemDoubleClick;
            
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
        public void Remove(Control control)
        {
            if (Controls.Contains(control))
            {
                using (new WaitCursor())
                {
                    Controls.Remove(control);
                    for (int index = 0; index < Controls.Count; index++)
                    {
                        Control item = Controls[index];
                        if (item != null)
                        {
                            item.BackColor = (index % 2 == 0) ? BackColorEven : BackColorOdd;
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
            get { return _SelectedIndex; }
            set
            {
                if (value >= 0 && Count > value)
                {
                    SelectedItem = Controls[value];
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
        public Control SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != null)
                {
                    _SelectedItem.BackColor = (Controls.IndexOf(_SelectedItem) % 2 == 0) ? BackColorEven : BackColorOdd;
                    _SelectedItem.ForeColor = Color.Black;
                    _SelectedItem.Refresh();
                }
                _SelectedItem = value;
                if (value != null)
                {
                    value.BackColor = BackSelectedColor;
                    value.ForeColor = Color.White;
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
                    value.Refresh();
                    Focus();
                }
                else
                {
                    _SelectedIndex = -1;
                }
                if (IndexChanged != null)
                {
                    IndexChanged(this, new ScrollEventArgs(SelectedIndex, SelectedItem));
                }
            }
        }private Control _SelectedItem;

        /// <summary>
        /// Item action delegate
        /// </summary>
        public delegate void ItemHandler(object sender, ScrollEventArgs args);

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
        private void OnItemSelected(Control item)
        {
            if (item == null) return;
            SelectedIndex = Controls.GetChildIndex(item);
            SelectedItem = item;
            if (ItemSelected != null)
            {
                ItemSelected(this, new ScrollEventArgs(SelectedIndex, SelectedItem));
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
                        int index = Controls.GetChildIndex(SelectedItem);
                        if (index == Count - 1)
                        {
                            Parent.SelectNextControl(this, true, true, true, true);
                            SelectedItem = null;
                            SelectedIndex = -1;
                        }
                        else
                        {
                            int indexDown = index + 1;
                            if (indexDown > -1 && Count > indexDown)
                            {
                                SelectedIndex = indexDown;
                            }    
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
                        int index = Controls.GetChildIndex(SelectedItem);
                        if (index == 0)
                        {
                            Parent.SelectNextControl(this, false, true, true, true);
                            SelectedItem = null;
                            SelectedIndex = -1;
                        }
                        else
                        {
                            int indexUp = index - 1;
                            if (indexUp > -1 && Count > indexUp)
                            {
                                SelectedIndex = indexUp;
                            }        
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
        private void OnItemClick(object sender, EventArgs e)
        {
            SelectedItem = sender as Control;
        }

        /// <summary>
        /// Upon DoubleClick, fire ItemSelected event
        /// </summary>
        private void OnItemDoubleClick(object sender, EventArgs e)
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
        /// Refresh
        /// </summary>
        public new void Refresh()
        {
            base.Refresh();
            foreach (Control control in Controls)
            {
                control.Refresh();
            }
        }

        /// <summary>
        /// Invalidate
        /// </summary>
        public new void Invalidate()
        {
            base.Invalidate();
            foreach (Control control in Controls)
            {
                control.Invalidate();
            }
        }
    }

    /// <summary>
    /// ScrollListBox Event Args
    /// </summary>
    public class ScrollEventArgs : EventArgs
    {
        /// <summary>
        /// ScrollListBox Event Args
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="item">item</param>
        public ScrollEventArgs(int index, Control item)
        {
            Index = index;
            Item = item;
        }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Item
        /// </summary>
        public Control Item { get; private set; }
    }
}
