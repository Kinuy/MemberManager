using MemberManager.Model;
using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.ViewModel;

public class MemberListingViewModel :ViewModelBase
{
    private readonly ObservableCollection<MemberListingItemViewModel> _memberListingItemViewModels;
    private readonly SelectedMemberStore _selectedMemberStore;

    public IEnumerable<MemberListingItemViewModel> MemberListingItemViewModels => _memberListingItemViewModels;

    private MemberListingItemViewModel _selectedMemberListingItemViewModel;

    public MemberListingItemViewModel SelectedMemberListingItemViewModel
    {
        get
        {
            return _selectedMemberListingItemViewModel;
        }
        set
        {
            _selectedMemberListingItemViewModel = value;
            OnPropertyChanged(nameof(SelectedMemberListingItemViewModel));

            _selectedMemberStore.SelectedMember = _selectedMemberListingItemViewModel?.Member;
        }
    }
    public MemberListingViewModel(SelectedMemberStore selectedMemberStore)
    {
        _selectedMemberStore = selectedMemberStore;
        _memberListingItemViewModels = new ObservableCollection<MemberListingItemViewModel>();

        _memberListingItemViewModels.Add(new MemberListingItemViewModel(new Member("Tobi","39")));
        _memberListingItemViewModels.Add(new MemberListingItemViewModel(new Member("Steffi", "41")));
        _memberListingItemViewModels.Add(new MemberListingItemViewModel(new Member("Lucy", "1")));

    }
}
