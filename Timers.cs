/// <summary>
/// The Timers class manages timers for executing callback functions after a specified duration.
/// </summary>
public class Timers : MonoBehaviour
{
    /// <summary>
    /// Gets the singleton instance of the Timers class.
    /// </summary>
    public static Timers Instance;

    /// <summary>
    /// Dictionary to store timers sorted by expiration time.
    /// </summary>
    SortedDictionary<float, Timer> _timers = new SortedDictionary<float, Timer>();

    /// <summary>
    /// Current time.
    /// </summary>
    float time = 0;

    /// <summary>
    /// Awake is called before the first frame update.
    /// </summary>
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        time += Time.deltaTime;

        List<float> expiredTimerKeys = new List<float>();

        // Iterate over timers and check for expired ones
        foreach (var kvp in _timers)
        {
            float key = kvp.Key;
            Timer timer = kvp.Value;

            if (timer.StartTime + timer.Duration < time)
            {
                timer.Callback();
                expiredTimerKeys.Add(key);
            }
        }

        // Remove expired timers
        for (int i = 0; i < expiredTimerKeys.Count; i++)
        {
            _timers.Remove(expiredTimerKeys[i]);
        }

        // Reset time if no active timers
        if (_timers.Count == 0)
        {
            time = 0;
        }
    }

    /// <summary>
    /// Set a timer with a given duration and callback function.
    /// </summary>
    /// <param name="duration">The duration of the timer.</param>
    /// <param name="callback">The callback function to execute when the timer expires.</param>
    public void SetTimer(float duration, Action callback)
    {
        _timers.Add(time + duration, new Timer(time, duration, callback));
    }
}

/// <summary>
/// Struct to represent a timer.
/// </summary>
public struct Timer
{
    /// <summary>
    /// The start time of the timer.
    /// </summary>
    public float StartTime;

    /// <summary>
    /// The duration of the timer.
    /// </summary>
    public float Duration;

    /// <summary>
    /// The callback function to execute when the timer expires.
    /// </summary>
    public Action Callback;

    /// <summary>
    /// Initializes a new instance of the Timer struct with the specified start time, duration, and callback function.
    /// </summary>
    /// <param name="startTime">The start time of the timer.</param>
    /// <param name="duration">The duration of the timer.</param>
    /// <param name="callback">The callback function to execute when the timer expires.</param>
    public Timer(float startTime, float duration, Action callback)
    {
        StartTime = startTime;
        Duration = duration;
        Callback = callback;
    }
}
