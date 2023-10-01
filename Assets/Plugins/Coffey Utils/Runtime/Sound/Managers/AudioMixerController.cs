using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace CoffeyUtils.Sound
{
    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private float _startValue = 0.75f;
        [SerializeField] private string _musicVolume = "MusicVolume";
        [SerializeField] private string _sfxVolume = "SfxVolume";

        private float _savedMusicValue;
        private float currentVolume;
        private float _savedSFXValue;
        public float fadeTime = 0.7f;

        private void Start()
        {
            SetMusicVolume(_startValue, true);
            SetSfxVolume(_startValue, true);
  
        }

        public void SetMusicVolume(float volume, bool setSaved = true, bool fade = false)
        {
            
            if (_mixer == null) return;
            
            if (fade)
            {
                currentVolume = _savedMusicValue;
                StartCoroutine(FadeVolume(volume, setSaved));
            } else if (!fade)
            {
                if (setSaved) _savedMusicValue = volume;
                _mixer.SetFloat(_musicVolume, Convert(volume));
            }
           
            
        }

        public void SetSfxVolume(float volume, bool setSaved = true)
        {
            if (setSaved) _savedSFXValue = volume;
            if (_mixer == null) return;
            _mixer.SetFloat(_sfxVolume, Convert(volume));

        }

        public void ResetMusicVolume(bool fade)
        {
            if (_mixer == null) return;

            if (fade)
            {
                FadeVolume(_savedMusicValue, false);
            } else if (!fade) _mixer.SetFloat(_musicVolume, Convert(_savedMusicValue));


        }
        public void ResetSFXVolume()
        {
            if (_mixer == null) return;
            _mixer.SetFloat(_musicVolume, Convert(_savedSFXValue));
        }




        private IEnumerator FadeVolume(float targetVolume, bool saveVolume)
        {
            // Get the initial volume and calculate the step size for the fade
            float initialVolume = currentVolume;
            float step = (targetVolume - initialVolume) / fadeTime;

            // Fade the volume over time
            float t = 0;
            while (t < fadeTime)
            {
                t += Time.deltaTime;
                currentVolume += step * Time.deltaTime;
                _mixer.SetFloat(_musicVolume, Convert(currentVolume));
                yield return null;
            }

            // Set the final volume level
            currentVolume = targetVolume;
            _mixer.SetFloat(_musicVolume, Convert(currentVolume));
            if (saveVolume) _savedMusicValue = currentVolume;
        }



    private static float Convert(float volume) => volume == 0 ? -80 : Mathf.Log10(volume) * 20;
    }
}