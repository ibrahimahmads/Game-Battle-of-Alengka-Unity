using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HouseCont : MonoBehaviour
{
    public GameObject housePrefab; // Prefab house yang akan dibuat
    public GameObject door;
    public GameObject hintMisi;
    public Message message;
    public Transform buildPoint; // Titik di mana rumah akan dibangun
    private bool isPlayerInRange = false; // Apakah player dalam jangkauan trigger
    private bool isBuilding = false; // Apakah proses pembangunan sedang berlangsung
    public bool isDoneBuild = false;

    void Update()
    {
        BangunRumah();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            message.ShowMessage("PRESS F TO BUILD");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            message.FinishMessage();
        }
    }

    public void BangunRumah()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F) && !isBuilding)
        {
            if (CheckMaterials())
            {
                StartCoroutine(BuildHouse());
                if(isDoneBuild)
                {
                    message.ShowMessage("DONE");
                    hintMisi.SetActive(true);
                }
            }
            else
            {
                StartCoroutine(tampilWarning());
            }
        }
    }

    private bool CheckMaterials()
    {
        // Kembalikan nilai true jika semua bahan sudah terkumpul
        return FindObjectOfType<ScoreManager>().daunIsDone && FindObjectOfType<ScoreManager>().kayuIsDone && FindObjectOfType<ScoreManager>().batuIsDone;
    }

    IEnumerator tampilWarning()
    {

        message.ShowMessage("MATERIAL BELUM TERKUMPUL SEMUA");
        yield return new WaitForSeconds(1.5f); 
        message.ShowMessage("PRESS F TO BUILD");
    }

    IEnumerator BuildHouse()
    {
        isBuilding = true;
        isDoneBuild = true;
        // Tampilkan animasi pembuatan rumah (animasi pada HouseTrigger)
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Build"); // Pastikan ada parameter trigger "Build" di Animator
        message.FinishMessage();

        // Tunggu selama animasi pembuatan rumah (sesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(0.7f); // Ubah waktu sesuai dengan durasi animasi Anda

        // Buat rumah di titik buildPoint
        GameObject newHouse = Instantiate(housePrefab, buildPoint.position, Quaternion.identity);
        newHouse.transform.position = new Vector3(223.358f, 2.87f, buildPoint.position.z);
        door.transform.position = new Vector3(216f, 1f, 1f);
        
        gameObject.SetActive(false);
        isBuilding = false;
    }
}
