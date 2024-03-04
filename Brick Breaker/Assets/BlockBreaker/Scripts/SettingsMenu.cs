using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
