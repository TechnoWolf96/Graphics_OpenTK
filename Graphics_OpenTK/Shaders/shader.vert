#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec3 aColor;

uniform mat4 transform;
uniform mat4 view; // camera parameter
uniform mat4 projection; // camera parameter

out vec3 Normal; // Fragment normal
out vec3 FragPos;
out vec3 ourColor;


void main()
{
    gl_Position = vec4(aPos, 1.0) * transform * view * projection;
    FragPos = vec3(vec4(aPos, 1.0) * transform);
    Normal = aNormal * mat3(transpose(inverse(transform))); // Calculate fragment normal with vertex normal
    ourColor = aColor;
}
