using System;

namespace XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B;
            while (true)
            {
                A = Int32.Parse(Console.ReadLine());
                B = Int32.Parse(Console.ReadLine());
                // Sieć składa się z trzech neuronów tak jak w przykładzie: https://www.youtube.com/watch?v=AuEz4Ul9tHM
                Neuron left, right, output;
                left = new Neuron(2, new double[] { 0.6, 0.6 });
                right = new Neuron(2, new double[] { 1.1, 1.1 });
                output = new Neuron(2, new double[] { -2, 1.1 });
                // Dwie liczby wejściowe od użytkownika są podawane jako synapsy
                Synapse inputA = new Synapse(A);
                Synapse inputB = new Synapse(B);
                // Budowa sieci poprzez połączenie poszczególnych neuronów
                left.SetInput(0, inputA);
                left.SetInput(1, inputB);
                right.SetInput(0, inputA);
                right.SetInput(1, inputB);
                output.SetInput(0, left);
                output.SetInput(1, right);
                // Aktywacja neuronów
                left.Activate();
                right.Activate();
                output.Activate();
                Console.WriteLine("Wynik: " + output);
            }
        }
    }
}
