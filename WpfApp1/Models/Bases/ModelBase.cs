using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.Bases
{
    public abstract class ModelBase : IDisposable, INotifyPropertyChanged
    {
        protected CompositeDisposable disposables = new CompositeDisposable();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}
