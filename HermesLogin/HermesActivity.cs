
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HermesLogin
{
	[Activity (Label = "HermesActivity")]			
	public class HermesActivity : Activity
	{
		
		private Button btnReservarCancha;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			var name = Intent.Extras.GetString ("name");
			var email = Intent.Extras.GetString ("email");

			SetContentView (Resource.Layout.HermesActivity);

			btnReservarCancha = FindViewById<Button> (Resource.Id.btnReservarCancha);
			btnReservarCancha.Click += (sender, e) =>
			{
				
				var intent = new Intent(this, typeof(ReservarCanchasActivity));

				StartActivity(intent);
			};

		}
	}
}

