using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopClock
{
    public partial class TopClockForm : Form
    {
        [DllImportAttribute("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount );
        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        private Size originalFormSize = new Size();
        private Point originalTimeLabelLocation = new Point();
        private Color originalFormTransparencyKey = new Color();
        private Color originalFormBackColor = new Color();
        private FormBorderStyle originalFormBorderStyle = FormBorderStyle.None;
        private Color originalStartCbxColor = new Color();

        private Color originalTimerLabelForeColor = new Color();
        private Color originalTimerLabelInvertedForeColor = new Color();
        private Color originalTimerLabelBackColor = new Color();

        private IntPtr trayclockwclass;

        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowsProc childProc = new EnumWindowsProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                {
                    listHandle.Free();
                }
            }
            return result;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            return true;
        }

        public static string GetWindowClassName(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(128);

            GetClassName(hWnd, buffer, buffer.Capacity);

            return buffer.ToString();
        }

        public TopClockForm()
        {
            InitializeComponent();

            g_cmbUpdateTime.SelectedIndex = 0;

            SaveOriginalState();

            originalStartCbxColor = g_cbxStart.BackColor;

            originalTimerLabelForeColor = g_timeLabel.ForeColor;
            originalTimerLabelBackColor = Color.Transparent;            
            originalTimerLabelInvertedForeColor = Color.FromArgb(g_timeLabel.ForeColor.ToArgb() ^ 0xffffff);
            
            UpdateTimeLabel(timerTotalMinutes);

            List<IntPtr> list = GetChildWindows(GetDesktopWindow());
            List<String> classed = new List<String>();

            foreach (IntPtr ptr in list)
            {
                String classname = GetWindowClassName(ptr);

                if (classname == "TrayClockWClass")
                {
                    trayclockwclass = ptr;
                }
            }

            ShowWindow(trayclockwclass, 0);
        }

        private void TopClockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowWindow(trayclockwclass, 1);
        }

        private void g_cbxStart_CheckedChanged(object sender, EventArgs e)
        {
            if (g_cbxStart.Checked)
            {
                Start();
                g_cbxStart.Text = "Click to &PAUSE";
            }
            else
            {
                Pause();
                g_cbxStart.Text = "Click to &START";
            }
        }

        private void Start()
        {   
            g_cbxStart.BackColor = Color.Green;
            g_cmbUpdateTime.Enabled = false;
            g_btnMinusM.Enabled = false;
            g_btnPlusM.Enabled = false;
            g_btnMinusH.Enabled = false;
            g_btnPlusH.Enabled = false;

            g_timer.Interval = 60000;
            g_timer.Enabled = true;
            g_timer.Tick += new System.EventHandler(OnTimerEvent);
            g_timer.Tick -= new System.EventHandler(OnTimerEndEvent);
        }

        private void Pause()
        {
            g_cbxStart.BackColor = originalStartCbxColor;
            g_cmbUpdateTime.Enabled = true;
            g_btnMinusM.Enabled = true;
            g_btnPlusM.Enabled = true;
            g_btnMinusH.Enabled = true;
            g_btnPlusH.Enabled = true;

            g_timer.Enabled = false;
            g_timer.Tick -= new System.EventHandler(OnTimerEvent);
            g_timer.Tick -= new System.EventHandler(OnTimerEndEvent);
        }

        static bool labelInvertColor = false;
        private void OnTimerEndEvent(object sender, EventArgs e)
        {
            if (labelInvertColor )
            {
                g_timeLabel.ForeColor = originalTimerLabelInvertedForeColor;
                g_timeLabel.BackColor = originalTimerLabelForeColor;
            }
            else
            {
                g_timeLabel.ForeColor = originalTimerLabelForeColor;
                g_timeLabel.BackColor = originalTimerLabelInvertedForeColor;
            }

            labelInvertColor = !labelInvertColor;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if ( currentTimeM > 0 )
            {
                currentTimeM--;

                if (currentTimeM == 0)
                {
                    g_cbxStart.Text = "&Finished! Click Reset!";
                    g_cbxStart.Enabled = false;
                    labelInvertColor = false;

                    g_timer.Interval = 500;
                    g_timer.Enabled = true;
                    g_timer.Tick -= new System.EventHandler(OnTimerEvent);
                    g_timer.Tick += new System.EventHandler(OnTimerEndEvent);                    
                }
            }

            String value = (String)g_cmbUpdateTime.SelectedItem;
            uint minutesToCheck = UInt32.Parse(value);

            if (currentTimeM == 0 || 0 == ((currentTimeM % 60) % minutesToCheck) )
            {
                UpdateTimeLabel(currentTimeM);
            }
        }

        private void g_btnReset_Click(object sender, EventArgs e)
        {
            g_timer.Enabled = false;
            g_cbxStart.Enabled = true;
            g_cbxStart.Checked = false;

            currentTimeM = timerTotalMinutes;
            UpdateTimeLabel(timerTotalMinutes);
            
            g_timeLabel.ForeColor = originalTimerLabelForeColor;
            g_timeLabel.BackColor = originalTimerLabelBackColor;
        }

        private uint timerTotalMinutes = 0;
        private uint currentTimeM = 0;

        private void g_btnPlusH_Click(object sender, EventArgs e)
        {
            timerTotalMinutes += 60;
            UpdateTimeLabel(timerTotalMinutes);
            currentTimeM = timerTotalMinutes;
        }

        private void g_btnMinusH_Click(object sender, EventArgs e)
        {
            if (timerTotalMinutes>=60)
            {
                timerTotalMinutes -= 60;
            }
                
            UpdateTimeLabel(timerTotalMinutes);
            currentTimeM = timerTotalMinutes;
        }

        private void g_btnPlusM_Click(object sender, EventArgs e)
        {
            uint hours = timerTotalMinutes / 60;
            uint minutes = (timerTotalMinutes + 1) % 60;
            timerTotalMinutes = (60 * hours) + minutes;
            UpdateTimeLabel(timerTotalMinutes);
            currentTimeM = timerTotalMinutes;
        }

        private void g_btnMinusM_Click(object sender, EventArgs e)
        {
            uint hours = timerTotalMinutes / 60;
            uint minutes = (timerTotalMinutes + 60 - 1) % 60;
            timerTotalMinutes = (60 * hours) + minutes;
            UpdateTimeLabel(timerTotalMinutes);
            currentTimeM = timerTotalMinutes;
        }

        private void UpdateTimeLabel(uint inTotalMinutes)
        {
            g_cbxStart.Enabled = inTotalMinutes > 0;

            uint totalHours = (uint)Math.Floor((double)inTotalMinutes / 60);
            uint totalMinutes = inTotalMinutes % 60;

            g_timeLabel.Text = String.Format("{0,2}:{1,2}", totalHours.ToString("D2"), totalMinutes.ToString("D2"));
        }

        private void SaveOriginalState()
        {
            originalFormSize = Size;
            originalTimeLabelLocation = g_timeLabel.Location;
            originalFormTransparencyKey = TransparencyKey;
            originalFormBackColor = BackColor;
            originalFormBorderStyle = FormBorderStyle;
        }

        private void RestoreOriginalState()
        {
            Size = originalFormSize;
            g_timeLabel.Location = originalTimeLabelLocation;
            TransparencyKey = originalFormTransparencyKey;
            BackColor = originalFormBackColor;
            FormBorderStyle = originalFormBorderStyle;
        }

        private void HideInterface()
        {
            // Display the form as top most form.
            TopMost = true;

            // label in the origin
            g_timeLabel.Location = new Point(0, 0);

            // set the form transparent
            TransparencyKey = Color.Turquoise;
            BackColor = Color.Turquoise;

            // remove borders
            FormBorderStyle = FormBorderStyle.None;

            // set form size like the time label size
            Size = g_timeLabel.Size;
        }

        private void ShowInterface()
        {
            // Not anymore TopMost
            TopMost = false;

            RestoreOriginalState();
        }

        private bool IsBorderless()
        {
            return FormBorderStyle == System.Windows.Forms.FormBorderStyle.None;
        }

        private void ToggleInterface()
        {
            if (IsBorderless())
            {
                ShowInterface();
            }
            else
            {
                HideInterface();
            }
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private void g_timeLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && IsBorderless() )
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void g_timeLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ToggleInterface();
            }
        }
    }
}
