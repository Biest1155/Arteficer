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
using Newtonsoft.Json;

namespace Arteficer.Models
{
    class Repository
    {
        public List<Artefact> Artefacts { get; set; } = new List<Artefact>();
        string filename = "Artefact.dat";

        private static Repository instance;
        public static Repository GetInstance()
        {
            if (instance is null)
            {
                instance = new Repository();
            }
            return instance;
        }

        private Repository()
        {

        }

        public void save()
        {
            string savefile = JsonConvert.SerializeObject(Artefacts);
            File.WriteAllText(filename, savefile);
        }

        public void read()
        {
            if (File.Exists(filename))
            {
                var file = File.OpenText(filename);
                string filestring = file.ReadToEnd();
                file.Dispose();
                Artefacts = JsonConvert.DeserializeObject<List<Artefact>>(filestring);
            }
        }
    }
}