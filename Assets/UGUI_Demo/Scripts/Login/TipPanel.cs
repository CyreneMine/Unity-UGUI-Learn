using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Button sureBtn;
    public TMP_Text tipText;
    public override void Init()
    {
        sureBtn.onClick.AddListener((() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();
        }));
    }

    public void ChangeInfo(string info)
    {
        tipText.text = info;
    }
}
