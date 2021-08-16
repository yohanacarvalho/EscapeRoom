using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abreFrigobar : MonoBehaviour
{

    public Animator a;
    int estado = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0)){
         

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //executa a especial
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.transform != null){ 

                    if (hit.transform.gameObject.name.Equals("trigger_frigobar")){                        
                        print("valor de int estado = "+estado);
                        print("valor de Animator 'estado' = "+ a.GetInteger("estado"));

                        estado *= -1;
                        a.SetInteger("fechado", estado);

                    }
                

                }
            }
        }
    }
}
