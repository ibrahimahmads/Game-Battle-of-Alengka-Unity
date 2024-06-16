using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcievementBase : MonoBehaviour
{
    public int achievementCH = 0;
    public Message message;
    void Update()
    {

    }

    public virtual void Unlock()
    {
        GameManager.instance.achievement[achievementCH-1] = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           message.ShowMessage("PREES \"F\" TO TAKE");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            message.FinishMessage();
        }
    }
}
