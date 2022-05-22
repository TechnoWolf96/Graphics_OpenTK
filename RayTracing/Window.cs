using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Graphics_OpenTK
{

    public struct Camera
    {
        public static Vector3 Position = new Vector3(0.0f, 0.0f, -7f);
        public static Vector3 View = new Vector3(0.0f, 0.0f, 1.0f);
        public static Vector3 Up = new Vector3(0.0f, 1.0f, 0.0f);
        public static Vector3 Side = new Vector3(1.0f, 0.0f, 0.0f);
        public static Vector2 Scale = new Vector2(1.0f);
    }




    public class Window : GameWindow
    {

        float[] vertexData = new float[]
        {
            -1f, -1f, 0f,
            -1f,  1f, 0f,
             1f, -1f, 0f,
             1f,  1f, 0f
        };

        int _vertexBufferObject;
        int _vertexArrayObject;
        Shader _shaderProgram;

        float forwardCamera = 0f;
        float rightCamera = 0f;
        float highCamera = 0f;
        float _mirrorCoeff = 1f;
        float mirrorCoeff
        {
            get => _mirrorCoeff;
            set
            {
                if (value < 0f) _mirrorCoeff = 0;
                else if (value > 1f) _mirrorCoeff = 1f;
                else _mirrorCoeff = value;
            }
        }

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings){}

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            _shaderProgram = new Shader("../../../Shaders/shader.vert", "../../../Shaders/rayTracing.frag");

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertexData.Length,
                vertexData, BufferUsageHint.StaticDraw);

            var posLoc = _shaderProgram.GetAttribLocation("vPosition");
            GL.EnableVertexAttribArray(posLoc);
            GL.VertexAttribPointer(posLoc, 3, VertexAttribPointerType.Float, false, 0, 0);



            



        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vertexArrayObject);

            _shaderProgram.SetVector3("uCamera.Position", Camera.Position
                + Vector3.UnitZ * forwardCamera + Vector3.UnitX * rightCamera + Vector3.UnitY * highCamera);// + Vector3.UnitZ * forwardCamera + Vector3.UnitX * leftCamera);

            _shaderProgram.SetVector3("uCamera.View", Camera.View);
            _shaderProgram.SetVector3("uCamera.Up", Camera.Up);
            _shaderProgram.SetVector3("uCamera.Side", Camera.Side );
            _shaderProgram.SetVector2("uCamera.Scale", Camera.Scale);
            _shaderProgram.SetFloat("mirrorCoeff", mirrorCoeff);

            _shaderProgram.Use();

            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);


            SwapBuffers();
        }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            var input = KeyboardState;

            if (input.IsKeyDown(Keys.W)) forwardCamera += (float)args.Time;
            if (input.IsKeyDown(Keys.S)) forwardCamera -= (float)args.Time;

            if (input.IsKeyDown(Keys.D)) rightCamera += (float)args.Time;
            if (input.IsKeyDown(Keys.A)) rightCamera -= (float)args.Time;

            if (input.IsKeyDown(Keys.Space)) highCamera += (float)args.Time;
            if (input.IsKeyDown(Keys.LeftShift)) highCamera -= (float)args.Time;

            if (input.IsKeyDown(Keys.E)) mirrorCoeff -= (float)args.Time;
            if (input.IsKeyDown(Keys.Q)) mirrorCoeff += (float)args.Time;

        }



    }
}

