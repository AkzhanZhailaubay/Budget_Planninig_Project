using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget_Planner_Alnur_Madiyev_w68646.Core
{
    public class ObservableObject : INotifyPropertyChanged //call INotifyPropertyChanged EventHandler
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
