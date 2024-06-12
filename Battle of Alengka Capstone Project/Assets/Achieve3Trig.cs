using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve3Trig : AchievementBase1
{
    public override void Unlock()
    {
        GameManager.instance.achievement[2] = true;
        base.Unlock();
    }
}
