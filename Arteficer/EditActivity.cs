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

            Button edit = FindViewById<Button>(Resource.Id.re_artificeButton_Edit);
            edit.Click += EditArtefact;

            Button mainMenu = FindViewById<Button>(Resource.Id.mainMenuButton_Edit);
            mainMenu.Click += MainMenuArtefact;

            artefact = repository.Artefacts.FirstOrDefault(e => e.Id == Intent.Extras.GetInt("artefactsId"));
            FindViewById<TextView>(Resource.Id.nameEdit_Edit).Text = artefact.Name;
            FindViewById<TextView>(Resource.Id.typeEdit_Edit).Text = artefact.Type;
            FindViewById<TextView>(Resource.Id.elementEdit_Edit).Text = artefact.Element;
            FindViewById<TextView>(Resource.Id.descriptionEdit_Edit).Text = artefact.Description;
        }

        private void MainMenuArtefact(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void EditArtefact(object sender, EventArgs e)
        {
            artefact.Name = FindViewById<TextView>(Resource.Id.nameEdit_Edit).Text;
            artefact.Type = FindViewById<TextView>(Resource.Id.typeEdit_Edit).Text;
            artefact.Element = FindViewById<TextView>(Resource.Id.elementEdit_Edit).Text;
            artefact.Description = FindViewById<TextView>(Resource.Id.descriptionEdit_Edit).Text;
            repository.save();
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}