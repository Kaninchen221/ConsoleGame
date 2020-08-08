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
            ApplyForegroundColor(States.ForegroundColor);
            ApplyBackgroundColor(States.BackgroundColor);

            var Offset = States.Position;
            Texture.Foreach((char Char, Vector2i CharPosition) =>
            {
                var Position = Offset + CharPosition;
                ApplyPosition(Position);

                Console.Write(Char);

            });
        }
        private void ApplyRenderStates(RenderStates States)
        {
            ApplyPosition(States.Position);

            Console.ForegroundColor = States.ForegroundColor;
            Console.BackgroundColor = States.BackgroundColor;
        }

        private void ApplyForegroundColor(ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
        }

        private void ApplyBackgroundColor(ConsoleColor Color)
        {
            Console.BackgroundColor = Color;
        }

        private void ApplyPosition(Vector2i Position)
        {
            if (Position == null)
                throw new ArgumentNullException("States.Position is null");

            Console.SetCursorPosition(Position.X, Position.Y);
        }
    }
}
