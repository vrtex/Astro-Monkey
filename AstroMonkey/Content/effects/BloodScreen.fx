#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

//float health = 0;
float time = 0;
float currTime;
Texture2D bloodScreen;

matrix WorldViewProjection;

Texture2D SpriteTexture;

SamplerState SpriteTextureSampler = sampler_state {
	Texture = <SpriteTexture>;
};

SamplerState TextureSampler = sampler_state
{
	Texture = <bloodScreen>;
};

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 color = tex2D(SpriteTextureSampler, input.TextureCoordinates) * input.Color;
	float2 position = input.TextureCoordinates.xy;

	float4 c2 = bloodScreen.Sample(TextureSampler, float2(0, 0));

	if (currTime < time + .2) {
		color.r = color.r + color.r * (currTime - time) * 2;
	}

	return c2 + color;

	
}

technique BasicColorDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};