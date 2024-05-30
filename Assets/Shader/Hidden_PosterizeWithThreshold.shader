Shader "Hidden/PosterizeWithThreshold" {
	Properties {
		[HideInInspector] _MainTex ("Texture", 2D) = "white" {}
		[NoScaleOffset] _UserLut ("LUT map", 2D) = "black" {}
		_Contribution ("Effect strength", Range(0, 1)) = 1
		_Threshold ("Luminance threshold", Range(0, 1)) = 0.5
		_ThresholdSharpness ("  threshold sharpness", Range(0.1, 30)) = 10
		[ToggleUI] _CompareDebug ("Debug compare", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}