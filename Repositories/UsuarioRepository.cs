using System.Collections.Generic;
using System.Linq;
using SponteBackEnd.Models;

namespace SponteBackEnd.Repositories
{    
    public static class UsuarioRepositorio
    {
        public static Usuario Get(string nome, string senha)
        {
            var usuarios = new List<Usuario>();
            usuarios.Add(new Usuario {Id = 1, Nome = "Carlos", Senha = "spweb123"});
            return usuarios.Where(x => x.Nome.ToLower() == nome.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}
