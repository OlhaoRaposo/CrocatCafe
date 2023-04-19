using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControler : MonoBehaviour
{
    [Header("Bool reference")]
    public bool isNight;
    public DateSave dateSave;
    [SerializeField]
    private float timeMultiplier;
    [SerializeField]
    private float startHour;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private SunLight sunLight;
    [Header("EndOfTheDayText")] 
    [SerializeField]
    private Text endOfDayText;
    public GameObject endOfTheDayObject;
    [SerializeField]
    private bool waitingForEndOfTheDay;
    [Header("ScriptsReferences")]
    [SerializeField]
    private WheatherManagerFSM wheatherManager;
    [SerializeField]
    private ArmazenManager armazen;
    
    private DateTime currentTime;
    private TimeSpan CalculateTimeDiference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if (difference.TotalSeconds < 0) {
            difference += TimeSpan.FromHours(24);
        }
        return difference;
    }
    
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunLight.sunriseTime = TimeSpan.FromHours(sunLight.sunriseHour);
        sunLight.sunsetTime = TimeSpan.FromHours(sunLight.sunsetHour);
        StartOfTheDay();
    }

    void Update()
    {
        if (!waitingForEndOfTheDay)
        {
            UpdateTimeOfDay();
            RotateSun();
            UpdateLightSettings();
        }
    }
    private void RotateSun()
    {
        float sunLightRotation;
        if (currentTime.TimeOfDay > sunLight.sunriseTime && currentTime.TimeOfDay < sunLight.sunsetTime) {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDiference(sunLight.sunriseTime, sunLight.sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDiference(sunLight.sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
            
        }else {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDiference(sunLight.sunsetTime, sunLight.sunriseTime);
            TimeSpan timeSinseSunset = CalculateTimeDiference(sunLight.sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinseSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }
        sunLight.sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation,Vector3.right);
        sunLight.clock.transform.rotation = Quaternion.AngleAxis(sunLightRotation,Vector3.forward);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.sunLight.transform.forward, Vector3.down);
        sunLight.sunLight.intensity = Mathf.Lerp(0, sunLight.maxSunLightIntesity, sunLight.lightAnimation.lightChangeCurve.Evaluate(dotProduct));
        sunLight.moonLight.intensity = Mathf.Lerp(sunLight.maxMoonLightIntesity, 0, sunLight.lightAnimation.lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(sunLight.lightAnimation.nightAmbientLight, sunLight.lightAnimation.dayAmbientLight, sunLight.lightAnimation.lightChangeCurve.Evaluate(dotProduct));
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier * 100);
        if (currentTime.Hour == 0) {
            EndOftheDay();
            waitingForEndOfTheDay = true;
        }else if (currentTime.Hour == 19)
        {
            NightTime(true);
        }
        if (timeText != null) {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void NightTime(bool light)
    {
        foreach (GameObject post in sunLight.post)
        {
            GameObject lightObj;
            lightObj = post.transform.GetChild(0).gameObject;
            lightObj.SetActive(light);
            isNight = light;
        }
        
    }
    private void EndOftheDay()
    {
        if (dateSave.day >=2) {
            dateSave.day = 1;
            dateSave.month += 1;
            
        }else if(dateSave.month >= 3) {
            dateSave.month = 0;
            dateSave.year += 1;
        }else {
            dateSave.day += 1;
            wheatherManager.GetSetWheather();
        }
        wheatherManager.MonthSelection(dateSave.month);
        endOfTheDayObject.SetActive(true);
        dateSave.mieuros = armazen.money - dateSave.mieuros;
        StartCoroutine(EndOfTheDay($"Dia: {dateSave.day} \nMês: {dateSave.month + 1}\nAno: {dateSave.year}\nMieuros Recebido hoje: {dateSave.mieuros}",0));
    }

    public void StartOfTheDay()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        endOfDayText.text = "";
        endOfTheDayObject.SetActive(false);
        waitingForEndOfTheDay = false;
        dateSave.mieuros = armazen.money;
        NightTime(false);
    }
    IEnumerator EndOfTheDay(string text, int aux)
    {
        yield return new WaitForSeconds(.06f);
        int i = aux;
        if (i < text.Length) {
            endOfDayText.text += text[i];
        }
        
        if (aux >= text.Length) {
            StopCoroutine("PreDayText");
        }else {
            i++;
            StartCoroutine(EndOfTheDay(text, i));
        }
    }
}
[Serializable]
public class DateSave
{
    public int day = 1;
    public int month = 1;
    public int year = 2002;
    public int mieuros;
}
[Serializable]
public class SunLight
{
    [Header("Light")]
    public Light sunLight;
    public float maxSunLightIntesity;

    [Header("Sunrise")]
    public float sunriseHour;
    public TimeSpan sunriseTime;
    [Header("Sunset")]
    public float sunsetHour;
    public TimeSpan sunsetTime;
    [Header("Moon")]
    public Light moonLight;
    public float maxMoonLightIntesity;
    [Header("Animation")]
    public LightAnimation lightAnimation;
    public GameObject clock;
    public GameObject[] post;
}
[Serializable] 
public class LightAnimation
{
    [Header("LightAnimation")]
    public AnimationCurve lightChangeCurve;
    public Color dayAmbientLight;
    public Color nightAmbientLight;
}
