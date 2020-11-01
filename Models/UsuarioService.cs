using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                return bd.Usuarios.ToList();
            }
        }

        public Usuario BuscarPorId(int Id)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                return bd.Usuarios.Find(Id);
            }
        }

        public void Incluir (Usuario novoUsuario)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                bd.Add(novoUsuario);
                bd.SaveChanges();
            }
        }

        public void Editar(Usuario editadoUsuario)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                Usuario usuario = bd.Usuarios.Find(editadoUsuario.Id);

                usuario.Login = editadoUsuario.Login;
                usuario.Nome = editadoUsuario.Nome;
                usuario.Senha = editadoUsuario.Senha;
                usuario.Tipo = editadoUsuario.Tipo;

                bd.SaveChanges();
            }
        }

        public void Excluir(int Id)
        {
            using(BibliotecaContext bd = new BibliotecaContext())
            {
                bd.Usuarios.Remove(bd.Usuarios.Find(Id));
                bd.SaveChanges();
            }
        }
    }
}