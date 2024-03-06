using System.Collections.Generic;
using System.Numerics;
using SFML.System;

namespace Snake;

public class Snake
{
    public Vector2 Direction; // Направление змейки.
        
    // Динамический массив, для хранения змейки - хранит координаты всех точек змейки.
    private readonly List<Vector2> _snake;

    public Snake(Vector2 startStartPosition, Vector2 direction)
    {
        // Задаем значения для поля Direction змейки.
        Direction = direction;
            
        // Инициализируем массив со змейкой:
        _snake = new List<Vector2>();
            
        // Добавляем точку в массив _snake.
        _snake.Add(startStartPosition);
    }
        
    /// <summary>
    /// Метод добавляет в массив новый сегмент змейки (с координатами, равными последнему сегменту змейки).
    /// </summary>
    public void IncreaseSize()
    {
        _snake.Add(new Vector2(_snake[^1].X, _snake[^1].Y));
    }
        
    /// <summary>
    /// Метод возвращает длину змейки - размер массива _snake.
    /// </summary>
    public int GetSize()
    {
        return _snake.Count;
    }

    /// <summary>
    /// Метод возвращает координаты сегмента змейки по его индексу в массиве _snake.
    /// </summary>
    public Vector2 GetPoint(int index)
    {
        return _snake[index];
    }
        
    /// <summary>
    /// Метод меняет направление змейки влево.
    /// </summary>
    public void SetMoveDirectionToLeft()
    {
        // Задаем направление змейке влево.
        Direction.X = -1;
        Direction.Y = 0;
    }

    /// <summary>
    /// Метод меняет направление змейки вправо.
    /// </summary>
    public void SetMoveDirectionToRight()
    {
        // Задаем направление змейке вправо.
        Direction.X = 1;
        Direction.Y = 0;
    }

    /// <summary>
    /// Метод меняет направление змейки вверх.
    /// </summary>
    public void SetMoveDirectionToUp()
    {
        // Задаем направление змейке вверх.
        Direction.X = 0;
        Direction.Y = -1;
    }

    /// <summary>
    /// Метод меняет направление змейки вниз.
    /// </summary>
    public void SetMoveDirectionToDown()
    {
        // Задаем направление змейке вниз.
        Direction.X = 0;
        Direction.Y = 1;
    }

    /// <summary>
    /// Метод передвигает змейку в текущем направлении.
    /// </summary>
    public void MoveForward()
    {
        // Проверяем может ли змейка двигаться
        if (!CanMove())
        {
            return;
        }
        
        // Двигаем все сегменты змейки в нужном направлении.
        for (var i = _snake.Count - 1; i > 0; i--)
        {
            // Каждый сегмент занимает положение предыдущего сегмента массива.
            _snake[i] = _snake[i - 1];
        }
            
        // Голова змейки меняет положение в соответствии с текущим направлением.
        _snake[0] += Direction;
    }

    private bool CanMove()
    {
        // Todo Написать логику перезарядки перемещения змейки
    }
}