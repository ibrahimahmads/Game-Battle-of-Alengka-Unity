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


    // Start is called before the first frame update
    void Start()
    {
        SetStyle(DialogueSegments[0].Speaker);
        StartCoroutine(PlayDialogue(DialogueSegments[0].Dialogue));
    }

    // Update is called once per frame
    void Update()
    {
        SkipIndicator.enabled = canCont;
        if(Input.GetKeyDown(KeyCode.Space) && canCont)
        {
            DialogueIndex++;
            if(DialogueIndex == DialogueSegments.Length)
            {
                gameObject.SetActive(false);
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
            yield return new WaitForSeconds(1f / TextSpeed);
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