using System.Drawing;
using System.Windows.Forms;
using static LineDrawingDemo.LineDrawingLib.LineDrawing;

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
            if (_clicksCount++ == 0) { AddNewLine(); }

            var point = DrawingPanel.PointToClient(Cursor.Position);
            AddNewPoint(point);

            if (_clicksCount == _clicskMax)
            {
                DrawingPanel.Invalidate();
                _clicksCount = 0;
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            GetLines().ForEach(line =>
            {
                using var pen = new Pen(line.Color);
                e.Graphics.DrawLines(pen, line.Points.ToArray());
            });
        }
    }
}
