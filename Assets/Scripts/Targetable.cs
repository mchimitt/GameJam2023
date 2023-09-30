using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    public static List<Targetable> Targetables = new List<Targetable>();

    [SerializeField] private TargetableType _type;
    
    public TargetableType Type => _type;
    public void SetType(TargetableType type) => _type = type;

    private void OnEnable()
    {
        Targetables.Add(this);
    }

    private void OnDisable()
    {
        Targetables.Remove(this);
    }

    public static IEnumerable<Targetable> GetAllWithinRange(Vector3 pos, float range)
    {
        // TODO: Check cone of vision
        return Targetables.Where(target => Vector3.Distance(pos, target.transform.position) <= range).ToList();
    }
}
