using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Game.Scripts.Services.Audio.Utilities
{
    public class AudioFader
    {
        public async UniTask FadeAsync(
            AudioSource audioSource,
            bool fadeIn,
            float duration,
            float globalVolume,
            CancellationToken token = default,
            Action onComplete = null)
        {
            float from = fadeIn ? 0f : globalVolume;
            float to = fadeIn ? globalVolume : 0f;
            float time = 0f;


            if (duration <= 0f)
            {
                audioSource.volume = to;
                onComplete?.Invoke();
                return;
            }

            try
            {
                while (time < duration)
                {
                    token.ThrowIfCancellationRequested();

                    time += Time.deltaTime;
                    float t = Mathf.Clamp01(time / duration);
                    audioSource.volume = Mathf.Lerp(from, to, t);
                    
                    await UniTask.Yield(PlayerLoopTiming.Update, token);
                }

                audioSource.volume = to;
                onComplete?.Invoke();
            }
            catch (OperationCanceledException) { }
        }
    }
}