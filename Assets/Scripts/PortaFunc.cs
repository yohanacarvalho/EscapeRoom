using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFunc : MonoBehaviour
{

    public GameObject ObjetoAtual; 
    public GameObject ObjetoEssencial;   

    public GameObject MensagemSucesso;   
    public GameObject MensagemFalha;     

     public Animator Animation;  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){

            //verifica se a mensagem de falaha esta ativa
            if (MensagemFalha.activeSelf == true){
                MensagemFalha.SetActive(false);
            }

            //calcula qual objeto foi clicado
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //executa a especial
            if(Physics.Raycast(ray, out hit, 100.0f)){
                if (hit.transform != null){

                    //Faz algo aqui
                    //Codigo passando o objeto: hit.transform.gameObject
                    if (hit.transform.gameObject == ObjetoAtual){
                        especial();                        
                    }

                    


                    
                }
            }
        }

        //Termina o jogo depois de ter dado a chave
        if ( MensagemSucesso.activeSelf && Input.GetKey("return")){
            print("fim de jogo");
            Application.Quit();
        }

    }


    void especial(){

        //verifica se contém a chave
        if (ObjetoEssencial.activeSelf == true){

            //então finaliza o jogo
            Animation.SetInteger("fechado", -1);
            MensagemSucesso.SetActive(true);
            Destroy(ObjetoEssencial);
        }
        else {

            //mostra a mensagem que precisa da chave
            MensagemFalha.SetActive(true);
        }

    }
}
