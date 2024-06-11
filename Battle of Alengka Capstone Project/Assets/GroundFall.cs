using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;

    public float shakeDuration = 0.5f;  // Durasi getaran
    public float shakeMagnitude = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;  // Awalnya, ground tidak akan bergerak
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            StartCoroutine(ShakeAndFall()); // Menambahkan delay 0.5 detik sebelum jatuh
        }
    }

    IEnumerator ShakeAndFall()
    {
        Vector3 originalPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);

            elapsedTime += Time.deltaTime;
            yield return null;  // Tunggu frame berikutnya
        }

        transform.position = originalPosition;  // Kembalikan posisi awal
        rb.isKinematic = false;  // Mengizinkan ground untuk jatuh
    }
}
