using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using App204.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebView = Xamarin.Forms.WebView;

[assembly: ExportRenderer(typeof(WebView), typeof(HybridWebViewRenderer))]
namespace App204.Droid
{
    public class HybridWebViewRenderer : WebViewRenderer
    {
        public HybridWebViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {

            }
            if (e.NewElement != null)
            {
                //Control.SetWebChromeClient(new FullScreenClient(linearLayout, contentLayout));
            }
        }
    }

    public class FullScreenClient : WebChromeClient
    {
        readonly FrameLayout.LayoutParams matchParentLayout = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                                                                                         ViewGroup.LayoutParams.MatchParent);
        readonly ViewGroup content;
        readonly ViewGroup parent;
        Android.Views.View customView;

        public FullScreenClient(ViewGroup parent, ViewGroup content)
        {
            this.parent = parent;
            this.content = content;
        }

        public override void OnShowCustomView(Android.Views.View view, ICustomViewCallback callback)
        {
            customView = view;
            view.LayoutParameters = matchParentLayout;
            parent.AddView(view);
            content.Visibility = ViewStates.Gone;
        }

        public override void OnHideCustomView()
        {
            content.Visibility = ViewStates.Visible;
            parent.RemoveView(customView);
            customView = null;
        }
    }
}