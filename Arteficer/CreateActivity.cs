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
    [Activity(Label = "CreateActivity")]
    public class CreateActivity : Activity
    {
        Artefact artefact = new Artefact();
        Repository repository = Repository.GetInstance();
        EditText name;
        EditText type;
        EditText element;
        EditText description;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.create_layout);
            Button back = FindViewById<Button>(Resource.Id.backButton);
            back.Click += delegate {
                OnBackPressed();
            };
            Button artifice = FindViewById<Button>(Resource.Id.artificeButton);
            artifice.Click += Artifice_Click;
            name = FindViewById<EditText>(Resource.Id.nameEditCreate);
            type = FindViewById<EditText>(Resource.Id.typeEditCreate);
            element = FindViewById<EditText>(Resource.Id.elementEditCreate);
            description = FindViewById<EditText>(Resource.Id.descriptionEdit);
        }
        public void Artifice_Click(object sender, EventArgs e)
        {
            if (repository.Artefacts.Count() == 0)
            {
                artefact.Id = 0;
            }
            else
            {
                artefact.Id = repository.Artefacts.Max(m => m.Id+1);

            }
            artefact.Name = name.Text;
            artefact.Type = type.Text;
            artefact.Element = element.Text;
            artefact.Description = description.Text;
            repository.Artefacts.Add(artefact);
            repository.save();
            OnBackPressed();
        }
    }
}