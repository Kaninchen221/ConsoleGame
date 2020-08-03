using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public interface IDrawable
    {
        public void Draw(IRenderTarget Target, RenderStates States);
    }
}
