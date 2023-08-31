internal class Program
{
    private static void Main(string[] args)
    {
        Player player = new Player(10, 12);
        Renderer renderer = new Renderer();
        renderer.Draw(player);
    }
}

class Player
{
    public Player(int positionX, int positionY, char symbol = '@')
    {
        Symbol = symbol;
        PositionX = positionX;
        PositionY = positionY;
    }

    public char Symbol { get; private set; }
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
}

class Renderer
{
    public void Draw(int positionX, int positionY, char character = '@')
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.SetCursorPosition(positionX, positionY);
        Console.Write(character);
        Console.ReadKey(true);
    }

    public void Draw(Player player)
    {
        Draw(player.PositionX, player.PositionY, player.Symbol);
    }
}