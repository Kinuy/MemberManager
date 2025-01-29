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
    public IEnumerable<MemberListingItemViewModel> MemberListingItemViewModels => _memberListingItemViewModels;

    public MemberListingViewModel()
    {
        _memberListingItemViewModels = new ObservableCollection<MemberListingItemViewModel>();

        _memberListingItemViewModels.Add(new MemberListingItemViewModel("Tobi"));
        _memberListingItemViewModels.Add(new MemberListingItemViewModel("Steffi"));
        _memberListingItemViewModels.Add(new MemberListingItemViewModel("Lucy"));
    }
}
