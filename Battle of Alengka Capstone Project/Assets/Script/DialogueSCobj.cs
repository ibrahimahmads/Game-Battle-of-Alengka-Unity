using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subject", menuName ="Create New Subject")]
public class DialogueSCobj : ScriptableObject
{
    public string SubjectName;
    public Color BorderColor;
    public Color InnerColor;
    public Sprite SubjectFace;
}
