using PHS.Networking.Utilities;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tcp.NET.Client.Models
{
    public class ParamsTcpClient : IParamsTcpClient
    {
        public string Host { get; protected set; }
        public int Port { get; protected set; }
        public byte[] EndOfLineBytes { get; protected set; }
        public bool UsePingPong { get; protected set; }
        public byte[] PingBytes { get; protected set; }
        public byte[] PongBytes { get; protected set; }
        public bool IsSSL { get; protected set; }
        public bool OnlyEmitBytes { get; protected set; }
        public byte[] Token { get; protected set; }
        public bool UseDisconnectBytes { get; protected set; }
        public byte[] DisconnectBytes { get; protected set; }
        public X509CertificateCollection ClientCertificates { get; protected set; }

        public ParamsTcpClient(string host, int port, string endOfLineCharacters, string token = "", bool isSSL = true, bool onlyEmitBytes = false, bool usePingPong = true, string pingCharacters = "ping", string pongCharacters = "pong", bool useDisconnectBytes = true, byte[] disconnectBytes = null, X509CertificateCollection clientCertificates = null)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException("Host is not valid");
            }

            if (port <= 0)
            {
                throw new ArgumentException("Port is not valid");
            }

            if (string.IsNullOrEmpty(endOfLineCharacters))
            {
                throw new ArgumentException("End of Line Characters are not valid");
            }

            if (usePingPong && string.IsNullOrEmpty(pingCharacters))
            {
                throw new ArgumentException("Ping Characters are not valid");
            }

            if (usePingPong && string.IsNullOrEmpty(pongCharacters))
            {
                throw new ArgumentException("Pong Characters are not valid");
            }

            Host = host;
            Port = port;
            EndOfLineBytes = Encoding.UTF8.GetBytes(endOfLineCharacters);
            UsePingPong = usePingPong;
            PingBytes = Encoding.UTF8.GetBytes(pingCharacters);
            PongBytes = Encoding.UTF8.GetBytes(pongCharacters);
            IsSSL = isSSL;
            OnlyEmitBytes = onlyEmitBytes;
            UseDisconnectBytes = useDisconnectBytes;
            DisconnectBytes = disconnectBytes;
            ClientCertificates = clientCertificates;

            if (!string.IsNullOrWhiteSpace(token))
            {
                Token = Encoding.UTF8.GetBytes(token);
            }

            if (UseDisconnectBytes && (DisconnectBytes == null || Statics.ByteArrayEquals(DisconnectBytes, Array.Empty<byte>())))
            {
                DisconnectBytes = new byte[] { 3 };
            }
        }
    }
}
