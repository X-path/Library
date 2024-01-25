using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverButton : MonoBehaviour
{
    public int deliverBookID;
    [HideInInspector] public LendContainer lendContainer;
    public void Deliver_Click()
    {
        lendContainer.DeliverInfo(deliverBookID);
    }
}
