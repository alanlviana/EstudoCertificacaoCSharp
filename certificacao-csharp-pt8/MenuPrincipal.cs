
using certificacao_csharp_pt8.Aula1;
using certificacao_csharp_pt8.Aula2;
using Curso.Arquitetura.Menu;
using System.Collections.Generic;

namespace certificacao_csharp_pt8
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem> {
                new MenuItem("A classe file stream", typeof(ClasseFileStream)),
                new MenuItem("Gravando com file stream", typeof(EscrevendoComFileStream)),
                new MenuItem("Desafio FileStream", typeof(DesafioFileStream)),
                new MenuItem("Usando StreamWriter", typeof(UsandoStreamWriter)),
                new MenuItem("Usando StreamReader", typeof(ArquivosCompactados)),
                new MenuItem("Criando arquivos compactados", typeof(ArquivosCompactados)),
                new MenuItem("BinaryWriter vs StreamWriter", typeof(BinaryWriterStreamWriter)),
                new MenuItem("Usando a classe File", typeof(UsandoClasseFile)),
                new MenuItem("Obtendo Informações sobre drivers", typeof(ObtendoInformacoesDrivers)),
                new MenuItem("Obtendo Informações sobre arquivo", typeof(ObtendoInformacoesArquivo)),
                new MenuItem("Usando stream default do console", typeof(UsandoStreamConsole)),
                new MenuItem("Criando um diretório", typeof(CriandoUmDiretorio)),
                new MenuItem("Trabalhando com ambientes", typeof(TrabalhandoComCaminhos)),
                new MenuItem("Busca Recursiva", typeof(BuscaRecursivaArquivo)),
                new MenuItem("Acessando a WEB - WebRequest", typeof(CriandoRequisicao)),
                new MenuItem("Acessando a WEB - WebClient", typeof(CriandoRequisicaoWebClient)),
                new MenuItem("Acessando a WEB - Assincrona", typeof(CriandoRequisicaoAssincrona)),
                new MenuItem("Acessando a WEB - Multiplataforma", typeof(CriandoRequisicaoMultiPlataforma)),
                new MenuItem("Tratamento de Erros - Métodos Assincronos", typeof(ExcecoesMetodosAssincronos)),
                new MenuItem("Acessando banco de dados", typeof(AcessandoBancoDados)),
                new MenuItem("Consumindo JSON", typeof(ConsumindoJson)),
                

            }; 
        }
    }
}
