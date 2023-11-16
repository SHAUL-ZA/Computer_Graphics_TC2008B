/*
Functions to work with transformation matrices in 3D

Gilberto Echeverria
2022-11-03
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enumeration to define the axis
public enum AXIS {X, Y, Z};
// Values:        0  1  2

public class HW_Transforms : MonoBehaviour
{
    public static Matrix4x4 TranslationMat(float tx, float ty, float tz)
    {
    
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 3] = tx;
        matrix[1, 3] = ty;
        matrix[2, 3] = tz;
        return matrix;
    }

    public static Matrix4x4 ScaleMat(float sx, float sy, float sz)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = sx;
        matrix[1, 1] = sy;
        matrix[2, 2] = sz;
        return matrix;
    }

    public static Matrix4x4 RotateMat(float angle, AXIS axis)
    {
        float rads = angle * Mathf.Deg2Rad;
        float sinTheta = Mathf.Sin(rads);
        float cosTheta = Mathf.Cos(rads);

        Matrix4x4 matrix = Matrix4x4.identity;
        if (axis == AXIS.X) {
            matrix[0,0] = 1; //first row, first column
            matrix[0,1] = 0; //first row, second column
            matrix[0,2] = 0; //first row, third column
            matrix[1,0] = 0; //second row, first column
            matrix[1,1] = cosTheta; //second row, second column
            matrix[1,2] = -sinTheta; //second row, third column
            matrix[2,0] = 0; //third row, first column
            matrix[2,1] = sinTheta; //third row, second column
            matrix[2,2] = cosTheta; //third row, third column
        } else if (axis == AXIS.Y) {
            matrix[0,0] = cosTheta; //first row, first column
            matrix[0,1] = 0; //first row, second column
            matrix[0,2] = sinTheta; //first row, third column
            matrix[1,0] = 0; //second row, first column
            matrix[1,1] = 1; //second row, second column
            matrix[1,2] = 0; //second row, third column
            matrix[2,0] = -sinTheta; //third row, first column
            matrix[2,1] = 0; //third row, second column
            matrix[2,2] = cosTheta; //third row, third column

        } else if (axis == AXIS.Z) {
           matrix[0,0] = cosTheta;
           matrix[0,1] = -sinTheta;
           matrix[0,1] = sinTheta;
           matrix[1,1] = cosTheta;

        }
        return matrix;
    }
}
