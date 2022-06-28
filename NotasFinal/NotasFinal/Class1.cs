using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasFinal
{
    public class EstNot
    {
        private int suspensos;
        private int aprobados;
        private int notables;
        private int sobresalientes;

        private double media;

        public int Suspensos
        {
            get { return suspensos; }
            set { this.suspensos = value; }
        }
        public int Aprobados
        {
            get { return aprobados; }
            set { this.aprobados = value; }
        }
        public int Notables
        {
            get { return notables; }
            set { this.notables = value; }
        }
        public int Sobresalientes
        {
            get { return sobresalientes; }
            set { this.sobresalientes = value; }
        }

        public double Media
        {
            get { return media; }
            set { this.media = value; }
        }

        /// <summary>
        /// En este constructor inicializaremos las variables para no tener que darles valor más adelante
        /// </summary>
        public EstNot()
        {
            this.suspensos = 0;
            this.aprobados = 0;
            this.notables = 0;
            this.sobresalientes = 0;
            this.media = 0.0;

        }
        /// <summary>
        /// Constructor a partir de un array, calcula las estadísticas al crear el objeto
        /// </summary>
        /// <param name="listnot"></param>
        public EstNot(List<int> listnot)
        {

            for (int i = 0; i < listnot.Count; i++)
            {
                if (listnot[i] < 5)
                {
                    suspensos++; // Por debajo de 5 suspenso
                }
                else if (listnot[i] > 5 && listnot[i] < 7)
                {
                    aprobados++; // Nota para aprobar: 5
                }
                else if (listnot[i] > 7 && listnot[i] < 9)
                {
                    notables++; // Nota para notable: 7
                }
                else if (listnot[i] > 9)
                {
                    sobresalientes++;  // Nota para sobresaliente: 9
                }

                media = media + listnot[i];
            }

            media = media / listnot.Count;
        }

        /// <summary>
        /// Para un conjunto de lista de notas, calculamos las estadísticas
        /// Calcula la media y el número de suspensos/aprobados/notables/sobresalientes
        /// </summary>
        /// <remarks>Introducir valores comprendidos entre 0 y 10</remarks>
        /// <param name="listnot"></param>
        /// <returns>El método devuelve una excepción si ha habido algún problema, la media en caso contrario</returns>
        public double CalcularResultados(List<int> listnot)
        {
            return CalcularMedia(listnot);
        }

        private double CalcularMedia(List<int> listnot)
        {
            if (listnot.Count <= 0)
            {
                throw new Exception("La lista no contiene elementos");
            }

            for (int i = 0; i < 10; i++)
            {
                if (listnot[i] < 0 || listnot[i] > 10)
                {
                    throw new ArgumentOutOfRangeException("Los valores no están entre 0 y 10");
                }
            }


            for (int i = 0; i < listnot.Count; i++)
            {
                if (listnot[i] < 5)
                {
                    suspensos++;
                }// Por debajo de 5 suspenso
                else if (listnot[i] >= 5 && listnot[i] < 7)
                {
                    aprobados++;// Nota para aprobar: 5
                }
                else if (listnot[i] >= 7 && listnot[i] < 9)
                {
                    notables++;
                } // Nota para notable: 7
                else if (listnot[i] > 9)
                {
                    sobresalientes++;
                }// Nota para sobresaliente: 9

                media = media + listnot[i];
            }

            media = media / listnot.Count;

            return media;
        }
    }
}
