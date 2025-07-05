using UnityEngine;

[CreateAssetMenu(fileName = "Ammo_", menuName = "Scriptable Objects/Ammo/AmmoSO")]
public class AmmoSO : ScriptableObject
{
    [Tooltip("Speed of the ammo projectile")]
    [Min(0f)]
    [SerializeField] public float ammoSpeed;

    [Tooltip("Range of the ammo projectile before it is considered expired")]
    [Min(0f)]
    [SerializeField]
    public float ammoRange;
}
