using Infrastructure.Options;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.AuthOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "SmartDeskServer";
        public const string AUDIENCE = "SmartDeskClient";
    }
}
