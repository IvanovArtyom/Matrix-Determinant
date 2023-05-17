using System.Collections.Generic;

public class Matrix
{
    public static void Main()
    {
        var m = new int[][] { new[] { 2, 5, 3 },
                              new[] { 1, -2, -1 },
                              new[] { 1, 3, 4 } 
        };

        // Test
        var t = Determinant(m);
        // ...should return -20
    }

    public static int Determinant(int[][] matrix)
    {
        if (matrix.Length == 1)
            return matrix[0][0];

        int det = 0;

        for (int j = 0; j < matrix.Length; j++)
        {
            int value = matrix[0][j] * Determinant(CalculateMinor(matrix, 0, j));
            det += (j % 2 == 0) ? value : -value;
        }

        return det;
    }

    public static int[][] CalculateMinor(int[][] matrix, int row, int column)
    {
        int[][] minor = new int[matrix.Length - 1][];
        int index = 0;

        for (int i = 0; i < matrix.Length; i++)
        {
            if (i == row)
                continue;

            List<int> line = new();

            for (int j = 0; j < matrix.Length; j++)
            {
                if (j == column)
                    continue;

                line.Add(matrix[i][j]);
            }

            minor[index++] = line.ToArray();
        }

        return minor;
    }
}