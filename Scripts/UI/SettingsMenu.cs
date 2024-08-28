using UnityEngine;
using UnityEngine.Audio;

namespace UI {
    public class SettingsMenu : MonoBehaviour {
        public AudioMixer audioMixer;
        public void SetVolume(float volume) {
            audioMixer.SetFloat("Volume", volume);
        }

        public void SetFullscreen(bool isFullScreen) {
            Screen.fullScreen = isFullScreen;
        }
    }
}
