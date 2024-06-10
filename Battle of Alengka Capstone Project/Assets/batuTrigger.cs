using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batuTrigger : MonoBehaviour
{
    public GameObject rockPrefab; // Prefab batu yang akan muncul
    public Transform spawnPoint;  // Titik awal munculnya batu
    public float throwForce = 10f; // Kekuatan lemparan batu
    public float destroyDelay = 2f;
    public float secondRockOffset = 1f;
    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            SpawnAndThrowRock();
        }
    }

    void SpawnAndThrowRock()
    {
        // Membuat batu di titik spawn
        GameObject rock = Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);
        Vector3 secondRockPosition = spawnPoint.position + new Vector3(secondRockOffset, 0, 0);
        GameObject rock2 = Instantiate(rockPrefab, secondRockPosition, Quaternion.identity);
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = rock2.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Debug.Log("Applying force to rock.");

            // Memberikan kekuatan ke atas pada batu
            rb.AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);
            rb2.AddForce(Vector2.up * (throwForce-2), ForceMode2D.Impulse);

            Destroy(rock, destroyDelay);
            Destroy(rock2, destroyDelay);
        }else
        {
            // Menambahkan log untuk debug
            Debug.LogError("Rigidbody2D not found on rock.");
        }
    }
}
