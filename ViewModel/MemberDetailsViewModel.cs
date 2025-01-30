using MemberManager.Model;
using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class MemberDetailsViewModel : ViewModelBase
{
    private readonly SelectedMemberStore _selectedMemberStore;

    private Member SelectedMember => _selectedMemberStore.SelectedMember;

    public bool HasSelectedMember => SelectedMember != null;
    public string Username => SelectedMember?.Username ?? "Unknown";
    public string Age => SelectedMember?.Age ?? "Unknown Age";

    public MemberDetailsViewModel(SelectedMemberStore selectedMemberStore) 
    {
        _selectedMemberStore = selectedMemberStore;

        _selectedMemberStore.SelectedMemberChanged += _selectedMemberStore_SelectedMemberChanged;
    }

    protected override void Dispose() 
    {
        _selectedMemberStore.SelectedMemberChanged -= _selectedMemberStore_SelectedMemberChanged;
        base.Dispose();
    }

    private void _selectedMemberStore_SelectedMemberChanged()
    {
        OnPropertyChanged(nameof(HasSelectedMember));
        OnPropertyChanged(nameof(Username));
        OnPropertyChanged(nameof(Age));

    }
}
