using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Graphics_OpenTK
{
    internal class Shader
    {
        public readonly int Handle;
        private Dictionary<string, int> _uniformLocations; // В словаре храним все значения из шейдерной программы

        public Shader(string vertPath, string fragPath)
        {
            // Создание вершинного шейдера
            string shaderSource = File.ReadAllText(vertPath);
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, shaderSource);
            CompileAndCheckShader(vertexShader);

            // Создание фрагментного шейдера
            shaderSource = File.ReadAllText(fragPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderSource);
            CompileAndCheckShader(fragmentShader);

            // Создание шейдерной программы
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);
            GL.LinkProgram(Handle);

            // Проверка на корректную линковку шейдерной программы
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
                throw new Exception($"Error occurred whilst linking Program({Handle})");

            // Оба шейдера занесены в шейдерную программу - они больше не нужны, удаляем их
            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

            // Заполняем словарь значениями из шейдерной программы
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
            _uniformLocations = new Dictionary<string, int>();
            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(Handle, i, out _, out _);
                var location = GL.GetUniformLocation(Handle, key);
                _uniformLocations.Add(key, location);
            }

        }


        // Изменение значения переменных uniform mat4
        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Handle);
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }

        // Изменение значения переменных uniform vec3
        public void SetVector3(string name, Vector3 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform3(_uniformLocations[name], data);
        }


        public void Use() => GL.UseProgram(Handle);
        public void Deactive() => GL.UseProgram(0);
        public void Delete() => GL.DeleteProgram(Handle);


        // Получить индекс шейдерной переменной по названию
        public int GetAttribLocation(string attribName) => GL.GetAttribLocation(Handle, attribName);


        


        private void CompileAndCheckShader(int shader)
        {
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
            }
        }


    }
}
