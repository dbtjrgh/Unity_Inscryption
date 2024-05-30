Shader "Custom/GravestoneCard" {
	Properties {
		_Albedo ("Albedo", 2D) = "white" {}
		_EmissionMap ("EmissionMap", 2D) = "white" {}
		_RenderTexture ("RenderTexture", 2D) = "black" {}
		_Normals ("Normals", 2D) = "bump" {}
		_EmissionColor ("EmissionColor", Vector) = (0,0,0,0)
		_FadeColor ("FadeColor", Vector) = (0,0,0,0)
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