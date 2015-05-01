using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace HermesLogin
{
	public class CreateAccountDialog :DialogFragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				base.OnCreateView(inflater, container, savedInstanceState);
				var view = inflater.Inflate(Resource.Layout.SignUpDialog, container, false);
				return view;
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

