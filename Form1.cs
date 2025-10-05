using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenLimiter
{
    public partial class Form1 : Form
    {
        private Rectangle selectedArea = Rectangle.Empty;
        private IntPtr selectedMonitorHandle = IntPtr.Zero;
        private System.Windows.Forms.Timer timer; // явный тип

        public Form1()
        {
            InitializeComponent();
            LoadMonitors();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        private void LoadMonitors()
        {
            comboScreens.Items.Clear();
            foreach (var screen in Screen.AllScreens)
            {
                comboScreens.Items.Add(screen.DeviceName + $" ({screen.Bounds.Width}x{screen.Bounds.Height})");
            }
            if (comboScreens.Items.Count > 0)
                comboScreens.SelectedIndex = 0;
        }

        private void btnSelectArea_Click(object sender, EventArgs e)
        {
            if (comboScreens.SelectedIndex < 0) return;
            var screen = Screen.AllScreens[comboScreens.SelectedIndex];

            selectedMonitorHandle = screen.GetHmonitor();

            using (var overlay = new OverlayForm(screen))
            {
                overlay.ShowDialog();
                selectedArea = overlay.GetAbsoluteRectangle();
            }

            if (selectedArea != Rectangle.Empty)
                MessageBox.Show($"Выбрана область: {selectedArea.Width}x{selectedArea.Height} на мониторе {comboScreens.SelectedIndex + 1}");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (selectedArea == Rectangle.Empty)
            {
                MessageBox.Show("Сначала выделите область.");
                return;
            }
            timer.Start();
            MessageBox.Show("Ограничение окон включено.");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Ограничение окон отключено.");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (selectedArea != Rectangle.Empty)
                LimitWindows(selectedArea);
        }

        private void LimitWindows(Rectangle limit)
        {
            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if (!NativeMethods.IsWindowVisible(hWnd)) return true;

                IntPtr windowMonitor = NativeMethods.MonitorFromWindow(hWnd, NativeMethods.MONITOR_DEFAULTTONEAREST);
                if (windowMonitor != selectedMonitorHandle) return true;

                NativeMethods.SetWindowPos(hWnd, IntPtr.Zero,
                    limit.Left, limit.Top, limit.Width, limit.Height,
                    NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);

                return true;
            }, IntPtr.Zero);
        }

        // ---- ЛОГИКА ТРЕЯ ----
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.BalloonTipTitle = "ScreenLimiter";
                notifyIcon.BalloonTipText = "Приложение свернуто в трей";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
    }
}
