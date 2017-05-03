using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using C1.Android.Gauge;
using Android.Graphics;
using Java.Util;

namespace C1Gauge101
{
    [Activity(Label = "@string/bulletgraph", MainLauncher = false, Icon = "@drawable/gauge_bullet")]
    public class BulletGraphActivity : Activity
    {
        private C1BulletGraph mBulletGraph;
        private TextView mBadText;
        private TextView mGoodText;
        private TextView mTargetText;
        private int mValue = 13;
        private int mBad = 50;
        private int mGood = 70;
        private int mTarget = 90;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_bullet_graph);

            // initializing widgets
            mBulletGraph = (C1BulletGraph)FindViewById(Resource.Id.bulletGraph1);
            mBadText = (TextView)FindViewById(Resource.Id.badText);
            mGoodText = (TextView)FindViewById(Resource.Id.goodText);
            mTargetText = (TextView)FindViewById(Resource.Id.targetText);

            // setting default values
            mBulletGraph.Value = mValue;
            mBulletGraph.Bad = mBad;
            mBulletGraph.Good = mGood;
            mBulletGraph.Max = 100;
            mBulletGraph.Target = mTarget;
            mBulletGraph.ShowText = GaugeShowText.None;
            mBulletGraph.Step = 1;
            // properties set in XML layout
            // mBulletGraph.setGaugeWidth(.5f);

            mBadText.Text = mBad.ToString();
            mGoodText.Text = mGood.ToString();
            mTargetText.Text = mTarget.ToString();

            Button button = (Button)FindViewById(Resource.Id.buttonBadMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonBadPlus);
            button.Click += button_Click;

            button = (Button)FindViewById(Resource.Id.buttonGoodMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonGoodPlus);
            button.Click += button_Click;

            button = (Button)FindViewById(Resource.Id.buttonTargetMinus);
            button.Click += button_Click;
            button = (Button)FindViewById(Resource.Id.buttonTargetPlus);
            button.Click += button_Click;
        }
        void button_Click(object sender, System.EventArgs e)
        {
            View v = (View)sender;
            switch (v.Id)
            {
                case Resource.Id.buttonBadMinus:
                    mBad -= (mBad > mBulletGraph.Min) ? 5 : 0;
                    mBulletGraph.Bad = mBad;
                    mBadText.Text = mBad.ToString();
                    break;
                case Resource.Id.buttonBadPlus:
                    mBad += (mBad < mBulletGraph.Max) ? 5 : 0;
                    mBulletGraph.Bad = mBad;
                    mBadText.Text = mBad.ToString();
                    break;
                case Resource.Id.buttonGoodMinus:
                    mGood -= (mGood > mBulletGraph.Min) ? 5 : 0;
                    mBulletGraph.Good = mGood;
                    mGoodText.Text = mGood.ToString();
                    break;
                case Resource.Id.buttonGoodPlus:
                    mGood += (mGood < mBulletGraph.Max) ? 5 : 0;
                    mBulletGraph.Good = mGood;
                    mGoodText.Text = mGood.ToString();
                    break;
                case Resource.Id.buttonTargetMinus:
                    mTarget -= (mTarget > mBulletGraph.Min) ? 5 : 0;
                    mBulletGraph.Target = mTarget;
                    mTargetText.Text = mTarget.ToString();
                    break;
                case Resource.Id.buttonTargetPlus:
                    mTarget += (mTarget < mBulletGraph.Max) ? 5 : 0;
                    mBulletGraph.Target = mTarget;
                    mTargetText.Text = mTarget.ToString();
                    break;
            }
        }

    }
}


