using System;

namespace Mathematic
{
    //My own NN class
    public class NeuralNetwork
    {
        int inputSize;
        int hiddenSize;
        int outputSize;

        public double[,] weights1 = null;
        public double[,] weights2 = null;

        public double[,] bias1 = null;
        public double[,] bias2 = null;

        public double J { get; set; }

        public NeuralNetwork(int inputLayer, int hiddenLayer, int outputLayer)
        {
            inputSize = inputLayer;
            hiddenSize = hiddenLayer;
            outputSize = outputLayer;

            weights1 = Matrix.Random(inputSize, hiddenSize);
            weights2 = Matrix.Random(hiddenSize, outputSize);

            bias1 = Matrix.Random(1, hiddenLayer);
            bias2 = Matrix.Random(1, outputLayer);
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double[,] Predict(double[,] input)
        {
            double[,] H = Matrix.Multiply(input, weights1);
            H = Matrix.Add(H, bias1);
            double[,] OutH = Matrix.f(H, Sigmoid);

            double[,] O = Matrix.Multiply(OutH, weights2);
            O = Matrix.Add(O, bias2);
            double[,] OutO = Matrix.f(O, Sigmoid);

            return OutO;
        }

        public void Mutate(Func<Double, Double> func)
        {
            weights1 = Matrix.f(weights1, func);
            weights2 = Matrix.f(weights2, func);
        }
    }
}