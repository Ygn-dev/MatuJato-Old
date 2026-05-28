using UnityEngine;

public class BotonCamara : MonoBehaviour
{
    public Collider2D triggerArea;
    public CameraRespondTrigger camaraScript;
    public DatosNivel datosNivel;
    public Respawn respawn;
    public bool antigirarxd;
    public Animator animacionPalanca;
    private bool estadoPalancaInicial = false;
    private bool antiGirarBuff;
    private bool alternarBuff;

    void Start()
    {
        respawn.respawnEvent += Reset;
        antiGirarBuff = antigirarxd;
        alternarBuff = datosNivel.alternar;
        if (animacionPalanca == null)
        {
            animacionPalanca = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El Player fue reconocido con éxito!");
            if (!camaraScript.activated)
            {
                Debug.Log("La cámara no estaba ocupada. Ejecutando lógica de giro y animación...");
                if (datosNivel.alternar)
                {
                    if (antigirarxd) camaraScript.Girar(90f, 3.5f);
                    else camaraScript.Girar(-90f, 3.5f);
                }
                else
                {
                    if (antigirarxd) camaraScript.Girar(-90f, 3.5f);
                    else camaraScript.Girar(90f, 3.5f);
                }
                if (animacionPalanca != null)
                {
                    bool estadoActual = animacionPalanca.GetBool("activada");
                    animacionPalanca.SetBool("activada", !estadoActual);
                }
                datosNivel.alternar = !datosNivel.alternar;
            }
            else Debug.LogError("Ojo: camaraScript.activated está en TRUE. La cámara está bloqueando este botón.");
        }
    }


    private void Reset()
    {
        datosNivel.alternar = alternarBuff;
        antigirarxd = antiGirarBuff;
        if (animacionPalanca != null)
        {
            animacionPalanca.SetBool("activada", estadoPalancaInicial);
            animacionPalanca.Play("Idle", 0, 0f);
        }
    }
}
