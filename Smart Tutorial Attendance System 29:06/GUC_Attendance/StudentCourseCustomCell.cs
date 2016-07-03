﻿// Smart Tutorial Attendance System
// Created By: Zeyad Ahmed Atef
// Started: February 2016

using System;
using Xamarin.Forms;
using GUC_Attendance.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using Acr.UserDialogs;
using Splat;


namespace GUC_Attendance
{
	public class StudentCourseCustomCell : ViewCell
	{
		public StudentCourseCustomCell ()
		{
			//instantiate each of our views
			StackLayout cellWrapper = new StackLayout ();
			StackLayout horizontalLayout = new StackLayout ();

			Label week = new Label ();
			Label day = new Label ();
			Label attended = new Label ();


			//set bindings
			week.SetBinding (Label.TextProperty, "week");
			day.SetBinding (Label.TextProperty, "day");
			attended.SetBinding (Label.TextProperty, "attended");


			//Set properties for desired design
			cellWrapper.BackgroundColor = Color.FromHex ("#dbedf2");
			cellWrapper.Padding = 10;
			horizontalLayout.Orientation = StackOrientation.Vertical;
			week.TextColor = Color.FromHex ("#f35e20");
			day.TextColor = Color.Black;
			attended.TextColor = Color.Black;


			//add views to the view hierarchy
			horizontalLayout.Children.Add (week);
			horizontalLayout.Children.Add (day);
			horizontalLayout.Children.Add (attended);

			cellWrapper.Children.Add (horizontalLayout);
			View = cellWrapper;
		}




	}
}

