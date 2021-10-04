using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType
{
    // 与weatherParticles顺序对应，none放在最后
    SNOW,
    NONE,
}

public class WeatherSystem : MonoBehaviour
{
    public ParticleSystem[] weatherParticles;

    private WeatherType currentWeather;

    void Start()
    {
        ResetWeather();
    }

    public void ChangeWeather(WeatherType _weather)
    {
        if (_weather == currentWeather) return;

        ResetWeather();

        if (_weather == WeatherType.NONE)
        {
            // Do Nothing
        }
        else
        {
            // Play Particle
            weatherParticles[(int)_weather].Play();
            currentWeather = _weather;
        } 
    }

    private void ResetWeather()
    {
        foreach (ParticleSystem particle in weatherParticles)
        {
            particle.Stop();
        }
        currentWeather = WeatherType.NONE;
    }

    private void Update()
    {
        /*
        // MARKER TEST
        if (Input.GetKeyDown(KeyCode.T))
        {
            ParticleSystem rain = weatherParticles[0];
            if (rain.isPlaying)
                rain.Stop();
            else
                rain.Play();
        }
        */
    }
}
