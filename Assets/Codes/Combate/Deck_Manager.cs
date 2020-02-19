using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck_Manager : MonoBehaviour
{
    [Header("Características das habilidades - TODAS CARTAS")]

    public string[] nomeDoAtaque;

    public float[] tempoDeRecarga;

    public float[] danoDoAtaque;

    public int[] vidaCurada;

    public float[] intensidadeBuff;

    public float[] intensidadeDebuff;

    public float[] tempoDeEfeitoBuffs;

    [Header("Gerenciamento de Cartas")]

    //public GameObject[] botoesDeAtaque;


    public int[] cartasAtuais;
    public GameObject[] slotCartas;
    public GameObject[] marcadoresSelecionado;
    public GameObject[] marcadoresNaoSelecionado;
    public bool[] cartasSelecao;
    public Sprite[] spritesCartas;

    public void RetiraCarta(int card)
    {
        cartasSelecao[card] = false;
        for(int i=0; i<cartasAtuais.Length;i++)
        {
            if(cartasAtuais[i] == card)
            {
                cartasAtuais[i] = 9;
                slotCartas[i].SetActive(false);
                marcadoresSelecionado[card].SetActive(false);
                marcadoresNaoSelecionado[card].SetActive(true);
            }
        }
    }

    public void SelecionarCartas(int card)
    {
        if(cartasSelecao[card])
        {
            cartasSelecao[card] = false;
            marcadoresSelecionado[card].SetActive(false);
            marcadoresNaoSelecionado[card].SetActive(true);
            cartasSelecao[card] = false;
            for(int i=0;i<4;i++)
            {
                if(cartasAtuais[i] == card)
                {
                    cartasAtuais[i] = 9;
                    slotCartas[i].SetActive(false);
                    break;
                }
            }
        } else
        {
            cartasSelecao[card] = true;
            for(int i=0; i<4; i++)
            {
                if(cartasAtuais[i] == 9)
                {
                    cartasAtuais[i] = card;
                    slotCartas[i].SetActive(true);
                    slotCartas[i].GetComponent<SpriteRenderer>().sprite = spritesCartas[card];
                    marcadoresSelecionado[card].SetActive(true);
                    marcadoresNaoSelecionado[card].SetActive(false);
                    break;
                }
            }
        }
    }

}
