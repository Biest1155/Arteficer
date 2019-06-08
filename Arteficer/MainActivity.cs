using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Arteficer.Models;
using Android.Content;
using System.Linq;

namespace Arteficer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Repository repository = Repository.GetInstance();
        ListView listview;
        EditText name;
        EditText type;
        EditText element;
        Switch setpiece;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);                  // Set our view from the "main" layout resource

            Button search = FindViewById<Button>(Resource.Id.searchButton);
            Button random = FindViewById<Button>(Resource.Id.randomButton);
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
            setpiece = FindViewById<Switch>(Resource.Id.setpieceSwitch);
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
            string artefactName = ((TextView)e.View).Text;
            int artefactId = repository.Artefacts.FirstOrDefault(c => c.Name == artefactName).Id;
            intent.PutExtra("artefactId", artefactId);
            StartActivity(intent);

        }
    }
}