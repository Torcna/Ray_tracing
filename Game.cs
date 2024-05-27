using StbImageSharp;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Management;

namespace ray_trasing
{
    // Game class that inherets from the Game Window Class
    internal class Game : GameWindow
    {
        // camera
        //Camera camera;

        //// transformation variables
        //float yRot = 0f;

        int vao;
        int vbo;
        int ebo;

        int _program;

        float[] _verteces = new float[] {
            -1f, -1f, 0f,
            1f, -1f, 0f,
            1f, 1f, 0f,
            -1f, 1f, 0f };

        uint[] _indices = new uint[]
        {
            0,1,2,
            0,2,3
        };

        int width, height;


        ////Model model_ikran;
        ////World_model model_world;
        ////Player_model player_Model;
        ////Enemy_model model_enemy;
        ////Fireball_model model_fireball;
        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.width = width;
            this.height = height;

            // center window
            CenterWindow(new Vector2i(width, height));
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.width = e.Width;
            this.height = e.Height;
        }

        // called once when game is started
        protected override void OnLoad()
        {
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float)*_verteces.Length, _verteces, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            ShaderHelpers.InitShaders("../../../shaders/default.vert", "../../../shaders/default.frag", out _program);

            base.OnLoad();

        }
        protected override void OnUnload()
        {
            base.OnUnload();
            

        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            if (0>1)
            {
                //// Set the color to fill the screen with
                //GL.ClearColor(0.3f, 0.3f, 1f, 1f);
                //// Fill the screen with the color
                //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                //// draw our triangle
                //GL.UseProgram(shaderProgram); // bind vao
                //GL.BindVertexArray(vao); // use shader program
                //GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);

                //GL.BindTexture(TextureTarget.Texture2D, textureID);


                //// transformation matrices
                //Matrix4 model = Matrix4.Identity;
                //Matrix4 view = camera.GetViewMatrix();
                //Matrix4 projection = camera.GetProjectionMatrix();


                //model = Matrix4.CreateRotationY(yRot);
                //yRot += 0.001f;

                //Matrix4 translation = Matrix4.CreateTranslation(0f, 0f, -3f);

                //model *= translation;

                //int modelLocation = GL.GetUniformLocation(shaderProgram, "model");
                //int viewLocation = GL.GetUniformLocation(shaderProgram, "view");
                //int projectionLocation = GL.GetUniformLocation(shaderProgram, "projection");

                //GL.UniformMatrix4(modelLocation, true, ref model);
                //GL.UniformMatrix4(viewLocation, true, ref view);
                //GL.UniformMatrix4(projectionLocation, true, ref projection);

                //GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
                ////GL.DrawArrays(PrimitiveType.Triangles, 0, 3); // draw the triangle | args = Primitive type, first vertex, last vertex


                // swap the buffers
            }
            GL.ClearColor(Color4.AliceBlue);


            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, ebo);

            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

            Context.SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            MouseState mouse = MouseState;
            KeyboardState input = KeyboardState;

            base.OnUpdateFrame(args);
            //camera.InputController(input, mouse, args, model_fireball);
        }


    }
}