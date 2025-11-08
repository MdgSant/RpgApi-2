using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RpgApi.Extensions
{
    public static class ClaimTypesExtension
    {
        public static int UsuarioId(this ClaimsPrincipal user)
        {
            try
            {
                var usuarioId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                return int.Parse(usuarioId);
            }
            catch
            {
                return 0;
            }
        }

    public static string UsuarioPerfil(this ClaimsPrincipal user)
    {
        try
        {
            var UsuarioPerfil = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            return UsuarioPerfil; 
        }
        catch 
        {
          return string.Empty;
        }
    }




    }
}