using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public int time;
    public bool addTime; //jeœli true, to zegar dodaje czas, jeœli false to zegar odejmuje czas
    public override void Picked()
    {
        if (addTime)
        {
            GameManager.gameManager.AddTime(time);
        }
        else
        {
            GameManager.gameManager.AddTime(-time);
        }

        Destroy(this.gameObject);
        
    }
}
