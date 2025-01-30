using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModel;

public class MemberDetailsFormViewModel : ViewModelBase
{
	private string _username;
	public string Username
	{
		get
		{
			return _username;
		}
		set
		{
			_username = value;
			OnPropertyChanged(nameof(Username));
			OnPropertyChanged(nameof(CanSubmit));
		}
	}

	private string _age;
	public string Age
	{
		get
		{
			return _age;
		}
		set
		{
			_age = value;
			OnPropertyChanged(nameof(Age));
		}
	}

	public bool CanSubmit => !string.IsNullOrEmpty(_username);

	public ICommand SubmitCommand { get;}
	public ICommand CancelCommand { get; }
}
