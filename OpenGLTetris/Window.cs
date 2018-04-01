using OpenGLTetris.Blocks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace OpenGLTetris
{
    public class Window : GameWindow
    {
        private double cameraXAngle = -40;
        private double cameraYAngle = -10;

        private double sizeUnit = 0.05;

        private BaseBlock currentBlock;

        private double possitionXLeftBound = -1;
        private double possitionXRightBound = 1;
        private double startPossitionX = 0;
        private double possitionX = 0;
        private double PossitionX
        {
            get => possitionX;
            set
            {
                if (value > possitionXRightBound)
                {
                    possitionX = possitionXRightBound;
                }
                else if (value < possitionXLeftBound)
                {
                    possitionX = possitionXLeftBound;
                }
                else
                {
                    possitionX = value;
                }
            }
        }

        private double startPossitionY = 1.5;
        private double endPossitionY = -1.5;
        private double possitionY = 1.5;

        public Window() : base(600, 600, new GraphicsMode(32, 24, 0, 4), "Tetris") { }

        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.Lighting);
            GL.Light(LightName.Light0, LightParameter.Ambient, new[] { 0.2f, 0.2f, 0.2f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new[] { 0.8f, 0.8f, 0.8f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Position, new[] { 1.0f, 0.0f, -1.0f });
            GL.Enable(EnableCap.Light0);

            GL.Enable(EnableCap.ColorMaterial);

            GL.Enable(EnableCap.DepthTest);

            currentBlock = RandomBlockFactory.GetBlock(sizeUnit);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > Height)
            {
                GL.Viewport((Width - Height) / 2, 0, Height, Height);
            }
            else
            {
                GL.Viewport(0, (Height - Width) / 2, Width, Width);
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (possitionY <= endPossitionY)
            {
                ResetGame();
            }

            possitionY -= 2 * sizeUnit;
        }

        private void ResetGame()
        {
            possitionY = startPossitionY;
            PossitionX = startPossitionX;
            currentBlock = RandomBlockFactory.GetBlock(sizeUnit);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            GL.Rotate(cameraXAngle, 1, 0, 0);
            GL.Rotate(cameraYAngle, 0, 1, 0);

            GL.Translate(0, possitionY, 0);
            GL.Translate(possitionX, 0, 0);

            currentBlock.Draw();

            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {           
                currentBlock.Rotate();
            }

            if (e.Key == Key.Left)
            {
                PossitionX -= 2 * sizeUnit;
            }
            if (e.Key == Key.Right)
            {
                PossitionX += 2 * sizeUnit;
            }

            if (e.Key == Key.R)
            {
                ResetGame();
            }

            if (e.Key == Key.Escape)
            {
                Exit();
            }
        }
    }
}

