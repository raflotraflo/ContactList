﻿using Android.App;
using Android.Widget;
using Android.OS;
using ContactList.Adapters;
using System.Collections.Generic;
using ContactList.Models;

namespace ContactList
{
    [Activity(Label = "ContactList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Contact> _contacts;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.addButton);
            button.Click += delegate { };

            Initialize();

            var contactListView = FindViewById<ListView>(Resource.Id.contactListView);

            contactListView.Adapter = new ContactListAdapter(_contacts, this);

        }

        private void Initialize()
        {
            _contacts = new List<Contact>();

            for(int i=1; i <= 20; i++)
            {
                _contacts.Add(new Contact("My concact " + i, "my_email@gmail.com", "530529985"));
            }
        }
    }
}

