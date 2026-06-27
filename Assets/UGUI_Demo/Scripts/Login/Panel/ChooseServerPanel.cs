
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ChooseServerPanel : BasePanel
{
    public ScrollRect svLeft;
    public ScrollRect svRight;
    public TMP_Text txtRange;
    public TMP_Text txtFront;
    public Image state;
    public List<GameObject> itemList = new List<GameObject>();
    public override void Init()
    {
        //动态创建左侧服务器区间按钮
        List<ServerInfo> serverInfos = LoginMgr.Instance.ServerInfos;
        int btnCount = serverInfos.Count/5+1;
        
        for (int i = 0; i < btnCount; i++)
        {
            int beginIndex = i * 5 + 1;
            int endIndex = beginIndex + 4;
            if (endIndex > serverInfos.Count)
            {
                endIndex = serverInfos.Count;
            }
            ServerLeftItem sl = GameObject.Instantiate(Resources.Load<ServerLeftItem>("UI/ServerLeftItem"));
            sl.transform.SetParent(svLeft.content,false);
            sl.InitInfo(beginIndex, endIndex);
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();
        if (LoginMgr.Instance.LoginData.choiceServerId <= 0)
        {
            txtFront.text = "无选区";
            state.gameObject.SetActive(false);
        }
        else
        {
            ServerInfo serverInfo = LoginMgr.Instance.ServerInfos[LoginMgr.Instance.LoginData.choiceServerId -1];
            txtFront.text = $"{serverInfo.id}区+ {serverInfo.name}";
            state.gameObject.SetActive(true);
            SpriteAtlas sa = Resources.Load<SpriteAtlas>("Login");
            switch (serverInfo.state)
            {
                case 0:
                    state.gameObject.SetActive(false);
                    break;
                case 1:
                    state.sprite = sa.GetSprite("ui_DL_huobao_01");
                    break;
                case 2:
                    state.sprite = sa.GetSprite("ui_DL_fanhua_01");
                    break;
                case 3:
                    state.sprite = sa.GetSprite("ui_DL_liuchang_01");
                    break;
                case 4:
                    state.sprite = sa.GetSprite("ui_DL_weihu_01");
                    break;
            }
        }
        UpdatePanel(1,5 > LoginMgr.Instance.ServerInfos.Count ? LoginMgr.Instance.ServerInfos.Count:5);
    }

    public void UpdatePanel(int beginIndex, int endIndex)
    {
        txtRange.text = $"服务器 {beginIndex}—{endIndex}";
        for (int i = 0; i < itemList.Count; i++)
        {
            Destroy(itemList[i]);
        }
        itemList.Clear();
        for (int i = beginIndex; i <= endIndex; i++)
        {
            ServerInfo nowServerInfo = LoginMgr.Instance.ServerInfos[i-1];
            GameObject srObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/ServerRightItem"));
            srObj.transform.SetParent(svRight.content,false);
            ServerRightItem sr = srObj.GetComponent<ServerRightItem>();
            sr.InitInfo(nowServerInfo);
            itemList.Add(srObj);
        }
    }
}
