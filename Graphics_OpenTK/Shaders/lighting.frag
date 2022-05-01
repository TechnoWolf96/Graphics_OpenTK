#version 330 core

out vec4 FragColor;

uniform vec3 objectColor; 
uniform vec3 lightColor; 
uniform vec3 lightPos; 
uniform vec3 viewPos; // camera parameter

in vec3 Normal; // The normal of the fragment is calculated in the vertex shader.
in vec3 FragPos; 
in vec3 ourColor;

void main()
{
    float ambientStrength = 0.15;
    int shininess = 2;
    vec3 ambient = ambientStrength * lightColor;

    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);


    //The diffuse part of the phong model.
    float diff = max(dot(norm, lightDir), 0.0); //We make sure the value is non negative with the max function.
    vec3 diffuse = diff * lightColor;


    float specularStrength = 0.9;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), shininess);
    vec3 specular = specularStrength * spec * lightColor;


    vec3 result = (ambient + diffuse + specular) * ourColor;
    FragColor = vec4(result, 1.0);
}