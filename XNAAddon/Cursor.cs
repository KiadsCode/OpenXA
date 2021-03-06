using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNAAddon {
    public static class Cursor {
        private static bool _mbtl = false;
        public static Vector2 GetPosition() {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public static bool Intersection(BoxCollider other) {
            bool flag;
            if (GetPosition().X < other.sides[1]
                && GetPosition().X > other.sides[0]
                && GetPosition().Y < other.sides[3]
                && GetPosition().Y > other.sides[2]) {
                flag = true;
            } else {
                flag = false;
            }
            return flag;
        }

        public static bool IsButtonDown(GameObject other) {
            return Cursor.Intersection(other.collider) && Mouse.GetState().LeftButton == ButtonState.Pressed;
        }
        public static bool IsButtonUp(GameObject other) {
            return Cursor.Intersection(other.collider) && Mouse.GetState().LeftButton == ButtonState.Released;
        }
        public static bool IsButtonPressed(GameObject other) {
            bool flag = false;
            if (Cursor.Intersection(other.collider) && !_mbtl && Mouse.GetState().LeftButton == ButtonState.Released) {
                _mbtl = true;
                flag = false;
            }
            if (Cursor.Intersection(other.collider) && _mbtl && Mouse.GetState().LeftButton == ButtonState.Pressed) {
                _mbtl = false;
                flag = true;
            }
            return flag;
        }
        public static bool IsButtonPressed() {
            bool flag = false;
            if (!_mbtl && Mouse.GetState().LeftButton == ButtonState.Released) {
                _mbtl = true;
                flag = false;
            }
            if (_mbtl && Mouse.GetState().LeftButton == ButtonState.Pressed) {
                _mbtl = false;
                flag = true;
            }
            return flag;
        }
    }
}