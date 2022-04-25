using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using Graphics_OpenTK;
using OpenTK.Windowing.GraphicsLibraryFramework;

sealed class Program : GameWindow
{
    private float[] _vertices = new float[]
    {
         // Position          Normal
            -0.5f, -0.5f, -0.5f,      0.0f,  0.0f, -1.0f, // Front face
             0.5f, -0.5f, -0.5f,      0.0f,  0.0f, -1.0f,
             0.5f,  0.5f, -0.5f,      0.0f,  0.0f, -1.0f,
             0.5f,  0.5f, -0.5f,      0.0f,  0.0f, -1.0f,
            -0.5f,  0.5f, -0.5f,      0.0f,  0.0f, -1.0f,
            -0.5f, -0.5f, -0.5f,      0.0f,  0.0f, -1.0f,

            -0.5f, -0.5f,  0.5f,      0.0f,  0.0f,  1.0f, // Back face
             0.5f, -0.5f,  0.5f,      0.0f,  0.0f,  1.0f,
             0.5f,  0.5f,  0.5f,      0.0f,  0.0f,  1.0f,
             0.5f,  0.5f,  0.5f,      0.0f,  0.0f,  1.0f,
            -0.5f,  0.5f,  0.5f,      0.0f,  0.0f,  1.0f,
            -0.5f, -0.5f,  0.5f,      0.0f,  0.0f,  1.0f,

            -0.5f,  0.5f,  0.5f,     -1.0f,  0.0f,  0.0f, // Left face
            -0.5f,  0.5f, -0.5f,     -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,     -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,     -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f,  0.5f,     -1.0f,  0.0f,  0.0f,
            -0.5f,  0.5f,  0.5f,     -1.0f,  0.0f,  0.0f,

             0.5f,  0.5f,  0.5f,      1.0f,  0.0f,  0.0f, // Right face
             0.5f,  0.5f, -0.5f,      1.0f,  0.0f,  0.0f,
             0.5f, -0.5f, -0.5f,      1.0f,  0.0f,  0.0f,
             0.5f, -0.5f, -0.5f,      1.0f,  0.0f,  0.0f,
             0.5f, -0.5f,  0.5f,      1.0f,  0.0f,  0.0f,
             0.5f,  0.5f,  0.5f,      1.0f,  0.0f,  0.0f,

            -0.5f, -0.5f, -0.5f,      0.0f, -1.0f,  0.0f, // Bottom face
             0.5f, -0.5f, -0.5f,      0.0f, -1.0f,  0.0f,
             0.5f, -0.5f,  0.5f,      0.0f, -1.0f,  0.0f,
             0.5f, -0.5f,  0.5f,      0.0f, -1.0f,  0.0f,
            -0.5f, -0.5f,  0.5f,      0.0f, -1.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,      0.0f, -1.0f,  0.0f,

            -0.5f,  0.5f, -0.5f,      0.0f,  1.0f,  0.0f, // Top face
             0.5f,  0.5f, -0.5f,      0.0f,  1.0f,  0.0f,
             0.5f,  0.5f,  0.5f,      0.0f,  1.0f,  0.0f,
             0.5f,  0.5f,  0.5f,      0.0f,  1.0f,  0.0f,
            -0.5f,  0.5f,  0.5f,      0.0f,  1.0f,  0.0f,
            -0.5f,  0.5f, -0.5f,      0.0f,  1.0f,  0.0f


    };

    private uint[] _indices =
        {
            // Дно
            0, 3, 1,
            1, 2, 3,
            // Левая часть
            4, 5, 7,
            4, 6, 7,
            // Передняя часть
            8, 9, 10,
            10, 9, 11
        };

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private Shader _shader;
    private int _elementBufferObject;

    private Camera _camera;
    private bool _firstMove = true;
    private Vector2 _lastPos;
    private double _time;


    public Program(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
        : base(gameWindowSettings, nativeWindowSettings) {}




    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(Color4.Gray);

        // Создание VBO и VAO для работы с ними
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);

        // Инициализация вершин (В вершинном шейдере layout = 0)- считывание координат из массива _vertices
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        // Инициализация цветов (В вершинном шейдере layout = 1) - считывание цветов из массива _vertices
        GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);

        // Создание буфера с индексами вершин для отрисовки вершин в нужной последовательности
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.DynamicDraw);

        // Запуск шейдерной программы
        _shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");
        _shader.Use();

        // Создание подвижной камеры
        _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);

        // Скрытие курсора
        CursorGrabbed = true;

        //GL.Enable(EnableCap.CullFace);
        GL.Enable(EnableCap.DepthTest);

    }

    protected override void OnUnload()
    {
        _shader.Delete();
        base.OnUnload();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        _time += 4.0 * args.Time;

        GL.BindVertexArray(_vertexArrayObject);
        var transform = Matrix4.Identity;
        _shader.Use();
        _shader.SetMatrix4("transform", transform);

        var model = Matrix4.Identity; // * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time));
        _shader.SetMatrix4("model", model);
        _shader.SetMatrix4("view", _camera.GetViewMatrix());
        _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());




        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

        SwapBuffers();
        base.OnRenderFrame(args);
    }


    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        if (!IsFocused) // Check to see if the window is focused
        {
            return;
        }

        var input = KeyboardState;

        if (input.IsKeyDown(Keys.Escape))
        {
            Close();
        }

        const float cameraSpeed = 1.5f;
        const float sensitivity = 0.2f;

        if (input.IsKeyDown(Keys.W))
        {
            _camera.Position += _camera.Front * cameraSpeed * (float)args.Time; // Forward
        }

        if (input.IsKeyDown(Keys.S))
        {
            _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time; // Backwards
        }
        if (input.IsKeyDown(Keys.A))
        {
            _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time; // Left
        }
        if (input.IsKeyDown(Keys.D))
        {
            _camera.Position += _camera.Right * cameraSpeed * (float)args.Time; // Right
        }
        if (input.IsKeyDown(Keys.Space))
        {
            _camera.Position += _camera.Up * cameraSpeed * (float)args.Time; // Up
        }
        if (input.IsKeyDown(Keys.LeftShift))
        {
            _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time; // Down
        }

        // Get the mouse state
        var mouse = MouseState;

        if (_firstMove) // This bool variable is initially set to true.
        {
            _lastPos = new Vector2(mouse.X, mouse.Y);
            _firstMove = false;
        }
        else
        {
            // Calculate the offset of the mouse position
            var deltaX = mouse.X - _lastPos.X;
            var deltaY = mouse.Y - _lastPos.Y;
            _lastPos = new Vector2(mouse.X, mouse.Y);

            // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
            _camera.Yaw += deltaX * sensitivity;
            _camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top
        }

    }



    static void Main()
    {
        var gameWindowSettings = new GameWindowSettings();
        var nativeWindowSettings = new NativeWindowSettings()
        {
            Size = new Vector2i(800, 600),
            WindowBorder = WindowBorder.Fixed,
            
        };
        var program = new Program(gameWindowSettings, nativeWindowSettings);
        program.Run();
    }
}

