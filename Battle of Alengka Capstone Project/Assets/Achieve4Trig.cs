using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve4Trig : AchievementBase1
{
    public override void Unlock()
    {
        GameManager.instance.achievement[3] = true;
        base.Unlock();
    }
}
