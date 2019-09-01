using UnityEngine;
using Z;

public class Weapons : MonoBehaviour
{   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Zarch.csharp.S("mp").slider() < 5) { Zarch.code = "$(help).text('low mp');$(help).active(bool(1)); $.thread({Thread.Sleep(1000)}, {$(help).active(bool())}) "; return; }

            Zarch.code = "$(help).active(bool())";

            Zarch.csharp.S("mp").slider(Zarch.csharp.S("mp").slider() - 5);

            var go = Instantiate((GameObject)Zarch.objects["shot"]);

            Zarch.csharp.S(go).pos(Zarch.csharp.S("player").pos());

            ((Rigidbody)Zarch.csharp.S(go).get(typeof(Rigidbody))).AddForce((((Transform)Zarch.csharp.S("player").get("Transform")).forward * 3000));

            go.AddComponent<Shot>(); Zarch.csharp.S_coroutine(() => { Destroy(go); }, 5, 0);
        }
    }
}

public class Shot : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var b = Instantiate((GameObject)Zarch.objects["boom"], transform.position,Quaternion.identity);

            Zarch.csharp.S_coroutine(() => { Destroy(b); }, 3, 0); Destroy(gameObject); 
        }
    }
}