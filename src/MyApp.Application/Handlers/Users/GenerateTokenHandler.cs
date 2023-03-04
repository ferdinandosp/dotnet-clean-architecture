using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApp.Application.Handlers.Users;

public class GenerateTokenHandler
  : IRequestHandler<GenerateTokenHandlerRequest, GenerateTokenHandlerResponse>
{
    private readonly string _issuer;
    private readonly string _key;

    public GenerateTokenHandler(IConfiguration configuration)
    {
        _issuer = configuration["Jwt:Issuer"]!;
        _key = configuration["Jwt:Key"]!;
    }

    public Task<GenerateTokenHandlerResponse> Handle(GenerateTokenHandlerRequest request, CancellationToken cancellationToken)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, request.EmailAddress),
            new Claim(ClaimTypes.Role, request.UserRole.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _issuer,
            _issuer,
            claims,
            expires: DateTime.Now.AddMinutes(request.ExpiryInMinutes),
            signingCredentials: creds);

        return Task.FromResult(
            new GenerateTokenHandlerResponse(
                new JwtSecurityTokenHandler().WriteToken(token)));
    }
}