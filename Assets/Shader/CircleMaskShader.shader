Shader "Unlit/CircleMaskShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.uv);
                float2 center = float2(0.5, 0.5);
                float dist = distance(i.uv, center);
                if (dist > 0.5)
                {
                    col.a = 0; // 알파 값을 0으로 설정하여 픽셀을 투명하게 만듦
                }
                return col;
            }
            ENDCG
        }
    }
        FallBack "Diffuse"
}
