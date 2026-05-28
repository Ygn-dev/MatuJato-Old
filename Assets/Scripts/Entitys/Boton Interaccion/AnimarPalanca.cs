using UnityEngine;

public class AnimarPalanca : MonoBehaviour
{
    public Animator animacionPalanca;
    private bool palancaDerecha = true;
    void Start()
    {
        if (animacionPalanca == null)
        {
            animacionPalanca = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (animacionPalanca != null)
            {
                if (palancaDerecha)
                {
                    //Como estaba a la derecha, va a la IZQUIERDA
                    animacionPalanca.SetTrigger("Izquierda");
                    palancaDerecha = false;
                }
                else
                {
                    //Regresa a la DERECHA
                    animacionPalanca.SetTrigger("Derecha");
                    palancaDerecha = true;
                }
            }
        }
    }

    // Al reiniciar el nivel, vuelve a su estado inicial (Derecha)
    public void ResetPalanca()
    {
        palancaDerecha = true;
        if (animacionPalanca != null)
        {
            animacionPalanca.Play("Idle", 0, 0f);
        }
    }
}
