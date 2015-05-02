using System;
using Android.Graphics;

namespace HermesLogin
{
	public class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
	{
		private int[] mIndicatorColors;
		private int[] mDividerColors;

		public int GetIndicatorColor(int position)
		{
			return mIndicatorColors[position % mIndicatorColors.Length];
		}

		public int GetDividerColor (int position)
		{
			return mDividerColors[position % mDividerColors.Length];
		}

		public int[] IndicatorColors
		{
			set { mIndicatorColors = value; }
		}

		public int[] DividerColors
		{
			set { mDividerColors = value; }
		}
	}

}

