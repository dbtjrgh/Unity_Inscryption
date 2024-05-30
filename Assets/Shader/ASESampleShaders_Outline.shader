Shader "ASESampleShaders/Outline" {
	Properties {
		_ASEOutlineColor ("Outline Color", Vector) = (0,0.2551723,1,0)
		_ASEOutlineWidth ("Outline Width", Float) = 0.03
		[HideInInspector] __dirty ("", Float) = 1
		_Albedo ("Albedo", 2D) = "white" {}
		[HideInInspector] _texcoord ("", 2D) = "white" {}
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
}