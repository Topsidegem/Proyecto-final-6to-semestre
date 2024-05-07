Shader "Custom/Walls&Floor"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _MetallicMap("Metallic", 2D) = "white" {}
        _BumpMap("Normal Map", 2D) = "bump" {}
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
            float3 worldNormal;
        };

        
        sampler2D _MainTex;
        sampler2D _MetallicMap;
        sampler2D _BumpMap;
        float _Metallic;
        float4 _Color;

    
    void surf(Input IN, inout SurfaceOutputStandard o)
    {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

        float metallic = tex2D(_MetallicMap, IN.uv_MainTex).r;
        c.rgb *= (1.0 - _Metallic) + metallic * _Metallic;

        o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));

        o.Albedo = c.rgb;
        o.Alpha = c.a;
    }
    ENDCG
    }
        FallBack "Diffuse"
}
