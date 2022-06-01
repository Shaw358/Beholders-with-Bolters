using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyToClipboard : MonoBehaviour
{
    [SerializeField] ConnectToRoom ctroom;

    public void CopyToCB()
    {
        ctroom.generation.ID.CopyToClipboard();
    }
}

public static class ClipboardExtension
{
    /// <summary>
    /// Puts the string into the Clipboard.
    /// </summary>
    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}