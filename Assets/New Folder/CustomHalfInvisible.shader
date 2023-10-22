Shader "Custom/HalfInvisible"
{
    Properties
    {
        _InvisibleThresholdX("Invisible Threshold X", Range(0, 1)) = 0.5
        _InvisibleThresholdY("Invisible Threshold Y", Range(0, 1)) = 0.5
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _InvisibleThresholdX;
            float _InvisibleThresholdY;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Calculate the position along the X and Y axes
                float x = i.texcoord.x;
                float y = i.texcoord.y;

                // Use the threshold properties to make half the object invisible
                if (x < _InvisibleThresholdX || y < _InvisibleThresholdY)
                {
                    discard;
                }

                // Sample the texture
                half4 col = tex2D(_MainTex, i.texcoord);
                return col;
            }
            ENDCG
        }
    }
}
