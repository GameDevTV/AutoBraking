using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketControl : MonoBehaviour
{
    [SerializeField] string jumpInstruction = "jump";
    [SerializeField] string pedalInstruction = "pedal";
    [SerializeField] string resetInstruction = "reset";

    LocalSocket localSocket;
    string instructionCache;
    bool isJumpQueued = false;

    private void Start()
    {
        Application.runInBackground = true;
        localSocket = new LocalSocket();
    }

    private void Update()
    {
        //LogSpeedToSocket();
        if (!localSocket.isReadyToReceive) { return; }
        JumpIfAsked();
        ProcessPedalCommands();
        ResetIfAsked();
    }

    // todo get reset working properly while keeping session
    private void ResetIfAsked()
    {
        if (localSocket.GetLastInstruction().Contains(resetInstruction))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ProcessPedalCommands()
    {
        var lastInstruction = localSocket.GetLastInstruction();
        if (lastInstruction.Contains(pedalInstruction) && lastInstruction != instructionCache)
        {
            instructionCache = lastInstruction;
            string param = lastInstruction.Substring(pedalInstruction.Length);
            GetComponent<CarControlWrapper>().SetPedalPos(float.Parse(param));
        }
    }

    private void JumpIfAsked()
    {
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
            GetComponent<Rigidbody>().velocity.z
        );
    }
}
