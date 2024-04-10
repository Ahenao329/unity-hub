using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{

    #region Atributos
    public float VelocidadMovimiento = 5.0f;
    public float VelocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float FuerzaSalto = 8f;
    public bool PuedoSaltar;
    public float VelocidadInicial;
    public float VelocidadAgachado;

    #endregion
     
    #region Metodos
    // Start is called before the first frame update
    void Start()
    {
        PuedoSaltar = false;
        anim = GetComponent<Animator>();

        VelocidadInicial = VelocidadMovimiento;
        VelocidadAgachado = VelocidadMovimiento*0.5F;
    }

    /*La difertencia con el update es que hara que cada cuadro corra al mismo timpo
    sinb importar en que computadora se corra el juego. Estandariza el tiempo*/
    void FixedUpdate() {
        transform.Rotate(0, x * Time.deltaTime * VelocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * VelocidadMovimiento);
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");        

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);


        if (PuedoSaltar)
        {  
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salte", true);
                rb.AddForce(new Vector3(0, FuerzaSalto, 0), ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {

                anim.SetBool("Agachado", true);
                VelocidadMovimiento = VelocidadAgachado;
            }
            else
            {
                anim.SetBool("Agachado", false);
                VelocidadMovimiento = VelocidadInicial;
            }
            anim.SetBool("TocoSuelo", true);
        }
        else
        {
            EstoyCallendo();
        }
    }
    public void EstoyCallendo()
    {
        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Salte", false);

    }
#endregion
}
