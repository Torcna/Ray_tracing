﻿#version 330 core
layout (location = 0) in vec3 aPosition;

out vec3 glPosition;
void main ()
{
	gl_Position = vec4(aPosition, 1.0);
	glPosition = aPosition;
}