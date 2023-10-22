Shader "Custom/CircularSliceShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _SliceValue("Slice Value", Range(0, 1)) = 0.5
    }
   
    SubShader
    {
        Tags { "Queue"="Transparent" }
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
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _SliceValue;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.texcoord = v.texcoord;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_MainTex, i.texcoord);
                
                // Calculate the distance from the center of the circle
                float2 center = float2(0.5, 0.5);
                float distance = length(i.texcoord - center);
                
                // Determine visibility based on the slice value
                half visibility = (distance < _SliceValue * 0.5) ? 1 : 0;
                
                // Apply visibility to the alpha channel of the fragment color
                col.a *= visibility;
                
                return col;
            }
            ENDCG
        }
    }
}
