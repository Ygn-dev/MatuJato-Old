using UnityEngine;

public class AnimarPalanca : MonoBehaviour
{
    public Animator animacionPalanca;

    // Como arranca a la derecha, la inicializamos en true
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
                    // Primera entrada: Como estaba a la derecha, va a la IZQUIERDA
                    animacionPalanca.SetTrigger("Izquierda");
                    palancaDerecha = false;
                    Debug.Log("Palanca movida a la IZQUIERDA");
                }
                else
                {
                    // Segunda entrada: Regresa a la DERECHA
                    animacionPalanca.SetTrigger("Derecha");
                    palancaDerecha = true;
                    Debug.Log("Palanca movida a la DERECHA");
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
