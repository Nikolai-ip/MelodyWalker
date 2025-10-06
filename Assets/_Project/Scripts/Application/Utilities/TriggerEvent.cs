using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Application.Utilities
{
    public class TriggerEvent<T>: IInitializable, IDisposable, ITriggerEventInvoker<T> where T : Component
    {
        public event Action<T> OnTriggerEnterEvent;
        public event Action<T> OnTriggerExitEvent;

        public bool Enable
        {
            get => _enable;
            set
            {
                _enable = value;
                OnEnableChanged(_enable);
            }
        }

        private readonly TriggerEvent _triggerEvent;
        private bool _enable;

        public TriggerEvent(TriggerEvent triggerEvent)
        {
            _triggerEvent = triggerEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T component))
                OnTriggerEnterEvent?.Invoke(component);
        }

        private void OnTriggerExit(Collider other)
        {
            if  (other.TryGetComponent(out T component))
                OnTriggerExitEvent?.Invoke(component);
        }

        public void Initialize()
        {
            SubscribeToTriggerEvents();
        }

        private void SubscribeToTriggerEvents()
        {
            _triggerEvent.OnTriggerEnterEvent += OnTriggerEnter;
            _triggerEvent.OnTriggerExitEvent += OnTriggerExit;
        }

        private void OnEnableChanged(bool enable)
        {
            if (enable)
                SubscribeToTriggerEvents();
            else
                RemoveTriggerSubscribtions();
        }

        private void RemoveTriggerSubscribtions()
        {
            _triggerEvent.OnTriggerEnterEvent -= OnTriggerEnter;
            _triggerEvent.OnTriggerExitEvent -= OnTriggerExit;
        }
        public void Dispose()
        {
            RemoveTriggerSubscribtions();
        }
    }

    public class TriggerEvent : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent;
        public event Action<Collider> OnTriggerExitEvent;
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }
    }
    public interface ITriggerEventInvoker<T> where T : Component
    {
        event Action<T> OnTriggerEnterEvent;
        event Action<T> OnTriggerExitEvent;
        public bool Enable { set; }
    }
}