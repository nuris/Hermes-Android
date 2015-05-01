using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HermesLogin
{
	[Activity (Label = "HermesLogin", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Button btnSignUp; 

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			//Accion del boton crear cuenta
			btnSignUp = FindViewById<Button>(Resource.Id.btnSignUpEmail);
			btnSignUp.Click += (object sender, EventArgs args) => 
			{
				//Llamar al dialogo de crear cuenta	
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				CreateAccountDialog createAccountDialog = new CreateAccountDialog();
				createAccountDialog.Show(transaction, "dialog fragment");
			};
				

		}
	}
}


