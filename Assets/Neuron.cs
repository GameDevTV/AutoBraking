using UnityEngine;

public class Neuron
{
    float bias;
    float weight;

    public enum TransferType { binary, sigmoid }
    TransferType transferType;

    public Neuron(TransferType transferType, float bias, float weight)
    {
        this.transferType = transferType; 
        this.bias = bias;
        this.weight = weight;
    }

    public float GetOutput(float input)
    {
        float sum = input * weight;
        sum = sum + bias;
        return Transfer(sum, transferType);
    }

    public static float Transfer(float x, TransferType transferType)
    {
        if (transferType == TransferType.sigmoid)
        {
            return (2 / (1 + Mathf.Exp(-2f * x)) - 1f);
        }

        if (transferType == TransferType.binary)
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

        else
        {
            Debug.LogError("Unknown transfer type"); // todo de-yuck
            return 0;
        }
    }
}
