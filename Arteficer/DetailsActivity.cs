using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Arteficer.Models;
using Newtonsoft.Json;

namespace Arteficer
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        Repository repository = Repository.GetInstance();
        Artefact artefact;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.details_layout);

            Button edit = FindViewById<Button>(Resource.Id.edit_buttonDetails);
            edit.Click += EditArtefact;

            Button delete = FindViewById<Button>(Resource.Id.delete_buttonDetails);
            delete.Click += DeleteArtefact;

            artefact = repository.Artefacts.FirstOrDefault(e => e.Id == Intent.Extras.GetInt("artefactId"));
            FindViewById<TextView>(Resource.Id.name_detailsText).Text = artefact.Name;
            FindViewById<TextView>(Resource.Id.type_detailsText).Text = artefact.Type;
            FindViewById<TextView>(Resource.Id.element_detailsText).Text = artefact.Element;
            FindViewById<TextView>(Resource.Id.description_detailsText).Text = artefact.Description;
            // Create your application here
        }

        protected override void OnStart()
        {
            artefact = repository.Artefacts.FirstOrDefault(e => e.Id == Intent.Extras.GetInt("artefactId"));
            FindViewById<TextView>(Resource.Id.name_detailsText).Text = artefact.Name;
            FindViewById<TextView>(Resource.Id.type_detailsText).Text = artefact.Type;
            FindViewById<TextView>(Resource.Id.element_detailsText).Text = artefact.Element;
            FindViewById<TextView>(Resource.Id.description_detailsText).Text = artefact.Description;
            base.OnStart();
        }

        private void EditArtefact(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(EditActivity));
            intent.PutExtra("artefactId", artefact.Id);
            StartActivity(intent);
        }

        private void DeleteArtefact(object sender, EventArgs e)
        {
            repository.Artefacts.Remove(artefact);
            repository.save();
            OnBackPressed();
        }
    }
}