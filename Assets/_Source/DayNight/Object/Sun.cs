using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Interfaces;

namespace DayNight
{
    public class Sun : MonoBehaviour, ITimeOfDayObserver
    {
        public DayNightCycle dayNightCycle;

        private void Start()
        {
            if (dayNightCycle != null)
            {
                dayNightCycle.RegisterObserver(this);
            }
            else
            {
                Debug.LogWarning("DayNightCycle is not assigned to Sun.");
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
            // Логика для изменения положения солнца
            float angle = time * 360f; // Полный круг
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
