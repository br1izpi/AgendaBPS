using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda
{
    class FechaAgenda
    {/*Esta clase se encarga de manejar las fechas. Cada mes tiene 30 días
      */

        public static int DIAS_MES = 30;
        public static int MESES_ANIO = 12;
        public static FechaAgenda FECHA_TRABAJO_CAUSAL = new FechaAgenda(0,0,30);
        public int dia { get; set; }
        public int mes { get; set; }
        public int anio{ get; set; }
       

        public FechaAgenda(int d, int m, int a) {
            this.dia = d;
            this.mes = m;
            this.anio = a;
        }
        
        public FechaAgenda() {
            this.anio = 0;
            this.dia = 0;
            this.mes = 0;
        }
       
        public bool son_iguales(FechaAgenda f2) {
            return (this.anio == f2.anio && this.mes == f2.mes && this.dia == f2.dia);
        }

        public FechaAgenda convertir_dias_FechaAgenda(int dias) {
            FechaAgenda f_resultado = new FechaAgenda();

            int mes_parcial=0, dia_parcial=0, anio_parcial = 0;
            //condition ?  consequent :  alternative
            mes_parcial = dias >= 30 ? dias/DIAS_MES : 0;
     
            dia_parcial = dias >= 30 ? dias%DIAS_MES : dias;
            
            
            anio_parcial = mes_parcial >= MESES_ANIO ?  mes_parcial/MESES_ANIO :  0;

            f_resultado.dia = dia_parcial;
            /*if(mes_parcial >= MESES_ANIO){
                anio_parcial = mes_parcial / MESES_ANIO;
                mes_parcial = mes_parcial % MESES_ANIO;
            }*/
            f_resultado.mes = mes_parcial;
                
            f_resultado.anio = anio_parcial;



            return f_resultado;

        }

        public static FechaAgenda calcula_periodo(FechaAgenda f_inicial, FechaAgenda f_final) {
            FechaAgenda f_resultado = new FechaAgenda();

            //OBTIENE EL DIA RESULTADO
            if (f_inicial.dia > f_final.dia)
            {
                f_final.mes -= 1;
                f_resultado.dia = (DIAS_MES+f_final.dia) - f_inicial.dia;
            }
            else { 
                f_resultado.dia = f_final.dia - f_inicial.dia;
            }

            //OBTIENE EL MES RESULTADO
            if (f_inicial.mes > f_final.mes)
            {
                f_final.anio -= 1;
                f_resultado.mes = (MESES_ANIO - f_inicial.mes) + f_final.mes;
            }
            else
            {
                f_resultado.mes = f_final.mes - f_inicial.mes;
            }

            //OBTIENE EL AÑO RESULTADO
            f_resultado.anio = f_final.anio - f_inicial.anio;

            f_resultado.dia += 1;//SIEMPRE SE SUMA 1 DIA
            if (f_resultado.dia == DIAS_MES) {
                f_resultado.dia = 0;
                f_resultado.mes++;
            }
            return f_resultado;
        }
        
        public override String ToString()
        {   
            return this.dia + "/" + this.mes + "/" + this.anio;
        }

        public static FechaAgenda sumar_periodo(FechaAgenda f1, FechaAgenda f2)
        {
            int dias, meses, anios;
            dias = f1.dia + f2.dia;
            meses = f1.mes + f2.mes;
            anios = f1.anio + f2.anio;

            //Rectifica días y suma mes si corresponde
            if (dias >= DIAS_MES) {
                Console.WriteLine("entrea a rectifica dias");
                meses += dias / DIAS_MES;
                dias = dias % DIAS_MES;
                Console.WriteLine("dias::::" + dias);
            }
            //Rectifica meses y suma año si corresponde
            if (meses >= MESES_ANIO)
            {
                Console.WriteLine("entrea a rectifica meses");
                anios += meses / MESES_ANIO;
                meses = meses % MESES_ANIO;
                Console.WriteLine("meses::::" + meses);
            }

           return new FechaAgenda(dias,meses, anios);

        }

        public String ToString_periodo() { 
            string d = this.dia > 1 ? " días." :  " día.";
            return this.anio + " años " + this.mes + " meses y " + this.dia + d;
        }

        public static FechaAgenda faltante_causal(FechaAgenda trabajado) {
            FechaAgenda faltante_causal = new FechaAgenda();
            FechaAgenda causal = FECHA_TRABAJO_CAUSAL;
            FechaAgenda trabajado_aux = trabajado;
            /*RESTAR A ANIOS_TRABAJO_CAUSAL {30 años} LOS AÑOS TRABAJADOS*/
            //Determinado días
            if (causal.dia < trabajado_aux.dia)
            {
                causal.dia += DIAS_MES;
                trabajado_aux.mes += 1;
            }
            faltante_causal.dia = causal.dia - trabajado_aux.dia;
            
            //Determinado meses
            if (causal.mes < trabajado_aux.mes)
            {
                causal.mes += MESES_ANIO;
                trabajado_aux.anio += 1;
            }
            faltante_causal.mes = causal.mes - trabajado_aux.mes;
            
            //Determinado años
            faltante_causal.anio = causal.anio - trabajado_aux.anio;


            return faltante_causal;
        }

        public bool aplica_bonificacion(int computo_especial) {
           /*Devuelve true o false en caso si cumple con el período mínimo según computo especial.
            Ejemplo: Cómputo especial 22 período mínimo 10 años*/
            bool aplica=false;
            //CAMBIAR PARA QUE SEA TRAÍDO DE LA BASE DE DATOS
            switch (computo_especial){
                case 22: 
                    aplica = (this.anio >= 10 ? true : false);
                    break;
                    
            }

            return aplica;
        }

        public FechaAgenda devuelve_bonificacion(Bonificacion b) { 
            /*Devuelve la bonificación obtenida. 
             Precondición: aplica_bonificacion()=true;
             */
            FechaAgenda bonificacion = new FechaAgenda();
           // EJEMPLO CON computo_especial = 22
            FechaAgenda aux = this;
            double anios_bonificados = aux.anio / b.trabajado;


            return bonificacion;
        }


    }// fin class      
}//fin namespace
