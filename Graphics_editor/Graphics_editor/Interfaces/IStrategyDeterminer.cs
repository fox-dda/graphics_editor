using GraphicsEditor.Enums;
using StructureMap;


namespace GraphicsEditor.Interfaces
{
    public interface IStrategyDeterminer
    {
        /// <summary>
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        Strategy DefineStrategy(string figure);
    }
}
