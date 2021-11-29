using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda
{
    class Bonificacion
    {
        public double bonificacion { get; set; }
        public double trabajado { get; set; }
        public int computo_especial { get; set; }
        public String comentarios { get; set; }

        public Bonificacion() { }
        public Bonificacion( double anios_bonificacion, double anios_trabajados, int ce, String comentario) {
            this.bonificacion = anios_bonificacion;
            this.trabajado = anios_trabajados;
            this.computo_especial = ce;
            this.comentarios = comentario;
        }

        public override String ToString()
        {
            return "CE "+this.computo_especial + " :  " + this.bonificacion + " x " + this.trabajado;
        }

        public FechaAgenda devuelve_bonificacion(FechaAgenda periodo_trabajado) {
            FechaAgenda resultado = new FechaAgenda();


            double a_bonif = (periodo_trabajado.anio / this.trabajado) * (this.bonificacion - this.trabajado);
            string s = a_bonif.ToString();
            int a_bonif_entero = Int16.Parse(Math.Round(a_bonif).ToString());
            double m_bonif_arrastra = (a_bonif - a_bonif_entero) * this.trabajado;
            double m_bonif = (periodo_trabajado.mes / this.trabajado) * (this.bonificacion - this.trabajado);
            m_bonif += m_bonif_arrastra;
            double d_bonif = (periodo_trabajado.dia / this.trabajado) * (this.bonificacion - this.trabajado);
            //int dia=0;
            int dint_bonif = Int16.Parse(Math.Truncate(d_bonif).ToString());
            int aint_bonif = a_bonif_entero;
            int mint_bonif = Int16.Parse(Math.Truncate(m_bonif).ToString());


            if (dint_bonif >= 30)
            {
                m_bonif += dint_bonif / 30;
                dint_bonif = dint_bonif % 30;
            }
            if (mint_bonif >= 12)
            {
                aint_bonif += mint_bonif / 12;
                mint_bonif = mint_bonif % 12;
            }

            resultado.anio = aint_bonif;
            resultado.mes = mint_bonif;
            resultado.dia = dint_bonif;

         
            
            return resultado;
        }
    }
}
