using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI Text;

    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowMessage(string x)
    {
        Text.enabled = true;
        Text.text = x;
    }

    public void FinishMessage()
    {
        Text.enabled = false;
    }
}
