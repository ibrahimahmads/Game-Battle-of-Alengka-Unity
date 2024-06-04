using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public DialogueSegment[] DialogueSegments;
    [Space]
    public Image SpeakerFace;
    public Image DisBorderColor;
    public Image DisInnerBorder;
    public Image SkipIndicator;
    [Space]
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI DialogueDis;
    [Space]
    public float TextSpeed;
    public int DialogueIndex;
    public bool canCont;

    Player_Mov move_player;
    ShootCont shoot_player;


    // Start is called before the first frame update
    void Start()
    {
        move_player = FindAnyObjectByType<Player_Mov>();
        shoot_player = FindAnyObjectByType<ShootCont>();
        SetStyle(DialogueSegments[0].Speaker);
        StartCoroutine(PlayDialogue(DialogueSegments[0].Dialogue));
        Time.timeScale = 0;
        if(move_player != null)
        {
            move_player.enabled = false;
        }
        if(shoot_player != null)
        {
            shoot_player.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        SkipIndicator.enabled = canCont;
        if(Input.GetButtonDown("Fire1") && canCont)
        {
            DialogueIndex++;
            if(DialogueIndex == DialogueSegments.Length)
            {
                gameObject.SetActive(false);
                GameManager.instance.LoadScene(1);
                return;
            }

            SetStyle(DialogueSegments[DialogueIndex].Speaker);
            StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex].Dialogue));
        }
    }
    
    void SetStyle (DialogueSCobj Speaker)
    {
        
        if (Speaker.SubjectFace == null)
        {
            SpeakerFace.color = new Color(0, 0, 0, 0);
        }
        else
        {
            SpeakerFace.sprite = Speaker.SubjectFace;
            SpeakerFace.color = Color.white;
        }


        DisBorderColor.color = Speaker.BorderColor;
        DisInnerBorder.color = Speaker.InnerColor;
        SpeakerName.SetText(Speaker.SubjectName);

    }
    IEnumerator PlayDialogue(string Dialogue)
    {

        canCont = false;
        DialogueDis.SetText(string.Empty);

        for(int i = 0; i < Dialogue.Length; i++)
        {
            DialogueDis.text += Dialogue[i];
            yield return new WaitForSecondsRealtime(1f / TextSpeed);
        }
        canCont = true;
    }
}

[System.Serializable]
public class DialogueSegment
{
    public DialogueSCobj Speaker;
    public string Dialogue;

}