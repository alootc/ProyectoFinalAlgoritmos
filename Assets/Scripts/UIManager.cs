using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager : MonoBehaviour
{
    public SaveVolume save_volume;
    public GameObject popup_audio_settings;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            bool active = popup_audio_settings.activeSelf;
            popup_audio_settings.SetActive(!active);

        }


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("Nivel-2");
        //}
    }
 

    public void AddVolume(string id)
    {
        switch (id)
        {
            case "master-volumen":
                float vma = save_volume.master_volumen;
                save_volume.master_volumen = Mathf.Clamp(vma + 0.1f, 0.001f, 1f);
                break;

            case "music-volumen":
                float vmu = save_volume.music_volume;
                save_volume.music_volume = Mathf.Clamp(vmu + 0.1f, 0.001f, 1f);
                break;

            case "sfx-volumen":
                float vsf = save_volume.sfx_volume;
                save_volume.sfx_volume = Mathf.Clamp(vsf + 0.1f, 0.001f, 1f);
                break;

        }
    }

    public void LessVolume(string id)
    {
        switch (id)
        {
            case "master-volumen":
                float vma = save_volume.master_volumen;
                save_volume.master_volumen = Mathf.Clamp(vma - 0.1f, 0.001f, 1f);
                break;

            case "music-volumen":
                float vmu = save_volume.music_volume;
                save_volume.music_volume = Mathf.Clamp(vmu - 0.1f, 0.001f, 1f);
                break;

            case "sfx-volumen":
                float vsf = save_volume.sfx_volume;
                save_volume.sfx_volume = Mathf.Clamp(vsf - 0.1f, 0.001f, 1f);
                break;

        }
    }

}
