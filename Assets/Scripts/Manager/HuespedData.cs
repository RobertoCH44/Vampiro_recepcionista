using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Huesped Data", menuName = "Huesped Data")]
public class HuespedData : ScriptableObject
{
    public string huespedName;
    public int blood;
    public int reputation;
    public int money;
    //public bool dead;

    public string HuespedName { get { return huespedName; } }
    public int Blood { get { return blood; } }
    public int Reputation { get { return reputation; } }
    public int Money { get { return money; } }
    //public bool Dead { get { return dead; } }

}