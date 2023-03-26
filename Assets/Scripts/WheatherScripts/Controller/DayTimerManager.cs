using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DayTimerManager : MonoBehaviour
{
    public WheatherManagerFSM wheatherManager;
    [Header("Tempo da metade do dia em minutos")]
    public float halfdaytime;
    private float daytime;

    [Header("Time Text")]
    public Text dayStatusText;

    [Header("Day Image")]
    public Image dayCircle;

    [Header("DayLightCycle")]
    [SerializeField]
    public DayLightSettings dayLight;

    [Header("DayResume")]
    public GameObject preDayObject;
    public Text preDayText;
    private bool preDay;


    [Header("DayTimer")]
    private int year;
    private int month;
    private int day;
    private int colorIndex;
    private float t = 0f;
    private int len;
    private float time = 120;
    private int monthType;
    private void Start()
    {
        daytime = 21600 + halfdaytime * 60;
        len = dayLight.colors.Length;
        wheatherManager.MonthSelection(monthType);
    }
    private void Update()
    {
        if (daytime >= 86400)
        {
            daytime = 21600;
            preDay = true;
            preDayObject.SetActive(true);
            AttPreDayText();
        }
        else if (daytime >= 64800)
        {
            SetNight();
        }
        if (preDay == false)
        {
            dayLight.sunlight.transform.Rotate(Time.deltaTime * ((43200 / (halfdaytime * 60) / 270) / 2), 0, 0);
            dayCircle.transform.Rotate(0, 0, Time.deltaTime * (43200 / (halfdaytime * 60) / 270));

            daytime += Time.deltaTime * (43200 / (halfdaytime * 60));
            SetSunColor();
        }
        AttDataText();
    }
    private void SetSunColor()
    {
        dayLight.sunlight.color = Color.Lerp(dayLight.sunlight.color, dayLight.colors[colorIndex], dayLight.dayLerpTime * Time.deltaTime);
        t += Time.deltaTime * (43200 / (halfdaytime * 60));
        if (t > 10000f)
        {
            t = 0f;
            colorIndex += 1;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
    private void SetNight()
    {
    }
    public void SetDay()
    {
        SetData();
        //Reset All DaySettings
        t = 0;
        dayLight.sunlight.transform.rotation = quaternion.Euler(40, 0, -40);
        colorIndex = 0;
        dayLight.sunlight.color = Color.Lerp(dayLight.sunlight.color, dayLight.colors[colorIndex], dayLight.dayLerpTime * Time.deltaTime);
        dayCircle.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }
    public void NextDay()
    {
        preDayText.text = "";
        SetDay();
        preDayObject.SetActive(false);
        preDay = false;
    }

    void AttDataText()
    {
        float hour;
        hour = ((daytime / 60) / 60);
        if (hour > 23.99f)
        {
            hour = 0;
        }
        dayStatusText.text = $"Hora atual {hour.ToString("0.00")}\nDia {day + 1}\nMês: {month + 1}\nAno:{1993 + year}";
    }
    private void SetData()
    {
        if (monthType == 3)
        {
            monthType = 0;
        }
        else if (monthType < 3)
        {
            monthType++;
        }
        //Faz O Dia e o Mes rodar
        if (day > 19)
        {
            day = 0;
            if (month > 4)
            {
                year++;
                month = 1;
            }
            else
            {
                month++;
                wheatherManager.MonthSelection(monthType);
            }
        }
        else
        {
            day++;
            wheatherManager.GetSetWheather();
        }
    }
    private void AttPreDayText()
    {
        preDayText.text = "";
        StartCoroutine(PreDayText($"Dia: {day + 1} \nMês: {month + 1}\nMieuros Recebido hoje: {1}", 0));
    }
    IEnumerator PreDayText(string text, int aux)
    {
        yield return new WaitForSeconds(.06f);
        int i = aux;
        if (i < text.Length)
        {
            preDayText.text += text[i];
        }
        if (aux >= text.Length)
        {
            StopCoroutine("PreDayText");
        }
        else
        {
            i++;
            StartCoroutine(PreDayText(text, i));
        }
    }
}
[Serializable]
public class DayLightSettings
{
    public Color[] colors;
    public Light sunlight;
    public float dayLerpTime;
}

