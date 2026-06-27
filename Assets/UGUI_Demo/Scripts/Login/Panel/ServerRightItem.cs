using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerRightItem : MonoBehaviour
{
    public Button btnSelf;
    public Image isNew;
    public Image state;
    public TMP_Text txtName;
    public ServerInfo serverInfo;
    void Start()
    {
        btnSelf.onClick.AddListener((() =>
        {
            LoginMgr.Instance.LoginData.choiceServerId = serverInfo.id;
            UIManager.Instance.HidePanel<ChooseServerPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        }));
    }
    public void InitInfo(ServerInfo info)
    {
        serverInfo = info;
        txtName.text = $"{serverInfo.id}区+{serverInfo.name}";
        isNew.gameObject.SetActive(serverInfo.isNew);
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
    
}
