using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptReceita : MonoBehaviour
{

    public GameObject ObjetoClique;
    public GameObject ObjetoMensagem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //raycast para coletar itens ----------------------------
        if (Input.GetMouseButtonDown(0)){

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //executa a especial
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.transform != null){ 

                    if (hit.transform.gameObject == ObjetoClique ){
                        ObjetoMensagem.SetActive(true);
                    }

                }
            }
        }        
    }
}
