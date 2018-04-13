using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SocketControl : MonoBehaviour
{
    Socket listeningSocket = new Socket(
            AddressFamily.InterNetwork, // like the InterNet(work)... see what Sam did there?
            SocketType.Stream,
            ProtocolType.Tcp // not UDP to protect against data loss
        );
    Socket connectionSocket; // todo use result as "opaque x" per Sam?
    byte[] buffer = new byte[10];
    bool isJumpQueued = false;

    const int PORT = 5555;

    void Start()
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

    void OnReceipt(System.IAsyncResult result)
    {
        var bytesOut = connectionSocket.EndReceive(result); // to be tidy AND to get result length
        var instruction = Encoding.ASCII.GetString(buffer, 0, bytesOut); // only print recent result length

        if (instruction.Contains("jump"))
        {
            isJumpQueued = true;
        }

        BeginReceive();
    }

    private void Update()
    {
        PrintSpeed();
        if (isJumpQueued)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
            isJumpQueued = false;
        }
    }

    void PrintSpeed()
    {
        if (connectionSocket == null || !connectionSocket.Connected) { return; } // todo
        connectionSocket.Send(Encoding.ASCII.GetBytes(
            "Speed at t = : " +
            Time.time +
            " = " +
            GetComponent<Rigidbody>().velocity.z +
            '\n'
        ));
    }
}
