using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotel : MonoBehaviour
{
    public Manager manager;

    public GameObject player,cameraObject;

    public GameObject puerta101, puerta102, puerta103, puerta201, puerta202, puerta203;
    public GameObject puerta301, puerta302, puerta303, puerta401, puerta402, puerta403;
    public GameObject habitacion1UI, habitacion2UI, habitacion3UI, habitacion4UI, habitacion5UI, habitacion6UI, habitacion7UI, habitacion8UI, habitacion9UI, habitacion10UI, habitacion11UI, habitacion12UI;

    public GameObject tablasH4, tablasH5, tablasH6;
    public GameObject tablasH7, tablasH8, tablasH9;
    public GameObject tablasH10, tablasH11, tablasH12;
    public GameObject piso3Construccion, piso3Azotea, piso3, piso3Compra;
    public GameObject piso4Construccion, piso4Azotea, piso4, piso4Compra;
    public GameObject numeroHPiso3, numeroHPiso4;
    public GameObject basura1, basura2, basura3, basura4;

    //Habitaciones
    public string habitacionActual;
    public GameObject activadorHombre, activadorMujer, activadorPayaso, activadorPadrecito, activadorDrogo, activadorMusico,activadorMago;
    public Stats stats;

    public ChangeScene changeScene;
    public string cinematicaPolicia;

    public Animator animfadeOut;

    //Mejora de hotel
    public int presupuesto;

    public AudioSource audioSource;
    public Text textNoche;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        textNoche.text = (":" + manager.noche);

        //ActivarPuertas/pisos/adornos y DesactivarBasura
        if (manager.h4 >= 1)
        {
            tablasH4.SetActive(false);
            puerta201.SetActive(true);
        }
        if(manager.h5 >= 1)
        {
            tablasH5.SetActive(false);
            puerta202.SetActive(true);
        }
        if(manager.h6 >= 1)
        {
            tablasH6.SetActive(false);
            puerta203.SetActive(true);
        }
        //
        if (manager.h7 >= 1)
        {
            tablasH7.SetActive(false);
            puerta301.SetActive(true);
        }
        if (manager.h8 >= 1)
        {
            tablasH8.SetActive(false);
            puerta302.SetActive(true);
        }
        if (manager.h9 >= 1)
        {
            tablasH9.SetActive(false);
            puerta303.SetActive(true);
        }
        //
        if (manager.h10 >= 1)
        {
            tablasH10.SetActive(false);
            puerta401.SetActive(true);
        }
        if (manager.h11 >= 1)
        {
            tablasH11.SetActive(false);
            puerta402.SetActive(true);
        }
        if (manager.h12 >= 1)
        {
            tablasH12.SetActive(false);
            puerta403.SetActive(true);
        }

        if (manager.basura1 >= 1)
        {
            basura1.SetActive(false);
        }
        if (manager.basura2 >= 1)
        {
            basura2.SetActive(false);
        }
        if (manager.basura3 >= 1)
        {
            basura3.SetActive(false);
        }
        if (manager.basura4 >= 1)
        {
            basura4.SetActive(false);
        }

        if (manager.piso3 >= 1)
        {
            piso3Compra.SetActive(false);
            if(manager.piso3 >= 2)
            {
                piso3Azotea.SetActive(false);
                numeroHPiso3.SetActive(true);
                piso3.SetActive(true);
            }
            if (manager.piso3 == 1)
            {
                manager.piso3 += 1;
                piso3Construccion.SetActive(true);
            }
            //Piso4
            piso4Compra.SetActive(true);
            piso4Azotea.SetActive(true);
            if (manager.piso4 >= 1)
            {
                piso4Compra.SetActive(false);
                if (manager.piso4 >= 2)
                {
                    piso4Azotea.SetActive(false);
                    numeroHPiso4.SetActive(true);
                    piso4.SetActive(true);
                }
                if (manager.piso4 == 1)
                {
                    manager.piso4 += 1;
                    piso4Construccion.SetActive(true);
                }
            }
        }

        //Poner Huespedes en habitaciones
        if (manager.habitacion01 != null)
        {
            puerta101.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion01.huespedName;
        }
        if (manager.habitacion02 != null)
        {
            puerta102.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion02.huespedName;
        }
        if (manager.habitacion03 != null)
        {
            puerta103.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion03.huespedName;
        }
        if (manager.habitacion04 != null)
        {
            puerta201.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion04.huespedName;
        }
        //
        if (manager.habitacion05 != null)
        {
            puerta202.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion05.huespedName;
        }
        if (manager.habitacion06 != null)
        {
            puerta203.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion06.huespedName;
        }
        if (manager.habitacion07 != null)
        {
            puerta301.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion07.huespedName;
        }
        if (manager.habitacion08 != null)
        {
            puerta302.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion08.huespedName;
        }
        if (manager.habitacion09 != null)
        {
            puerta303.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion09.huespedName;
        }
        if (manager.habitacion10 != null)
        {
            puerta401.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion10.huespedName;
        }
        if (manager.habitacion11 != null)
        {
            puerta402.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion11.huespedName;
        }
        if (manager.habitacion12 != null)
        {
            puerta403.GetComponent<CambioDeLugar>().nuevoLugar = manager.habitacion12.huespedName;
        }

        //Mejora Hotel
        presupuesto = manager.money;
    }
    public void BeberSangre(int blood)
    {
        manager.blood += blood;
        stats.SetValoresActuales();
    }

    //habitaciones Cambio de lugar del jugador y la camara A HABITACION CORRESPONDIENTE
    public void Piso1()
    {
        player.transform.position = new Vector3(0, -1.153f, 0);
    }
    public void Piso2()
    {
        player.transform.position = new Vector3(0, 6.63f, 0);
    }
    public void Piso3()
    {
        player.transform.position = new Vector3(0, 13.292f, 0);
    }
    public void Piso4()
    {
        player.transform.position = new Vector3(0, 20.006f, 0);
    }

    public void TeleportTo(Vector3 place)
    {
        player.transform.position = place;
    }

    public void HabitacionHombre(int habitacion)
    {               
        if(habitacion == 1 && manager.habitacion01Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorHombre.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorHombre.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionMujer(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorMujer.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorMujer.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionPayaso(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorPayaso.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorPayaso.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionPadrecito(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorPadrecito.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorPadrecito.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionDrogo(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorDrogo.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorDrogo.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionMago(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorMago.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorMago.transform.position;
        cameraObject.transform.position = player.transform.position;
    }
    public void HabitacionMusico(int habitacion)
    {
        if (habitacion == 1 && manager.habitacion01Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 2 && manager.habitacion02Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 3 && manager.habitacion03Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 4 && manager.habitacion04Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 5 && manager.habitacion05Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 6 && manager.habitacion06Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 7 && manager.habitacion07Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 8 && manager.habitacion08Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 9 && manager.habitacion09Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 10 && manager.habitacion10Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 11 && manager.habitacion11Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }
        if (habitacion == 12 && manager.habitacion12Dead)
        {
            activadorMusico.SendMessage("HuespedMuerto");
        }

        player.transform.position = activadorMusico.transform.position;
        cameraObject.transform.position = player.transform.position;
    }

    //Actualizar muertes
    public void AsesinatoHabitacion()
    {
        if (habitacionActual == "habitacion1")
        {
            manager.habitacion01Dead = true;
        }
        if (habitacionActual == "habitacion2")
        {
            manager.habitacion02Dead = true;
        }
        if (habitacionActual == "habitacion3")
        {
            manager.habitacion03Dead = true;
        }
        if (habitacionActual == "habitacion4")
        {
            manager.habitacion04Dead = true;
        }
        if (habitacionActual == "habitacion5")
        {
            manager.habitacion05Dead = true;
        }
        if (habitacionActual == "habitacion6")
        {
            manager.habitacion06Dead = true;
        }
        if (habitacionActual == "habitacion7")
        {
            manager.habitacion07Dead = true;
        }
        if (habitacionActual == "habitacion8")
        {
            manager.habitacion08Dead = true;
        }
        if (habitacionActual == "habitacion9")
        {
            manager.habitacion09Dead = true;
        }
        if (habitacionActual == "habitacion10")
        {
            manager.habitacion10Dead = true;
        }
        if (habitacionActual == "habitacion11")
        {
            manager.habitacion11Dead = true;
        }
        if (habitacionActual == "habitacion12")
        {
            manager.habitacion12Dead = true;
        }
    }

    //Checar Habitaciones Para los resultados-Llamado desde TimerHotel al terminar el tiempo
    public void ChecarHaibitaciones()
    {
        if(manager.habitacion01 != null)
        {
            if (!manager.habitacion01Dead)
            {
                habitacion1UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion01.huespedName;
                habitacion1UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion01.money;
                manager.money += manager.habitacion01.money;
            }
            else
            {
                habitacion1UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion01.huespedName;
                habitacion1UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion01.reputation;
                manager.reputation += manager.habitacion01.reputation;
            }            
        }
        if (manager.habitacion02 != null)
        {
            if (!manager.habitacion02Dead)
            {
                habitacion2UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion02.huespedName;
                habitacion2UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion02.money;
                manager.money += manager.habitacion02.money;
            }
            else
            {
                habitacion2UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion02.huespedName;
                habitacion2UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion02.reputation;
                manager.reputation += manager.habitacion02.reputation;
            }
        }
        if (manager.habitacion03 != null)
        {
            if (!manager.habitacion03Dead)
            {
                habitacion3UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion03.huespedName;
                habitacion3UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion03.money;
                manager.money += manager.habitacion03.money;
            }
            else
            {
                habitacion3UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion03.huespedName;
                habitacion3UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion03.reputation;
                manager.reputation += manager.habitacion03.reputation;
            }
        }
        if (manager.habitacion04 != null)
        {
            if (!manager.habitacion04Dead)
            {
                habitacion4UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion04.huespedName;
                habitacion4UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion04.money;
                manager.money += manager.habitacion04.money;
            }
            else
            {
                habitacion4UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion04.huespedName;
                habitacion4UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion04.reputation;
                manager.reputation += manager.habitacion04.reputation;
            }
        }
        if (manager.habitacion05 != null)
        {
            if (!manager.habitacion05Dead)
            {
                habitacion5UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion05.huespedName;
                habitacion5UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion05.money;
                manager.money += manager.habitacion05.money;
            }
            else
            {
                habitacion5UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion05.huespedName;
                habitacion5UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion05.reputation;
                manager.reputation += manager.habitacion05.reputation;
            }
        }
        if (manager.habitacion06 != null)
        {
            if (!manager.habitacion06Dead)
            {
                habitacion6UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion06.huespedName;
                habitacion6UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion06.money;
                manager.money += manager.habitacion06.money;
            }
            else
            {
                habitacion6UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion06.huespedName;
                habitacion6UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion06.reputation;
                manager.reputation += manager.habitacion06.reputation;
            }
        }
        if (manager.habitacion07 != null)
        {
            if (!manager.habitacion07Dead)
            {
                habitacion7UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion07.huespedName;
                habitacion7UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion07.money;
                manager.money += manager.habitacion07.money;
            }
            else
            {
                habitacion7UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion07.huespedName;
                habitacion7UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion07.reputation;
                manager.reputation += manager.habitacion07.reputation;
            }
        }
        if (manager.habitacion08 != null)
        {
            if (!manager.habitacion08Dead)
            {
                habitacion8UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion08.huespedName;
                habitacion8UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion08.money;
                manager.money += manager.habitacion08.money;
            }
            else
            {
                habitacion8UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion08.huespedName;
                habitacion8UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion08.reputation;
                manager.reputation += manager.habitacion08.reputation;
            }
        }
        if (manager.habitacion09 != null)
        {
            if (!manager.habitacion09Dead)
            {
                habitacion9UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion09.huespedName;
                habitacion9UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion09.money;
                manager.money += manager.habitacion09.money;
            }
            else
            {
                habitacion9UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion09.huespedName;
                habitacion9UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion09.reputation;
                manager.reputation += manager.habitacion09.reputation;
            }
        }
        if (manager.habitacion10 != null)
        {
            if (!manager.habitacion10Dead)
            {
                habitacion10UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion10.huespedName;
                habitacion10UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion10.money;
                manager.money += manager.habitacion10.money;
            }
            else
            {
                habitacion10UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion10.huespedName;
                habitacion10UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion10.reputation;
                manager.reputation += manager.habitacion10.reputation;
            }
        }
        if (manager.habitacion11 != null)
        {
            if (!manager.habitacion11Dead)
            {
                habitacion11UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion11.huespedName;
                habitacion11UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion11.money;
                manager.money += manager.habitacion11.money;
            }
            else
            {
                habitacion11UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion11.huespedName;
                habitacion11UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion11.reputation;
                manager.reputation += manager.habitacion11.reputation;
            }
        }
        if (manager.habitacion12 != null)
        {
            if (!manager.habitacion12Dead)
            {
                habitacion12UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion12.huespedName;
                habitacion12UI.transform.GetChild(1).GetComponent<Text>().text = "+$" + manager.habitacion12.money;
                manager.money += manager.habitacion12.money;
            }
            else
            {
                habitacion12UI.transform.GetChild(0).GetComponent<Text>().text = manager.habitacion12.huespedName;
                habitacion12UI.transform.GetChild(1).GetComponent<Text>().text = "Reputacion " + manager.habitacion12.reputation;
                manager.reputation += manager.habitacion12.reputation;
            }
        }

        manager.Guardar();

        //GAME OVER por la reputacion
        if (manager.reputation <= 0)
        {
            changeScene.levelChange = cinematicaPolicia;
        }
    }

    //Mejora del hotel- LLamado desde: CompraMejora/CompraDeHabitacion/CompraPiso
    public void AgregarHabitacion(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.habitaciones += 1;
        manager.AgregarHabitacion(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }
    public void CompraMejora(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.QuitarBasura(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }
    public void CompraPiso(int costo, int reputacion, int id)
    {
        audioSource.Play();
        presupuesto -= costo;
        manager.money = presupuesto;
        manager.AgregarPiso(id);
        manager.reputation += reputacion;
        stats.SetValoresActuales();
    }

    public void FadeToBlack()
    {
        animfadeOut.Play("FadeIn");
    }
}
