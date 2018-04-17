using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketControl : MonoBehaviour
{
    [Header("Instruction Strings")]
    [SerializeField] string jump = "jump";
    [SerializeField] string pedal = "pedal";
    [SerializeField] string reset = "reset";
    [SerializeField] string getSpeed = "getSpeed";

    LocalSocket localSocket;
    string lastInstruction, instructionCache;
    bool isJumpQueued = false;

    private void Start()
    {
        Application.runInBackground = true;
        localSocket = new LocalSocket();
    }

    private void Update()
    {
        if (!localSocket.isReadyToReceive) { return; }

        lastInstruction = localSocket.GetLastInstruction();
        if (lastInstruction == instructionCache) { return; }
        instructionCache = lastInstruction;

        EchoSpeedIfAsked();
        JumpIfAsked();
        ProcessPedalCommands();
        ResetIfAsked();
    }

    // todo get reset working properly while keeping session
    private void ResetIfAsked()
    {
        if (localSocket.GetLastInstruction().Contains(reset))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ProcessPedalCommands()
    {
        if (lastInstruction.Contains(pedal))
        {
            instructionCache = lastInstruction;
            string param = lastInstruction.Substring(pedal.Length);
            GetComponent<CarControlWrapper>().SetPedalPos(float.Parse(param));
        }
    }

    private void JumpIfAsked()
    {
        if (localSocket.GetLastInstruction().Contains(jump))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
            isJumpQueued = false;
        }
    }

    private void EchoSpeedIfAsked()
    {
        if (localSocket.GetLastInstruction().Contains(getSpeed))
        {
            localSocket.SocketLog(GetComponent<CarControlWrapper>().GetSpeed().ToString());
        }
    }
}
