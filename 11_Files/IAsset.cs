using System.Security.Cryptography.X509Certificates;

namespace _11_Files
{
    public interface IAsset
    {
        double GetValue();
        string GetName();
    }
    
}