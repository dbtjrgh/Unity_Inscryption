Shader "SuperSystems/Wireframe-Transparent-Culled" {
	Properties {
		_WireThickness ("Wire Thickness", Range(0, 800)) = 100
		_WireSmoothness ("Wire Smoothness", Range(0, 20)) = 3
		_WireColor ("Wire Color", Vector) = (0,1,0,1)
		_BaseColor ("Base Color", Vector) = (0,0,0,0)
		_MaxTriSize ("Max Tri Size", Range(0, 200)) = 25
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
}