Shader "Unlit/YellowShader"
{
    Properties
    {
        _DiffuseColor("DiffuseColor", Color) = (1,1,0,1)
        _LightDirection("LightDirection", Vector) = (1,1,1,0)
        _SpecularColor("SpecularColor", Color) = (1,1,1,1)
        _Shininess("Shininess", Range(0.1, 100)) = 10
        _Ambient("AmbientColor", Color)=(1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 viewDir : TEXCOORD0;
            };

            float4 _DiffuseColor;
            float4 _LightDirection;
            float4 _SpecularColor;
            float _Shininess;
            float4 _Ambient;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.viewDir = normalize(_WorldSpaceCameraPos - v.vertex.xyz);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float4 ambient = _Ambient * 0.4f;

                // sample the texture
                //fixed4 col = float4(1.0f,1.0f,0.0,1.0f);

                float4 lightDir = normalize(_LightDirection);
                float lightIntensity = max(dot(i.normal,lightDir),0);
                float4 diffuse=_DiffuseColor * lightIntensity;


                float3 viewDir = normalize(i.viewDir);
                float3 halfwayDir = normalize(lightDir + viewDir);


                float specularIntensity = pow(max(dot(i.normal, halfwayDir), 0.0), _Shininess);
                float4 specular = _SpecularColor.rgba * specularIntensity;

                

                float4 color = diffuse+specular+ambient;
                



                float threshold = 0.1;

                float4 banding=floor(color/threshold);
                float4 col=banding*threshold;


                return col;
            }
            ENDCG
        }
    }
}