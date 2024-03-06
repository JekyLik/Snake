using System.Numerics;

namespace Snake;

/// <summary>
/// Класс, отвечающий за размеры игрового поля.
/// </summary>
public class GameBoard
{
    public Vector2 Size; // Размер игрового поля.

    public GameBoard(int sizeX, int sizeY)
    {
        // Конструктор сохраняет размеры игрового поля в поле класса.
        Size.X = sizeX;
        Size.Y = sizeY;
    }
}