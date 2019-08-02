using System;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaPlayground
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;
            var width = info.Width;
            var height = info.Height;

            //These variables are defined in XAML to use hot reloading
            float.TryParse(Resources["StrokeWidth"].ToString(), out var strokeWidth);
            var color = Resources["Color"].ToString();

            canvas.Clear();

            canvas.DrawLine(0, height/2, width/2-100, height/2, new SKPaint(){Color = SKColor.Parse(color),StrokeWidth = strokeWidth, IsAntialias = true });
            var path = new SKPath();
            path.AddArc(new SKRect(width/2-110, height/2-110, width/2+110, height/2+110),180, 180 );
            canvas.DrawPath(path, new SKPaint() { Color = SKColor.Parse(color), Style = SKPaintStyle.Stroke, StrokeWidth = strokeWidth, IsAntialias = true});
            canvas.DrawLine(width / 2+100, height / 2, width, height / 2, new SKPaint() { Color = SKColor.Parse(color), StrokeWidth = strokeWidth, IsAntialias = true });

        }
    }
}