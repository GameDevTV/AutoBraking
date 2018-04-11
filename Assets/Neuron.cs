using UnityEngine;

public class Neuron
{
    float bias;
    float weight;

    public enum TransferType { binary, sigmoid }
    TransferType transferType;

    public struct NeuronSetup
    {
        public TransferType transferType;
        public float bias;
        public float weight;
    }

    // Constructor
    public Neuron(NeuronSetup setup)
    {
        transferType = setup.transferType; 
        bias = setup.bias;
        weight = setup.weight;
    }

    public float GetOutput(float input)
    {
        float sum = input * weight;
        sum = sum + bias;
        return Transfer(sum, transferType);
    }

    public static float Transfer(float x, TransferType transferType)
    {
        switch (transferType)
        {
            case (TransferType.sigmoid):
                {
                    return (2 / (1 + Mathf.Exp(-2f * x)) - 1f);
                }
            case (TransferType.binary):
                {
                    return BinaryTransfer(x);
                }
            default:
                {
                    Debug.LogError("Unknown transfer type");
                    return 0;
                }
        }
    }

    private static float BinaryTransfer(float x)
    {
        if (x < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
