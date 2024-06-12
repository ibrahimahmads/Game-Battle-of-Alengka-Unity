using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve1Trig : AchievementBase1
{
    public override void Unlock()
    {
        GameManager.instance.achievement[0] = true;
        base.Unlock();
    }
}
