using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string a = "") // callerMemberName fonctionne comme le nameof, il renvoie le nom de la propriété qui appelle la méthode
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a));
        }
    }
}
