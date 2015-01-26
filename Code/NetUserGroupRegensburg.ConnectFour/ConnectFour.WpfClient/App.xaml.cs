using ConnectFour.Core;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ConnectFour.WpfClient
{
// ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Composition root
            var board = new BoardFactory(new CellPropertyChangedDecoratorFactory()).CreateBoard(7, 6);

            var playerA = CreatePlayer("Player A", new Color(0, 0, 128));
            var playerB = CreatePlayer("Player B", new Color(128, 0, 0));

            var playerViewModels = new List<IPlayerViewModel>
                                   {
                                       new PlayerViewModel(playerA) { HasTurn = true },
                                       new PlayerViewModel(playerB)
                                   };

            var clickColumnCommands = new List<IClickColumnCommand>();

            var boardViewModel = new BoardViewModel(board.Cells, clickColumnCommands);

            var mainWindowViewModel = new MainWindowViewModel(playerViewModels, boardViewModel, board);

            clickColumnCommands.AddRange(board.Columns.Select(column => new ClickColumnCommand(column, mainWindowViewModel)));

            // Show main window
            MainWindow = new MainWindow { DataContext = mainWindowViewModel };
            MainWindow.Show();
        }

        private static Player CreatePlayer(string playerName, Color playerColor)
        {
            var chips = new List<Chip>();
            for (var i = 0; i < 21; i++)
            {
                chips.Add(new Chip(playerName, playerColor));
            }

            return new Player(playerName, playerColor, chips);
        }
    }
}
