using System;
using System.Collections.Generic;

namespace Ex_Options
{
    class Program
    {
        static void Main(string[] args)

        {
            //creation des 3 options 
            Option genieLogiciel = new Option();
            genieLogiciel.nom = "GL";
            Console.WriteLine("entrez le nombre de places disponibles dans GL :");
            genieLogiciel.placesDisponibles = int.Parse(Console.ReadLine());

            Option administrationBD = new Option();
            administrationBD.nom = "ABD";
            Console.WriteLine("entrez le nombre de places disponibles dans ABD :");
            administrationBD.placesDisponibles = int.Parse(Console.ReadLine());

            Option administrationSR = new Option();
            administrationSR.nom = "ASR";
            Console.WriteLine("entrez le nombre de places disponibles dans ASR :");
            administrationSR.placesDisponibles = int.Parse(Console.ReadLine());

            Console.WriteLine("entrez le nombre des etudiants de la filiére informatique : ");
            int nbEtudiant = int.Parse(Console.ReadLine());

            //creer une liste des tuples contenant les etudiants et leurs choix
            var listEt = new List<Tuple<Etudiant, string, string, string>>();


            //entrer les etudiants et leurs choix
            for (int i = 0; i < nbEtudiant; i++)
            {
                Console.WriteLine("entrez le nom d'etudiant");
                string nomEt = Console.ReadLine();
                Console.WriteLine("entrez le prenom d'etudiant");
                string prenomEt = Console.ReadLine();
                Console.WriteLine("entrez la note d'etudiant de 1ère année :");  
                float noteMoyEt = float.Parse(Console.ReadLine());
                //instancier l'objet etudiant1
                Etudiant etudiant1 = new Etudiant(nomEt, prenomEt, noteMoyEt);

                Console.WriteLine("entrez le choix 1 ");
                string ch1 = Console.ReadLine();
                Console.WriteLine("entrez le choix 2");
                string ch2 = Console.ReadLine();
                Console.WriteLine("entrez le choix 3");
                string ch3 = Console.ReadLine();

                //creer le tuple contenant l'objet etudiant1 et ses choix
                var tuple1 = Tuple.Create(etudiant1, ch1, ch2, ch3);
                listEt.Add(tuple1);

            }
            //classer la liste des etudiants par ses notes moyennes de 1 ére année
            listEt.Sort((s1, s2) => s2.Item1.noteMoy.CompareTo(s1.Item1.noteMoy));

            //creer 3 listes des etudiants de 3 options pour l'affichage
            var listEtGL = new List<Etudiant>();
            var listEtABD = new List<Etudiant>();
            var listEtASR = new List<Etudiant>();

            //traiter les cas des options
            for (int k = 0; k < nbEtudiant; k++)
            {
                switch (listEt[k].Item2)
                {
                    case "GL":
                        if (genieLogiciel.placesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[k].Item1;
                            listEtGL.Add(item1);
                            --genieLogiciel.placesDisponibles;
                        }
                        else
                        {

                            switch (listEt[k].Item3)
                            {
                                case "ABD":
                                    if (administrationBD.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtABD.Add(item2);
                                        --administrationBD.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "ASR" && administrationSR.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtASR.Add(item3);
                                            --administrationSR.placesDisponibles;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (administrationSR.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtASR.Add(item2);
                                        --administrationSR.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "ABD" && administrationBD.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtABD.Add(item3);
                                            --administrationBD.placesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ABD":
                        if (administrationBD.placesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[k].Item1;
                            listEtABD.Add(item1);
                            --administrationBD.placesDisponibles;
                        }
                        else
                        {

                            switch (listEt[k].Item3)
                            {
                                case "GL":
                                    if (genieLogiciel.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtGL.Add(item2);
                                        --genieLogiciel.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "ASR" && administrationSR.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtASR.Add(item3);
                                            --administrationSR.placesDisponibles;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (administrationSR.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtASR.Add(item2);
                                        --administrationSR.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "GL" && genieLogiciel.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtGL.Add(item3);
                                            --genieLogiciel.placesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ASR":
                        if (administrationSR.placesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[k].Item1;
                            listEtASR.Add(item1);
                            --administrationSR.placesDisponibles;
                        }
                        else
                        {

                            switch (listEt[k].Item3)
                            {
                                case "ABD":
                                    if (administrationBD.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtABD.Add(item2);
                                        --administrationBD.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "GL" && genieLogiciel.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtGL.Add(item3);
                                            --genieLogiciel.placesDisponibles;
                                        }
                                    }
                                    break;

                                case "GL":
                                    if (genieLogiciel.placesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[k].Item1;
                                        listEtGL.Add(item2);
                                        --genieLogiciel.placesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[k].Item4 == "ABD" && administrationBD.placesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[k].Item1;
                                            listEtABD.Add(item3);
                                            --administrationBD.placesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                }

            }

            //affichage des 3 listes des options
            Console.WriteLine("la liste de GL :");
            foreach (Etudiant item in listEtGL)
            {
                Console.WriteLine(item.nom + "\t" + item.prenom + "\t" + item.noteMoy);
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("la liste de ABD :");
            foreach (Etudiant item1 in listEtABD)
            {
                Console.WriteLine(item1.nom + "\t" + item1.prenom + "\t" + item1.noteMoy);
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("la liste de ASR :");

            foreach (Etudiant item2 in listEtASR)
            {
                Console.WriteLine(item2.nom + "\t" + item2.prenom + "\t" + item2.noteMoy);
            }
        }

    }
}