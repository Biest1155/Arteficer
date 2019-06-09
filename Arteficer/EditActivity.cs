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
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        Repository repository = Repository.GetInstance();
        Artefact artefact;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.edit_layout);

            artefact = repository.Artefacts.FirstOrDefault(e => e.Id == Intent.Extras.GetInt("artefactsId"));
            FindViewById<TextView>(Resource.Id.name_detailsText).Text = artefact.Name;
            FindViewById<TextView>(Resource.Id.type_detailsText).Text = artefact.Type;
            FindViewById<TextView>(Resource.Id.element_detailsText).Text = artefact.Element;
            FindViewById<TextView>(Resource.Id.description_detailsText).Text = artefact.Description;

            // Create your application here
        }
    }
}