
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
