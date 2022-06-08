Shader "Custom/Sample3"
{
    Properties 
	{
		_Tex1 ("Texture 1 (RGB) Depth (A)", 2D) = "white" {}
		_Tex2 ("Texture 2 (RGB) Depth (A)", 2D) = "white" {}
		[Toggle] _isBlend("isBlend", float) = 0
	}


	SubShader
	{ 

		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _Tex1;
		sampler2D _Tex2;

		struct Input
		{
			float2 uv_Tex1;
			float2 uv_Tex2;
		};

		float _isBlend;

		float3 blend(float4 texture1, float a1, float4 texture2, float a2)
		{
			float depth = 0.2;
			float ma = max(texture1.a + a1, texture2.a + a2) - depth;
			float b1 = max(texture1.a + a1 - ma, 0);
			float b2 = max(texture2.a + a2 - ma, 0);
			return (texture1.rgb * b1 + texture2.rgb * b2) / (b1 + b2);
		}

		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 c1 = tex2D (_Tex1, IN.uv_Tex1);
			half4 c2 = tex2D (_Tex2, IN.uv_Tex2);

			if(_isBlend)
            {
               o.Albedo = c1.rgb;
            }
            else
            {
                o.Albedo = blend(c1, IN.uv_Tex2.x, c2, 1 - IN.uv_Tex2.x);
            }

			
		}
		ENDCG
	} 

	FallBack "Diffuse"
}
