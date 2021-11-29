using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
       /*   FechaAgenda fechaInicial = new FechaAgenda(Int32.Parse(txt_diasDesde1.Text), Int32.Parse(txt_mesDesde1.Text), Int32.Parse(txt_anioDesde1.Text));
            FechaAgenda fechaFinal = new FechaAgenda(Int32.Parse(txt_diaHasta1.Text), Int32.Parse(txt_mesHasta1.Text), Int32.Parse(txt_anioHasta1.Text));

            FechaAgenda resultado = FechaAgenda.calcula_periodo(fechaInicial,fechaFinal);
            txt_diaResultado.Text = resultado.dia.ToString();
            txt_mesResultado.Text = resultado.mes.ToString();
            txt_anioResultado.Text = resultado.anio.ToString();
        */

          //HAY QUE VER COMO IMPLEMENTAR MULTIPLES PERÍODOS
            List<FechaAgenda> lista = new List<FechaAgenda>();
            if(ck_p1.Checked){
                try
                {
                    lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde1.Text), Int32.Parse(txt_mesDesde1.Text), Int32.Parse(txt_anioDesde1.Text)),
                        new FechaAgenda(Int32.Parse(txt_diaHasta1.Text), Int32.Parse(txt_mesHasta1.Text), Int32.Parse(txt_anioHasta1.Text))));
                          }
                catch (Exception ex) {
                    MessageBox.Show("Revisar período 1");
                }
            }
            if (ck_p2.Checked)
            {
                try { 
                lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde2.Text), Int32.Parse(txt_mesDesde2.Text), Int32.Parse(txt_anioDesde2.Text)),
                    new FechaAgenda(Int32.Parse(txt_diaHasta2.Text), Int32.Parse(txt_mesHasta2.Text), Int32.Parse(txt_anioHasta2.Text))));
                }catch(Exception ex){
                    MessageBox.Show("Revisar período 2");}

                
            }
            if (ck_p3.Checked)
            { 
                try { 
                lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde3.Text), Int32.Parse(txt_mesDesde3.Text), Int32.Parse(txt_anioDesde3.Text)),
                    new FechaAgenda(Int32.Parse(txt_diaHasta3.Text), Int32.Parse(txt_mesHasta3.Text), Int32.Parse(txt_anioHasta3.Text))));
                }catch(Exception ex){
                    MessageBox.Show("Revisar período 3");}
                
            }

            if (ck_p4.Checked)
            { 
                try {
                    lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde4.Text), Int32.Parse(txt_mesDesde4.Text), Int32.Parse(txt_anioDesde4.Text)),
                    new FechaAgenda(Int32.Parse(txt_diaHasta4.Text), Int32.Parse(txt_mesHasta4.Text), Int32.Parse(txt_anioHasta4.Text))));
                }catch(Exception ex){
                    MessageBox.Show("Revisar período 4");}
               
            }

            if (ck_p5.Checked)
            { try { 
                lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde5.Text), Int32.Parse(txt_mesDesde5.Text), Int32.Parse(txt_anioDesde5.Text)),
                    new FechaAgenda(Int32.Parse(txt_diaHasta5.Text), Int32.Parse(txt_mesHasta5.Text), Int32.Parse(txt_anioHasta5.Text))));
            }catch(Exception ex){
                MessageBox.Show("Revisar período 5");
            }
            }

            if (ck_p6.Checked)
            {
                try
                {
                    lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde6.Text), Int32.Parse(txt_mesDesde6.Text), Int32.Parse(txt_anioDesde6.Text)),
                        new FechaAgenda(Int32.Parse(txt_diaHasta6.Text), Int32.Parse(txt_mesHasta6.Text), Int32.Parse(txt_anioHasta6.Text))));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Revisar período 6");
                }
            }
            
            if (ck_p7.Checked)
            { try { 
                lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde7.Text), Int32.Parse(txt_mesDesde7.Text), Int32.Parse(txt_anioDesde7.Text)),
                    new FechaAgenda(Int32.Parse(txt_diaHasta7.Text), Int32.Parse(txt_mesHasta7.Text), Int32.Parse(txt_anioHasta7.Text))));
            }catch(Exception ex){
                MessageBox.Show("Revisar período 7");
            }}

            if (ck_p8.Checked)
            {
                try
                {
                    lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde8.Text), Int32.Parse(txt_mesDesde8.Text), Int32.Parse(txt_anioDesde8.Text)),
                        new FechaAgenda(Int32.Parse(txt_diaHasta8.Text), Int32.Parse(txt_mesHasta8.Text), Int32.Parse(txt_anioHasta8.Text))));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Revisar período 8");
                }
            }

            if (ck_p9.Checked)
            {
                try
                {
                    lista.Add(FechaAgenda.calcula_periodo(new FechaAgenda(Int32.Parse(txt_diasDesde9.Text), Int32.Parse(txt_mesDesde9.Text), Int32.Parse(txt_anioDesde9.Text)),
                        new FechaAgenda(Int32.Parse(txt_diaHasta9.Text), Int32.Parse(txt_mesHasta9.Text), Int32.Parse(txt_anioHasta9.Text))));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Revisar período 9");
                }
            }

               
            
            
            FechaAgenda f_resultado = new FechaAgenda(0,0,0);
           
            foreach( FechaAgenda i in lista){
                f_resultado = FechaAgenda.sumar_periodo(f_resultado,i);
               // MessageBox.Show(f_resultado.ToString());  
            }

            txt_diaResultado.Text = f_resultado.dia.ToString();
            txt_mesResultado.Text = f_resultado.mes.ToString();
            txt_anioResultado.Text = f_resultado.anio.ToString();

            FechaAgenda faltante_para_causal = new FechaAgenda(0,0,0);
            faltante_para_causal = FechaAgenda.faltante_causal(f_resultado);
            txt_dias_causal.Text = faltante_para_causal.dia.ToString();
            txt_meses_causal.Text = faltante_para_causal.mes.ToString();
            txt_anios_causal.Text = faltante_para_causal.anio.ToString();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_todo(this);

        }

        private void limpiar_todo(Control control)
        {
            /*Limpia todos los TextBox*/
            foreach (var txt in control.Controls){
                if (txt is TextBox){
                    ((TextBox)txt).Clear();
                }
            }

            /*Limpia todos los CheckBox*/
            foreach (var ck in control.Controls){
                if (ck is CheckBox) {
                    ((CheckBox)ck).Checked = false;
                }
            }
        }



    }
}
