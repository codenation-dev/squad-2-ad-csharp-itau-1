using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CentralErros.Test
{
    public static class FakeUserClaims
    {
        public static ClaimsPrincipal GerarUsuarioPadraoParaContexto()
        {
            return new ClaimsPrincipal(
                    new List<ClaimsIdentity>()
                    {
                        new ClaimsIdentity(
                            new List<Claim>()
                            {
                                new Claim("id", Guid.NewGuid().ToString()),
                                new Claim("Roles", "usuario") //usuario ou user?
                            }
                        )}
                    );
        }
        public static ClaimsPrincipal GerarUsuarioAdminParaContexto()
        {
            return new ClaimsPrincipal(
                     new List<ClaimsIdentity>()
                     {
                        new ClaimsIdentity(
                            new List<Claim>()
                            {
                                new Claim("id", Guid.NewGuid().ToString()),
                                new Claim("Roles", "usuario") //problemas aqui?
                            }
                        )}
                     );
        }
    }
}
