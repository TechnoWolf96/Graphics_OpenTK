using Graphics_OpenTK;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace LearnOpenTK
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1920, 1080),
                Title = "Raytracing",
                Location = new Vector2i(320, 200),
                WindowBorder = OpenTK.Windowing.Common.WindowBorder.Fixed
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
