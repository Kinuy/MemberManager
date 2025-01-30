using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class MainViewModel :ViewModelBase
{
    private readonly ModalNavigationStore _modalNavigationStore;

    public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

    public bool IsModalOpen => _modalNavigationStore.IsOpen;

    public MemberManagerViewModel MemberManagerViewModel { get; }

    public MainViewModel(ModalNavigationStore modalNavigationStore, MemberManagerViewModel memberManagerViewModel)
    {
        _modalNavigationStore = modalNavigationStore;
        MemberManagerViewModel = memberManagerViewModel;

        _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;

    }

    protected override void Dispose()
    {
        _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

        base.Dispose();
    }

    private void ModalNavigationStore_CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsModalOpen));
    }
}
