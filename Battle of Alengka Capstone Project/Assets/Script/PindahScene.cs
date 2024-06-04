using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahScene : MonoBehaviour
{
    public GameObject dialogPanel;
    private void Start()
    {
        if (dialogPanel != null)
        {
            dialogPanel.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktifkan panel dialog
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(true);
            }
        }
    }
}
