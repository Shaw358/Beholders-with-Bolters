using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    private int layer;
    [SerializeField]private Sprite[] maps;

    void Start()
    {
        layer = 1;
        gameObject.GetComponent<Image>().sprite = maps[layer-1];
    }

    public void DisplayLayer(int setlayer)
    {
        layer = setlayer;
        // Level 1, Level 2, Level 3???
        switch (layer)
        {
            case 1:
                gameObject.GetComponent<Image>().sprite = maps[layer-1];
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = maps[layer-1];
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = maps[layer-1];
                break;
        }
    }
}
