using UnityEngine;

public class Main : MonoBehaviour
{
    
    void Start()
    {
        TipPanel showPanel = UIManager.Instance.ShowPanel<TipPanel>();
        showPanel.ChangeInfo("我永远喜欢昔涟酱");
    }
    
}
