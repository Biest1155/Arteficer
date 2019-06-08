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
using Arteficer.Models;

namespace Arteficer
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        Repository repository = Repository.GetInstance();
        Artefact artefact;
        View view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.details_layout);
            artefact = repository.Artefacts.FirstOrDefault(e => e.Id == Intent.Extras.GetInt("artefactId"));

            view.FindViewById<TextView>(Resource.Id.name_detailsText).Text = artefact.Name;
            view.FindViewById<TextView>(Resource.Id.type_detailsText).Text = artefact.Type;
            view.FindViewById<TextView>(Resource.Id.element_detailsText).Text = artefact.Element;
            view.FindViewById<TextView>(Resource.Id.setpiece_detailsCheck).Activated = artefact.setpiece;
            view.FindViewById<TextView>(Resource.Id.description_detailsText).Text = artefact.Description;
            // Create your application here
        }
    }
}