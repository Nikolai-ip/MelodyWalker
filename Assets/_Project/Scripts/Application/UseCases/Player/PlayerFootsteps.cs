using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float maxStepRate = 3f;      // шаг/с на высокой скорости
    [SerializeField] private float speedForMaxRate = 5f;  // скорость, при которой достигается maxStepRate
    [SerializeField] private float minSpeedForSteps = 0.2f; // ниже — шагов нет и сбрасываем накопление
    [SerializeField] private float minStepInterval = 0.12f; // антидребезг (сек)

    private AudioSource _audio;
    private Vector3 _lastPos;
    private float _accum;
    private float _lastStepTime;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.playOnAwake = false;
        _audio.spatialBlend = 1f;
        _lastPos = transform.position;
        _lastStepTime = -999f;
    }

    private void Update()
    {
        var pos = transform.position;
        float dt = Mathf.Max(Time.deltaTime, 0.0001f);
        float speed = (pos - _lastPos).magnitude / dt;
        _lastPos = pos;

        // если почти стоим — сбрасываем долг и выходим
        if (speed < minSpeedForSteps)
        {
            _accum = 0f;
            return;
        }

        // линейная частота от 0 до maxStepRate
        float rate = maxStepRate * Mathf.Clamp01(speed / Mathf.Max(speedForMaxRate, 0.0001f));
        _accum = Mathf.Min(_accum + rate * dt, 1.5f); // лёгкий лимит, чтобы не копился «задолжник»

        // как только накопили единицу шага — и прошёл минимальный интервал — играем
        if (_accum >= 1f && (Time.time - _lastStepTime) >= minStepInterval)
        {
            Play();
            _accum -= 1f;
            _lastStepTime = Time.time;
        }
    }

    private void Play()
    {
        if (clips == null || clips.Length == 0) return;
        _audio.PlayOneShot(clips[Random.Range(0, clips.Length)], 1f);
    }
}
