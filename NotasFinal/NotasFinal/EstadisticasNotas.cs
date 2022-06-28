using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasFinalNS
{
    /// <summary>
    /// Clase que calcula las estadisticas de un conjunto de notas
    /// <para>Calcula el numero de aprobados, suspensos, notables y sobresalientes</para>
    /// <para>Calcula la media de las notas introducidas</para>
    /// </summary>
    public class EstadisticasNotas
    {
        public const int TopeSuspenso = 5;
        public const int TopeAprobado = 7;
        public const int TopeNotable = 9;

        public const string ListaVacia = "No puede estar vacía la lista de notas";
        public const string NotasIncorrectas = "La notas han de estar comprendidas entre el 0 y el 10";

        private int suspensos;
        private int aprobados;
        private int notables;
        private int sobresalientes;
        private double media;

        /// <summary>
        /// Getters y setters de las variables de la clase
        /// </summary>
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
        public EstadisticasNotas()
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
        /// <param name="listnot">Notas que se introducen</param>
        public EstadisticasNotas(List<int> listnot)
        {
            CalcularMedia(listnot);
        }

        /// <summary>
        /// Función que a raiz de un conjunto de notas que se introducen calcula
        /// <para>el numero de suspensos, aprob, not y sobres</para>
        /// <para>y la media de ese conjunto de notas</para>
        /// </summary>
        /// <param name="listnot">Notas introducidas</param>
        /// <remarks>Saltan dos excepciones</remarks>
        /// <returns>Cantidad de suspensos<see cref=">Suspensos"/> cantidad de aprobados <see cref=">Aprobados
        /// "/>cantidad de notables <see cref=">Notables"/>cantidad de sobresalientes<see cref=">Sobresalientes"/>
        /// y la media de dichas notas<see cref=">Media"/></returns>
        public double CalcularResultados(List<int> listnot)
        {
            return CalcularMedia(listnot);
        }

        private double CalcularMedia(List<int> listnot)
        {
            if (listnot.Count <= 0)
            {
                throw new Exception(ListaVacia);
            }

            for (int i = 0; i < listnot.Count; i++)
            {
                if (listnot[i] < 0 || listnot[i] > 10)
                {
                    throw new ArgumentOutOfRangeException(NotasIncorrectas);
                }
            }


            for (int i = 0; i < listnot.Count; i++)
            {
                if (listnot[i] < TopeSuspenso)
                {
                    suspensos++;
                }
                else if (listnot[i] >= TopeSuspenso && listnot[i] < TopeAprobado)
                {
                    aprobados++;// Nota para aprobar: 5
                }
                else if (listnot[i] >= TopeAprobado && listnot[i] < TopeNotable)
                {
                    notables++;
                } // Nota para notable: 7
                else if (listnot[i] >= TopeNotable)
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
