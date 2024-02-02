using System;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    // Network architecture parameters
    public int inputNodes;
    public int hiddenNodes;
    public int outputNodes;

    // Learning parameters
    public double learningRate;

    // Weight matrices
    private Matrix weightsInputHidden;
    private Matrix weightsHiddenOutput;

    void Start()
    {
        // Initialize the network with predefined architecture
        InitializeNetwork(inputNodes, hiddenNodes, outputNodes, learningRate);
    }

    private void InitializeNetwork(int input, int hidden, int output, double lr)
    {
        inputNodes = input;
        hiddenNodes = hidden;
        outputNodes = output;
        learningRate = lr;

        // Initialize weight matrices with random values
        weightsInputHidden = new Matrix(hiddenNodes, inputNodes, true);
        weightsHiddenOutput = new Matrix(outputNodes, hiddenNodes, true);
    }

    // Placeholder for forward propagation method
    public double[] Predict(double[] inputsArray)
    {
        // Convert inputs array to matrix
        Matrix inputs = Matrix.FromArray(inputsArray);

        // Generate hidden outputs
        Matrix hidden = Matrix.Multiply(weightsInputHidden, inputs);
        hidden.ApplySigmoid();

        // Generate final output
        Matrix output = Matrix.Multiply(weightsHiddenOutput, hidden);
        output.ApplySigmoid();

        return output.ToArray();
    }


    public void Train(double[] inputsArray, double[] targetsArray)
    {
        // Forward propagation (same as in Predict method)
        Matrix inputs = Matrix.FromArray(inputsArray);
        Matrix hidden = Matrix.Multiply(weightsInputHidden, inputs);
        hidden.ApplySigmoid();
        Matrix outputs = Matrix.Multiply(weightsHiddenOutput, hidden);
        outputs.ApplySigmoid();

        // Convert targets array to matrix
        Matrix targets = Matrix.FromArray(targetsArray);

        // Calculate output layer error (targets - outputs)
        Matrix outputErrors = Matrix.Subtract(targets, outputs);

        // Calculate gradient for weightsHiddenOutput
        outputs.ApplySigmoidDerivative();
        Matrix gradient = Matrix.Hadamard(outputErrors, outputs);
        gradient.Multiply(learningRate);

        // Adjust weights by deltas
        Matrix hidden_T = Matrix.Transpose(hidden);
        Matrix weightHO_deltas = Matrix.Multiply(gradient, hidden_T);
        weightsHiddenOutput.Add(weightHO_deltas);

        // Calculate hidden layer errors
        Matrix weightsHO_T = Matrix.Transpose(weightsHiddenOutput);
        Matrix hiddenErrors = Matrix.Multiply(weightsHO_T, outputErrors);

        // Calculate gradient for weightsInputHidden
        hidden.ApplySigmoidDerivative();
        Matrix hiddenGradient = Matrix.Hadamard(hiddenErrors, hidden);
        hiddenGradient.Multiply(learningRate);

        // Adjust weightsInputHidden by deltas
        Matrix inputs_T = Matrix.Transpose(inputs);
        Matrix weightIH_deltas = Matrix.Multiply(hiddenGradient, inputs_T);
        weightsInputHidden.Add(weightIH_deltas);
    }

        // Constructor or initializer might set the learning rate, for example:
    public NeuralNetwork(int input, int hidden, int output)
    {
        this.learningRate = 0.1; // Example learning rate
        InitializeNetwork(input, hidden, output, this.learningRate);
    }


}

