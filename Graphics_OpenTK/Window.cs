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
                                    
            -0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f, // Передняя грань
             0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
            -0.5f,  0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
            -0.5f, -0.17f,  0.5f,     0.0f,  0.0f,  1.0f,    1.0f,  0.4f,  0.0f,
                                    
            -0.5f,  0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f, // Левая грань
            -0.5f,  0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f, -0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f, -0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
            -0.5f,  0.17f,  0.5f,    -1.0f,  0.0f,  0.0f,    1.0f,  0.9f,  0.1f,
                                    
             0.5f,  0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f, // Правая грань
             0.5f,  0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f, -0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
             0.5f,  0.17f,  0.5f,     1.0f,  0.0f,  0.0f,    0.0f,  0.0f,  1.0f,
                                    
            -0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f, // Bottom face
             0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
             0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
            -0.5f, -0.17f,  0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,
            -0.5f, -0.17f, -0.5f,     0.0f, -1.0f,  0.0f,    1.0f,  1.0f,  1.0f,

            -0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f, // Top face
             0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
             0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
            -0.5f,  0.17f,  0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
            -0.5f,  0.17f, -0.5f,     0.0f,  1.0f,  0.0f,    1.0f,  0.0f,  0.0f,
        };

        private Vector3 _lightPos = new Vector3(1.0f, 1.3f, 1.5f);

        private int _vertexBufferObject;
        private int _vaoBottomPart;
        private int _vaoMiddlePart;
        private int _vaoTopPart;
        private int _vaoLamp;
        private Shader _lampShader;
        private Shader _lightingShader;

        private float _rotation = 0;
        private float _topSpeed = 30f;
        private float _bottomSpeed = 20f;


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

            _lightingShader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/lighting.frag");
            _lampShader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            {
                // Генерация VAO для средней части кубика
                _vaoMiddlePart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoMiddlePart);

                // Запоминание координат вершин объекта
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Запоминание нормалей объекта
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

                int color = _lightingShader.GetAttribLocation("aColor");
                GL.EnableVertexAttribArray(color);
                GL.VertexAttribPointer(color, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 6 * sizeof(float));
            }

            {
                // Генерация VAO для верхней части кубика
                _vaoBottomPart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoBottomPart);

                // Запоминание координат вершин объекта
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Запоминание нормалей объекта
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

                int color = _lightingShader.GetAttribLocation("aColor");
                GL.EnableVertexAttribArray(color);
                GL.VertexAttribPointer(color, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 6 * sizeof(float));
            }

            {
                // Генерация VAO для нижней части кубика
                _vaoTopPart = GL.GenVertexArray();
                GL.BindVertexArray(_vaoTopPart);

                // Запоминание координат вершин объекта
                int vertexPos = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(vertexPos);
                GL.VertexAttribPointer(vertexPos, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 0);

                // Запоминание нормалей объекта
                int normal = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normal);
                GL.VertexAttribPointer(normal, 3, VertexAttribPointerType.Float, false, 9 * sizeof(float), 3 * sizeof(float));

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

            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);

            CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Отрисовка средней части куба
            GL.BindVertexArray(_vaoMiddlePart);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);


            
            // Отрисовка верхней части куба
            GL.BindVertexArray(_vaoTopPart);
            _lightingShader.Use();

            Matrix4 topTransform = Matrix4.Identity;
            topTransform *= Matrix4.CreateTranslation(0.0f, 0.34f, 0.0f);
            _rotation += (float)e.Time;
            topTransform *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_rotation*_topSpeed));
            _lightingShader.SetMatrix4("model", topTransform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);


            // Отрисовка нижней части куба
            GL.BindVertexArray(_vaoTopPart);
            _lightingShader.Use();

            Matrix4 bottomTransform = Matrix4.Identity;
            bottomTransform *= Matrix4.CreateTranslation(0.0f, -0.33f, 0.0f);
            bottomTransform *= Matrix4.CreateRotationY(-MathHelper.DegreesToRadians(_rotation * _bottomSpeed));
            _lightingShader.SetMatrix4("model", bottomTransform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);






            GL.BindVertexArray(_vaoMiddlePart);

            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("model", lampMatrix);
            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

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
                _camera.Position += _camera.Front * cameraSpeed * (float)e.Time; // Forward
            }
            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)e.Time; // Down
            }
            if (input.IsKeyDown(Keys.Up))
            {
                _lightPos += Vector3.UnitY * cameraSpeed * (float)e.Time; // Light Up
            }
            if (input.IsKeyDown(Keys.Down))
            {
                _lightPos -= Vector3.UnitY * cameraSpeed * (float)e.Time; // Light Down
            }
            if (input.IsKeyDown(Keys.Right))
            {
                _lightPos += Vector3.UnitX * cameraSpeed * (float)e.Time; // Light Up
            }
            if (input.IsKeyDown(Keys.Left))
            {
                _lightPos -= Vector3.UnitX * cameraSpeed * (float)e.Time; // Light Down
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

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            _camera.Fov -= e.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
    }
}

