using Compartido.DTOs.UsuarioDTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {

        public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Usuario(usuarioDTO.Nombre, usuarioDTO.Apellido, usuarioDTO.Email, usuarioDTO.Contrasenia, usuarioDTO.Rol);
        }

        public static List<MostrarUsuarioDTO> UsuarioDTOFromUsuario(List<Usuario> usuarios)
        {
            List<MostrarUsuarioDTO> mostrarUsuariosDTO = new List<MostrarUsuarioDTO>();

            foreach (Usuario u in usuarios)
            {
                MostrarUsuarioDTO mostrarUsuarioDTO = new MostrarUsuarioDTO()
                {
                    Id = u.Id,
                    Nombre = u.Nombre.Valor,
                    Apellido = u.Apellido,
                    Email = u.Email.Valor,
                    Contrasenia = u.Contrasenia.Valor,
                    Rol = u.Rol,
                    Estado = u.Estado
                };
                mostrarUsuariosDTO.Add(mostrarUsuarioDTO);
            }
            return mostrarUsuariosDTO;
        }

        public static UsuarioEnteroDTO UsuarioToUsuarioEnteroDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                UsuarioEnteroDTO usuarioEnteroDTO = new UsuarioEnteroDTO()
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre.Valor,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email.Valor,
                    Contrasenia = usuario.Contrasenia.Valor,
                    Rol = usuario.Rol,
                    Estado = usuario.Estado
                };
                return usuarioEnteroDTO;
            }
            else
            {
                throw new UsuarioException("Credenciales Incorrectas");
            }
        }

        public static MostrarUsuarioDTO UsuarioToMostrarUsuarioDTO(Usuario usuario)
        {
            MostrarUsuarioDTO usuarioDTO = new MostrarUsuarioDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre.Valor,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Contrasenia = usuario.Contrasenia.Valor,
                Rol = usuario.Rol,
                Estado = usuario.Estado
            };
            return usuarioDTO;
        }

        public static Usuario UsuarioFromMostrarUsuarioDTO(MostrarUsuarioDTO mostrarUsuarioDTO)
        {
            if (mostrarUsuarioDTO == null)
            {
                throw new ArgumentException("Datos incorrectos");
            }
            return new Usuario(
                mostrarUsuarioDTO.Nombre,
                mostrarUsuarioDTO.Apellido,
                mostrarUsuarioDTO.Email,
                mostrarUsuarioDTO.Contrasenia,
                mostrarUsuarioDTO.Rol
                );
        }
    }
}
