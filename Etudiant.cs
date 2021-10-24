using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_Options
{
    class Etudiant
    {
        public string nom;
        public string prenom;
        public float noteMoy;

        public Etudiant(string nomE, string prenomE, float noteMoyE)
        {
            nom = nomE;
            prenom = prenomE;
            noteMoy = noteMoyE;
        }
    }
}