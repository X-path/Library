using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveButton : MonoBehaviour
{
    public TMP_InputField isbn_InputField;
    public TMP_InputField name_InputField;
    public TMP_InputField writer_InputField;
    public TMP_InputField allCopyCount_InputField;

    public TextMeshProUGUI debugText;
    public void Save()
    {
        int _isbn = 0;
        int _allCopyCount = 0;

        int.TryParse(isbn_InputField.text, out int isbn_result);
        _isbn = isbn_result;

        int.TryParse(allCopyCount_InputField.text, out int allCopyCount_result);
        _allCopyCount = allCopyCount_result;

        if (NullorEmptyControll())
        {
            if (LibraryManager.instance.BookIsbnControl(_isbn))
            {
                LibraryManager.instance.AddBook(_isbn, name_InputField.text, writer_InputField.text, _allCopyCount);
            }
            else
            {
                Debug.Log($"ISBN available");
                debugText.text = "ISBN Available";
            }
        }
        else
        {
            Debug.Log($"Empty Area");
            debugText.text = "Empty Area";
        }

    }
    bool NullorEmptyControll()
    {
        if (!string.IsNullOrEmpty(isbn_InputField.text) && !string.IsNullOrEmpty(name_InputField.text) && !string.IsNullOrEmpty(writer_InputField.text) && !string.IsNullOrEmpty(allCopyCount_InputField.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
