using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Создаем контроллеры и все игровые объекты.
            CreateGameViewAndControllers(out var gameController, out var gameView);
            // Создание окна игры.
            var window = new RenderWindow(new VideoMode(600, 600), "Snake Game");
            // Закрываем окно, если нажали кнопку закрыть
            window.Closed += (_, _) => window.Close();
            
            // Пока окно открыто.
            while (window.IsOpen)
            {
                // Обработка событий окна
                window.DispatchEvents();
                
                
                // Проверяем значение, возвращенное из метода Update.
                if (gameController.Update())
                {
                    // Показываем экран окончания игры.
                    ShowGameOverScreen(window);
                    continue;
                }

                // Отрисоваем карту.
                gameView.DrawMap(window);
                // Отрисоваем все игровые объекты.
                gameView.DrawGameObjects(window);
                // Отображаем объекты в окне.
                window.Display();
            }
        }

        /// <summary>
        /// Метод создает контроллеры и все игровые объекты.
        /// </summary>
        private static void CreateGameViewAndControllers(out GameController gameController, out GameView gameView)
        {
            var gameViewSettings = new GameViewSettings();
            var snake = new Snake(new Vector2(2, 3), new Vector2(1, 0));
            var gameBoard = new GameBoard(20, 20);
            var gameOverController = new GameOverController(gameBoard, snake);
            var inputController = new InputController(snake);
            var foodController = new FoodController(gameBoard, snake);

            foodController.GenerateNewFood(); // Создаем первую еду.

            gameView = new GameView(gameViewSettings, gameBoard, snake, foodController);
            gameController = new GameController(foodController, gameOverController, inputController, snake);
        }

        private static void ShowGameOverScreen(RenderWindow window)
        {
            window.Clear(Color.Black);

            var font = new Font("/Users/vitaly/Downloads/Snake_Final/Snake/Assets/Fonts/FreeMonospaced.ttf");
            var text = new Text("Game over", font, 50);
            text.FillColor = Color.White;
            text.Position = new Vector2f(180f, 180f);

            // Выводим сообщение о проигрыше.
            window.Draw(text); 
            // Отображаем объекты в окне.
            window.Display();
        }
    }
}