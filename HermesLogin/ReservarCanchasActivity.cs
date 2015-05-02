
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
	[Activity (Label = "ReservarCanchasActivity")]			
	public class ReservarCanchasActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.ReservarCanchaActivity);
			FragmentTransaction transaction = FragmentManager.BeginTransaction();
			SlidingTabsFragment fragment = new SlidingTabsFragment ();
			transaction.Replace(Resource.Id.sample_content_fragment, fragment);
			transaction.Commit();

		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.actionbar_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}
	}
}

