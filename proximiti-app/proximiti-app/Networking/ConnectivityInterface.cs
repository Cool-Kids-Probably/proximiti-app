using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace proximiti.Networking
{
    interface ConnectivityInterface
    {
        async Task<int> Send(String[] args, Byte[] data)
        {
            
        }

    }
}
