using UnityEngine;

public class Neuron
{
    float bias;
    float weight;

    public enum OutputFunction { step, sigmoid }
    OutputFunction outputFunction;

    public struct NeuronSetup
    {
        public OutputFunction outputFunction;
        public float bias;
        public float weight;
    }

    // Constructor
    public Neuron(NeuronSetup setup)
    {
        outputFunction = setup.outputFunction; 
        bias = setup.bias;
        weight = setup.weight;
    }

    public float GetOutput(float input)
    {
        float sum = input * weight;
        sum = sum + bias;
        return CalculateOutput(sum, outputFunction);
    }

    public static float CalculateOutput(float input, OutputFunction outputFunction)
    {
        switch (outputFunction)
        {
        case (OutputFunction.sigmoid):
            {
                return (2 / (1 + Mathf.Exp(-2f * input)) - 1f);
            }
        case (OutputFunction.step):
            {
                return StepFunction(input);
            }
        default:
            {
                Debug.LogError("Unknown parameter");
                return 0;
            }
        }
    }

    private static float StepFunction(float x)
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
