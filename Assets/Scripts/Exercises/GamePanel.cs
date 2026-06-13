
using TMPro;
using UnityEngine;
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
    private void Awake()
    {
        panel = this;
    }

    private void Start()
    {
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
