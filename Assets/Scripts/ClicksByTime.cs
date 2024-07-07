using System;
using UnityEngine;

[RequireComponent(typeof(Cat))]
public class ClicksByTime : MonoBehaviour
{
    private Cat _cat;

    private DateTime _lastTimeCredit;

    private void Awake()
    {
        _cat = GetComponent<Cat>(); 

        if (PlayerPrefs.HasKey(nameof(_lastTimeCredit)))
            _lastTimeCredit = DateTime.Parse(PlayerPrefs.GetString(nameof(_lastTimeCredit)));
        else
            _lastTimeCredit = DateTime.Now;    
    }

    private void Update()
    {
       ApplyPeriodicCredits();
    }

    private void ApplyPeriodicCredits()
    {
        double lastSecond = (DateTime.Now - _lastTimeCredit).TotalSeconds;
        int spans = (int)lastSecond / 3;

        if (spans > 0)
        {
            for (int i = 0; i < spans; i++)
            {
                CreditClicks();
            }

            _lastTimeCredit = DateTime.Now;

            PlayerPrefs.SetString(nameof(_lastTimeCredit), _lastTimeCredit.ToString());
        }
    }

    private void CreditClicks()
    {
        _cat.AddClicks(3);
    }
}
