using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.Serialization;
using System.Text;

public class SocketControl : MonoBehaviour
{

    Socket connectionSocket;
    byte[] buffer = new byte[10];
    bool isJumpQueued = false;

    // Use this for initialization
    void Start()
    {
        Socket listeningSocket = new System.Net.Sockets.Socket(
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
        connectionSocket = listeningSocket.Accept(); // initialise socket todo make a-sync
        connectionSocket.Send(Encoding.ASCII.GetBytes("I'm alive!\n"));

        ReceiveBytes();
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
