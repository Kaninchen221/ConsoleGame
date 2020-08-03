using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public interface IRenderTarget
    {
        public void Draw(char Char, RenderStates States);
        public void Draw(string Line, RenderStates States);
        public void Draw(Texture Texture, RenderStates States);
    }
}
