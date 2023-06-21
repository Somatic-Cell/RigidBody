using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference
{
    public class Numerical : MonoBehaviour
    {
        [SerializeField] protected Vector3 initPos = new Vector3(0f, 0f, 0f);       // 初期位置
        [SerializeField] protected Vector3 initVel = new Vector3(10f, 10f, 0f);     // 初期速度
        [SerializeField] protected Vector3 gravity = new Vector3(0f, -9.8f, 0f);    // 重力加速度

        private Vector3 position;       // 現在の位置
        private Vector3 velocity;       // 現在の速度
        private Vector3 acceleration;   // 現在の加速度

        // 最初に一度呼ばれるメソッド．
        void Start()
        {
            // メンバ変数の初期化．
            position = initPos;
            velocity = initVel;
            acceleration = gravity;

            // アタッチしているオブジェクトの位置を初期化．
            this.transform.position = position;
        }

        // FixedUpdate は物理演算を行う際によく用いられる．
        // とりあえず固定の周期で動いてくれるメソッドと思えばいい．
        // 詳細はこちら：https://docs.unity3d.com/ja/2021.1/ScriptReference/MonoBehaviour.FixedUpdate.html
        void FixedUpdate()
        {
            float dt = Time.deltaTime;

            position = velocity * dt + position;
            acceleration = gravity;
			//if (position.y < 0f)
			//{
			//	acceleration += Mathf.Abs(position.y) * new Vector3(0f, 1000f, 0f);
			//}
			velocity = acceleration * dt + velocity;

            // アタッチしているオブジェクトの位置を更新．
            this.transform.position = position;
        }
    }
}
