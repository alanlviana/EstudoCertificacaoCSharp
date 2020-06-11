using certificacao_csharp_pt11.Aula01;
using certificacao_csharp_pt11.Aula02;
using certificacao_csharp_pt11.Aula03;
using certificacao_csharp_pt11.Aula06;
using certificacao_csharp_pt11.Aula07;
using certificacao_csharp_pt11.Auto04;
using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace certificacao_csharp_pt11
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Tarefas em série e em paralelo", typeof(TarefaSerieETarefaParalelo)),
                new MenuItem("Muitos Itens em Parapelo", typeof(MuitosItensEmParalelo)),
                new MenuItem("Processamento com cancelamento", typeof(ProcessamentoComCancelamento)),
                new MenuItem("Paralelismo com LINQ", typeof(ParalelismoComLinq)),
                new MenuItem("Gerenciando Tarefas", typeof(GerenciandoTarefas)),
                new MenuItem("Aguardando fim várias tarefas", typeof(AguardandoFimVariasTarefas)),
                new MenuItem("Tarefas de continuacao", typeof(TarefasDeContinuacao)),
                new MenuItem("Hierarquia de tarefas", typeof(HierarquiaDeTarefas)),
                new MenuItem("Trabalhando com Threads", typeof(TrabalhandoComThread)),
                new MenuItem("Usando o ThreadPoll", typeof(UsandoOPollDeThreads)),
                new MenuItem("Tratamento de exceções com Async/Await", typeof(TratamentoExcecaoAsyncAwait)),
                new MenuItem("Trabalhando com dicionário com concorrência", typeof(TrabalhandoDicionarioConcorrencia)),
                new MenuItem("Implementando Bloqueio", typeof(ImplementandoBloqueio)),
                new MenuItem("Condição de Corrida e Método Thread Safe", typeof(CondicaoCorridaMetodoThreadSafe)),

                

            }; 
        }
    }
}
