#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float time = 0;
float currTime;


matrix WorldViewProjection;

Texture2D SpriteTexture;
Texture2D BloodScreen;

SamplerState TextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

SamplerState NormalSampler = sampler_state
{
	Texture = <BloodScreen>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(float4 pos : SV_POSITION, float4 color : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
	float4 tex = SpriteTexture.Sample(TextureSampler, texCoord);
	
	//nic się nie zmienia
	
	float4 normal = BloodScreen.Sample(NormalSampler, texCoord);
	if (currTime < time + .2) {
		normal.r = normal.r * (currTime - time) * 2;
		normal.g = normal.g * (currTime - time) * 2;
		normal.b = normal.b * (currTime - time) * 2;
	}
	else {
		normal.r = 0;
		normal.g = 0;
		normal.b = 0;
	}

	return normal + tex;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};