using Reactive.Bindings;
using System.Reactive.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings.Extensions;
using WpfApp1.Models;
using System.Windows;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : Bases.ViewModelBase
    {
        public TeamViewModel Team { get; set; }
        public ReactiveCommand CheckPalyerCommand { get; set; }

        private TeamModel team;

        public MainWindowViewModel()
        {
            team = new TeamModel().AddTo(disposables);
            Enumerable.Range(1, 10)
                .Select(a => new PlayerModel() { Name = $"Player{a}" }).ToList()
                .ForEach(a => team.Players.Add(a));

            Team = new TeamViewModel(team).AddTo(disposables);

            CheckPalyerCommand = new ReactiveCommand().WithSubscribe(() =>
            {
                var playerNames = string.Join(", ", team.Players.ToList().Select(a => a.Name));
                MessageBox.Show(playerNames);
            }).AddTo(disposables);
        }
    }
}
