using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerLeftItem : MonoBehaviour
{
    public Button btnSelf;
    public TMP_Text txtInfo;
    private int beginIndex;
    private int endIndex;

    private void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            ChooseServerPanel panel = UIManager.Instance.GetPanel<ChooseServerPanel>();
            panel.UpdatePanel(beginIndex, endIndex);
        });
    }
    public void InitInfo(int beginIndex,int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;
        
        txtInfo.text = $"{beginIndex}—{endIndex}区";
    }
}
