using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePresenter : MonoBehaviour
{    
    [SerializeField] private Character _character;
    [SerializeField] private Text _damageText;
    [SerializeField] private float _fadeTime = 1f;        

    private void OnEnable()
    {
        _character.TakenDamage += VisualizeDamage;
    }    

    private void OnDisable()
    {
        _character.TakenDamage -= VisualizeDamage;
    }

    private void VisualizeDamage(object sender, DamageInfo e)
    { 
        _damageText.text = e.Value.ToString();
        _damageText.color = e.Type.Color;       
    } 
}
