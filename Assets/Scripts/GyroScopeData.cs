using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroScopeData
{
    public GyroScopeData(float x, float z)
    {
        xTreshHold = x;
        zTreshHold = z;
    }

    float xTreshHold;
    float zTreshHold;

   
    public bool IsFlat()
    {
        if (AttitudeSensor.current.attitude.ReadValue().x <= xTreshHold && AttitudeSensor.current.attitude.ReadValue().x >= -xTreshHold &&
             AttitudeSensor.current.attitude.ReadValue().z >= -zTreshHold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 RecordAccelrometerValues()
    {
        return Accelerometer.current.acceleration.ReadValue();
    }
}

