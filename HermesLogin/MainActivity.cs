using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Android.Media;

using String = System.String; 

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
				Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
				CreateAccountDialog createAccountDialog = new CreateAccountDialog();
				createAccountDialog.Show(transaction, "dialog fragment");
				//se le entrega el evento al dialogo que es capturar los textos
				//cuando se crea el evento, los datos pueden ser enviados al servidor
				createAccountDialog.onSignUpEventComplete += CreateAccountDialog_onSignUpEventComplete;
			};
				

		}

		void CreateAccountDialog_onSignUpEventComplete (object sender, OnSignUpEventsArgs e)
		{
			//Notificacion de la cuenta creada
			//deberia ser un metodo?

//			// Instantiate the builder and set notification elements:
			Notification.Builder builder = new Notification.Builder (this)
				.SetAutoCancel (true) // dismiss the notification from the notification area when the user clicks on it
				.SetContentTitle ("Hermes App") // Set the title
				.SetSmallIcon (Resource.Drawable.Icon) // This is the icon to display
				.SetContentText ("Su cuenta ha sido creada con éxito!") // the message to display.
				.SetDefaults (NotificationDefaults.Vibrate);

			//Notificacion con el sonido del sistema
			builder.SetSound (RingtoneManager.GetDefaultUri(RingtoneType.Ringtone));
			// Build the notification:
			Notification notification = builder.Build();
			// Turn on vibrate:
			notification.Defaults |= NotificationDefaults.Vibrate;

			// Finally publish the notification
			NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			// Publish the notification:
			const int notificationId = 0;
			notificationManager.Notify (notificationId, notification);

			//Se inicia la aplicacion
			var intent = new Intent(this, typeof(HermesActivity));
			intent.PutExtra ("email", e.Email);
			intent.PutExtra ("name", e.Name);
			StartActivity(intent);
		}

	}
}


