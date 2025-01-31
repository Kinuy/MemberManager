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

	private bool _isSubmitting;
	public bool IsSubmitting
	{
		get
		{
			return _isSubmitting;
		}
		set
		{
			_isSubmitting = value;
			OnPropertyChanged(nameof(IsSubmitting));
		}
	}

    private string _errorMessage;
    public string ErrorMessage
    {
        get
        {
            return _errorMessage;
        }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    public bool CanSubmit => !string.IsNullOrEmpty(_username);

	public ICommand SubmitCommand { get;}
	public ICommand CancelCommand { get; }


    public MemberDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
    {
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
    }


}
