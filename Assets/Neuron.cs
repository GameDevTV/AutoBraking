using UnityEngine;

public class Neuron
{
    float bias;
    float weight;
    public enum TransferType { binary, sigmoid }
    TransferType transferType;

    public void SetBias(float bias)
    {
        this.bias = bias;
    }

    public void SetWeight(float weight)
    {
        this.weight = weight;
    }

    public void SetTransferType(TransferType transferType)
    {
        this.transferType = transferType;
    }

    public float GetOutput(float input)
    {
        float product = 1 * bias;
        product += input * weight;
        return Transfer(product, transferType);
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
