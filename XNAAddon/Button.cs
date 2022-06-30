using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OpenXA
{
    public class Button {
        public bool Active = true;
        public Texture2D mainTexture;
        public GameObject gameObject { get; set; }
        public Vector2 mouseNotScale = new Vector2(1f, 1f);
        public Vector2 mouseOnScale = new Vector2(1.1f, 1.1f);

        public Button(Texture2D texture, Vector2 position) {
            mainTexture = texture;
            gameObject = new GameObject(position, texture);
            mouseOnScale = new Vector2(1.1f, 1.1f);
            mouseNotScale = new Vector2(1f, 1f);
        }

        public bool OnButtonPressed() {
            bool result = false;
            if (Cursor.Intersection(gameObject)) {
                gameObject.scale = mouseOnScale;
            } else {
                gameObject.scale = mouseNotScale;
            }
            if (Cursor.IsButtonPressed(gameObject)) {
                result = true;
            } else {
                result = false;
            }
            return result;
        }

        public void create(SpriteBatch spriteBatch) {
            gameObject.draw(spriteBatch);
        }
    }
}