using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class LocalSocket
{
    public bool isReadyToReceive = false;

    Socket listeningSocket = new Socket(
            AddressFamily.InterNetwork, // like the InterNet(work)... see what Sam did there?
            SocketType.Stream,
            ProtocolType.Tcp // not UDP to protect against data loss
        );
    Socket connectionSocket; // todo use result as "opaque x" per Sam?
    byte[] buffer = new byte[10];
    string lastInstruction; // todo consdier callback

    const int PORT = 5555;

    public LocalSocket()
    {
        RegisterConnectionAcceptCallback();
    }

    private void RegisterConnectionAcceptCallback()
    {
        listeningSocket.Bind(new IPEndPoint(IPAddress.Loopback,PORT));
        listeningSocket.Listen(1);
        Debug.Log("Waiting for localHost connection on port " + PORT + "...");
        listeningSocket.BeginAccept(new System.AsyncCallback(OnAcceptConnection), null);
    }

    void OnAcceptConnection(System.IAsyncResult result)
    {
        Debug.Log("Socket connected");
        connectionSocket = listeningSocket.EndAccept(result);
        connectionSocket.Send(Encoding.ASCII.GetBytes("Connected to simulator\n"));
        BeginReceive();
    }

    public void SocketLog(string logText)
    {
        if (connectionSocket == null || !connectionSocket.Connected) { return; } // todo
        connectionSocket.Send(Encoding.ASCII.GetBytes(logText));
    }

    public string GetLastInstruction() // TODO delegate?
    {
        return lastInstruction;
    }

    private void BeginReceive()
    {
        connectionSocket.BeginReceive(
            buffer,
            0,
            buffer.Length,
            SocketFlags.None,
            OnReceipt,
            null
        );
    }

    private void OnReceipt(System.IAsyncResult result)
    {
        isReadyToReceive = true; // TODO delegate?
        var bytesOut = connectionSocket.EndReceive(result); // to be tidy AND to get result length
        lastInstruction = Encoding.ASCII.GetString(buffer, 0, bytesOut); // only print recent result length
        BeginReceive();
    }
}
