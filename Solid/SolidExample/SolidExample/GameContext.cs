namespace SolidExample
{
    /// <summary>
    /// Принцип инверсии зависимости
    /// </summary>
    public class GameContext
    {
        private IGame _game;

        public GameContext(IGame game)
        {
            _game = game;
        }
        public void Run()
        {
            GameRunner.StartGame((FindNumerGame)_game);
        }
    }
}
