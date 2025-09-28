namespace ScreenLimiter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboScreens;
        private Button btnGetResolution;
        private Button btnSelectArea;
        private Button btnApply;
        private Button btnStop;
        private Label lblLeft;
        private Label lblTop;
        private Label lblWidth;
        private Label lblHeight;
        private TextBox txtLeft;
        private TextBox txtTop;
        private TextBox txtWidth;
        private TextBox txtHeight;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboScreens = new ComboBox();
            this.btnGetResolution = new Button();
            this.btnSelectArea = new Button();
            this.btnApply = new Button();
            this.btnStop = new Button();
            this.lblLeft = new Label();
            this.lblTop = new Label();
            this.lblWidth = new Label();
            this.lblHeight = new Label();
            this.txtLeft = new TextBox();
            this.txtTop = new TextBox();
            this.txtWidth = new TextBox();
            this.txtHeight = new TextBox();
            this.SuspendLayout();

            // comboScreens
            this.comboScreens.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboScreens.Location = new System.Drawing.Point(20, 20);
            this.comboScreens.Size = new System.Drawing.Size(250, 23);
            this.comboScreens.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnGetResolution
            this.btnGetResolution.Text = "Получить";
            this.btnGetResolution.Location = new System.Drawing.Point(280, 20);
            this.btnGetResolution.Size = new System.Drawing.Size(100, 23);
            this.btnGetResolution.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnGetResolution.Click += new System.EventHandler(this.btnGetResolution_Click);

            // btnSelectArea
            this.btnSelectArea.Text = "Выделить область";
            this.btnSelectArea.Location = new System.Drawing.Point(20, 60);
            this.btnSelectArea.Size = new System.Drawing.Size(150, 23);
            this.btnSelectArea.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnSelectArea.Click += new System.EventHandler(this.btnSelectArea_Click);

            // Labels
            this.lblLeft.Text = "Left:"; this.lblLeft.Location = new System.Drawing.Point(20, 100);
            this.lblTop.Text = "Top:"; this.lblTop.Location = new System.Drawing.Point(20, 130);
            this.lblWidth.Text = "Width:"; this.lblWidth.Location = new System.Drawing.Point(20, 160);
            this.lblHeight.Text = "Height:"; this.lblHeight.Location = new System.Drawing.Point(20, 190);

            // TextBoxes
            this.txtLeft.Location = new System.Drawing.Point(80, 100); this.txtLeft.Size = new System.Drawing.Size(100, 23);
            this.txtLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTop.Location = new System.Drawing.Point(80, 130); this.txtTop.Size = new System.Drawing.Size(100, 23);
            this.txtTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtWidth.Location = new System.Drawing.Point(80, 160); this.txtWidth.Size = new System.Drawing.Size(100, 23);
            this.txtWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtHeight.Location = new System.Drawing.Point(80, 190); this.txtHeight.Size = new System.Drawing.Size(100, 23);
            this.txtHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnApply
            this.btnApply.Text = "Применить"; this.btnApply.Location = new System.Drawing.Point(20, 230);
            this.btnApply.Size = new System.Drawing.Size(150, 30);
            this.btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            // btnStop
            this.btnStop.Text = "Стоп"; this.btnStop.Location = new System.Drawing.Point(180, 230);
            this.btnStop.Size = new System.Drawing.Size(150, 30);
            this.btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.MinimumSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.comboScreens);
            this.Controls.Add(this.btnGetResolution);
            this.Controls.Add(this.btnSelectArea);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnStop);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Text = "Screen Limiter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
