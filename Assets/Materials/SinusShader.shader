Shader "Custom/SinusShader"
{
    Properties
    {
		_Stripes("Stripes", Float) = 2
		_StripesThickness("_StripesThickness", Float) = 0.2
		_Frequency("_Frequency", Float) = 0.2
		_Speed("_Speed", Float) = 0.2
		_Emission("_Emission", Float) = 0.2

        _Color1 ("Color1", Color) = (1,1,1,1)
		_Color2("Color2", Color) = (1,1,1,1)

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;

        fixed4 _Color1;
		fixed4 _Color2;
		float _Emission;

		float _Frequency;
		float _Stripes;
		float _StripesThickness;
		float _Speed;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		float2 rot(float2 uv, float r) {
			float sinX = sin(r);
			float cosX = cos(r);
			float sinY = sin(r);
			float2x2 rotationMatrix = float2x2(cosX, -sinX, sinY, cosX);
			return mul(uv, rotationMatrix);
		}
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			float s = _Stripes;		//stripes
			float st = _StripesThickness;		//stripe thickness

			float2 uv = rot(IN.uv_MainTex, -0.2 + sin(_Time.x)*_Speed);

			float osc = sin(uv.x*(uv.x + .5)*_Frequency);
			uv.y += osc * sin(_Time.x + uv.x*2.);
			uv.y = frac(uv.y*s);

			float3 bg = _Color1.rgb;
			float3 fg = _Color2.rgb;

			float mask = smoothstep(0.5, 0.55, uv.y);
			mask += smoothstep(0.5 + st, 0.55 + st, 1. - uv.y);

			float3 col = mask * bg + (1. - mask)*fg;

			// Output to screen
			//fragColor = float3(col, 1.0);

			o.Albedo = col.rgb;
			o.Emission = col.rgb * _Emission;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = 1.0;
		}
        ENDCG
    }
    FallBack "Diffuse"
}
