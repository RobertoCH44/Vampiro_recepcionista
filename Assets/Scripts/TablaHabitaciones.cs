using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaHabitaciones : MonoBehaviour
{

    public Recepcion recepcion;
    
    public void Habitacion1()
    {
        recepcion.AsignarHabitacion(1);
        recepcion.llave1.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion2()
    {
        recepcion.AsignarHabitacion(2);
        recepcion.llave2.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion3()
    {
        recepcion.AsignarHabitacion(3);
        recepcion.llave3.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion4()
    {
        recepcion.AsignarHabitacion(4);
        recepcion.llave4.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion5()
    {
        recepcion.AsignarHabitacion(5);
        recepcion.llave5.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion6()
    {
        recepcion.AsignarHabitacion(6);
        recepcion.llave6.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Habitacion7()
    {
        recepcion.AsignarHabitacion(7);
        recepcion.llave7.SetActive(false);
        this.gameObject.SetActive(false);
    }
}