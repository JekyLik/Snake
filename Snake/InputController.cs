using SFML.Window;

namespace Snake;

public class InputController
{
    private Snake _snake;

    /// <summary>
    /// Конструктор объекта InputController, который сохраняет ссылку на объект Snake.
    /// </summary>
    public InputController(Snake snake)
    {
        // Конструктор сохраняет змейку в поле класса.
        _snake = snake;
    }

    /// <summary>
    /// Метод-обработчик нажатия клавиш на клавиатуре.
    /// При нажатии на w или UpArrow меняет направление на MoveUp
    /// При нажатии на s или DownArrow меняет направление на MoveDown
    /// При нажатии на a или LeftArrow меняет направление на MoveLeft
    /// При нажатии на d или RightArrow меняет направление на MoveRight
    /// Важно!
    /// Змейка не может пойти в противоположную сторону
    /// Пример: Если змейка шла влево, то идти вправо ей запрещено.
    /// </summary>
    public void ProcessInput()
    {
        // Проверяем нажатую кнопку и в зависимости от нее - задаем змейке соответствующее направление.

        // Перемещаем змейку вверх
        if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
        {
            // Проверка, что текущее направление змейки не вниз.
            if ((int)_snake.Direction.Y != 1)
            {
                _snake.SetMoveDirectionToUp();
            }
        }
        
        // Todo Напишите код для перемещения змейки влево
        // Todo Напишите код для перемещения змейки вправо
        // Todo Напишите код для перемещения змейки вниз


        // Двигаем змейку.
        MoveSnake();
    }

    public void MoveSnake()
    {
        // Двигаем змейку.
        _snake.MoveForward();
    }
}