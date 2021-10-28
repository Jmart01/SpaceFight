using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Timers;

namespace spaceFight
{
    class Game
    {
        private Timer aTimer;
        private static float EnemiesNeededToSpawnBoss = 5;

        public Game(uint windowWidth, uint windowHeight, string title = "Space Fight")
        {
            _window = new RenderWindow(new VideoMode(windowWidth, windowHeight), title);
            _window.Closed += ExitGame;
            _window.SetFramerateLimit(60);
            _gameObjects = new List<GameObject>();
            Input.SetInput(_window);

            aTimer = new System.Timers.Timer(2 * 1000);
            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
       {
           SpawnEnemy();
           /*if(Input.IsKeyDown(Keyboard.Key.Space))
           {
               Console.WriteLine("I am getting turnt");
               _Game.AddGameObject(new Projectile(new RectangleShape(new Vector2f(50, 50)), AssetManager.GetTexture("Projectile.png"), (int)Shape.Position.X + 10, (int)Shape.Position.Y, 400));
           }*/
       }

        public void AddGameObject(GameObject newObject)
        {
            if(!_gameObjects.Contains(newObject))
            {
                _gameObjects.Add(newObject);
            }
            else
            {
                Console.WriteLine("cant add");
            }
            
        }
        public void Run()
        {
            Start();
            Update();
        }

        private void Start()
        {
            //SpawnEnemy();
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

        public void RemoveFromGame(GameObject objectToRemove)
        {
            if(_gameObjects.Contains(objectToRemove))
            {
                _gameObjects.Remove(objectToRemove);
            }
        }

        void SpawnEnemy()
        {
            System.Random rand = new Random();
            float SpawnPosX = rand.Next(0, (int)Window.Size.X);
            float SpawnPosY = 0;

            new Enemy(new RectangleShape(new Vector2f(100, 100)), AssetManager.GetTexture("EnemyShip.png"), SpawnPosX, SpawnPosY, 200);
        }

        public GameObject[] GetAllObjects()
        {
            return _gameObjects.ToArray();
        }

        public void DecreseEnemyCountToSpawnBoss()
        {
            EnemiesNeededToSpawnBoss--;
            Console.WriteLine(EnemiesNeededToSpawnBoss);
            if(EnemiesNeededToSpawnBoss <= 0)
            {
                SpawnBoss();
            }
        }
        void SpawnBoss()
        {
            new Boss(new RectangleShape(new Vector2f(100, 100)), AssetManager.GetTexture("Bolbi.png"), 100, 100, 400);
            EnemiesNeededToSpawnBoss = 5;
        }
    }
}
