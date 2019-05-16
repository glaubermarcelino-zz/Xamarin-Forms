using Android.Graphics;
using App1.Controls;
using App1.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FrameGradiente), typeof(FrameGradienteRenderer))]
namespace App1.Droid.Renderer
{
    public class FrameGradienteRenderer : VisualElementRenderer<Frame>
    {
        public Xamarin.Forms.Color StartColor { get; set; }
        public Xamarin.Forms.Color EndColor { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            var frame = e.NewElement as FrameGradiente;
            this.StartColor = frame.StartColor;
            this.EndColor = frame.EndColor;
            base.OnElementChanged(e);
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            this.StartColor.ToAndroid();
            this.EndColor.ToAndroid();


            var paint = new Paint()
            {
                Dither = true
            };

            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(), Android.Graphics.Shader.TileMode.Mirror);

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
    }
}