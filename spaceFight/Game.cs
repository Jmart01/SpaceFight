using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceFight
{
    class Game
    {
        

        public Game(uint windowWidth, uint windowHeight, string title = "Space Fight")
        {
            _window = new RenderWindow(new VideoMode(windowWidth, windowHeight), title);
            _window.Closed += ExitGame;
            _window.SetFramerateLimit(60);
            _gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject newObject)
        {
            if(!_gameObjects.Contains(newObject))
            {
                _gameObjects.Add(newObject);
            }
            
        }
        public void Run()
        {
            Start();
            Update();
        }

        private void Start()
        {

        }

        private void Update()
        {
            
            while(_window.IsOpen)
            {
                Time.Update();
                UpdateGameLogic();
                Render();
                _window.DispatchEvents();
            }
        }

        private void UpdateGameLogic()
        {
            for(int i = 0; i < _gameObjects.Count; i++)
            {
                if(_gameObjects[i] != null)
                {
                    _gameObjects[i].Update();
                }
            }
        }

        private void Render()
        {
            Window.Clear();
            //draw out all object here
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] != null)
                {
                    Window.Draw(_gameObjects[i].Shape);
                }
            }

            Window.Display();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Window.Close();
        }


        RenderWindow _window;

        public RenderWindow Window
        {
            private set { _window = value; }
            get { return _window; }
        }

        private List<GameObject> _gameObjects;
    }
}
