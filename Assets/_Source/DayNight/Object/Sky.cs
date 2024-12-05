using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Interfaces;

namespace DayNight
{
    public class Sky : MonoBehaviour, ITimeOfDayObserver
    {
        public DayNightCycle dayNightCycle;
        public Color morningColor;
        public Color dayColor;
        public Color eveningColor;
        public Color nightColor;
        private Camera camera;

        private void Start()
        {
            camera = Camera.main;
            if (dayNightCycle != null)
            {
                dayNightCycle.RegisterObserver(this);
            }
            else
            {
                Debug.LogWarning("DayNightCycle is not assigned to Sky.");
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
            Color targetColor;

            if (time < 0.25f)
                targetColor = morningColor;
            else if (time < 0.5f)
                targetColor = dayColor;
            else if (time < 0.75f)
                targetColor = eveningColor;
            else
                targetColor = nightColor;

            camera.backgroundColor = Color.Lerp(camera.backgroundColor, targetColor, Time.deltaTime);
        }
    }
}
