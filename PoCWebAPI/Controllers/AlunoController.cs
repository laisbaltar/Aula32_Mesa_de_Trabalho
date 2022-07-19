using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PoCWebAPI.Controllers
{
    // Tabelas = Models
    public class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }

    // Banco de Dados = Contexts
    public class DbEscola
    {
        public List<Alunos> alunos { get; set; } = new List<Alunos>
        {
            new Alunos
            {
                Id = 1,
                Nome = "Laís",
                Sobrenome = "Baltar"
            },
            new Alunos
            {
                Id = 2,
                Nome = "Iasmim",
                Sobrenome = "Vivanco"
            },
            new Alunos
            {
                Id = 3,
                Nome = "Gabrielle",
                Sobrenome = "Santana"
            }
        };
    }


    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private DbEscola dbEscola = new DbEscola();

        [HttpGet("{Id}")]
        public Alunos RetornarAlunoPelaId(int Id)
        {
            var Resultado = new Alunos();
            foreach (Alunos local in dbEscola.alunos)
            {
                if (local.Id == Id)
                {
                    Resultado = local;
                }
            }
            return Resultado;
        }

        [HttpPost("{Id}")]
        public Alunos CadastrarNovoAluno(Alunos novoAluno)
        {
            dbEscola.alunos.Add(novoAluno);
            return novoAluno;
        }

        [HttpDelete("{Id}")]
        public Alunos DeletarAluno(int Id)
        {
            Alunos alunoDeletado = new Alunos();

            foreach (Alunos aluno in dbEscola.alunos)
            {
                if (aluno.Id == Id)
                {
                    alunoDeletado = aluno;
                    dbEscola.alunos.Remove(alunoDeletado);
                    return alunoDeletado;
                }
            }
            return alunoDeletado;
        }
    }
}
