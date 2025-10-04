using System;
using UnityEngine;

namespace _Project.Scripts.Application.UseCases.Common.ZoneTriggers
{
    public class ZoneTrigger<T> : MonoBehaviour
    {
        public event Action<T> ZoneEntered;
        public event Action<T> ZoneStay;
        public event Action<T> ZoneExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out T component))
                ZoneEntered?.Invoke(component);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out T component))
                ZoneStay?.Invoke(component);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out T component))
                ZoneExited?.Invoke(component);
        }
    }
}