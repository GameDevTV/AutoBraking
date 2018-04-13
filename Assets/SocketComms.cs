using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketComms : MonoBehaviour {

    [SerializeField] string jumpInstruction = "jump";

    LocalSocket localSocket;
    bool isJumpQueued = false;

    private void Start()
    {
        Application.runInBackground = true;
        localSocket = new LocalSocket();
    }

    private void Update()
    {
        LogSpeedToSocket();
        JumpIfAsked();
    }

    private void JumpIfAsked()
    {
        if (!localSocket.isReadyToReceive) { return; }
        if (localSocket.GetLastInstruction().Contains(jumpInstruction))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
            isJumpQueued = false;
        }
    }

    private void LogSpeedToSocket()
    {
        localSocket.SocketLog(
            "Speed at t = : " +
            Time.time +
            " = " +
            GetComponent<Rigidbody>().velocity.z +
            '\n'
        );
    }
}
