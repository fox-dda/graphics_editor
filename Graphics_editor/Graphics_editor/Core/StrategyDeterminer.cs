using SDK;
using GraphicsEditor.Enums;
using StructureMap;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Engine
{
    /// <summary>
    /// Определитель стратегии
    /// </summary>
    internal class StrategyDeterminer: IStrategyDeterminer
    {
        public StrategyDeterminer()
        {
            _container = new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<IDrawable>().NameBy(x => x.Name);
                });
            });
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
