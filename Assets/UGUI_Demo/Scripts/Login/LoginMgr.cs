using UnityEngine;

public class LoginMgr
{
    private static LoginMgr instance = new LoginMgr();
    public static LoginMgr Instance => instance;
    private LoginData loginData;
    public LoginData LoginData => loginData;
    private RegisterData registerData;
    public RegisterData RegisterData => registerData;
    private LoginMgr()
    {
        loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
    }

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(loginData, "LoginData");
    }

    public void SaveRegisterData()
    {
        foreach (var VARIABLE in registerData.registerInfo)
        {
            Debug.Log(VARIABLE.Key + ":" + VARIABLE.Value);
        }
        JsonMgr.Instance.SaveData(registerData, "RegisterData");
    }

    public bool RegisterUser(string username, string password)
    {
        if (registerData.registerInfo.ContainsKey(username))
        {
            UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("用户已存在");
            return false;
        }
        else
        {
            registerData.registerInfo.Add(username, password);
            SaveRegisterData();
            return true;
        }
    }

    public bool CheckInfo(string username, string password)
    {
        if (registerData.registerInfo.ContainsKey(username))
        {
            if (registerData.registerInfo[username] == password)
            {
                return true;
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("密码错误");
                return false;
            }
        }
        else
        {
            UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号不存在");
            return false;
        }
    }
}
