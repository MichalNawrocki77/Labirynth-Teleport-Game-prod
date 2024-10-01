using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Picked();
    }

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }
}
