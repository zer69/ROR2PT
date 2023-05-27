using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Graph : MonoBehaviour
{
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    public float dotSize;
    
    public List<Color> colorList;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        colorList[0] = new Color(colorList[0].r, colorList[0].g, colorList[0].b, 1f);
        colorList[1] = new Color(colorList[1].r, colorList[1].g, colorList[1].b, 1f);
    }

    private GameObject CreateDotVisual(Vector2 anchoredPosition, bool dnf)
    {
        GameObject gameObject = new GameObject("dotVisual", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = dotSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(dotSize, dotSize);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        if (dnf)
            gameObject.GetComponent<Image>().color = colorList[1];
        else
            gameObject.GetComponent<Image>().color = colorList[0];
        return gameObject;
    }

    public void ShowGraph(Loadout loadout)
    {
        foreach (Transform child in graphContainer)
        {
            GameObject.Destroy(child.gameObject);
        }
        if (loadout.recordList.Count == 0)
            return;

        

        
        float graphHeight = graphContainer.sizeDelta.y - dotSize;
        float yMaximum = (float)loadout.MaxTime();
        float xSize = graphContainer.sizeDelta.x / (loadout.recordList.Count + 1);

        GameObject lastDotGameObject = null;
        for (int i = 0; i < loadout.recordList.Count; i++)
        {
            float xPosition = (i + 1) * xSize;
            float yPosition = (loadout.ParseRecord(loadout.recordList[i]) / yMaximum) * graphHeight + dotSize/2;
            GameObject dotVisualGameObject = CreateDotVisual(new Vector2(xPosition, yPosition), loadout.recordList[i].dnf);
            if (lastDotGameObject != null)
            {
                CreateDotConnection(lastDotGameObject.GetComponent<RectTransform>().anchoredPosition, dotVisualGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastDotGameObject = dotVisualGameObject;
        }
        foreach(Transform child in graphContainer)
        {
            if (child.gameObject.name == "dotConnection")
                child.SetAsFirstSibling();
        }
    }

    public void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, dotSize/5f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));

    }
}
