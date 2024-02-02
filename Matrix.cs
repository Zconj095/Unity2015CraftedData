using System;

public class Matrix
{
    public int rows;
    public int cols;
    public double[,] data;

    public Matrix(int rows, int cols, bool isRandom)
    {
        this.rows = rows;
        this.cols = cols;
        data = new double[rows, cols];

        if (isRandom)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = UnityEngine.Random.Range(-1f, 1f); // Using Unity's Random for range
                }
            }
        }
    }

    // Add methods for matrix operations here
    public void ApplySigmoid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                data[i, j] = 1 / (1 + Math.Exp(-data[i, j]));
            }
        }
    }

    public static Matrix Subtract(Matrix a, Matrix b)
    {
        // Assume a and b are the same size
        Matrix result = new Matrix(a.rows, a.cols, false);
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                result.data[i, j] = a.data[i, j] - b.data[i, j];
            }
        }
        return result;
    }

    public void Multiply(Matrix m)
    {
        // Hadamard product
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this.data[i, j] *= m.data[i, j];
            }
        }
    }

    public void ApplySigmoidDerivative()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double value = data[i, j];
                data[i, j] = value * (1 - value); // Derivative of sigmoid
            }
        }
    }

    // Convert an array to a Matrix
    public static Matrix FromArray(double[] array)
    {
        Matrix result = new Matrix(array.Length, 1, false);
        for (int i = 0; i < array.Length; i++)
        {
            result.data[i, 0] = array[i];
        }
        return result;
    }

    // Convert a Matrix to an array
    public double[] ToArray()
    {
        double[] array = new double[this.rows];
        for (int i = 0; i < this.rows; i++)
        {
            array[i] = this.data[i, 0];
        }
        return array;
    }

    // Add two matrices
    public void Add(Matrix m)
    {
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                this.data[i, j] += m.data[i, j];
            }
        }
    }

    // Element-wise multiplication (Hadamard product)
    public static Matrix Hadamard(Matrix a, Matrix b)
    {
        Matrix result = new Matrix(a.rows, a.cols, false);
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                result.data[i, j] = a.data[i, j] * b.data[i, j];
            }
        }
        return result;
    }

    // Transpose a matrix
    public static Matrix Transpose(Matrix m)
    {
        Matrix result = new Matrix(m.cols, m.rows, false);
        for (int i = 0; i < m.rows; i++)
        {
            for (int j = 0; j < m.cols; j++)
            {
                result.data[j, i] = m.data[i, j];
            }
        }
        return result;
    }

    // Multiply learning rate
    public void Multiply(double scalar)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this.data[i, j] *= scalar;
            }
        }
    }

    // Static method to multiply two matrices
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.cols != b.rows)
        {
            throw new Exception("Matrix dimensions do not match for multiplication");
        }

        Matrix result = new Matrix(a.rows, b.cols, false);
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.cols; k++)
                {
                    sum += a.data[i, k] * b.data[k, j];
                }
                result.data[i, j] = sum;
            }
        }
        return result;


    }
}
