using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class WheatherManager : MonoBehaviour
{
   [Header("Tempo da metade do dia em minutos")]
   public float halfdaytime;
   private float daytime;
   private int day;
   public bool isDay;
   public bool isNight;
   [Header("Test Text")]
   public Text timeText;
   [Header("Day Image")] 
   public Image dayCircle;
   [Header("Sun")]
   public Light sunlight;
   public Color[] colors;
   public float lerpTime;
   private int colorIndex;
   private float t = 0f;
   private int len;
   private float time = 120;
   private void Start()
   {
      daytime = 21600 + halfdaytime * 60;
      len = colors.Length;
   }
   
   private void Update()
   {
      if (daytime >= 86400) {
         SetDay();
      }else if (daytime >= 64800) {
         SetNight();
      }
      
      sunlight.transform.Rotate(Time.deltaTime * ((43200/(halfdaytime * 60)/270) / 2),0,0);
      dayCircle.transform.Rotate(0,0,Time.deltaTime * (43200/(halfdaytime * 60)/270) );
      daytime += Time.deltaTime * (43200/(halfdaytime * 60));
      SetTestText();
      SetSunColor();
   }

   private void SetSunColor()
   {
      sunlight.color = Color.Lerp(sunlight.color, colors[colorIndex],lerpTime * Time.deltaTime);
      t += Time.deltaTime * (43200/(halfdaytime * 60));
      if (t > 10000f )
      {
         t = 0f;
         colorIndex += 1;
         colorIndex = (colorIndex >= len) ? 0 : colorIndex;
      }
      Debug.Log("T " + t);
      Debug.Log("Color index " + colorIndex);
   }
   private void SetNight()
   {
      isDay = false;
      isNight = true;
      RenderSettings.ambientIntensity = 0;
   }
   private void SetDay()
   {
      day++;
      daytime = 21600;
      t = 0;
      sunlight.transform.rotation = quaternion.Euler(40,0,-40);
      colorIndex = 0;
      sunlight.color = Color.Lerp(sunlight.color, colors[colorIndex],lerpTime * Time.deltaTime);
      dayCircle.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
      isDay = true;
      isNight = false;
      RenderSettings.ambientIntensity = 0;
   }
   void SetTestText()
   {
      float hour;
      hour = ((daytime/60)/60);
      if (hour > 23) {
         hour = 0;
      }
      timeText.text = $"Hora atual {hour.ToString("0")}\n         Day {day}";
   }
}

