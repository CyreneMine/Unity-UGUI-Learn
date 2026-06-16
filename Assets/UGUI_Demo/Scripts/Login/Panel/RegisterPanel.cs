using TMPro;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public Button cancelBtn;
    public Button registerBtn;
    public TMP_InputField passwordField;
    public TMP_InputField usernameField;
    public override void Init()
    {
        cancelBtn.onClick.AddListener((() =>
        {
            UIManager.Instance.ShowPanel<LoginPanel>();
            
            UIManager.Instance.HidePanel<RegisterPanel>();
        }));
        registerBtn.onClick.AddListener((() =>
        {
            if (LoginMgr.Instance.RegisterUser(usernameField.text, passwordField.text))
            {
                LoginPanel loginPanel = UIManager.Instance.ShowPanel<LoginPanel>();
                loginPanel.SetInfo(usernameField.text, passwordField.text);
                UIManager.Instance.HidePanel<RegisterPanel>();
            }
            else
            {
                passwordField.text = null;
                usernameField.text = null;
            }
            
        }));
    }
}
