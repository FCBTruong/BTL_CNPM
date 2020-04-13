using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    private const int MAX_SIZE_RULER = 16;

    public static Ruler Instance { set; get; }
    public Vector2 pointStart;

    public GameObject valueBoxPrefab;

    public List<GameObject> elementsOfRuler = new List<GameObject>();
    public List<ValueBox> hideBoxList = new List<ValueBox>();

    private int hideIndex = 5;
    private int xValue;

    private Animator anim;

    public static int score;

    private void Update()
    {
        if (GameManager.Instance.gameOverStatus) return;
        if(hideBoxList.Count != 0)
        {
            if (hideBoxList[0].InputNumber())
            {
                hideBoxList.RemoveAt(0);
            }
        }
        else
        {
            if (score == 0) score = 1;
            GameManager.Instance.NextLevel(score);
        }
    }
    private void Start()
    {
        score = 1;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        anim = this.GetComponent<Animator>();
      
        CreateRuler();
        RefreshRuler();
    }

    public void CreateRuler()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject valueBox = Instantiate(valueBoxPrefab) as GameObject;
            valueBox.transform.SetParent(this.transform);
            valueBox.transform.localScale = this.transform.localScale;
            valueBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(pointStart.x + 90 * i, pointStart.y);
            elementsOfRuler.Add(valueBox);
        }
    }

    public void RefreshRuler()
    {
        score = 1;
        anim.SetTrigger("ShowLoad");
        xValue = UnityEngine.Random.Range(0, 989);
        hideIndex = UnityEngine.Random.Range(0, 13);
        foreach(GameObject gameObject in elementsOfRuler)
        {
            gameObject.GetComponent<ValueBox>().Refresh();
        }

        for (int i = 0; i < 16; i++)
        {
            elementsOfRuler[i].GetComponent<ValueBox>().SetNumber(xValue);
            xValue++;
        }

        for (int i = hideIndex; i < hideIndex + 4; i++)
        {
            elementsOfRuler[i].GetComponent<ValueBox>().SetInputStatus();
            //hideBoxList.Add(elementsOfRuler[i].GetComponent<ValueBox>());
            hideBoxList.Insert(0,elementsOfRuler[i].GetComponent<ValueBox>());
        }
    }
}
