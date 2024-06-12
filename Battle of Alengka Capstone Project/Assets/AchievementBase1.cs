using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementBase1 : MonoBehaviour
{
    public virtual void Unlock()
    {
        Destroy(gameObject);
    }
}
