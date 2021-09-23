using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerPrefsScript : MonoBehaviour
{

    public Slider SliderPlay;
    public Slider SliderFx;



    private void Awake()
    {
        //проверяем если ключа не было то создаем
        if (!PlayerPrefs.HasKey(PPString.SoundPlayVol.ToString()))
        {
            PlayerPrefs.SetFloat(PPString.SoundPlayVol.ToString(), 0.5f);
            SliderPlay.value = 0.5f;
            PlayerPrefs.Save();
        }
        else
        {
            //если ключ был то выставляем значение
            float Vol = PlayerPrefs.GetFloat(PPString.SoundPlayVol.ToString());
            SliderPlay.value = Vol;
            
        }


        //проверяем если ключа не было то создаем
        if (!PlayerPrefs.HasKey(PPString.SoundFxVol.ToString()))
        {
            PlayerPrefs.SetFloat(PPString.SoundFxVol.ToString(), 0.5f);
            SliderFx.value = 0.5f;
            PlayerPrefs.Save();
        }
        else
        {
            //если ключ был то выставляем значение
            float fx = PlayerPrefs.GetFloat(PPString.SoundFxVol.ToString());
            SliderFx.value = fx;
            
        }

        if (!PlayerPrefs.HasKey(PPString.MaxCompleteLevel.ToString()))
        {
            PlayerPrefs.SetInt(PPString.MaxCompleteLevel.ToString(), 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey(PPString.CurrentLevel.ToString()))
        {
            PlayerPrefs.SetInt(PPString.CurrentLevel.ToString(), 0);
            PlayerPrefs.Save();
        }

    }

    /// <summary>Save data onSliderChange </summary>
    public void SavePlay()
    {
        PlayerPrefs.SetFloat(PPString.SoundPlayVol.ToString(), SliderPlay.value);
        PlayerPrefs.Save();
    }

    /// <summary>Save data onSliderChange </summary>
    public void SaveFx()
    {
        PlayerPrefs.SetFloat(PPString.SoundFxVol.ToString(), SliderFx.value);
        PlayerPrefs.Save();
    }

}
