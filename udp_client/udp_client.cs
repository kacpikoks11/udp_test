using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPClient
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Type text to send:");
            string? input = Console.ReadLine();
            if (input == null)
                throw new Exception("No input");
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.1.255"); // 127.0.0.1 - loopback - do siebie, 192.168.1.255 - broadcast

            byte[] sendbuf = Encoding.ASCII.GetBytes(input);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            s.SendTo(sendbuf, ep);

            Console.WriteLine("Message sent to the broadcast address");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}