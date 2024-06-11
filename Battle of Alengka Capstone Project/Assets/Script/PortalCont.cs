using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCont : MonoBehaviour
{
    public Transform destinasi;
    public float shrinkDuration = 0.5f;   // Durasi mengecil
    public float growDuration = 0.5f;
    GameObject player;
    private Vector3 originalScale;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        originalScale = player.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position)>0.1f)
            {
                StartCoroutine(TeleportPlayer());
            }
        }
    }

    private IEnumerator TeleportPlayer()
    {
         yield return StartCoroutine(ChangeScale(Vector3.zero, shrinkDuration));

        // Memindahkan pemain ke posisi destinasi
        player.transform.position = destinasi.transform.position;

        // Membesarkan pemain kembali ke ukuran semula
        yield return StartCoroutine(ChangeScale(originalScale, growDuration));
    }

    private IEnumerator ChangeScale(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = player.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            t = t * t * (3f - 2f * t);  // Menggunakan interpolasi halus (SmoothStep)
            player.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;  // Tunggu frame berikutnya
        }

        player.transform.localScale = targetScale;  // Pastikan skala tepat di ukuran akhir
    }

}
