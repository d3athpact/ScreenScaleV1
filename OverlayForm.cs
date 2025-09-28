using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenLimiter
{
    public class OverlayForm : Form
    {
        private Point startPoint;
        private Rectangle currentRect;
        private bool drawing = false;
        private Rectangle screenBounds;

        public Rectangle SelectedRectangle { get; private set; }

        public OverlayForm(Screen monitor)
        {
            screenBounds = monitor.Bounds;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = screenBounds.Location;
            this.Size = screenBounds.Size;

            this.BackColor = Color.Black;
            this.Opacity = 0.3;
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Cross;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            startPoint = e.Location;
            drawing = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (drawing)
            {
                currentRect = GetRectangle(startPoint, e.Location);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            drawing = false;
            SelectedRectangle = currentRect;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (drawing)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, currentRect);
                }
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }

        // Возвращает координаты выделенной области в абсолютных координатах рабочего стола
        public Rectangle GetAbsoluteRectangle()
        {
            return new Rectangle(
                SelectedRectangle.Left + screenBounds.Left,
                SelectedRectangle.Top + screenBounds.Top,
                SelectedRectangle.Width,
                SelectedRectangle.Height);
        }
    }
}
