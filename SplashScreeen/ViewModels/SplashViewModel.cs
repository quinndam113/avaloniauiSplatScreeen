using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SplashScreeen.ViewModels
{
    internal class SplashViewModel : ViewModelBase
    {
        private string _startUpMessage = "Application is loading...";
        public string StartUpMessage
        {
            get { return _startUpMessage; } 
            set { 
                this.RaiseAndSetIfChanged(ref _startUpMessage, value);
            }
        }


        private CancellationTokenSource _cts = new CancellationTokenSource();
        public CancellationToken CancellationToken => _cts.Token;

        public void Cancel()
        {
            _cts.Cancel();
        }
    }
}
