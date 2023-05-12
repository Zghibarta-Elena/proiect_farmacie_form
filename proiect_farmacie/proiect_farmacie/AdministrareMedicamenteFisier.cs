﻿using System.IO;

namespace proiect_farmacie
{
    public class AdministrareMedicamenteFisier
    {
        private const int NR_MAX_Medicamente = 50;
        private string numeFisier;

        public AdministrareMedicamenteFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddMedicament(Medicament medicament)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(medicament.ConversieLaSir_PentruFisier());
            }
        }
        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            Medicament[] medicament = new Medicament[NR_MAX_Medicamente];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMedicamente = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicament[nrMedicamente++] = new Medicament(linieFisier);
                }
            }

            return medicament;
        }

  
    }
}
