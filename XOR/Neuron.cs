using System;

public class Neuron
{
    double[] weights;
    Synapse[] inputs;
    Synapse output;

    public Neuron(int inputsCount, double[] weights = null)
    {
        inputs = new Synapse[inputsCount];
        if (weights == null) // jeśli nie podamy wag z góry to są one losowane
        {
            weights = new double[inputsCount];
            Random rand = new Random();
            for (int i = 0; i < inputsCount; i++)
            {
                weights[i] = rand.Next(1001) / 10.0; // losowe wagi od 0.0 do 100.0
            }
        }
        else
            this.weights = weights;
        output = new Synapse();
    }

    public void SetInput(int index, Synapse inputSynapse)
    {
        inputs[index] = inputSynapse;
    }

    public void SetInput(int index, Neuron inputNeuron)
    {
        inputs[index] = inputNeuron.output;
    }

    public void Activate()
    {
        double value = 0.0;
        for (int i = 0; i < inputs.Length; i++)
        {
            value += inputs[i].Value * weights[i];
        }
        if (value > 1)
            output.Value = 1;
        else
            output.Value = 0;
    }

    public override string ToString()
    {
        return output.Value.ToString();
    }
}
