using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public static LibraryManager instance = null;

    [SerializeField] LibrarySO librarySO;
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

}
