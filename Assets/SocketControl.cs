using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.Serialization;
using System.Text;

public class SocketControl : MonoBehaviour
{
    Socket listeningSocket, connectionSocket; // todo use result as "opaque x"
    byte[] buffer = new byte[10];
    bool isJumpQueued = false;

    // Use this for initialization
    void Start()
    {
        listeningSocket = new Socket(
            AddressFamily.InterNetwork, // like the InterNet(work)... see what Sam did there?
            SocketType.Stream,
            ProtocolType.Tcp // not UDP to protect against data loss
        );
        listeningSocket.Bind(new System.Net.IPEndPoint(
            System.Net.IPAddress.Parse("127.0.0.1"),
            5555)
        );
        listeningSocket.Listen(1);

        print("Waiting for connection...");
        var callback = new System.AsyncCallback(OnAcceptConnection);
        listeningSocket.BeginAccept(OnAcceptConnection, null);
        ReceiveBytes();
    }

    void OnAcceptConnection(System.IAsyncResult result)
    {
        print(System.Reflection.MethodBase.GetCurrentMethod().Name + "() called");
        connectionSocket = listeningSocket.EndAccept(result);

        print(connectionSocket);
        connectionSocket.Send(Encoding.ASCII.GetBytes("Connected\n"));
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
        if (connectionSocket == null || !connectionSocket.Connected) { return; }
        connectionSocket.Send(Encoding.ASCII.GetBytes(
            "Speed at t = : " +
            Time.time +
            " = " +
            GetComponent<Rigidbody>().velocity.z +
            '\n'
        ));
    }

    private void ReceiveBytes()
    {
        if (connectionSocket == null) { return; }
        // register async-callback
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

        ReceiveBytes();
    }
}
