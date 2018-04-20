using UnityEngine;

public class Neuron
{
    float bias;
    float weight1;
    float weight2;

    public enum OutputFunction { step, sigmoid }
    OutputFunction outputFunction;

    public struct NeuronSetup
    {
        public OutputFunction outputFunction;
        public float bias;
        public float weight;
        public float weight2;
    }

    // Constructor
    public Neuron(NeuronSetup setup)
    {
        outputFunction = setup.outputFunction; 
        bias = setup.bias;
        weight1 = setup.weight;
        weight2 = setup.weight2;
    }

    public float GetOutput(float input, float input2)
    {
        float sum = input * weight1;
        sum += input2 * weight2;
        sum += bias;
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
