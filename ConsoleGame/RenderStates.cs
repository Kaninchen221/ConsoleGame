using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class RenderStates
    {
        public Vector2i Position { get; set; } = new Vector2i();
        public Texture Texture { get; set; } = new Texture();
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
    }
}
