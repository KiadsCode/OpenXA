using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OpenXA
{
    public class CheckMark {
        public Texture2D emptyMark;
        public Texture2D filledMark;
        public Vector2 mouseOnScale = new Vector2(1.1f, 1.1f);
        public Vector2 mouseNotScale = new Vector2(1f, 1f);
        public bool Value { get; set; }

        public CheckMark(Texture2D emptyMark, Texture2D filledMark, Vector2 position) {
            this.emptyMark = emptyMark;
            this.filledMark = filledMark;
            gameObject = new GameObject(position, emptyMark);
            mouseOnScale = new Vector2(1.1f, 1.1f);
            mouseNotScale = new Vector2(1f, 1f);
            Value = false;
        }

        public bool OnValueChanged() {
            if (Cursor.Intersection(gameObject)) {
                gameObject.scale = mouseOnScale;
            } else {
                gameObject.scale = mouseNotScale;
            }
            if (Cursor.IsButtonPressed(gameObject)) {
                Value = !Value;
                switch (Value) {
                    case true:
                        gameObject.ChangeTexture(filledMark);
                        break;
                    case false:
                        gameObject.ChangeTexture(emptyMark);
                        break;
                }
            }
            return Value;
        }

        public void draw(SpriteBatch spriteBatch) {
            gameObject.draw(spriteBatch);
        }

        public GameObject gameObject { get; set; }
    }
}