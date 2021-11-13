using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Curvas
{
    Linear,cubica,cuadratica
}

public class Tween : MonoBehaviour
{
    [Range(0,1)] [SerializeField] float tiempo, tiempototal;
    [SerializeField] float duracion;
    [SerializeField] Transform target;
    Vector3 PosInicial, PosFinal;
    public bool isplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        PosInicial = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TweenIniciar();
        }
        if (isplaying == false)
        {
            return;
        }
        if (tiempo >= 1)
        {
            isplaying = false;
            return;
        }
        transform.position = Vector3.Lerp(PosInicial, PosFinal, tiempo*tiempo);
        tiempototal = tiempototal + Time.deltaTime;
        tiempo = tiempototal/duracion ;        
       


    }

    void TweenIniciar()
    {
        isplaying = true;
        PosInicial = transform.position;
        PosFinal = target.position;
        tiempototal = 0;
        tiempo=0;

    }
    private float Linear( float tiempo)
    {
        return (tiempo);
    }
    private float cuadratica(float tiempo)
    {
        return (tiempo * tiempo * tiempo);
    }
    private float cubica(float tiempo)
    {
        return (tiempo*tiempo*tiempo);
    }
}
