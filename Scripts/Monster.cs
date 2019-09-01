using UnityEngine;
using UnityEngine.UI;
using Z;

public class Monster : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt("freeze") != 0 )
        {
            var target = Zarch.csharp.S("player").pos(); transform.LookAt(target);

            transform.position = Vector3.Lerp(transform.position, target, 0.008f);
        }
		if (ishurt) { hurt.color = flashColor; } else { hurt.color = Color.Lerp(hurt.color, Color.clear, Time.deltaTime * flashSpeed); } ishurt = false;
	}

    void FixedUpdate()
    {
        if (Zarch.csharp.S("hp").slider().Equals(0)) { Zarch.code = "$(help).text('wasted');$(help).active(bool(1)); "; Time.timeScale = 0; return; }

        if (Zarch.csharp.S("hp").slider() < 100) { Zarch.csharp.S("hp").slider(Zarch.csharp.S("hp").slider() + Time.deltaTime ); }

        if (Zarch.csharp.S("mp").slider() < 100) { Zarch.csharp.S("mp").slider(Zarch.csharp.S("mp").slider() + Time.deltaTime *2f ); }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            if (Time.time > lastHurt + hurtInterval)
            {
                Zarch.csharp.S("hp").slider(Zarch.csharp.S("hp").slider() - 5); lastHurt = Time.time + hurtInterval; ishurt = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            var r = Random.Range(-80, 80);
            
            while (Mathf.Abs(transform.position.x + r) > 94) { r = Random.Range(-80, 80); }
            
            transform.Translate(Vector3.forward * 200 * (1+Random.Range(-0.3f,0.3f)) + Vector3.left * r, Space.World);

            Zarch.csharp.S("money").text("$" + (System.Convert.ToInt32(Zarch.csharp.S("money").text().Substring(1)) + 10));
        }
    }

    float lastHurt; float hurtInterval = 0.2f;

    Image hurt; bool ishurt; float flashSpeed = 5f; Color flashColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);

    void Start() { hurt = ((GameObject)Zarch.objects["hurt"]).GetComponent<Image>(); }

}
