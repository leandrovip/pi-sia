using PI.SIA.Models;

namespace PI.SIA.Data;

public static class SeedDataExtensions
{
    public static IHost SeedData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<SiaContext>();
        SeedData(context);

        return host;
    }

    private static void SeedData(SiaContext context)
    {
        // Alunos
        var alice = new Aluno {Nome = "Alice Pinheiro", RegistroAluno = "RA123456", DataNascimento = DateTime.Parse("2005-09-01"), Endereco = "Endereço 1"};
        var joaoSilva = new Aluno {Nome = "Joao da Silva", RegistroAluno = "RA254781", DataNascimento = DateTime.Parse("2006-05-21"), Endereco = "Endereço Rua Jardim, 124"};
        var luizMiguel = new Aluno {Nome = "Luis Miguel Oliveira", RegistroAluno = "RA324781", DataNascimento = DateTime.Parse("2009-05-21"), Endereco = "Rua Almeira, 1245"};
        var pauloJose = new Aluno {Nome = "Paulo Jose", RegistroAluno = "RA287781", DataNascimento = DateTime.Parse("2008-05-21"), Endereco = "Endereço 2"};
        var cristina = new Aluno { Nome = "Cristina de Souza Silva", RegistroAluno = "RA2889781", DataNascimento = DateTime.Parse("2020-05-21"), Endereco = "Endereço 2" };
        var ricardo = new Aluno { Nome = "Ricardo Dias", RegistroAluno = "RA2889781", DataNascimento = DateTime.Parse("2020-05-21"), Endereco = "Endereço 2" };

        // Professores
        var professorMiguel = new Professor { Nome = "Professor Miguel", Especializacao = "Portugues" };
        var professoraJoana= new Professor { Nome = "Professora Joana", Especializacao = "Matemática" };
        var professorCaio = new Professor { Nome = "Professor Caio", Especializacao = "Inglês" };
        var professorJorge = new Professor {Nome = "Professor Jorge", Especializacao = "Geografia"};


        if (!context.Aluno.Any())
        {
            context.Aluno.AddRange(
                alice,
                joaoSilva,
                luizMiguel,
                pauloJose,
                cristina,
                ricardo
            );
            context.SaveChanges();
        }

        if (!context.Professor.Any())
        {
            context.Professor.AddRange(
                professorMiguel,
                professoraJoana,
                professorCaio,
                professorJorge
            );
            context.SaveChanges();
        }
    }
}