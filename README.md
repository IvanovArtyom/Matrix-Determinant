## Description:

Write a function that accepts a square matrix (```N x N``` 2D array) and returns the determinant of the matrix.

How to take the determinant of a matrix -- it is simplest to start with the smallest cases:

A 1x1 matrix ```|a|``` has determinant ```a```.

A 2x2 matrix ```[ [a, b], [c, d] ]``` or
```C#
|a  b|
|c  d|
```
has determinant: ```a*d - b*c```.

The determinant of an ```n x n``` sized matrix is calculated by reducing the problem to the calculation of the determinants of ```n``` matrices of ```n-1 x n-1``` size.

For the 3x3 case, ```[ [a, b, c], [d, e, f], [g, h, i] ]``` or
```C#
|a b c|
|d e f|
|g h i|
```
the determinant is: ```a * det(a_minor) - b * det(b_minor) + c * det(c_minor)```
where ```det(a_minor)``` refers to taking the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:
```C#
|- - -|
|- e f|
|- h i|
```
Note the alternation of signs.

The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row ```[a, b, c, d]```, then:

```det(M) = a * det(a_minor) - b * det(b_minor) + c * det(c_minor) - d * det(d_minor)```
### My solution:
```C#
using System.Collections.Generic;

public class Matrix
{
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
```
