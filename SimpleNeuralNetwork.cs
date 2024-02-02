using System;

public class SimpleNeuralNetwork
{
    public int inputNodes;
    public int hiddenNodes;
    public int outputNodes;

    public double[,] weightsInputHidden;
    public double[,] weightsHiddenOutput;

    public double learningRate;

    public SimpleNeuralNetwork(int input, int hidden, int output, double learningRate)
    {
        this.inputNodes = input;
        this.hiddenNodes = hidden;
        this.outputNodes = output;
        this.learningRate = learningRate;

        // Initialize weights to small random values
        weightsInputHidden = InitializeWeights(input, hidden);
        weightsHiddenOutput = InitializeWeights(hidden, output);
    
    }

    private double[,] InitializeWeights(int from, int to)
    {
        double[,] weights = new double[from, to];
        Random rand = new Random();
        for (int i = 0; i < from; i++)
        {
            for (int j = 0; j < to; j++)
            {
                // Assign random weights
                weights[i, j] = rand.NextDouble() * 0.2 - 0.1; // Small random numbers between -0.1 and 0.1
            }
        }
        return weights;
    }

    private double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }

    private double[] ApplySigmoid(double[] inputs)
    {
        double[] outputs = new double[inputs.Length];
        for (int i = 0; i < inputs.Length; i++)
        {
            outputs[i] = Sigmoid(inputs[i]);
        }
        return outputs;
    }

    public double[] Predict(double[] inputs)
    {
        // Convert input array to a matrix (if necessary, depending on your matrix implementation)
        // For simplicity, inputs are directly used here.

        // Forward propagation from input to hidden layer
        double[] hiddenInputs = MultiplyMatrixVector(weightsInputHidden, inputs); // Placeholder for actual matrix-vector multiplication
        double[] hiddenOutputs = ApplySigmoid(hiddenInputs);

        // Forward propagation from hidden to output layer
        double[] finalInputs = MultiplyMatrixVector(weightsHiddenOutput, hiddenOutputs); // Placeholder for actual matrix-vector multiplication
        double[] finalOutputs = ApplySigmoid(finalInputs);

        return finalOutputs;
    }

    private double[] MultiplyMatrixVector(double[,] matrix, double[] vector)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[] result = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            result[i] = 0;
            for (int j = 0; j < cols; j++)
            {
                result[i] += matrix[i, j] * vector[j];
            }
        }
        return result;
    }

    private double SigmoidDerivative(double x)
    {
        return x * (1.0 - x);
    }

    public void Train(double[] inputs, double[] targets)
    {
        // Forward pass
        double[] hiddenInputs = MultiplyMatrixVector(weightsInputHidden, inputs);
        double[] hiddenOutputs = ApplySigmoid(hiddenInputs);

        double[] finalInputs = MultiplyMatrixVector(weightsHiddenOutput, hiddenOutputs);
        double[] finalOutputs = ApplySigmoid(finalInputs);

        // Convert targets array to matrix (if necessary)
        double[] outputErrors = new double[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            outputErrors[i] = targets[i] - finalOutputs[i];
        }

        // Calculating errors for the hidden layer
        double[] hiddenErrors = new double[hiddenOutputs.Length];
        for (int i = 0; i < weightsHiddenOutput.GetLength(1); i++)
        {
            for (int j = 0; j < weightsHiddenOutput.GetLength(0); j++)
            {
                hiddenErrors[i] += weightsHiddenOutput[j, i] * outputErrors[j];
            }
        }

        // Update weights for the layers (Gradient Descent)
        // For weights from hidden to output
        for (int i = 0; i < weightsHiddenOutput.GetLength(0); i++)
        {
            for (int j = 0; j < weightsHiddenOutput.GetLength(1); j++)
            {
                double delta = learningRate * outputErrors[j] * SigmoidDerivative(finalOutputs[j]) * hiddenOutputs[i];
                weightsHiddenOutput[i, j] += delta;
            }
        }

        // For weights from input to hidden
        for (int i = 0; i < weightsInputHidden.GetLength(0); i++)
        {
            for (int j = 0; j < weightsInputHidden.GetLength(1); j++)
            {
                double delta = 0;
                for (int k = 0; k < hiddenErrors.Length; k++)
                {
                    delta += hiddenErrors[k] * SigmoidDerivative(hiddenOutputs[k]) * inputs[i];
                }
                weightsInputHidden[i, j] += learningRate * delta;
            }
        }
    }
}
