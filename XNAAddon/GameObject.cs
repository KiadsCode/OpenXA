using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace OpenXA
{
public class GameObject {
    public void ChangeTexture(Texture2D texture) {
        model = texture;
        GetOrigin();
    }
    public bool existing { get; set; }
    public Rectangle rectangle { get; set; }
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
        Rotatation = 0;
        layerDepth = 0;
        color = Color.White;
        existing = true;
        rectangle = new Rectangle(0, 0, this.model.Width, this.model.Height);

        GetOrigin();
    }

    /// <summary>
    /// Experemental version
    /// </summary>
    /// <returns>intersection result</returns>
    public void Intersection(GameObject obstacle, out bool result) {
        result = position.X < obstacle.position.X + obstacle.rectangle.Width && position.X + rectangle.Width > obstacle.position.X && position.Y < obstacle.position.Y + obstacle.rectangle.Height && position.Y + rectangle.Height > obstacle.position.Y;
    }
    public bool Intersection(GameObject obstacle) {
        return position.X < obstacle.position.X + obstacle.rectangle.Width && position.X + rectangle.Width > obstacle.position.X && position.Y < obstacle.position.Y + obstacle.rectangle.Height && position.Y + rectangle.Height > obstacle.position.Y;
    }

}
}