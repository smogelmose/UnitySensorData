using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public Button InputButton;
    public Text InputText;
    public bool record = false;

    // Start is called before the first frame update
    private void Start()
    {
        InputButton.onClick.AddListener(SetRecording);
    }

    public void SetRecording()
    {
        record = !record;
    }


    public void SetButtonText(string text)
    {
        InputText.text = text;
    }

}