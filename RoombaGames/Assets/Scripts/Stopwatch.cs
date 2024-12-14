using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text display;
    float timeValue;
    bool shouldRun;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRun) {
            timeValue += Time.deltaTime;
        } 
    }

    public void start() {
        shouldRun = true;
    }

    public void stop() {
        print(timeValue);
        shouldRun = false; 
        display.text = "Your time: " + timeValue.ToString("0.00") + "s";
    }

    public void reset() {
        shouldRun = false;
        timeValue = 0;
    }

    public float GetTimeValue() {
        return timeValue;
    }
}
