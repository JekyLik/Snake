namespace Snake;

public class GameOverController
{
    private GameBoard _gameBoard;
    private Snake _snake;

    /// <summary>
    /// Конструктор объекта GameOverController который сохраняет ссылки на объектs GameBoard b Snake.
    /// </summary>
    public GameOverController(GameBoard gameBoard, Snake snake)
    {
        // Конструктор сохраняет игровое поле и змейку в поля класса.
        _gameBoard = gameBoard;
        _snake = snake;
    }

    /// <summary>
    /// Метод проверяет, ударилась ли змейка о бортики игрового поля.
    /// возвращает True, если змейка ударилась о бортики игрового поля. В остальных случаях возвращает False.
    /// </summary>
    public bool IsSnakeOutside()
    {
        // Если координаты головы змейки совпадают с координатами бортиков игрового поля.
        if (_snake.GetPoint(0).X == 0 || _snake.GetPoint(0).Y == 0 ||
            (int) _snake.GetPoint(0).X == (int) _gameBoard.Size.X - 1 ||
            (int) _snake.GetPoint(0).Y == (int) _gameBoard.Size.Y - 1)
        {
            // Возвращаем true.
            return true;
        }
        // Иначе, возвращаем false.
        return false;
    }

    /// <summary>
    /// Метод проверяет, ударилась ли змейка сама в себя.
    /// Возвращает True, если змейка врезалась в себя. В остальных случаях возвращает False.
    /// </summary>
    public bool HasSelfCollision()
    {
        // Начинаем с 4-го индекса, так как если змейка меньше, она не может удариться сама в себя
        for (var i = 4; i < _snake.GetSize(); i++)
        {
            // Если координаты головы змеи совпадают с координатой ее тела. 
            if (_snake.GetPoint(0) == _snake.GetPoint(i))
            {
                // Возвращаем true.
                return true;
            }    
        }
        // Иначе, возвращаем false.
        return false;
    }

    /// <summary>
    /// Метод объединяет две проверки(IsSnakeOutside, HasSelfCollision) в одну.
    /// Возвращает True, если змейка врезалась в борт игрового поля или в себя. В остальных случаях возвращает False.
    /// </summary>
    public bool CheckGameOver()
    {
        // Если змейка снаружи игрового поля или врезалась в себя.
        if (IsSnakeOutside() || HasSelfCollision())
        {
            // Возвращаем true.
            return true;
        }
        // Иначе, возвращаем false.
        return false;
    }
}