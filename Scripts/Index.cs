using UnityEngine;
using Z;

public class Index : MonoBehaviour
{
    void Awake()
    {
        Zarch.classes.Register<BackGround>(); Zarch.classes.Register<Move>(); Zarch.classes.Register <Cursor>(); Zarch.classes.Register<Weapons>(); Zarch.classes.Register<InspectorCamera>();;

        Zarch.methods["active"] = param => { Zarch.csharp.S(gameObject).add((string)param[0]); return null; }; Zarch.methods["load"] = param => { Zarch.csharp.S((string)param[0]).add((string)param[1]); return null; };
    }

    void Start()
    {
        PlayerPrefs.SetInt("freeze", 0);

        Zarch.code = "active('BackGround');";

        Zarch.code = "active('Weapons')";

        Zarch.code = "load('player','Move')";

        Zarch.code = "load('cursor','Cursor')";

        Zarch.code = "load('inspectorCamera','InspectorCamera')";

        Zarch.code = "load('player','Health')";

        Zarch.code = "$.coroutine({$(help).active(bool())},3,0)";

        Zarch.csharp.S_coroutine(() => { PlayerPrefs.SetInt("freeze", 1); }, 3, 0);

        foreach (var m in GameObject.FindGameObjectsWithTag("Enemy")) { m.AddComponent<Monster>(); }

    }
}
