using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button loginBtn;
    public Button registerBtn;
    public TMP_InputField passwordField;
    public TMP_InputField usernameField;
    public Toggle autoLoginToggle;
    public Toggle rememberPwToggle;
    public override void Init()
    {
        loginBtn.onClick.AddListener((() =>
        {
            if (LoginMgr.Instance.CheckInfo(usernameField.text, passwordField.text))
            {
                LoginMgr.Instance.LoginData.userName = usernameField.text;
                LoginMgr.Instance.LoginData.password = passwordField.text;
                LoginMgr.Instance.LoginData.autoLogin = autoLoginToggle.isOn;
                LoginMgr.Instance.LoginData.rememberPw = rememberPwToggle.isOn;
                LoginMgr.Instance.SaveLoginData();
                if (LoginMgr.Instance.LoginData.choiceServerId < 1)
                {
                    UIManager.Instance.ShowPanel<ChooseServerPanel>();
                }
                else
                {
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }
                UIManager.Instance.HidePanel<LoginPanel>();
            }
        }));
        registerBtn.onClick.AddListener((() =>
        {
            UIManager.Instance.ShowPanel<RegisterPanel>();
            UIManager.Instance.HidePanel<LoginPanel>();
        }));
        autoLoginToggle.onValueChanged.AddListener((isOn) =>
        {
            rememberPwToggle.isOn = isOn;
        });
        rememberPwToggle.onValueChanged.AddListener((isOn) =>
        {
            if (!isOn)
            {
                autoLoginToggle.isOn = false;
            }
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        LoginData loginData = LoginMgr.Instance.LoginData;
        usernameField.text = loginData.userName;
        rememberPwToggle.isOn = loginData.rememberPw;
        autoLoginToggle.isOn = loginData.autoLogin;
        if (rememberPwToggle.isOn)
        {
            passwordField.text = loginData.password;
        }
        if (autoLoginToggle.isOn)
        {
            if (LoginMgr.Instance.CheckInfo(usernameField.text, passwordField.text))
            {
                if (LoginMgr.Instance.LoginData.choiceServerId < 1)
                {
                    UIManager.Instance.ShowPanel<ChooseServerPanel>();
                }
                else
                {
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }
                UIManager.Instance.HidePanel<LoginPanel>();
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号或密码错误");
            }

        }
    }

    public void SetInfo(string username, string password)
    {
        usernameField.text = username;
        passwordField.text = password;
    }
}
