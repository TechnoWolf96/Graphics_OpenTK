using Graphics_OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace LearnOpenTK
{
    public class Window : GameWindow
    {
        private readonly float[] _vertices =
        {
          // Координаты вершин        Координаты нормалей    Цвета вершин 
            -0.5f, -0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f, // Задняя грань
             0.5f, -0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f,
             0.5f,  0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f,
             0.5f,  0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f,
            -0.5f,  0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f,
            -0.5f, -0.17f, -0.5f,     0.0f,  0.0f, -1.0f,    0.0f,  1.0f,  0.0f,
            // Перекрытие
           -0.17f, -0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,
            0.17f, -0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,
            0.17f,  0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,
            0.17f,  0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,
           -0.17f,  0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,
           -0.17f, -0.17f, -0.501f,     0.0f,  0.0f, -1.0f,    0.0f,  0.8f,  0.0f,



            -0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f, // Передняя грань
             0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
            -0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
            -0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
            // Перекрытие
           -0.17f, -0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f, 
            0.17f, -0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f,
            0.17f,  0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f,
            0.17f,  0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f,
           -0.17f,  0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f,
           -0.17f, -0.17f,  0.501f,     0.0f,  0.0f,  1.0f,    0.9f,  0.35f,  0.0f,



            -0.5f,  0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f, // Левая грань
            -0.5f,  0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f,  0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            // Перекрытие
            -0.501f,  0.17f,  0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,
            -0.501f,  0.17f, -0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,
            -0.501f, -0.17f, -0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,
            -0.501f, -0.17f, -0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,
            -0.501f, -0.17f,  0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,
            -0.501f,  0.17f,  0.17f,    -1.0f,  0.0f,  0.0f,    0.8f,  0.8f,  0.07f,


             0.5f,  0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f, // Правая грань
             0.5f,  0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f,  0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             // Перекрытие
             0.501f,  0.17f,  0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,
             0.501f,  0.17f, -0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,
             0.501f, -0.17f, -0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,
             0.501f, -0.17f, -0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,
             0.501f, -0.17f,  0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,
             0.501f,  0.17f,  0.17f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  0.8f,


            -0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f, // Нижняя грань
             0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
            -0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
            -0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
            // Нижнее перекрытие
           -0.17f, -0.171f, -0.5f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f, -0.5f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f, -0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f, -0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f, -0.5f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f, -0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           // Левое перекрытие
           -0.5f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f, 0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f, 0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.5f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.5f, -0.171f,  0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           // Правое перекрытие
           0.17f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.5f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.5f, -0.171f, 0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.5f, -0.171f, 0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           0.17f, -0.171f, -0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           0.17f, -0.171f,  0.17f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           // Верхнее перекрытие
           -0.17f, -0.171f,  0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f,  0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f,  0.5f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
            0.17f, -0.171f,  0.5f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f,  0.17f,     0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,
           -0.17f, -0.171f,  0.5f,    0.0f, -1.0f,  0.0f,    0.8f,  0.8f,  0.8f,


            -0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f, // Верхняя грань
             0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
            -0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
            -0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
             // Нижнее перекрытие
           -0.17f, 0.171f, -0.5f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.17f, 0.171f, -0.5f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.17f, 0.171f, -0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.17f, 0.171f, -0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.17f, 0.171f, -0.5f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.17f, 0.171f, -0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           // Левое перекрытие
           -0.5f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,    0.8f, 0.0f,  0.0f,
           -0.17f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,   0.8f, 0.0f,  0.0f,
           -0.17f, 0.171f, 0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.17f, 0.171f, 0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.5f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,   0.8f,  0.0f,  0.0f,
           -0.5f, 0.171f,  0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           // Правое перекрытие
           0.17f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.5f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.5f, 0.171f, 0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.5f, 0.171f, 0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           0.17f, 0.171f, -0.17f,     0.0f, 1.0f,  0.0f,    0.8f, 0.0f,  0.0f,
           0.17f, 0.171f,  0.17f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           // Верхнее перекрытие
           -0.17f, 0.171f,  0.17f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.17f, 0.171f,  0.17f,     0.0f, 1.0f,  0.0f,    0.8f, 0.0f,  0.0f,
            0.17f, 0.171f,  0.5f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
            0.17f, 0.171f,  0.5f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.17f, 0.171f,  0.17f,     0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
           -0.17f, 0.171f,  0.5f,    0.0f, 1.0f,  0.0f,    0.8f,  0.0f,  0.0f,
        };
        private const int triangleCount = 108;


        private Vector3 _lightPos = new Vector3(1.0f, 1.3f, 1.5f); // Позиция источника света и его куба

        private int _vertexBufferObject;
        private int _vaoBottomPart;
        private int _vaoMiddlePart;
        private int _vaoTopPart;
        private int _vaoLamp;

        private Shader _lampShader;
        private Shader _lightingShader;

        // Вращение
        private float _сurrentRotation = 0;
        private float _topSpeedRotation = 30f;
        private float _bottomSpeedRotation = 20f;


        // Переменные, нужные для перемещения камеры
        private Camera _camera;
        private bool _firstMove = true;
        private Vector2 _lastPos;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest); 

            // Создание VBO для хранения массива с вершинами и нормалями
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            // Создание шейдерных программ
            _lightingShader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/lighting.frag");
            _lampShader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            {
                // Генерация VAO для средней части кубика
                _vaoMiddlePart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoMiddlePart);

                // Передача шейдеру кординат вершин
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Передача шейдеру нормалей вершин
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

                // Передача шейдеру цветов вершин
                int color = _lightingShader.GetAttribLocation("aColor");
                GL.EnableVertexAttribArray(color);
                GL.VertexAttribPointer(color, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 6 * sizeof(float));
            }

            {
                // Генерация VAO для верхней части кубика
                _vaoBottomPart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoBottomPart);

                // Передача шейдеру кординат вершин
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Передача шейдеру нормалей вершин
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

                // Передача шейдеру цветов вершин
                int color = _lightingShader.GetAttribLocation("aColor");
                GL.EnableVertexAttribArray(color);
                GL.VertexAttribPointer(color, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 6 * sizeof(float));
            }

            {
                // Генерация VAO для нижней части кубика
                _vaoTopPart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoTopPart);

                // Передача шейдеру кординат вершин
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Передача шейдеру нормалей вершин
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

                // Передача шейдеру цветов вершин
                int color = _lightingShader.GetAttribLocation("aColor");
                GL.EnableVertexAttribArray(color);
                GL.VertexAttribPointer(color, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 6 * sizeof(float));
            }


            {
                // Генерация VAO для лампы (нормали и цвета не учитываются)
                _vaoLamp = GL.GenVertexArray();
                GL.BindVertexArray(_vaoLamp);
                var positionLocation = _lampShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);
            }

            // Создание камеры
            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);
            CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Отрисовка средней части куба
            GL.BindVertexArray(_vaoMiddlePart);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("transform", Matrix4.Identity);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, triangleCount);


            
            // Отрисовка верхней части куба
            GL.BindVertexArray(_vaoTopPart);
            _lightingShader.Use();

            // Перемещение объекта и постоянный поворот
            Matrix4 topTransform = Matrix4.Identity;
            topTransform *= Matrix4.CreateTranslation(0.0f, 0.35f, 0.0f);
            _сurrentRotation += (float)args.Time;
            topTransform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_сurrentRotation*_topSpeedRotation));

            _lightingShader.SetMatrix4("transform", topTransform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, triangleCount);


            // Отрисовка нижней части куба
            GL.BindVertexArray(_vaoTopPart);
            _lightingShader.Use();

            // Перемещение объекта и постоянный поворот
            Matrix4 bottomTransform = Matrix4.Identity;
            bottomTransform *= Matrix4.CreateTranslation(0.0f, -0.35f, 0.0f);
            bottomTransform *= Matrix4.CreateRotationY(-MathHelper.DegreesToRadians(_сurrentRotation * _bottomSpeedRotation));

            _lightingShader.SetMatrix4("transform", bottomTransform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, triangleCount);



            // Отрисовка источника света
            GL.BindVertexArray(_vaoMiddlePart);
            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("transform", lampMatrix);
            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, triangleCount);



            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (!IsFocused)
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
            if (input.IsKeyDown(Keys.Up))
            {
                _lightPos += Vector3.UnitY * cameraSpeed * (float)args.Time; // Light Up
            }
            if (input.IsKeyDown(Keys.Down))
            {
                _lightPos -= Vector3.UnitY * cameraSpeed * (float)args.Time; // Light Down
            }
            if (input.IsKeyDown(Keys.Right))
            {
                _lightPos += Vector3.UnitX * cameraSpeed * (float)args.Time; // Light Up
            }
            if (input.IsKeyDown(Keys.Left))
            {
                _lightPos -= Vector3.UnitX * cameraSpeed * (float)args.Time; // Light Down
            }

            var mouse = MouseState;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs args)
        {
            base.OnMouseWheel(args);

            _camera.Fov -= args.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs args)
        {
            base.OnResize(args);

            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
    }
}

