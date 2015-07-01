using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI
{
    public class InputManager
    {
        private KeyboardState currentKeyState;
        private KeyboardState prevKeyState;

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }

        public void Update()
        {
            this.prevKeyState = this.currentKeyState;
            if (!ScreenManager.Instance.IsTransitioning)
            {
                this.currentKeyState = Keyboard.GetState();
            }
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (this.currentKeyState.IsKeyDown(key) && this.prevKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }
        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (this.currentKeyState.IsKeyUp(key) && this.prevKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (this.currentKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
