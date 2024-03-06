using System;
using System.Numerics;
using SFML.Graphics;

namespace Snake;

/// <summary>
/// Класс, отвечающий за генерацию еды.
/// </summary>
public class FoodController
{
    public Vector2 Food; // Координаты еды.
    private GameBoard _gameBoard; // Игровое поле.
    private Snake _snake; // Змейка.

    public FoodController(GameBoard gameBoard, Snake snake)
    {
        // Конструктор сохраняет игровое поле и змейку в поля класса.
        _gameBoard = gameBoard;
        _snake = snake;
    }

    public bool IsFoodPickedUp()
    {
        // Если голова змейки находится на позиции еды.
        if (_snake.GetPoint(0).Equals(Food))
        {
            // Возвращаем true.
            return true;
        }

        // Иначе, возвращаем false.
        return false;
    }

    private bool IsFoodInsideSnake(Snake snake)
    {
        var size = snake.GetSize();

        // Проверяем, совпадает ли позиция еды с позицией хотя бы одной из точек змейки.
        for (var i = 0; i < size; i++)
        {
            // Если совпадает.
            if (snake.GetPoint(i).Equals(Food))
            {
                // Возвращаем true.
                return true;
            }
        }

        // Иначе, возвращаем false.
        return false;
    }

    public void GenerateNewFood()
    {
        // Создаем генератор случайных чисел.
        var randomGenerator = new Random();

        // Пока еда находится в змейке, генерируем еду в случайном месте:
        do
        {
            // Создаем еду на случайной позиции в пределах игрового поля.
            Food.X = randomGenerator.Next(1, (int)(_gameBoard.Size.X - 1));
            Food.Y = randomGenerator.Next(1, (int)(_gameBoard.Size.Y - 1));
        } while (IsFoodInsideSnake(_snake));
    }
}