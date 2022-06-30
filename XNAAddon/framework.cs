using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace OpenXA.Framework
{
    public static class Framework
    {
        public static T LoadFile<T>(ContentManager contentManager, string file)
        {
            return contentManager.Load<T>(@"" + file);
        }
    }
}