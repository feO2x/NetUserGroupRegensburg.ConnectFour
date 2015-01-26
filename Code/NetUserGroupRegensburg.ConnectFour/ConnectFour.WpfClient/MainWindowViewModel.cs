using ConnectFour.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.WpfClient
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private readonly IBoardViewModel _boardViewModel;
        private readonly IReadOnlyList<IPlayerViewModel> _playerViewModels;
        private readonly IBoard _board;
        private string _gameText;

        public MainWindowViewModel(IReadOnlyList<IPlayerViewModel> playerViewModels, IBoardViewModel boardViewModel, IBoard board)
        {
            _playerViewModels = playerViewModels;
            _boardViewModel = boardViewModel;
            _board = board;
        }

        public IBoardViewModel BoardViewModel
        {
            get { return _boardViewModel; }
        }

        public IReadOnlyList<IPlayerViewModel> PlayerViewModels
        {
            get { return _playerViewModels; }
        }

        public string GameText
        {
            get { return _gameText; }
            private set { this.SetValueIfDifferent(value, ref _gameText); }
        }

        public void PlayTurn(IColumn column)
        {
            if (column == null) throw new ArgumentNullException("column");

            var aktuellerSpielerViewModel = _playerViewModels.First(vm => vm.HasTurn);
            aktuellerSpielerViewModel.Player.PlaceChipInColumn(column);

            var gewinnerName = _board.DetermineWinner();
            if (gewinnerName != null)
            {
                GameText = gewinnerName + " wins!";
            }

            foreach (var spielerViewModel in _playerViewModels)
            {
                spielerViewModel.HasTurn = !spielerViewModel.HasTurn;
            }
        }
    }
}