using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Write("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.Write("Informe a nota do aluno: ");
                        if (decimal.TryParse(Console.ReadLine(),out decimal nota))
                            aluno.Nota = nota;
                        else
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        if (indiceAluno == 5)
                            throw new IndexOutOfRangeException("Quantidade de alunos excedida.");
                        else {
                            alunos[indiceAluno] = aluno;
                            indiceAluno++;
                        }
                        break;
                    case "2":
/*                        for (int i = 0; i < indiceAluno; i++)
                            Console.WriteLine(alunos[i]);*/
                        foreach (var a in alunos)
                            if (!string.IsNullOrEmpty(a.Nome))
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota.ToString()}");
                        break;
                    case "3":
                        decimal soma = 0;
                        var cont = 0;
                        foreach (var a in alunos)
                            if (!string.IsNullOrEmpty(a.Nome)) {
                                soma += a.Nota;
                                cont++;
                            }
                        Console.WriteLine($"Média geral: {soma/cont}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
