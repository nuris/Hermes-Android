using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace HermesLogin
{
	public class OnSignUpEventsArgs: EventArgs
	{
		private string name;
		private string email;
		private string password;
		private string repeatPassword;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public string RepeatPassword
		{
			get { return repeatPassword; }
			set { repeatPassword = value; }
		}

		public OnSignUpEventsArgs(string name, string email, string password, string repeatPassword) : base()
		{
			Name = name;
			Email = email;
			Password = password;
			RepeatPassword = repeatPassword;
		}

	}
	
	class CreateAccountDialog :DialogFragment
	{
		private EditText txtName;
		private EditText txtEmail;
		private EditText txtPassword;
		private EditText txtRepeatPassword;
		private Button btnSignUpEmail;

		//el evento que ocurrirá cuando capture los textos
		public event EventHandler<OnSignUpEventsArgs> onSignUpEventComplete;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.SignUpDialog, container, false);
			//EditTexts
			txtName = view.FindViewById<EditText> (Resource.Id.txtName);
			txtEmail = view.FindViewById<EditText> (Resource.Id.txtEmail);
			txtPassword = view.FindViewById<EditText> (Resource.Id.txtPassword);
			txtRepeatPassword = view.FindViewById<EditText> (Resource.Id.txtRepeatPassword);
			//Boton crear cuenta
			btnSignUpEmail = view.FindViewById<Button> (Resource.Id.btnDialogSignUp);
			btnSignUpEmail.Click += btnSignUpEmail_Click;

				return view;
		}
		//El usuario hizo click en crear cuenta
		void btnSignUpEmail_Click(object sender, EventArgs e)
		{
			//luego de ingresar tdos los datos y hacer click
			onSignUpEventComplete.Invoke(this, new OnSignUpEventsArgs(txtName.Text, txtEmail.Text, txtPassword.Text, txtRepeatPassword.Text));
			this.Dismiss ();

		}	
		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			//titulo del dialogo invisible
			Dialog.Window.RequestFeature (WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			//inserta la animacion al dialogo
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;

		}

	}
}

