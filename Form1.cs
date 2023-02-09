using System.Numerics;

namespace MengerSponge;

public partial class Form1 : Form
{
    private static readonly Color BackgroundColor = Color.Black;
    private static readonly Color CarpetColor = Color.White;
    
    private const int Iterations = 200000;
    
    private readonly int     _xOffset, _yOffset;
    private readonly Point[] _attractors;
    private readonly Size    _carpetSize = new (400, 400);
    private readonly Panel   _canvas     = new ();
    
    
    public Form1()
    {
        InitializeComponent();
        CenterToScreen();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Width = 600;
        Height = 600;
        _attractors = InitAttractors();

        _xOffset = (Width - _carpetSize.Width) / 2;
        _yOffset = (Height - _carpetSize.Height) / 2;
        
        Controls.Add(_canvas);
        _canvas.BackColor = BackgroundColor;
        _canvas.Dock = DockStyle.Fill;
        
        _canvas.Paint += (DrawCarpet);
    }


    private void DrawCarpet(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        var random = new Random();
        var brush = new SolidBrush(CarpetColor);
        var previousPoint = new Point(0, 0);

        for (var i = 0; i < Iterations; i++)
        {
            var attractor = _attractors[random.NextInt64() % _attractors.Length];
            
            var vector = new Vector2(
                attractor.X - previousPoint.X, 
                attractor.Y - previousPoint.Y);

            var x = (int)(previousPoint.X + vector.X / 3 * 2);
            var y = (int)(previousPoint.Y + vector.Y / 3 * 2);
            
            var nextPoint = new Point(x, y);
            g.FillRectangle(
                brush, 
                nextPoint.X + _xOffset,
                nextPoint.Y + _yOffset,
                1, 1);
            
            previousPoint = nextPoint;
        }
    }


    private Point[] InitAttractors()
    {
        var squareWidth = _carpetSize.Width;
        
        Point[] points =
        {
            new (0              , 0              ),
            new (squareWidth / 2, 0              ),
            new (squareWidth    , 0              ),
            new (squareWidth    , squareWidth / 2),
            new (squareWidth    , squareWidth    ),
            new (squareWidth / 2, squareWidth    ),
            new (0              , squareWidth    ),
            new (0              , squareWidth / 2)
        };

        return points;
    }
}