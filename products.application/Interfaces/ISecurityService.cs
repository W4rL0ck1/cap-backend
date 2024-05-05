namespace Products.Application
{
    public interface ISecurityService
    {
         public string CreateHMACSHA512Hash(string input);
         public bool VerifyHMACSHA512Hash(string input, string hash);
    }
}