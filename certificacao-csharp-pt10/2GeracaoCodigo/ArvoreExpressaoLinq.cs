using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace certificacao_csharp_pt10._2GeracaoCodigo
{
    class ArvoreExpressaoLinq : IExecutavel
    {
        public void Executar()
        {
            // Criar as expressões
            var quocienteExpression = Expression.Parameter(typeof(float), "quo");
            var divisorExpression = Expression.Constant(2f, typeof(float));
            var divisaoExpression = Expression.Divide(quocienteExpression, divisorExpression);

            // Criar Arvore de Expressões
            var metadeExpression = Expression.Lambda<Func<float, float>>(divisaoExpression, new[] { quocienteExpression });

            // Compilar e Executar Arvore
            var metade = metadeExpression.Compile();
            var resultado = metade.Invoke(9);
            Console.WriteLine("A metade de 9 é: " + resultado);


            // Modificar a arvore de expressões
            var trocaDivisao = new TrocarDivisaoPorMUltiplicacaoVisitor();
            var dobroExpression = Expression.Lambda<Func<float,float>>(trocaDivisao.Modificar(divisaoExpression), new[] {quocienteExpression });
            var dobro = dobroExpression.Compile();

            Console.WriteLine("o dobro de 18 é "+dobro.Invoke(18));


        }
    }

    class TrocarDivisaoPorMUltiplicacaoVisitor: ExpressionVisitor
    {

        public Expression Modificar(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Divide)
            {
                return Expression.Multiply(node.Left, node.Right);
            }

            return base.VisitBinary(node);
        }

    }
}
