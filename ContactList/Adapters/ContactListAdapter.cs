using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactList.Models;

namespace ContactList.Adapters
{
    public class ContactListAdapter : BaseAdapter<Contact>
    {
        private List<Contact> _contacts;
        private Activity _parent;

        public ContactListAdapter(List<Contact> contacts, Activity parent)
        {
           _contacts = contacts;
           _parent = parent;
        }

        public override Contact this[int position]
        {
            get
            {
                return _contacts[position];
            }
        }

        public override int Count
        {
            get
            {
               return _contacts.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ContactViewHolder viewHolder = null;

            if(convertView == null)
            {
                convertView = _parent.LayoutInflater.Inflate(Resource.Layout.view_contact, null);

                viewHolder = new ContactViewHolder();
                viewHolder.NameTextView = convertView.FindViewById<TextView>(Resource.Id.nameTextView);
                viewHolder.PhoneNumberTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumberTextView);
                viewHolder.EmailImageView = convertView.FindViewById<ImageView>(Resource.Id.emailImageView);
                viewHolder.PhoneImageView = convertView.FindViewById<ImageView>(Resource.Id.phoneImageView);

                convertView.Tag = viewHolder;
            }

            if(viewHolder == null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }

            var contact = _contacts[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneNumberTextView.Text = contact.PhoneNumber;

            return convertView;
        }
    }
}