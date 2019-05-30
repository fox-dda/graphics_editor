using SDK;
using GraphicsEditor.Enums;
using StructureMap;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Core
{
    /// <summary>
    /// Определитель стратегии
    /// </summary>
    public class StrategyDeterminer: IStrategyDeterminer
    {
        /// <summary>
        /// Конструктор StrategyDeterminer
        /// </summary>
        /// <param name="container"></param>
        public StrategyDeterminer(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// DI контейнер
        /// </summary>
        private IContainer _container;

        /// <summary>
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(string figure)
        {
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

        /// <summary>
        /// Определить статегию отрисовки по фигуре
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Стратегия</returns>
        public Strategy DefineStrategy(DrawAction action)
        {
            if (action == DrawAction.DragDraft || action == DrawAction.DragPoint)
            {
                return Strategy.DragAndDrop;
            }
            else
            {
                return Strategy.Selection;
            }
        }
    }
}
