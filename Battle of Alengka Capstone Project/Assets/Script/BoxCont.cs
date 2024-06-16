using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxCont : MonoBehaviour
{
    public GameObject boxClosed; // GameObject box tertutup
    public GameObject boxOpen; // GameObject box terbuka
    public ScoreManager scoreManager; // Skrip ScoreManager
    public Message submitText;
    private bool isOpen = false; // Status box terbuka atau tertutup

    void Update()
    {
        SubmitItems();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenBox();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CloseBox();
        }
    }

    void OpenBox()
    {
        isOpen = true;
        boxClosed.SetActive(false);
        boxOpen.SetActive(true);
        submitText.ShowMessage("PRESS [F] TO SUBMIT"); 
    }

    void CloseBox()
    {
        isOpen = false;
        boxOpen.SetActive(false);
        boxClosed.SetActive(true);
        submitText.FinishMessage();
    }

    public void SubmitItems()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.F))
        {
            // Serahkan item-item yang dikumpulkan
            scoreManager.SubmitItems();
            CloseBox();
        }
    }
}
