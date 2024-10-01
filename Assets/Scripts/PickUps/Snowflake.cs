using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowflake : PickUp
{
    public int freeze = 5;
    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freeze);
        Destroy(this.gameObject);
    }
}
