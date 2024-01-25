using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LendButton : MonoBehaviour
{
    public int lendBookID;
    [HideInInspector] public FindandLendContainer findandLendContainer;
    public void Lend_Click()
    {
        findandLendContainer.LendInfo(lendBookID);
    }
}
