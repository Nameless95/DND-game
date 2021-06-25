Shader "Custom/Sky"{
    Properties{
        _MainTex ("Texture", 2D) = "white" {}
        _SColor ("Start Color", color) = (1, 1, 1, 1)
        _EColor ("End Color", color) = (1, 1, 1, 1)
        _Location ("PlayerLocation", Float) = 0
    }
    Subshader{
        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct vtf{
                float4 vertex: SV_POSITION;
                float2 uv: TEXCOORD0;
            };

            vtf vert(appdata_base i){
                vtf v;
                v.vertex = UnityObjectToClipPos(i.vertex);
                v.uv = i.texcoord;
                return v;
            }

            sampler2D _MainTex;
            fixed4 _SColor;
            fixed4 _EColor;
            float _Location;

            fixed4 frag(vtf i): COLOR{
                fixed4 texColor = tex2D(_MainTex, i.uv);
                //texColor = fixed4(texColor.b, texColor.b, texColor.b, 1);
                
                return lerp(_SColor, _EColor, saturate(_Location)) + texColor;
            }

            ENDCG
        }
    }
}