using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda;


namespace Agenda_Test
{
    [TestClass]
    public class FechaAgendaTest
    {
        [TestMethod]
        public void diferencia_dias_test()
        {
            //ARRANGE (DATOS DE ENTRADA)
            FechaAgenda f_inicial = new FechaAgenda(13,09,1989);
            FechaAgenda f_final = new FechaAgenda(28, 10, 2021);
            int resultado_esperado = 1;
            
           

            //ASSERT (AFIRMACIÓN, RESULTADO POSITIVO)
            Assert.AreEqual(resultado_esperado, resultado_obtenido);

        }
    }
}
