using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StaticVariables : MonoBehaviour
{
    #region variables
    public static StaticVariables i;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer, whatIsEnemy, 
        whatIsCollectable, whatIsUI;
    [SerializeField] private AudioMixerGroup masterMixer, sfxMixer, musicMixer;
    #endregion
    private void Awake() 
    {
        i = this;
    }

    #region GetFunctions
    public LayerMask GetGroundLayer() { return whatIsGround; }
    public LayerMask GetPlayerLayer() { return whatIsPlayer; }
    public LayerMask GetEnemyLayer() { return whatIsEnemy; }
    public LayerMask GetCollectableLayer() { return whatIsCollectable; }
    public LayerMask GetUILayer(){ return whatIsUI; }
    public AudioMixerGroup GetMasterMixer(){ return masterMixer; }
    public AudioMixerGroup GetSFXMixer(){ return sfxMixer; }
    public AudioMixerGroup GetMusicMixer(){ return musicMixer; }
    #endregion
}
