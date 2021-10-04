using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherTrigger : MonoBehaviour
{
    public WeatherType weather;
    private WeatherSystem weatherSystem;

    // Start is called before the first frame update
    void Start()
    {
        weatherSystem = FindObjectOfType<WeatherSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            weatherSystem.ChangeWeather(weather);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            weatherSystem.ChangeWeather(WeatherType.NONE);
        }
    }
}
