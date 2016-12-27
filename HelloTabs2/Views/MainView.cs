using Android.App;
using MugenMvvmToolkit.Android.Views.Activities;

namespace HelloTabs2.Views
{
    [Activity(Label = "MainView")]
    public class MainView : MvvmActivity
    {
        #region Constructors

        public MainView()
            : base(Resource.Layout.Main)
        {
        }

        #endregion
    }
}