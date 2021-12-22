using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawingDemo.WinFormsApp
{
    public partial class MainForm : Form
    {
        private static readonly List<Line> _lineList = new List<Line>();
        private static Line _line = new Line();

        public MainForm()
        {
            InitializeComponent();
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var point = DrawingPanel.PointToClient(Cursor.Position);

            if (_line.Points.Count < 1)
            {
                _line.Points.Add(point);
            }
            else
            {
                _line.Points.Add(point);
                _lineList.Add(_line);
                _line = new Line();
                DrawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            _lineList.ForEach(line =>
            {
                using var pen = new Pen(line.Color);
                e.Graphics.DrawLines(pen, line.Points.ToArray());
            });
        }
    }
}
