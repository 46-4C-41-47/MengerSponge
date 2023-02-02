namespace MengerSponge;

public partial class Form1 : Form
{
    private readonly Point[] _attractors;
    private Panel _canvas = new Panel();
    
    public Form1()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Width = 400;
        Height = 400;
        _attractors = InitAttractors();
        Controls.Add(_canvas);
        //Controls.Dock = DockStyle.Bottom;
        _canvas.BackColor = Color.Black;
        //DrawAttractors();
    }


    private void DrawAttractors()
    {
        Graphics g = _canvas.CreateGraphics();
        Pen p = new Pen(Color.Black);
        
        foreach (var point in _attractors)
        {
            g.DrawLine(p, point.X, point.Y, point.Y, point.Y);
        }
    }


    private Point[] InitAttractors()
    {
        //int centeringX, centeringY;
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