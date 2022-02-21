using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class PlayerViewModel : Bases.ViewModelBase
    {
        public ReactivePropertySlim<string> Name { get; set; }
        public PlayerModel Model { get; set; }

        public PlayerViewModel()
        {
            Model = new PlayerModel();
            initialize();
        }

        public PlayerViewModel(PlayerModel model)
        {
            Model = model;
            initialize();
        }

        private void initialize()
        {
            Name = Model.ToReactivePropertySlimAsSynchronized(a => a.Name).AddTo(disposables);
        }
    }
}
