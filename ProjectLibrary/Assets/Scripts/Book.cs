using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Book
{
    public int ISBN;
    public string Name;
    public string Writer;
    public int AllCopyCount;
    public int CopyCurrentCount;

    public Book(int isbn, string name, string writer, int allCopyCount)
    {
        ISBN = isbn;
        Name = name;
        Writer = writer;
        AllCopyCount = allCopyCount;
        CopyCurrentCount = allCopyCount; 
    }
}
