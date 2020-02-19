using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Types : MonoBehaviour
{
    [Header("Características das habilidades")]

    public string[] nomeDoAtaque;

    public float[] tempoDeRecarga;

    public float[] danoDoAtaque;

    public int[] vidaCurada;

    public float[] intensidadeBuff;

    public float[] intensidadeDebuff;

    public float[] tempoDeEfeitoBuffs;

    [Header("Outros")]

    public GameObject[] botoesDeAtaque;

    // Start is called before the first frame update
    void Start()
    {

        foreach(GameObject ataque in botoesDeAtaque)
        {
            Embaralhar(ataque);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Embaralhar(GameObject ataque)
    {
        int tipo = (Random.Range(0, nomeDoAtaque.Length));

        ataque.GetComponentInChildren<Text>().text = nomeDoAtaque[tipo];

        ataque.GetComponent<Attack_Button>().nomeDoAtaque = nomeDoAtaque[tipo];
        ataque.GetComponent<Attack_Button>().tempoDeRecarga = tempoDeRecarga[tipo];
        ataque.GetComponent<Attack_Button>().danoDoAtaque = danoDoAtaque[tipo];
        ataque.GetComponent<Attack_Button>().vidaCurada = vidaCurada[tipo];
        ataque.GetComponent<Attack_Button>().intensidadeBuff = intensidadeBuff[tipo];
        ataque.GetComponent<Attack_Button>().intensidadeDebuff = intensidadeDebuff[tipo];
        ataque.GetComponent<Attack_Button>().tempoDeEfeitoBuffs = tempoDeEfeitoBuffs[tipo];
    }
}
