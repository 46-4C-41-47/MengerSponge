using System.Numerics;

namespace MengerSponge;

public partial class Form1 : Form
{
    private readonly Point[] _attractors;
    private readonly Panel _canvas = new ();
    
    public Form1()
    {
        InitializeComponent();
        CenterToScreen();
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Width = 400;
        Height = 400;
        _attractors = InitAttractors();
        
        Controls.Add(_canvas);
        _canvas.BackColor = Color.Black;
        _canvas.Dock = DockStyle.Fill;
        
        _canvas.Paint += (DrawAttractors);
    }


    private void DrawAttractors(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        var random = new Random();
        var brush = new SolidBrush(Color.White);
        var previousPoint = new Point(
            (int) random.NextInt64() % Width, 
            (int) random.NextInt64() % Height);

        for (var i = 0; i < 100000; i++)
        {
            var attractor = _attractors[random.NextInt64() % _attractors.Length];
            
            var vector = new Vector2(
                attractor.X - previousPoint.X, 
                attractor.Y - previousPoint.Y);

            var x = (int)(previousPoint.X + vector.X / 3 * 2);
            var y = (int)(previousPoint.Y + vector.Y / 3 * 2);
            
            var nextPoint = new Point(x, y);
            g.FillRectangle(brush, nextPoint.X, nextPoint.Y, 1, 1);
            previousPoint = nextPoint;
        }
    }


    private Point[] InitAttractors()
    {
        var squareWidth = Width < Height ? Width : Height;
        
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