﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public class RenderStates
    {
        public Vector2i Position { get; set; } = new Vector2i(0, 0);
        public Texture Texture { get; set; } = new Texture();
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
    }
}
