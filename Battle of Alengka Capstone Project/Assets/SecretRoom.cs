using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoom : MonoBehaviour
{
    private Tilemap spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<Tilemap>();
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color newColor = originalColor;
            newColor.a = 0f; // Mengatur alpha menjadi 0 untuk membuatnya transparan
            spriteRenderer.color = newColor;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.color = originalColor; // Mengembalikan warna asli
        }
    }
}
