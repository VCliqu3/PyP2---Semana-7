using GameJolt.API;
using GameJolt.API.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrophiesObtainedUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<TrophyObtainedUI> trophiesObtainedUIs;
    [Space]
    [SerializeField] private Color trohpiesObtainedColor;
    [SerializeField] private Color trohpiesNotObtainedColor;

    [Serializable]
    public class TrophyObtainedUI
    {
        public int trophyID;
        public TextMeshProUGUI trophyText;
    }

    private void Start()
    {
        CheckTrophiesObtained();
    }

    private void CheckTrophiesObtained()
    {
        foreach(TrophyObtainedUI trophyObtainedUI in trophiesObtainedUIs)
        {
            Trophies.Get(trophyObtainedUI.trophyID, (trophy) =>
            {
                if (trophy.Unlocked)
                {
                    trophyObtainedUI.trophyText.color = trohpiesObtainedColor;
                    trophyObtainedUI.trophyText.text = $"Trofeo {trophy.Title} obtenido! ";
                }
                else
                {
                    trophyObtainedUI.trophyText.color = trohpiesNotObtainedColor;
                    trophyObtainedUI.trophyText.text = $"Trofeo no descubierto";
                }
            });
        }
    }
}
