using ITBIT.CORE.DTO;
using ITBIT.CORE.Entidades;
using ITBIT.CORE.Repositorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ITBIT.CORE.Servico
{
    public class ServicoUsuario : IServicoUsuario
    {

        private IRepositorioUsuario _repositorioUsuario;

        private IRepositorioSexo _repositorioSexo;

        public ServicoUsuario(IRepositorioUsuario repositoriousuario, IRepositorioSexo repositorioSexo)
        {
            _repositorioUsuario = repositoriousuario;
            _repositorioSexo    = repositorioSexo;
        }
        
        
        public void Editar(int idUsuario)
        {

            var usuario = _repositorioUsuario.GetUsuario(idUsuario);

            if (usuario.Status == true)
            {
                usuario.Status  = false;
            }
            else
            {
                usuario.Status = true;
            }

           _repositorioUsuario.Editar(usuario);
        }

        public UsuarioResponse GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioResponse> GetUsuario(string nome)
        {
            var usuario = _repositorioUsuario.GetUsuario(nome);

            return usuario.Select(x => new UsuarioResponse
            {
                UsuarioId      = x.UsuarioId,
                Nome           = x.Nome,
                DataNascimento = x.DataNascimento,
                Senha          = x.Senha,
                Email          = x.Email,    
                SexoId         = x.Sexo.SexoId,
                Sexo           = x.Sexo.Descricao,
                Status         = x.Status == true ? "Ativo" : "Inativo"

            }).ToList();
           
        }

        public void Salvar(UsuarioRequest usuarioRequest)
        {
            var sexo = _repositorioSexo.GetSexo(usuarioRequest.SexoId);
           
            var usuario = new Usuario(usuarioRequest.Nome, usuarioRequest.DataNascimento,
                usuarioRequest.Senha,usuarioRequest.Email, sexo);

            _repositorioUsuario.Salvar(usuario);
        }

        public IEnumerable<UsuarioResponse> GetUsuario()
        {
            var usuario = _repositorioUsuario.GetUsuario();

            return usuario.Select(x => new UsuarioResponse
            {
                UsuarioId      = x.UsuarioId,
                Nome           = x.Nome,
                DataNascimento = x.DataNascimento,
                Senha          = x.Senha,
                Email          = x.Email,
                SexoId         = x.Sexo.SexoId,
                Sexo           = x.Sexo.Descricao,
                Status         = x.Status == true ? "Ativo" : "Inativo"
            }).ToList();
        }

        public void Editar(UsuarioRequest usuarioRequest)
        {
            var usuario = _repositorioUsuario.GetUsuario(usuarioRequest.UsuarioId);

            usuario.Nome           = usuarioRequest.Nome;
            usuario.DataNascimento = usuarioRequest.DataNascimento;
            usuario.Email          = usuarioRequest.Email;
            usuario.Senha          = usuario.Senha;
            usuario.Status         = usuarioRequest.Status == 1 ? true : false;
            usuario.Sexo           = _repositorioSexo.GetSexo(usuarioRequest.SexoId);
        
            _repositorioUsuario.Editar(usuario);
        }

        public void Excluir(int id)
        {
            _repositorioUsuario.Excluir(id);
        }
    }
}
