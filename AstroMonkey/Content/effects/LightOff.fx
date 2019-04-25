#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;

float resolutionRatio;
float angle;

struct VertexInput
{
	float4 Position : POSITION;
};

struct VertexOutput
{
	float4 Position : POSITION;
	float4 ScreenPos : TEXCOORD0;
};

void MainVS(in VertexInput input, out VertexOutput output)
{
	//output.Position = mul(WorldViewProjection, input.Position);
	//output.ScreenPos = output.Position / output.Position.w;
}

sampler TextureSampler: register(s0);//, float2 Tex: TEXCOORD0
float4 MainPS(float2 Tex : TEXCOORD0): COLOR0
{
	float minDis = 0.05;
	float maxDis = 0.3;

	float4 Color = tex2D(TextureSampler, Tex);
	float2 position = Tex.xy;
	float distance = sqrt(pow(0.5 - position.x, 2) + pow(0.5 / resolutionRatio - position.y / resolutionRatio, 2));
	if(distance > minDis && distance < maxDis)
	{
		//if()
		Color.rgb = Color.rgb * lerp(1, 0, (distance - minDis) / (maxDis - minDis));
		
	}
	if(distance >= maxDis)
	{
		Color.rgb = 0;
	}
	//float angleFOV = (acos(dot(angle))));
	/*if(angleFOV < 20f)
	{
		Color.r = saturate(Color.r * 2);
	}*/

	return Color;
}

technique BasicColorDrawing
{
	pass P0
	{
		PixelShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};