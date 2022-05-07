using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePresenter : MonoBehaviour
{    
    [SerializeField] private Character _character;
    [SerializeField] private Text _damageIndicator;
    [SerializeField] private float _fadeTime = 1f;
    [SerializeField] private float _randomizePosition = 0.5f;
    [SerializeField] private float _offsetY = 1f;

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
        var rndX = Random.Range(-_randomizePosition, _randomizePosition);
        var rndY = Random.Range(-_randomizePosition, _randomizePosition);        
        var offset = new Vector2(rndX, rndY + _offsetY);

        var indicator = Instantiate(_damageIndicator, transform.position + (Vector3)offset,Quaternion.identity, transform);
        indicator.text = e.Value.ToString();
        indicator.color = e.Type.Color;        
        Destroy(indicator, _fadeTime);
    } 
}
