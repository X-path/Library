using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject addBookPanel;
    [SerializeField] GameObject findandLendPanel;
    [SerializeField] GameObject returnBookPanel;


    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        panel.SetActive(true);
    }
    public void ExitBtn(GameObject panel)
    {
        panel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
