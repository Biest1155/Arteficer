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

namespace Arteficer.Models
{
    public class Artefact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Element { get; set; } // Arcane, fire, ice
        public string Type { get; set; } // weapon, armor, trinket
        public string Description { get; set; } // what is it
        public bool setpiece { get; set; } // Does it belong to a set
    }
}