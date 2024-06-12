using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve2Trig : AchievementBase1
{
    public override void Unlock()
    {
        GameManager.instance.achievement[1] = true;
        base.Unlock();
    }
}
