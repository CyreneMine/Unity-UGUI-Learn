using System;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public static BagPanel panel;
    public Button backBtn;
    public ScrollRect scrollRect;
    private void Awake()
    {
        panel = this;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        
        for (int i = 0; i < 30; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("Item"));
            item.transform.SetParent(scrollRect.content, false);
            item.transform.localPosition = new Vector3(10, -10, 0) + new Vector3(i % 4 * 120, -i / 4 * 120, 0);
        }

        scrollRect.content.sizeDelta = new Vector2(0, Mathf.CeilToInt(30 / 4f) * 120);
        
        backBtn.onClick.AddListener((() =>
        {
            gameObject.SetActive(false);
        }));
    }
}
