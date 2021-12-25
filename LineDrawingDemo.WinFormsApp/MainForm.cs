using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LineDrawingDemo.LineDrawingLib;

namespace LineDrawingDemo.WinFormsApp
{
    public partial class MainForm : Form
    {
        private const uint _clicskMax = 2;
        private static uint _clicksCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_clicksCount++ == 0) LineDrawing.AddNewLine();

            LineDrawing.AddToLastLine(new Point(e.X, e.Y));

            if (_clicksCount == _clicskMax) _clicksCount = 0;

            DrawingPanel.Invalidate();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            LineDrawing.GetLines().ForEach(line =>
            {
                using var pen = new Pen(line.Color);

                if (line.Points.Count == 1)
                    e.Graphics.DrawRectangle(pen, new Rectangle(line.Points.Last(), new Size(1, 1)));
                else
                    e.Graphics.DrawLines(pen, line.Points.ToArray());
            });
        }
    }
}
