using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Net;
using System.Diagnostics;
using System.Drawing;


namespace ProcessMonitorOSA
{
    class NetworkInfo
    {
        private static List<TcpProcessRecord> TcpActiveConnections = null;
        private static List<UdpProcessRecord> UdpActiveConnections = null;
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int pdwSize,
    bool bOrder, int ulAf, TcpTableClass tableClass, uint reserved = 0);

        // The GetExtendedUdpTable function retrieves a table that contains a list of
        // UDP endpoints available to the application. Decorating the function with
        // DllImport attribute indicates that the attributed method is exposed by an
        // unmanaged dynamic-link library 'iphlpapi.dll' as a static entry point.
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int pdwSize,
            bool bOrder, int ulAf, UdpTableClass tableClass, uint reserved = 0);


    }
}
