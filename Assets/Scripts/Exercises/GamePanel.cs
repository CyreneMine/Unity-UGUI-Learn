
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public static GamePanel panel;
    [SerializeField] private PlayerObject player;
    [SerializeField] private Button btn_Atk;
    [SerializeField] private Toggle toggleAudioOn;
    [SerializeField] private Toggle toggleAudioOff;
    [SerializeField] private ToggleGroup audioToggleGroup;
    public TMP_Text playerName;
    [SerializeField] private Button btn_ChangeName;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button btn_Bag;
    [SerializeField] private Transform sun;
    [SerializeField] private TMP_Dropdown sunDropdown;
    public LongPress longPress;
    public float chargeSpeed = 150f;
    public GameObject chargeBar;
    public RectTransform chargeBarFill;
    private bool isDown = false;
    private float chargeTime;
    private void Awake()
    {
        panel = this;
    }

    private void Start()
    {
        chargeBar.SetActive(false);
        btn_Atk.onClick.AddListener(() =>
        {
            player.Fire();
        });
        toggleAudioOn.onValueChanged.AddListener(ToggleAudioChangeValue);
        toggleAudioOff.onValueChanged.AddListener(ToggleAudioChangeValue);
        btn_ChangeName.onClick.AddListener((() =>
        {
            ChangeNamePanel.panel.gameObject.SetActive(true);
        }));
        volumeSlider.value = MusicData.SoundVolume;
        volumeSlider.onValueChanged.AddListener((v =>
        {
            MusicData.SoundVolume = v;
        } ));
        btn_Bag.onClick.AddListener((() =>
        {
            BagPanel.panel.gameObject.SetActive(true);
        }));
        sunDropdown.onValueChanged.AddListener((v =>
        {
            if (v == 0)
            {
                sun.eulerAngles = new Vector3(50, -30, 0);
            }else if (v == 1)
            {
                sun.eulerAngles = new Vector3(210, -30, 0);
            }
        }));
        longPress.upEvent += ChargeUp;
        longPress.downEvent += ChargeDown;
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener(JoyDrag);
        et.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener(JoyEndDrag);
        et.triggers.Add(entry);
    }

    private void Update()
    {
        if (isDown)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime >= 0.2f)
            {
                chargeBar.SetActive(true);
                chargeBarFill.sizeDelta += new Vector2(chargeSpeed*Time.deltaTime,0);
                
            }
            if (chargeBarFill.sizeDelta.x >960)
            {
                PlayerObject.hp += 10;
                Debug.Log($"hp : {PlayerObject.hp}");
                chargeBarFill.sizeDelta = new Vector2(0,60);
            }
        }
        
    }

    public EventTrigger et;
    public RectTransform imgJoy;
    private void JoyDrag(BaseEventData data)
    {
        PointerEventData pointerEventData = data as PointerEventData;
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoy.transform.parent as RectTransform, 
            pointerEventData.position,
            pointerEventData.enterEventCamera,
            out delta);
        imgJoy.transform.localPosition = delta;
        if (imgJoy.anchoredPosition.magnitude > 200)
        {
            imgJoy.anchoredPosition = imgJoy.anchoredPosition.normalized * 200;
        }
        
        player.Move(imgJoy.anchoredPosition);
    }

    private void JoyEndDrag(BaseEventData data)
    {
        imgJoy.anchoredPosition = new Vector2(0, 0);
        player.Move(Vector2.zero);
    }
    private void ChargeUp()
    {
        isDown = true;
    }

    private void ChargeDown()
    {
        isDown = false;
        chargeBar.SetActive(false);
        chargeBarFill.sizeDelta = new Vector2(0,chargeBarFill.sizeDelta.y);
        chargeTime = 0;
    }
    private void ToggleAudioChangeValue(bool value)
    {
        foreach (Toggle toggle in audioToggleGroup.ActiveToggles())
        {
            if (toggle ==  toggleAudioOn)
            {
                MusicData.SoundIsOpen = true;
            }else if (toggle == toggleAudioOff)
            {
                MusicData.SoundIsOpen = false;
            }
        }
    }
}
