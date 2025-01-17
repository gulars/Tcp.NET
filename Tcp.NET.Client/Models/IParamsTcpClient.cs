using PHS.Networking.Models;
using System.Security.Cryptography.X509Certificates;

namespace Tcp.NET.Client.Models
{
    public interface IParamsTcpClient : IParams
    {
        byte[] DisconnectBytes { get; }
        byte[] EndOfLineBytes { get; }
        string Host { get; }
        bool IsSSL { get; }
        bool OnlyEmitBytes { get; }
        byte[] PingBytes { get; }
        byte[] PongBytes { get; }
        int Port { get; }
        byte[] Token { get; }
        bool UseDisconnectBytes { get; }
        bool UsePingPong { get; }
        X509CertificateCollection ClientCertificates { get; }
    }
}