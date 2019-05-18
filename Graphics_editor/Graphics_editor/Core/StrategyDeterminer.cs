using SDK;
using GraphicsEditor.Enums;
using StructureMap;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Определитель стратегии
    /// </summary>
    public class StrategyDeterminer: IStrategyDeterminer
    {
        public StrategyDeterminer(IContainer container)
        {
            _container = container;
        }


        /// <summary>
        /// DI контейнер
        /// </summary>
        public IContainer _container { get; set; }

        /// <summary>
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(string figure)
        {
            if (figure == "HighlightRect")
            {
                return Strategy.Selection;
            }
            else if (figure == "DragPoint" || figure == "DragDraft")
            {
                return Strategy.DragAndDrop;
            }

            var draft = _container.GetInstance<IDrawable>(figure);

            if (draft is IMultipoint multipointDraft)
            {
                return Strategy.Multipoint;
            }
            else
            {
                return Strategy.TwoPoint;
            }
        }
    }
}
