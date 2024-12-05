using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Interfaces;

namespace DayNight
{
    public class DayNightCycle : MonoBehaviour, IObservable
    {
        public float dayDuration = 60f; // Длительность суток в секундах
        private float timeOfDay = 0f;
        private List<ITimeOfDayObserver> observers = new List<ITimeOfDayObserver>();

        void Start()
        {
            StartCoroutine(UpdateTimeOfDay());
        }

        public void RegisterObserver(ITimeOfDayObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(ITimeOfDayObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.OnTimeOfDayChanged(timeOfDay);
            }
        }

        private IEnumerator UpdateTimeOfDay()
        {
            while (true)
            {
                timeOfDay += Time.deltaTime / dayDuration;
                if (timeOfDay >= 1f) timeOfDay = 0f;
                Notify();
                yield return null;
            }
        }
    }
}

