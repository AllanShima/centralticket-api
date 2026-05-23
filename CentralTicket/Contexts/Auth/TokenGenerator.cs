using CentralTicket.Contexts.Auth.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JetRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace CentralTicket.Contexts.Auth
{
    public class TokenGenerator()
    {
        //public string CreateToken(User user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Name.Value)
        //    };

        //    var key = new SymmetricSecurityKey(
        //        Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
        //}
        //public string GenerateToken(string email)
        //{
        //    // Lógica para gerar um token de autenticação
        //    // Isso pode incluir a criação de um JWT (JSON Web Token) ou outro tipo de token
        //    // O token deve conter informações relevantes, como o ID do usuário, nome, email, etc.
        //    // O token deve ser assinado para garantir sua integridade e autenticidade

        //    // vai gerar o token (string em si) usando a biblioteca JWT
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    // Chave secreta para assinar o token (deve ser mantida em segredo e segura)
        //    var key = "cfmEJwdlEiRu4G6RHQKMqReCAuBUSqF0uk0KSzZs90CpuOjiv4FFwXS0vqhKsrCO"u8.ToArray();

        //    // payload do token, ou seja, as informações que queremos incluir no token
        //    var claims = new List<Claim>
        //    {
        //        new(JetRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único do token
        //        new(JetRegisteredClaimNames.Email, email) // Email do usuário
                
        //    };

        //    // descriptor do token, ou seja, as configurações do token, como o payload (claims) e a chave de assinatura
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddHours(1), // O token expira em 1 hora
        //        Issuer = "CentralTicket", // Emissor do token
        //        Audience = "CentralTicketUsers", // Público-alvo do token
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Configuração de assinatura do token
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o token usando o token handler e o descriptor
        //    return tokenHandler.WriteToken(token); // Retorna o token como uma string
        //}
    }
}
