
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private PlayerObject player;
    [SerializeField] private Button btn_Atk;
    [SerializeField] private Toggle toggleAudioOn;
    [SerializeField] private Toggle toggleAudioOff;
    [SerializeField] private ToggleGroup audioToggleGroup;
    private void Start()
    {
        btn_Atk.onClick.AddListener(() =>
        {
            player.Fire();
        });
        toggleAudioOn.onValueChanged.AddListener(ToggleAudioChangeValue);
        toggleAudioOff.onValueChanged.AddListener(ToggleAudioChangeValue);
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
