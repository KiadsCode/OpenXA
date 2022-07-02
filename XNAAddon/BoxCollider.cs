using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OpenXA
{
    
    ///<summary>
    ///Useless
    ///</summary>
public class BoxCollider {
    public float Left;
    public float Right;
    public float Top;
    public float Bottom;

    public BoxCollider(Texture2D texture, Vector2 position) {
        this.ColliderSet(texture, position);
    }

    public void ColliderSet(Texture2D texture, Vector2 position) {
        Left = position.X - (texture.Width / 2);
        Right = position.X + (texture.Width / 2);
        Top = position.Y - (texture.Height / 2);
        Bottom = position.Y + (texture.Height / 2);
    }

    public bool Intersection(BoxCollider other) {
        if (Left < other.Right
            && Right > other.Left
            && Top < other.Bottom
            && Bottom > other.Top) {
            return true;
        }
        return false;
    }
}
}
