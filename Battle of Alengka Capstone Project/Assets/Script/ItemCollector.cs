using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public enum ItemType { Daun, Kayu, Batu }
    public ItemType itemType;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            switch (itemType)
            {
                case ItemType.Daun:
                    scoreManager.AddScore(ItemType.Daun);
                    break;
                case ItemType.Kayu:
                    scoreManager.AddScore(ItemType.Kayu);
                    break;
                case ItemType.Batu:
                    scoreManager.AddScore(ItemType.Batu);
                    break;
            }
            Destroy(gameObject);
        }
    }
}

