using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    private const int MAX_SIZE_RULER = 16;
    public Vector2 pointStart;

    public GameObject valueBoxPrefab;

    public List<GameObject> elementsOfRuler = new List<GameObject>();

    private int hideIndex = 5;
    
    private void Start()
    {
        CreateRuler();
    }

    private void CreateRuler()
    {
        if(elementsOfRuler != null)
        {
            foreach(GameObject gameObject in elementsOfRuler)
            {
                DestroyImmediate(gameObject);
            }
        }

        int xValue = 101;
        for(int i = 0; i < 16; i++)
        {
            GameObject valueBox = Instantiate(valueBoxPrefab) as GameObject;
            valueBox.transform.parent = this.transform;
            valueBox.transform.localScale = this.transform.localScale;
            valueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(pointStart.x + 90 * i, pointStart.y);
            valueBox.GetComponent<ValueBox>().SetNumber(xValue);
            xValue++;
            elementsOfRuler.Add(valueBox);
        }

        for(int i = hideIndex; i < hideIndex + 4; i++)
        {
            elementsOfRuler[i].GetComponent<ValueBox>().SetInputStatus();
        }
        //elementsOfRuler.Clear();
    }
}
