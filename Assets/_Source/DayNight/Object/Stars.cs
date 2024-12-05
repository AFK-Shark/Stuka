using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Interfaces;

namespace DayNight
{
    public class Stars : MonoBehaviour, ITimeOfDayObserver
    {
        public DayNightCycle dayNightCycle;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (dayNightCycle != null)
            {
                dayNightCycle.RegisterObserver(this);
            }
            else
            {
                Debug.LogWarning("DayNightCycle is not assigned to Stars.");
            }
        }

        private void OnDestroy()
        {
            if (dayNightCycle != null)
            {
                dayNightCycle.RemoveObserver(this);
            }
        }

        public void OnTimeOfDayChanged(float time)
        {
            // Логика для появления и исчезновения звезд
            if (time < 0.25f || time >= 0.75f)
            {
                spriteRenderer.color = new Color(1, 1, 1, 1); // Полная видимость
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0); // Полная невидимость
            }
        }
    }
}
