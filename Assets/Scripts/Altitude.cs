using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class Altitude : MonoBehaviour
{
    [SerializeField]
    ButtonScript button;
    CSV csv;
    GyroScopeData sensorData;

    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI zText;
    public TextMeshProUGUI debugText;

    public List<Vector3> accDataList = new List<Vector3>();
    int filenumber = 1;

    private void Start()
    {
        sensorData = new GyroScopeData(0.03f, 0.07f);
        InputSystem.EnableDevice(Accelerometer.current);
        InputSystem.EnableDevice(AttitudeSensor.current);
        csv = new CSV();
    }

    private void Update()
    {

        SetDebuggingTest();

        if (button.record && !sensorData.IsFlat() && accDataList.Count < 700)
        {
            accDataList.Add(sensorData.RecordAccelrometerValues());
            button.SetButtonText("Recording");
        }
        else if (button.record && sensorData.IsFlat() && accDataList.Count > 0)
        {
            button.record = false;
            csv.WriteCSV("Sensordata" + filenumber, accDataList);
            filenumber++;
            accDataList.Clear();
        }

        if (!button.record)
        {
            button.SetButtonText("Press for Input");
            accDataList.Clear();
        }
    }

    public void SetDebuggingTest()
    {
        if (SystemInfo.supportsGyroscope)
        {
            xText.text = "x:" + AttitudeSensor.current.attitude.ReadValue().x.ToString();
            yText.text = "y:" + AttitudeSensor.current.attitude.ReadValue().y.ToString();
            zText.text = "z:" + AttitudeSensor.current.attitude.ReadValue().z.ToString();
            debugText.text = sensorData.IsFlat().ToString();
        }
    }
}

