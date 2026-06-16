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
        {//TODO 判断用户输入的账号信息是否正确 后进入服务器面板
            if (LoginMgr.Instance.CheckInfo(usernameField.text, passwordField.text))
            {
                LoginMgr.Instance.LoginData.userName = usernameField.text;
                LoginMgr.Instance.LoginData.password = passwordField.text;
                LoginMgr.Instance.LoginData.autoLogin = autoLoginToggle.isOn;
                LoginMgr.Instance.LoginData.rememberPw = rememberPwToggle.isOn;
                LoginMgr.Instance.SaveLoginData();
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
        LoginData loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        usernameField.text = loginData.userName;
        rememberPwToggle.isOn = loginData.rememberPw;
        autoLoginToggle.isOn = loginData.autoLogin;
        if (rememberPwToggle.isOn)
        {
            passwordField.text = loginData.password;
        }
        if (autoLoginToggle.isOn)
        {//TODO 自动登录逻辑 直接进入选择服务器面板

        }
    }

    public void SetInfo(string username, string password)
    {
        usernameField.text = username;
        passwordField.text = password;
    }
}
