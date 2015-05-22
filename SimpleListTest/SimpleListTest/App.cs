﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SimpleListTest
{
    public class App : Application
    { 
        public App()
        {
            // create the VM and initialize the list
            var vm = new ViewModel();

            // setup the input controls
            var entry = new Entry {Placeholder = "Item Name"};
            entry.SetBinding<ViewModel>(Entry.TextProperty, a => a.EntryText);
            var btn = new Button {Text = "Add Item"};
            btn.SetBinding<ViewModel>(Button.CommandProperty, m => m.AddItemCommand);

            // setup the simple list
            var list = new SimpleList();
            list.SetBinding<ViewModel>(SimpleList.ItemsSourceProperty, a => a.Items);
            list.DisplayMember = "Name";

            // The root page of your application
            MainPage = new ContentPage
            {
                BindingContext = vm,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new StackLayout
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Children =
                            {
                                new Label 
                                {
							        XAlign = TextAlignment.Center,
							        Text = "Add an item"
						        },
                                entry,
                                btn,
                                list
                            }
                        }
						
					}
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
