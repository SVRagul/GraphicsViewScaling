using Microsoft.Maui.Layouts;

namespace DemoApp;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}

    private void ZoomIn_Clicked(object sender, EventArgs e)
    {
        (customView.GraphicalView.Drawable as DummyDrawing).scale = (float)10;
        this.customView.GraphicalView.Invalidate();
    }

    private void ZoomOut_Clicked(object sender, EventArgs e)
    {
        (customView.GraphicalView.Drawable as DummyDrawing).scale = (float)1;
        this.customView.GraphicalView.Invalidate();
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        this.customView.GraphicalView.Scale = e.NewValue;
    }
}

public class CustomView : AbsoluteLayout
{
    internal readonly GraphicsView? GraphicalView;
    public CustomView()
    {
        this.GraphicalView = new GraphicsView();
        this.GraphicalView.Drawable = new DummyDrawing();
        AbsoluteLayout.SetLayoutBounds(GraphicalView, new Rect(0, 0, 1, 1));
        AbsoluteLayout.SetLayoutFlags(GraphicalView, AbsoluteLayoutFlags.All);
        this.Add(GraphicalView);
    }
}

public class DummyDrawing : IDrawable
{
    public float scale { get; set; } = 1;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.DarkBlue;
        canvas.FillCircle(new PointF(200, 200), 100 * this.scale);
    }
}

