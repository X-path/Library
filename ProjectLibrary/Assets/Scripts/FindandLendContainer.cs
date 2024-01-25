using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FindandLendContainer : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] GameObject findandLendItemPrefab;
    [SerializeField] TMP_InputField searchInputField;
    [SerializeField] GameObject datePanel;
    [SerializeField] TextMeshProUGUI todayDateText;
    [SerializeField] TMP_InputField extraDateInputField;
    List<Book> books = new List<Book>();
    List<GameObject> items = new List<GameObject>();

    int lendInfoID = -1;
    private void OnEnable()
    {
        ItemCreator();
    }

    void ItemCreator()
    {
        int _count = LibraryManager.instance.librarySO.bookList.Count;
        books = LibraryManager.instance.librarySO.bookList;

        for (int i = 0; i < books.Count; i++)
        {
            GameObject _item = Instantiate(findandLendItemPrefab, container.transform);
            _item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = books[i].ISBN.ToString();
            _item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = books[i].Name;
            _item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = books[i].Writer;
            _item.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = books[i].CopyCurrentCount.ToString();
            _item.transform.GetChild(4).GetComponent<Button>().interactable = true;
            _item.transform.GetChild(4).GetComponent<LendButton>().lendBookID = i;
            _item.transform.GetChild(4).GetComponent<LendButton>().findandLendContainer = this;

            items.Add(_item);

            BtnInteractableControl(i);
        }
    }
    void BtnInteractableControl(int i)
    {
        if (books[i].AllCopyCount > 0)
        {
            items[i].transform.GetChild(4).GetComponent<Button>().interactable = true;
        }
        else
        {
            items[i].transform.GetChild(4).GetComponent<Button>().interactable = false;
        }
    }
    public void Search()
    {
        foreach (GameObject _element in items)
        {
            if (_element.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains(searchInputField.text, System.StringComparison.OrdinalIgnoreCase) ||
            _element.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text.Contains(searchInputField.text, System.StringComparison.OrdinalIgnoreCase) ||
            _element.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Contains(searchInputField.text, System.StringComparison.OrdinalIgnoreCase))
            {
                _element.SetActive(true);
            }
            else
            {
                _element.SetActive(false);
            }
        }
    }
    public void LendInfo(int infoID)
    {
        lendInfoID = infoID;
        datePanel.SetActive(true);
        todayDateText.text = DateTime.Today.ToString("dd/MM/yyyy");

        BtnInteractableControl(lendInfoID);

    }

    public void DateOKButton()
    {
        int _isbn = 0;
        string _name;
        string _writer;
        int _extradate;


        int.TryParse(items[lendInfoID].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text, out _isbn);
        _name = items[lendInfoID].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        _writer = items[lendInfoID].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
        int.TryParse(extraDateInputField.text, out _extradate);

        DateTime _deliverDate = DateTime.Today.AddDays(_extradate);


        LibraryManager.instance.LendBook(_isbn, _name, _writer, _deliverDate, items[lendInfoID]);

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].ISBN == _isbn)
            {
                items[lendInfoID].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = books[i].CopyCurrentCount.ToString();
            }

        }

        extraDateInputField.text = "";
        datePanel.SetActive(false);
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
