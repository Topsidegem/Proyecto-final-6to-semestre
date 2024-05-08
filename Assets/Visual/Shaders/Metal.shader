Shader "Custom/Metal"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _MetallicMap("Metallic", 2D) = "white" {}
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Color("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        sampler2D _MetallicMap;
        float _Metallic;
        float4 _Color;

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            o.Metallic = _Metallic;
            float metallic = tex2D(_MetallicMap, IN.uv_MainTex).r;

            o.Alpha = c.a;
        }
        ENDCG
    }

        FallBack "Diffuse"
}
