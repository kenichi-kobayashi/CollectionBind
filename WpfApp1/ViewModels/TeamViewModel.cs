using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class TeamViewModel : Bases.ViewModelBase
    {
        public ObservableCollection<PlayerViewModel> Players { get; set; }

        public TeamViewModel(Models.TeamModel model)
        {
            Players = new ObservableCollection<PlayerViewModel>(model.Players.Select(a => new PlayerViewModel(a)));
            Players.ObserveAddChanged().Subscribe(a => model.Players.Add(a.Model)).AddTo(disposables);
            Players.ObserveRemoveChanged().Subscribe(a => model.Players.Remove(a.Model)).AddTo(disposables);
        }
    }
}
