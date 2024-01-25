using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LendContainer : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] GameObject lendItemPrefab;
    List<Book> lendbooks = new List<Book>();
    List<GameObject> items = new List<GameObject>();
    [SerializeField] Toggle outDateToggle;

    private void OnEnable()
    {
        ItemCreator();
    }

    void ItemCreator()
    {
        int _count = LibraryManager.instance.librarySO.lendBookList.Count;
        lendbooks = LibraryManager.instance.librarySO.lendBookList;

        for (int i = 0; i < lendbooks.Count; i++)
        {
            GameObject _item = Instantiate(lendItemPrefab, container.transform);
            _item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lendbooks[i].ISBN.ToString();
            _item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = lendbooks[i].Name;
            _item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = lendbooks[i].Writer;
            _item.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = lendbooks[i].DeliverDate.ToString("dd/MM/yyyy");
            _item.transform.GetChild(4).GetComponent<DeliverButton>().deliverBookID = i;
            _item.transform.GetChild(4).GetComponent<DeliverButton>().lendContainer = this;

            items.Add(_item);
        }

    }
    public void OutDateControl()
    {
        if (items.Count == 0)
            return;

        if (outDateToggle.isOn)
        {
            for (int i = 0; i < lendbooks.Count; i++)
            {
                if (lendbooks[i].DeliverDate < DateTime.Today)
                {
                    items[i].SetActive(true);
                }
                else
                {
                    items[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetActive(true);
            }
        }
    }
    public void DeliverInfo(int infoID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].transform.GetChild(4).GetComponent<DeliverButton>().deliverBookID == infoID)
            {
                LibraryManager.instance.DeliverBook(i);
                GameObject _go = items[i].gameObject;
                items.RemoveAt(i);
                Destroy(_go);
            }
        }


    }
    void ItemsClear()
    {
        for (int i = items.Count - 1; i > 0; i--)
        {
            Destroy(items[i].gameObject);
        }

        items.Clear();
    }
    private void OnDisable()
    {
        ItemsClear();
    }
}
