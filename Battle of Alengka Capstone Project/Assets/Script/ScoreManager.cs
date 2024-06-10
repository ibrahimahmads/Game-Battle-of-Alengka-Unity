using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI daunText;
    public TextMeshProUGUI kayuText;
    public TextMeshProUGUI batuText;

    private int daunCount = 0;
    private int kayuCount = 0;
    private int batuCount = 0;

    public bool batuIsDone = false;
    public bool kayuIsDone = false;
    public bool daunIsDone = false;

    public void AddScore(ItemCollector.ItemType itemType)
    {
        switch (itemType)
        {
            case ItemCollector.ItemType.Daun:
                daunCount++;
                daunText.text = daunCount + "/1";
                break;
            case ItemCollector.ItemType.Kayu:
                kayuCount++;
                kayuText.text = kayuCount + "/1";
                break;
            case ItemCollector.ItemType.Batu:
                batuCount++;
                batuText.text = batuCount + "/1";
                break;
        }
    }

    public void SubmitItems()
    {
         if (daunCount == 1)
    {
        daunCount = 0;
        daunText.text = "DONE";
        daunIsDone = true;
    }
    
    if(kayuCount == 1)
    {
        kayuCount = 0;
        kayuText.text = "DONE";
        kayuIsDone = true;
    }

    if(batuCount == 1)
    {
        batuCount = 0;
        batuText.text = "DONE";
        batuIsDone = true;
    }       
    }
}
