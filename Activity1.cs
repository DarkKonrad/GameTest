using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Microsoft.Xna.Framework;
namespace Przyciskitest {
    [Activity(Label = "Przyciskitest"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity {

        private bool z = false;
        private void OnKeyPress(object sender,View.KeyEventArgs e)
        {
        
        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            
            
            Game1.ScrWidth = (int)(Resources.DisplayMetrics.WidthPixels/Resources.DisplayMetrics.Density);
            Game1.ScrHeight = (int)(Resources.DisplayMetrics.HeightPixels/Resources.DisplayMetrics.Density);
        

            var g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();

            
            //g.main.enterName.Find(x => x.AssetName == "name").clickEvent += delegate
            //{
            //    var pView = g.Services.GetService<View>();
            //    var inputMethodManager = this.GetSystemService(Context.InputMethodService) as InputMethodManager;
            //    inputMethodManager.ShowSoftInput(pView, ShowFlags.Forced);
            //    inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            //  //  inputMethodManager.HideSoftInputFromWindow(pView.WindowToken, 0);
                    
                
            //};
            //g.main.enterName.Find(x => x.AssetName == "done").clickEvent += delegate
            //     {
            //         var pView = g.Services.GetService<View>();
            //         var inputMethodManager = this.GetSystemService(Context.InputMethodService) as InputMethodManager;
            //         inputMethodManager.HideSoftInputFromWindow(pView.WindowToken, HideSoftInputFlags.None);
                   
            //     };
         
            

        }
      

    }

}

