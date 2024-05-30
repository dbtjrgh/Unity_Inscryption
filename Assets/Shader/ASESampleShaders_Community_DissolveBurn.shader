Shader "ASESampleShaders/Community/DissolveBurn" {
	Properties {
		_Cutoff ("Mask Clip Value", Float) = 0.5
		_Albedo ("Albedo", 2D) = "white" {}
		_Normal ("Normal", 2D) = "bump" {}
		_Metallic ("Metallic", 2D) = "white" {}
		_DisolveGuide ("Disolve Guide", 2D) = "white" {}
		_BurnRamp ("Burn Ramp", 2D) = "white" {}
		_DissolveAmount ("Dissolve Amount", Range(0, 1)) = 0
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
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
	//CustomEditor "ASEMaterialInspector"
}