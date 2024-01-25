using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LibraryManager : MonoBehaviour
{
    public static LibraryManager instance = null;

    [SerializeField] public LibrarySO librarySO;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    public bool BookIsbnControl(int isbn)
    {
        for (int i = 0; i < librarySO.bookList.Count; i++)
        {
            if (librarySO.bookList[i].ISBN == isbn)
            {
                return false;
            }
        }

        return true;
    }
    public void AddBook(int isbn, string name, string writer, int allCopyCount)
    {
        Book _book = new Book(isbn, name, writer, allCopyCount);
        librarySO.bookList.Add(_book);
    }

    public void LendBook(int isbn, string name, string writer, DateTime lendDate, GameObject item)
    {
        Book _book = new Book(isbn, name, writer, lendDate);
        librarySO.lendBookList.Add(_book);

        for (int i = 0; i < librarySO.bookList.Count; i++)
        {
            if (librarySO.bookList[i].ISBN == _book.ISBN)
            {
                librarySO.bookList[i].CopyCurrentCount -= 1;
                item.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = librarySO.bookList[i].CopyCurrentCount.ToString();
                if (librarySO.bookList[i].CopyCurrentCount == 0)
                {
                    item.transform.GetChild(4).GetComponent<Button>().interactable = false;
                }
            }
        }

    }
    public void DeliverBook(int infoID)
    {
        for (int k = 0; k < librarySO.lendBookList.Count; k++)
        {
            if (k == infoID)
            {
                for (int i = 0; i < librarySO.bookList.Count; i++)
                {
                    if (librarySO.lendBookList[k].ISBN == librarySO.bookList[i].ISBN)
                    {
                        librarySO.bookList[k].CopyCurrentCount += 1;
                        librarySO.lendBookList.RemoveAt(k);
                        break;
                    }
                }

            }
        }

    }

}
