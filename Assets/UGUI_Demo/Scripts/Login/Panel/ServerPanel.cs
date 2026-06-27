using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Button btnChange;
    public Button btnStart;
    public Button btnBack;
    public TMP_Text txtName;

    public override void Init()
    {
        
        btnStart.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            LoginMgr.Instance.SaveLoginData();
            UIManager.Instance.HidePanel<LoginBKPanel>();
            SceneManager.LoadScene("GameScene");
        });
        btnBack.onClick.AddListener(() =>
        {
            if (LoginMgr.Instance.LoginData.autoLogin)
            {
                LoginMgr.Instance.LoginData.autoLogin = false;
            }
                
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        btnChange.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<ChooseServerPanel>();
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        if (LoginMgr.Instance.LoginData.choiceServerId < 1)
        {
            txtName.text = "未选择服务器";
        }
        else
        {
            ServerInfo  serverInfo = LoginMgr.Instance.ServerInfos[LoginMgr.Instance.LoginData.choiceServerId - 1];
            txtName.text = $"{serverInfo.id}区 {serverInfo.name}";
            
        }
        
    }
}