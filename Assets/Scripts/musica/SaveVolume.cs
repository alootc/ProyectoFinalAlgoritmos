using UnityEngine;

[CreateAssetMenu(fileName = "SaveVolume", menuName = "ScriptableObjects")]
public class SaveVolume : ScriptableObject
{
    public float master_volumen;
    public float music_volume;
    public float sfx_volume;
}
