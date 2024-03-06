using System;
using SFML.Window;

namespace Snake;

/// <summary>
/// Класс, отвечающий за процесс игры.
/// </summary>
public class GameController
{
    private FoodController _foodController;
    private GameOverController _gameOverController;
    private InputController _inputController;
    private Snake _snake;

    /// <summary>
    /// Конструктор объекта GameController, который сохраняет ссылки на объекты классов:
    /// FoodController, GameOverController, InputController, Snake.
    /// </summary>
    public GameController(FoodController foodController, GameOverController gameOverController,
        InputController inputController, Snake snake)
    {
        // Конструктор сохраняет игровые контроллеры в поля класса.
        _foodController = foodController;
        _gameOverController = gameOverController;
        _inputController = inputController;
        _snake = snake;
    }

    /// <summary>
    /// Метод содержит в себе всю игровую механику:
    /// 1)Проверяет, проиграл ли игрок
    /// 2)Проверяет, подобрала змейку еду, если подобрала генерирует новую.
    /// 3)Меняет направление змейки при нажатой кнопке, иначе двигает змейку в том же направлении.
    /// Возвращает True если игрок проиграл, иначе False
    /// </summary>
    public bool Update()
    {
        // Если игра окончена.
        if (_gameOverController.CheckGameOver())
        {
            // Возвращаем true.
            return true;
        }

        // Если змейка подобрала еду.
        if (_foodController.IsFoodPickedUp())
        {
            // Увеличиваем размер змейки.
            _snake.IncreaseSize();
            // Генерируем новую еду.
            _foodController.GenerateNewFood();
        }


        // Меняем направление змейке.
        _inputController.ProcessInput();


        // Иначе, двигаем змейку в прежнем направлении.
        _inputController.MoveSnake();


        // Возвращаем false.
        return false;
    }
}