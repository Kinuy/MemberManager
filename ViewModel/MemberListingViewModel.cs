using MemberManager.Commands;
using MemberManager.Model;
using MemberManager.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class MemberListingViewModel :ViewModelBase
{
    private readonly ObservableCollection<MemberListingItemViewModel> _memberListingItemViewModels;
    private readonly MemberStore _memberStore;
    private readonly ModalNavigationStore _modalNavigationStore;
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

            _selectedMemberStore.SelectedMember = _selectedMemberListingItemViewModel.Member;
        }
    }


    public MemberListingViewModel(MemberStore memberStore, SelectedMemberStore selectedMemberStore, ModalNavigationStore modalNavigationStore)
    {
        _memberStore = memberStore;
        _modalNavigationStore = modalNavigationStore;
        _selectedMemberStore = selectedMemberStore;
        _memberListingItemViewModels = new ObservableCollection<MemberListingItemViewModel>();

        _memberStore.MemberAdded += MemberStore_MemberAdded;
        _memberStore.MemberUpdated += MemberStore_MemberUpdated;

    }

    private void MemberStore_MemberUpdated(Member member)
    {
        MemberListingItemViewModel memberListingItemViewModel = _memberListingItemViewModels.FirstOrDefault(y=>y.Member.Id == member.Id);

        if (memberListingItemViewModel != null) 
        { 
            memberListingItemViewModel.Update(member);
        }
    }

    protected override void Dispose()
    {
        _memberStore.MemberAdded -= MemberStore_MemberAdded;
        _memberStore.MemberUpdated -= MemberStore_MemberUpdated;

        base.Dispose();
    }

    private void MemberStore_MemberAdded(Member member)
    {
        AddMember(member);
    }

    private void AddMember(Member member)

    {
        MemberListingItemViewModel itemViewModel = new MemberListingItemViewModel(member, _memberStore, _modalNavigationStore);
        _memberListingItemViewModels.Add(itemViewModel);
    }
}
