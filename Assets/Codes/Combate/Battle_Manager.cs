using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Manager : MonoBehaviour
{
    [Header("Conectar com gerente de combate do oponente")]
    public GameObject vidaInimigo;

    [Header("Conectar com esse gerente de combate")]
    public GameObject vidaAmigo;

    [Header("Conectar aqui")]
    public GameObject tiposDeAtaque;

    [Header("Conectar com gerente de cena")]
    public GameObject manejamentoDeCena;

    private Button botaoApertado;

    [Header("Não mudar")]
    public int dano;
    public float tempoDeEspera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lancar_Ataque(Button esseBotao)
    {
        ////////////////////////////////////// interagir com o botão
        botaoApertado = esseBotao;

        esseBotao.interactable = false;

        esseBotao.GetComponent<Attack_Button>().Desligar();

        //////////////////////////////////// interagir com os efeitos da carta

        vidaInimigo.GetComponent<Life_Counter>().tomarDano(esseBotao.GetComponent<Attack_Button>().danoDoAtaque); ////causar dano

        if (vidaInimigo.GetComponent<Life_Counter>().vida <= 0) manejamentoDeCena.GetComponent<MySceneManager>().Reload(); ////reiniciar caso vida inimiga igual a zero

        vidaAmigo.GetComponent<Life_Counter>().recuperarVida(esseBotao.GetComponent<Attack_Button>().vidaCurada); //////efeitos de cura

        /////////buffs e debufs
        if (esseBotao.GetComponent<Attack_Button>().intensidadeDebuff < 1f) vidaAmigo.GetComponent<Life_Counter>().debuffer(esseBotao); ////debuffs

        if (esseBotao.GetComponent<Attack_Button>().intensidadeBuff > 1f) vidaInimigo.GetComponent<Life_Counter>().buffer(esseBotao); ////buffs

        /////////////////////////////////// embaralhar próximo ataque

        tiposDeAtaque.GetComponent<Attack_Types>().Embaralhar(esseBotao.gameObject);

    }
}
