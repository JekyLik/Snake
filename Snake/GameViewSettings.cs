using SFML.Graphics;

namespace Snake;

/// <summary>
/// Класс с настройками отрисовки игры (из каких элементов будет отрисовываться наша игра).
/// </summary>
public class GameViewSettings
{
    // Путь к папке с ресурсами.
    private const string ASSETS_PATH = "/Users/vitaly/Downloads/Snake_Final/Snake/Assets";

    // Размер одной ячейки на карте
    public int CellSize { get; }

    // Текстура границы игрового поля.
    public Texture WallTexture { get; }

    // Текстура тела змейки.
    public Texture SnakeBodyTexture { get; }

    // Текстура головы змейки.
    public Texture SnakeHeadTexture { get; }

    // Текстура еды.
    public Texture FoodTexture { get; }

    // Текстура фоны карты.
    public Texture BackgroundTexture { get; }


    public GameViewSettings()
    {
        CellSize = 30;
        WallTexture = new Texture(ASSETS_PATH + "/Textures/themes/theme_3/wall.png");
        SnakeBodyTexture = new Texture(ASSETS_PATH + "/Textures/themes/theme_3/snakeBody.png");
        SnakeHeadTexture = new Texture(ASSETS_PATH + "/Textures/themes/theme_3/snakeHead.png");
        FoodTexture = new Texture(ASSETS_PATH + "/Textures/themes/theme_3/food.png");
        BackgroundTexture = new Texture(ASSETS_PATH + "/Textures/themes/theme_3/background.png");
    }
}