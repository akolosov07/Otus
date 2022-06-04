namespace SolidExample
{
    /// <summary>
    /// Принцип единственной ответственности -
    /// данный класс предназначен только для старта игры
    /// </summary>
    public class GameRunner
    {
        /// <summary>
        /// Здесь реализуется принцип Барбары лисков,
        /// мы можем подставить вместо базового класса
        /// FindNumerGame любой его потомок и 
        /// выполнить метод Play
        /// </summary>
        /// <param name="game"></param>
        public static void StartGame(FindNumerGame game)
        {
            game.Play();
        }
    }
}
