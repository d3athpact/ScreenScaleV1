namespace ScreenLimiter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboScreens;
        private Button btnSelectArea;
        private Button btnApply;
        private Button btnStop;
        private System.Windows.Forms.NotifyIcon notifyIcon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            if (disposing && (notifyIcon != null)) notifyIcon.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboScreens = new ComboBox();
            this.btnSelectArea = new Button();
            this.btnApply = new Button();
            this.btnStop = new Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();

            // comboScreens
            this.comboScreens.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboScreens.Location = new System.Drawing.Point(20, 20);
            this.comboScreens.Size = new System.Drawing.Size(300, 23);
            this.comboScreens.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnSelectArea
            this.btnSelectArea.Text = "Выделить область";
            this.btnSelectArea.Location = new System.Drawing.Point(20, 60);
            this.btnSelectArea.Size = new System.Drawing.Size(150, 30);
            this.btnSelectArea.Click += new System.EventHandler(this.btnSelectArea_Click);

            // btnApply
            this.btnApply.Text = "Применить";
            this.btnApply.Location = new System.Drawing.Point(20, 110);
            this.btnApply.Size = new System.Drawing.Size(150, 30);
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            // btnStop
            this.btnStop.Text = "Стоп";
            this.btnStop.Location = new System.Drawing.Point(180, 110);
            this.btnStop.Size = new System.Drawing.Size(150, 30);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // notifyIcon
            this.notifyIcon.Icon = System.Drawing.SystemIcons.Application; // стандартная иконка
            this.notifyIcon.Text = "ScreenLimiter";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);

            // Form1
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.MinimumSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.comboScreens);
            this.Controls.Add(this.btnSelectArea);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnStop);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Text = "Screen Limiter";
            this.ResumeLayout(false);
        }
    }
}
