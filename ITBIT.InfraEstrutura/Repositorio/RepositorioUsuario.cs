using ITBIT.CORE.Entidades;
using ITBIT.CORE.Repositorio;
using ITBIT.InfraEstrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITBIT.InfraEstrutura.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private readonly UsuarioDBContext _usuarioDBContext;

        public RepositorioUsuario(UsuarioDBContext usuarioDBContext)
        {
            _usuarioDBContext = usuarioDBContext;
        }

        public void Editar(Usuario usuario)
        {
            _usuarioDBContext.Usuario.Update(usuario);
            _usuarioDBContext.SaveChanges();
        }

        public Usuario GetUsuario(int id)
        {
            return _usuarioDBContext.Usuario
                .Include(usuario => usuario.Sexo)
                .Where(x => x.UsuarioId == id).FirstOrDefault();
        }

        public void Excluir(int id)
        {
            _usuarioDBContext.Remove(_usuarioDBContext.Usuario.Find(id));
            _usuarioDBContext.SaveChanges();
        }

        public IEnumerable<Usuario> GetUsuario()
        {
           return  _usuarioDBContext.Usuario.ToList(); 
        }

        public IEnumerable<Usuario> GetUsuario(string nome)
        {
            var usuario = _usuarioDBContext.Usuario
                                           .Include(usuario => usuario.Sexo)
                                           .Where(x => x.Nome.Contains(nome))
                                           .ToList();

            return usuario;
        }

        public void Salvar(Usuario usuario)
        {
            _usuarioDBContext.Add(usuario);
            _usuarioDBContext.SaveChanges();
        }
    }
}
