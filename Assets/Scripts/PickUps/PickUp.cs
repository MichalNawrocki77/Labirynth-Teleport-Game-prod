using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //Kryszta� - dodaje punkty
    //Zegar - odejmuje czas
    //Zegar - dodaje czas
    //�nie�ynka - zamra�a czas
    //klucz - otweira drzwi
    public virtual void Picked()
    {
        Debug.Log("Podnioslem");
        Destroy(this.gameObject);
    }
}
