using System.Security.Claims;

namespace ChurchManagementApi.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetChurchUserId(this ClaimsPrincipal claimsPrincipal)
        {
            Claim nameIdentifier = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return Guid.Parse(nameIdentifier.Value);
        }
    }
}
