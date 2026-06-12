
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNamePanel : MonoBehaviour
{
    public static ChangeNamePanel panel;
    [SerializeField] private Button btn_ChangeName;
    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        gameObject.SetActive(false);
        panel = this;
    }

    private void Start()
    {
         btn_ChangeName.onClick.AddListener((() =>
         {
             GamePanel.panel.playerName.text = inputField.text;
             ChangeNamePanel.panel.gameObject.SetActive(false);
         }));
    }
}
