using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public class ConsoleRenderer : IRenderTarget
    {
        public void Draw(char Char, RenderStates States)
        {
            ApplyRenderStates(States);

            Console.Write(Char);
        }

        public void Draw(string Line, RenderStates States)
        {
            ApplyRenderStates(States);

            Console.Write(Line);
        }

        public void Draw(Texture Texture, RenderStates States)
        {
            ApplyRenderStates(States);

            var Position = new Vector2i(States.Position);
            var Offset = new Vector2i(0, 0);
            foreach(var Char in Texture.Data)
            {
                ApplyPosition(new Vector2i(Position.X + Offset.X, Position.Y + Offset.Y));

                Console.Write(Char);

                if (Offset.X == Texture.Size.X - 1)
                {
                    Offset.X = 0;
                    Offset.Y += 1;
                }
                else
                    Offset.X += 1;
            }
        }
        private void ApplyRenderStates(RenderStates States)
        {
            ApplyPosition(States.Position);

            Console.ForegroundColor = States.ForegroundColor;
            Console.BackgroundColor = States.BackgroundColor;
        }
        private void ApplyPosition(Vector2i Position)
        {
            if (Position == null)
                throw new ArgumentNullException("States.Position is null");

            Console.SetCursorPosition(Position.X, Position.Y);
        }
    }
}
