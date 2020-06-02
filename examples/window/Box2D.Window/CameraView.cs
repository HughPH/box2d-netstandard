﻿/*
    Window Simulation Copyright © Ben Ukhanov 2020
*/

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Box2D.Window
{
    public class CameraView : IView
    {
        public Vector2 Position { get; set; }

        public float Zoom { get; set; }

        public CameraView()
        {
            Position = Vector2.Zero;
            Zoom = WindowSettings.MinimumCameraZoom;
        }

        public void Update()
        {
            GL.LoadIdentity();

            var transform = Matrix4.Identity;
            var translation = Matrix4.CreateTranslation(-Position.X, -Position.Y, 0);
            var scale = Matrix4.CreateScale(Zoom, Zoom, 1.0f);

            transform = Matrix4.Mult(transform, translation);
            transform = Matrix4.Mult(transform, scale);

            GL.MultMatrix(ref transform);
        }
    }
}