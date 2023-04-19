using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdapter : TimeData
{
  public TimeAdapter(TimeControler timer)
  {
    day = timer.dateSave.day;
    month = timer.dateSave.month;
    year = timer.dateSave.year;
  }
}
