using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class MenuPrincipal : Menu
    {
        protected override IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                // Curso 1 e 2
                new MenuItem("Tipos de Valor", typeof(TiposDeValor)),
                new MenuItem("Tipos Inteiros", typeof(TiposInteiros)),
                new MenuItem("Ponto Flututante", typeof(PontoFlutuante)),
                new MenuItem("Decimal", typeof(Decimal)),
                new MenuItem("Booleanos", typeof(Booleanos)),
                new MenuItem("Estruturas", typeof(Estruturas)),
                new MenuItem("Enumeracoes", typeof(Enumeracoes)),
                new MenuItem("Tipos de Refêrencia", typeof(TiposDeReferencia)),
                new MenuItem("Classes", typeof(Classes)),
                new MenuItem("Interfaces", typeof(Interfaces)),
                new MenuItem("Delegates", typeof(Delegates)),
                new MenuItem("Objetos", typeof(Objetos)),
                new MenuItem("Dinâmicos", typeof(Dinamicos)),
                new MenuItem("Strings", typeof(Strings)),
                new MenuItem("Metodos", typeof(Metodos)),
                new MenuItem("Parâmetros Nomeados", typeof(ParametrosNomeados)),
                new MenuItem("Parâmetros Opcionais", typeof(ParametrosOpcionais)),
                new MenuItem("Métodos de Extensão", typeof(MetodosDeExtensao)),
                new MenuItem("Propriedades Indexadas", typeof(PropriedadesIndexadas)),
                new MenuItem("Sobrecargas", typeof(Sobrecargas)),
                new MenuItem("Métodos Substituidos", typeof(MetodosSubstituidos)),
                new MenuItem("Boxing", typeof(Boxing)),
                new MenuItem("Unboxing", typeof(Unboxing)),
                new MenuItem("Conversoes Implícitas", typeof(ConversoesImplicitas)),
                new MenuItem("Conversoes Explícitas", typeof(ConversoesExplicitas)),
                new MenuItem("Operadores IS e AS", typeof(OperadoresISeAS)),
                new MenuItem("Operadores de Conversão", typeof(OperadoresDeConversao)),
                new MenuItem("Métodos Auxiliares de Conversão", typeof(MetodosAuxiliares)),
                new MenuItem("Usando Dynamic", typeof(UsandoDynamic)),
                new MenuItem("Conversões de Dynamic", typeof(ConversoesDeDynamic)),
                new MenuItem("Resolucão de Sobrecarga", typeof(ResolucaoSobrecarga)),
                new MenuItem("Usando ExpandObject", typeof(UsandoExpandObject)),
                new MenuItem("Interoperabilidade COM", typeof(InteropCOM))
            };
        }
    }
}
