using System;

namespace SockInDark
{
    class Program
    {
        static void Main(string[] args)
        {
            SockFinderSim sockFinder = new SockFinderSim();
            sockFinder.SuffileSocks(10, 6, 4);
            sockFinder.BlindSockSelection();
        }
    }
}
