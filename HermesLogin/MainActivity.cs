using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

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
				//se le entrega el evento al dialogo que es capturar los textos
				//cuando se crea el evento, los datos pueden ser enviados al servidor
				createAccountDialog.onSignUpEventComplete += CreateAccountDialog_onSignUpEventComplete;
			};
				

		}

		void CreateAccountDialog_onSignUpEventComplete (object sender, OnSignUpEventsArgs e)
		{
			Thread thread = new Thread (sendDataToServer);
			thread.Start ();
		}

		private void sendDataToServer()
		{
			//Aqui se debe comunicar
			//colocar mientras un dialogo
			Thread.Sleep(3000);

			//Aqui deberia mostrar un dialogo si todo sale bien o mal
		}

	}
}


