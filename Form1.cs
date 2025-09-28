using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenLimiter
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Rectangle limitArea;
        private IntPtr selectedMonitorHandle;

        public Form1()
        {
            InitializeComponent();
            LoadMonitors();

            timer.Interval = 200; // Быстрая реакция на разворот окна
            timer.Tick += (s, e) => LimitWindows(limitArea);
        }

        private void LoadMonitors()
        {
            comboScreens.Items.Clear();
            foreach (var screen in Screen.AllScreens)
                comboScreens.Items.Add(screen.DeviceName + $" ({screen.Bounds.Width}x{screen.Bounds.Height})");
            if (comboScreens.Items.Count > 0)
                comboScreens.SelectedIndex = 0;
        }

        private void btnSelectArea_Click(object sender, EventArgs e)
        {
            if (comboScreens.SelectedIndex < 0) return;
            var screen = Screen.AllScreens[comboScreens.SelectedIndex];
            selectedMonitorHandle = screen.GetHmonitor();

            OverlayForm overlay = new OverlayForm(screen);
            overlay.ShowDialog();

            limitArea = overlay.GetAbsoluteRectangle();

            txtLeft.Text = limitArea.Left.ToString();
            txtTop.Text = limitArea.Top.ToString();
            txtWidth.Text = limitArea.Width.ToString();
            txtHeight.Text = limitArea.Height.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (limitArea == Rectangle.Empty)
            {
                MessageBox.Show("Выберите область сначала!");
                return;
            }
            timer.Start();
            MessageBox.Show("🔒 Ограничение окон включено!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            MessageBox.Show("⛔ Ограничение окон отключено!");
        }

        private void btnGetResolution_Click(object sender, EventArgs e)
        {
            if (comboScreens.SelectedIndex < 0) return;
            var screen = Screen.AllScreens[comboScreens.SelectedIndex];
            txtLeft.Text = screen.Bounds.Left.ToString();
            txtTop.Text = screen.Bounds.Top.ToString();
            txtWidth.Text = screen.Bounds.Width.ToString();
            txtHeight.Text = screen.Bounds.Height.ToString();
        }

        private void LimitWindows(Rectangle limit)
        {
            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if (!NativeMethods.IsWindowVisible(hWnd)) return true;

                IntPtr windowMonitor = NativeMethods.MonitorFromWindow(hWnd, NativeMethods.MONITOR_DEFAULTTONEAREST);
                if (windowMonitor != selectedMonitorHandle) return true; // пропускаем окна на других мониторах

                // Принудительно подгоняем размеры под выбранную область
                NativeMethods.SetWindowPos(hWnd, IntPtr.Zero, limit.Left, limit.Top, limit.Width, limit.Height,
                    NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);

                return true;
            }, IntPtr.Zero);
        }
    }
}
