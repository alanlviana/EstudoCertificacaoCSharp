using Curso.Arquitetura.Menu;
using System.CodeDom;
using System.CodeDom.Compiler;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Http.Headers;

namespace certificacao_csharp_pt10._2GeracaoCodigo
{
    class GeracaoCodigo : IExecutavel

    {
        public void Executar()
        {
            CodeCompileUnit unit = new CodeCompileUnit();

            // Criando namespace
            CodeNamespace namespaceRecursoHumano = new CodeNamespace("RecursosHumanos");
            unit.Namespaces.Add(namespaceRecursoHumano);

            // Criando import
            var importSystem = new CodeNamespaceImport("System");
            namespaceRecursoHumano.Imports.Add(importSystem);

            // Criando classe
            var classeFuncionario = new CodeTypeDeclaration("Funcionario");
            classeFuncionario.IsClass = true;
            namespaceRecursoHumano.Types.Add(classeFuncionario);

            // Criando Propriedades da classe Funcionario
            var fieldNomeFuncionario = new CodeMemberField(typeof(String), "Nome");
            fieldNomeFuncionario.Attributes = MemberAttributes.Public;
            var fieldSalarioFuncionario = new CodeMemberField(typeof(Decimal), "Salario");
            fieldSalarioFuncionario.Attributes = MemberAttributes.Public;
            classeFuncionario.Members.Add(fieldNomeFuncionario);
            classeFuncionario.Members.Add(fieldSalarioFuncionario);

            // criando um construtor
            var construtorFuncionario = new CodeConstructor();
            construtorFuncionario.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "nome"));
            construtorFuncionario.Parameters.Add(new CodeParameterDeclarationExpression(typeof(decimal), "salario"));
            construtorFuncionario.Attributes = MemberAttributes.Public;

            var thisReference = new CodeThisReferenceExpression();
            var atribuicaoNome = new CodeAssignStatement(new CodePropertyReferenceExpression(thisReference, "Nome"), new CodeArgumentReferenceExpression("nome"));
            var atribuicaoSalario = new CodeAssignStatement(new CodePropertyReferenceExpression(thisReference, "Salario"), new CodeArgumentReferenceExpression("salario"));

            construtorFuncionario.Statements.Add(atribuicaoNome);
            construtorFuncionario.Statements.Add(atribuicaoSalario);
            classeFuncionario.Members.Add(construtorFuncionario);
            



            CodeDomProvider csharProvider = CodeDomProvider.CreateProvider("CSharp");

            var stringWriter = new StringWriter();

            using(var streamWriter = new StreamWriter("Funcionario.cs"))
            {
                var cgo = new CodeGeneratorOptions();

                csharProvider.GenerateCodeFromCompileUnit(unit, streamWriter, cgo);
            }

            Console.WriteLine(File.ReadAllText("Funcionario.cs"));

        }
    }
}
