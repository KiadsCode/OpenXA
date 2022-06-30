using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAAddon
{
    public class GameObject {
        public void ChangeTexture(Texture2D texture) {
            model = texture;
            GetOrigin();
        }
        public bool existing { get; set; }
        public BoxCollider collider { get; set; }
        public Vector2 position { get; set; }
        public Color color = Color.White;
        public float layerDepth { get; private set; }

        public Vector2 Origin = Vector2.Zero;
        public Vector2 scale = new Vector2(1f, 1f);
        public Texture2D model;
        public SpriteEffects effects = SpriteEffects.None;
        public float Rotatation = 0f;

        public void Destroy() {
            existing = false;
            position = Vector2.Zero;
            model.Dispose();
            Rotatation = 0f;
            effects = SpriteEffects.None;
            color = Color.White;
            layerDepth = 0f;
            collider = null;
            scale = Vector2.Zero;
            Origin = Vector2.Zero;
        }

        public void create(Vector2 position, Texture2D Model) {
            Construct(position, Model);
        }

        public void GetOrigin() {
            Origin = new Vector2(model.Width / 2, model.Height / 2);
        }

        public GameObject(Vector2 position, Texture2D model) {
            Construct(position, model);
        }

        public void draw(SpriteBatch spriteBatch) {
            if (existing) {
                spriteBatch.Draw(model, position, null, color, Rotatation, Origin, scale, effects, layerDepth);
            }
        }
        void Construct(Vector2 position, Texture2D model) {
            this.position = position;
            this.model = model;
            collider = new BoxCollider(this.model, this.position);
            Rotatation = 0;
            layerDepth = 0;
            color = Color.White;
            existing = true;

            GetOrigin();
        }
    }
}