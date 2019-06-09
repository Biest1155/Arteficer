using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Arteficer.Models;
using Android.Content;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Arteficer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Repository repository = Repository.GetInstance();
        Artefact artefact;
        ListView listview;
        EditText name;
        EditText type;
        EditText element;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);                  // Set our view from the "main" layout resource

            Button search = FindViewById<Button>(Resource.Id.searchButton);
            search.Click += SearchFunktion;

            Button random = FindViewById<Button>(Resource.Id.randomButton);
            random.Click += RandomFunktion;

            Button create = FindViewById<Button>(Resource.Id.createButton); // Make connection to button
            create.Click += delegate {                                       // Make desired effect when clicked
                Intent intent = new Intent(this, typeof(CreateActivity));
                StartActivity(intent);
            };

            listview = FindViewById<ListView>(Resource.Id.listView1);
            listview.Adapter = new ArtefactAdapter(this, repository.Artefacts);
            listview.ItemClick += OpenArtefactDetailsClick;

            name = FindViewById<EditText>(Resource.Id.nameEdit);
            type = FindViewById<EditText>(Resource.Id.typeEdit);
            element = FindViewById<EditText>(Resource.Id.elementEdit);
        }

        private void RandomFunktion(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var response = repository.Artefacts.Where(artefact => (name.Text == artefact.Name || name.Text == "") && (type.Text == artefact.Type || type.Text == "") && (element.Text == artefact.Element || element.Text == "")).ToList();
            if (response.Count() == 0)
            {
                Toast.MakeText(this, "No artefacts found in the vault", ToastLength.Short).Show();
                OnStart();
            }
            else
            {
                int r = rnd.Next(response.Count);
                var result = response[r];
                var newList = new List<Artefact>();
                newList.Add(result);

                listview = FindViewById<ListView>(Resource.Id.listView1);
                listview.Adapter = new ArtefactAdapter(this, newList);
            }
        }

        private void SearchFunktion(object sender, EventArgs e)
        {
            var response = repository.Artefacts.Where(artefact => (name.Text == artefact.Name || name.Text == "") && (type.Text == artefact.Type || type.Text == "") && (element.Text == artefact.Element || element.Text == "")).ToList();
            if (response.Count() == 0)
            {
                Toast.MakeText(this, "No artefacts found in the vault", ToastLength.Short).Show();
                OnStart();
            }
            
            listview = FindViewById<ListView>(Resource.Id.listView1);
            listview.Adapter = new ArtefactAdapter(this, response);
        }

        protected override void OnStart()
        {
            listview = FindViewById<ListView>(Resource.Id.listView1);
            listview.Adapter = new ArtefactAdapter(this, repository.Artefacts);
            base.OnStart();
        }

        private void OpenArtefactDetailsClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(DetailsActivity));
            var listView = sender as ListView;
            var item = repository.Artefacts[e.Position].Id;
            intent.PutExtra("artefactId", item);
            StartActivity(intent);

        }
    }
}