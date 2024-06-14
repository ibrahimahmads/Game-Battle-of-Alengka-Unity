using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCMESSAGE : MonoBehaviour
{
    public Canvas bubbleChatCanvas; // Assign this in the inspector
    public TextMeshProUGUI bubbleChatText; // Assign this in the inspector
    public float displayDuration = 3.0f; // Duration the bubble chat is displayed

    private bool isChatActive = false;
    private float timer = 0.0f;

    void Start()
    {
        // Ensure the bubble chat is initially inactive
        bubbleChatCanvas.gameObject.SetActive(false);
        ShowBubbleChat("AKU INGIN KIJANG ITU RAMA");
    }

    void Update()
    {
        if (isChatActive )
        {
            timer += Time.deltaTime;
            if (timer >= displayDuration)
            {
                
                HideBubbleChat();
                Destroy(this);
            }
        }

        // Keep the bubble chat above the NPC
        Vector3 npcPosition = transform.position;
        if(bubbleChatCanvas != null)
        {
            bubbleChatCanvas.transform.position = npcPosition + Vector3.up * 2.0f; // Adjust the offset as needed
            bubbleChatCanvas.transform.forward = Camera.main.transform.forward; // Ensure the bubble chat faces the camera
        }

    }

    void ShowBubbleChat(string message)
    {
        bubbleChatText.text = message;
        bubbleChatCanvas.gameObject.SetActive(true);
        isChatActive = true;
        
    }

    void HideBubbleChat()
    {
        Destroy(bubbleChatCanvas.gameObject); 
        isChatActive = false;
    }


}
