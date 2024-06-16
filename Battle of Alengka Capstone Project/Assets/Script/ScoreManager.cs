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
    public TextMeshProUGUI misiBoxIsDone;
    public TextMeshProUGUI misiRumahIsDone;
    public TextMeshProUGUI alert;
    public GameObject misiBox;
    public GameObject misiRumah;

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

        if(daunCount == 1 && kayuCount == 1 && batuCount == 1)
        {
            misiBox.SetActive(true);
            TriggerAlert();
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

        if(CheckMaterials())
        {
            misiBoxIsDone.text = "DONE";
            misiRumah.SetActive(true);
            TriggerAlert();
        }
    }

    private bool CheckMaterials()
    {
        return daunIsDone && kayuIsDone && batuIsDone;
    }

    IEnumerator tampilAlert()
    {
        alert.enabled = true;
        yield return new WaitForSeconds(3f); 
        alert.enabled = false;
    }

    public void TriggerAlert()
    {
        StartCoroutine(tampilAlert());
    }
}
