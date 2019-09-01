using UnityEngine;
using Z;

public class BackGround : MonoBehaviour
{
    public static void faster(float speed) { b.Faster(speed); }

    public static void pause() { b.Pause(); }

    public static void resume() { b.Resume(); }

    #region 移动 不用看

    public void Faster(float speed)
    {
        this.speed += speed;

        if (this.speed > max) { this.speed = max; }

        if (this.speed < min) { this.speed = min; }
    }

    public void Pause()
    {
        temp = speed;
        speed = 0f;
    }

    public void Resume()
    {
        speed = temp;
    }

    void Awake()
    {
        bgs[0] = Zarch.objects["bg0"] as GameObject;                                // 场景内物体名
        bgs[1] = Zarch.objects["bg1"] as GameObject;
        bgs[2] = Zarch.objects["bg2"] as GameObject;
        bgs[3] = Zarch.objects["bg3"] as GameObject;

        b = this;
    }

    void FixedUpdate()
    {
        if (!Input.GetAxis("Vertical").Equals(0))
        {
            faster(Input.GetAxis("Vertical") * Time.time * 0.01f);
        }

        foreach (var bg in bgs)
        {
            bg.transform.Translate(new Vector3(0, 0, -speed));

            if (bg.transform.position.z < -ModelSize.z) { bg.transform.position = new Vector3(0, 0, bg.transform.position.z + ModelSize.z * 4); }
        }
    }

    [SerializeField]
    float max = 5;

    [SerializeField]
    float min = 0.5f;

    float speed = 0.5f;

    float temp = 0.5f;

    Vector3 ModelSize = new Vector3(97.5f + 97.5f, 0, 200.05f);

    static BackGround b;

    GameObject[] bgs = new GameObject[4];

    #endregion

}
