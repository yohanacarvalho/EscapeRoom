using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcMochila : MonoBehaviour
{


    private int vazios = 6;

    public GameObject[] Slots;

    public GameObject Chave;

    public GameObject[] Mensagens;

    // Start is called before the first frame update
    void Start()
    {
        print("Valor de Vazios = "+vazios);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1)){
            desligaMensagens();
        }
     

        //raycast para coletar itens ----------------------------
        if (Input.GetMouseButtonDown(0)){
            

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //executa a especial
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.transform != null){                    

                    //Atualiza a mochila com o objeto coletado
                    //Codigo passando o objeto: hit.transform.gameObject
                    if (hit.transform.gameObject.name.Equals("butter_object")){
                        atualizaMochila("butter_slot");
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.name.Equals("farinha_object")){
                        atualizaMochila("farinha_slot");
                        Destroy(hit.transform.gameObject);
                    }

                    else if (hit.transform.gameObject.name.Equals("fermento_object")){
                        atualizaMochila("fermento_slot");
                        Destroy(hit.transform.gameObject);
                    }

                    else if (hit.transform.gameObject.name.Equals("ovos_object")){
                        atualizaMochila("ovos_slot");
                        Destroy(hit.transform.gameObject);
                    }

                    else if (hit.transform.gameObject.name.Equals("sugar_object")){
                        atualizaMochila("sugar_slot");
                        Destroy(hit.transform.gameObject);
                    }                    

                    else if (hit.transform.gameObject.name.Equals("milk_object")){
                        atualizaMochila("milk_slot");
                        Destroy(hit.transform.gameObject);
                    }

                    else if (hit.transform.gameObject.name.Equals("chave_object")){
                        atualizaMochila("chave_slot");
                        Destroy(hit.transform.gameObject);
                    }

                    //funções da forma
                    else if (hit.transform.gameObject.name.Equals("forma_object")){
                        //verifica primeiro se jogador tem todos os ingredientes ativados:
                        if (temTodosIngredientes()){

                            //Destroi inventario todo
                            destroiInventario();
                            atualizaMochila("forma_slot");
                            Destroy(hit.transform.gameObject);
                        }

                    }

                    //funções do forno
                    else if (hit.transform.gameObject.name.Equals("forno_object")){
                        //busca se a forma ta ativa
                        if (GameObject.Find("forma_slot").activeSelf == true){
                            //se sim destroi a forma e da a chave
                            Destroy(GameObject.Find("forma_slot"));
                            Chave.SetActive(true);

                        }

                    }
                    
                    
                }
            }
        }

        //----------------------------------------------------------
    }

    

    public void desligaMensagens(){
        
        print("Desligando todas as mensagens");

        for (int i = 0; i < Mensagens.Length; i++){
            Mensagens[i].SetActive(false);
        }

    }


    void atualizaMochila(string nomeObjeto){

        print("Clicou em " + nomeObjeto + "\n");

        int i = 0;
        for ( i = 0; i < 8; i++){
            if ( Slots[i].name.Equals( nomeObjeto ) ){                
                Slots[i].SetActive(true);
                vazios--;
                print("valor de i = "+i);
                print("Valor de Vazios = "+vazios);
                break;
            }
        }
        
    }


    bool temTodosIngredientes(){
        
        if (vazios > 0){
            return false;
        }
        
        return true;
    }

    void destroiInventario(){
        for (int i = 0; i < 8; i++){
            Slots[i].SetActive(false);
        }
    }
}
