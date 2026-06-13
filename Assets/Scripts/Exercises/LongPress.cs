using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPress : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public event UnityAction upEvent;
    public event UnityAction downEvent;
    /*private bool isDown = false;
    public static float chargeTime =0f;

    public RectTransform chargeBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            
            chargeTime += Time.deltaTime;
        }
        chargeBar.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,(float)(chargeTime*960));
        if (chargeTime > 1)
        {
            PlayerObject.hp += 10;
            chargeTime = 0f;
            Debug.Log($"当前hp:{PlayerObject.hp}");
        }
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        upEvent?.Invoke();
        /*chargeBar.gameObject.SetActive(true);
        isDown = true;*/
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downEvent?.Invoke();
        /*chargeBar.gameObject.SetActive(false);
        isDown = false;
        chargeTime = 0f;*/
    }
}
