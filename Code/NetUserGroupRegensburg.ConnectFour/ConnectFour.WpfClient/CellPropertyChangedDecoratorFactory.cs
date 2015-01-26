using ConnectFour.Core;

namespace ConnectFour.WpfClient
{
    public class CellPropertyChangedDecoratorFactory : ICellFactory
    {
        public ICell Create(int columnIndex, int rowIndex)
        {
            return new CellPropertyChangedDecorator(new Cell(columnIndex, rowIndex));
        }
    }
}
