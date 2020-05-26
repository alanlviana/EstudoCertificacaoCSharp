using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace certificacao_csharp_pt9_console._01___Debugando.Performance
{
    class MonitoramentoPerformance
    {
        private const string NOME_CATEGORIA = "CinemaAlura";
        private const string CONTADOR_RELATORIO = "RelatorioFilmes";
        private const string CONTADOR_RELATORIO_BASE = "RelatorioFilmesBase";
        

        public static PerformanceCounter ContadorRelatorio;
        public static PerformanceCounter ContadorRelatorioBase;

        public static bool ConfigurarCategoria()
        {
            if (!PerformanceCounterCategory.Exists(NOME_CATEGORIA))
            {
                CounterCreationDataCollection counterCreationDataCollection = new CounterCreationDataCollection();
                PerformanceCounterCategory.Create(NOME_CATEGORIA, "Monitor de performance para curso alura.", PerformanceCounterCategoryType.SingleInstance, CONTADOR_RELATORIO, "Tempo gasto na consulta para relatório de filmes.");
                return true;
            }


            // Cria os contadores.
            ContadorRelatorio = new PerformanceCounter(NOME_CATEGORIA,
                CONTADOR_RELATORIO,
                false);

            ContadorRelatorioBase = new PerformanceCounter(NOME_CATEGORIA,
                CONTADOR_RELATORIO_BASE,
                false);

            return false;

        }




    }
}
