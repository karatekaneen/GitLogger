﻿using GitLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GitLogger
{
	public partial class App : Application
	{
        public static CommitViewModel CommitViewModel{ get; set; } = new CommitViewModel();
		public App ()
		{
			InitializeComponent();
            App.CommitViewModel.LoadData();
			MainPage = new GitLogger.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
