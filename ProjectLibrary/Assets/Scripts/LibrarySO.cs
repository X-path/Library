using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LibrarySO : ScriptableObject
{
    [SerializeField]
    public List<Book> bookList = new List<Book>();
}
