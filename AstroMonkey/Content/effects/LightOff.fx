#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;

/*struct VertexShaderInput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
	float4 ScreenCoords : TEXCOORD1;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	output.Position = mul(input.Position, WorldViewProjection);
	output.Color = input.Color;
	output.ScreenCoords = output.Position;

	return output;
}

float4 MainPS(VertexShaderOutput input): COLOR
{
	//This is what I want to do
	if(input.ScreenCoords.y > 0.5)
	input.Color.r = 0.0;

	return input.Color;
}
/*struct VertexShaderOutput
{
float4 position : SV_POSITION;
float4 color : COLOR0;
float2 texCoord: TEXCOORD0;
};

VertexShaderOutput SpriteVertexShader(	float4 position	: POSITION0,
float4 color : COLOR0,
float2 texCoord : TEXCOORD0)
{
VertexShaderOutput output;
//output.position = mul(position, MatrixTransform);
output.color = color;
output.texCoord = texCoord;
return output;
}

struct VertexInput
{
float4 Position : POSITION;
};

struct VertexOutput
{
float4 Position : POSITION;
float4 ScreenPos : TEXCOORD0;
};

void SpriteVertexShader(in VertexInput input, out VertexOutput output)
{
output.Position = mul(WorldViewProjection, input.Position);
output.ScreenPos = output.Position / output.Position.w;
}

sampler TextureSampler: register(s0);//, float2 Tex: TEXCOORD0
float4 SpritePixelShader(float2 Tex : TEXCOORD0, float4 Position : POSITION, in VertexOutput input): COLOR0
{
float4 Color = tex2D(TextureSampler, Tex);
//input.ScreenPosition.xy /= input.ScreenPosition.w;
float2 position = 0.5f * (float2(input.ScreenPos.x, -input.ScreenPos.y) + 1);
//float2 position = input.ScreenPos.xy / input.ScreenPos.w;
if(position.y > 0.1) Color.r = 0.0;

return Color;
}*/
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
	output.Position = mul(WorldViewProjection, input.Position);
	output.ScreenPos = output.Position / output.Position.w;
}

sampler TextureSampler: register(s0);//, float2 Tex: TEXCOORD0
float4 MainPS(float2 Tex : TEXCOORD0, float4 Position : POSITION, in VertexOutput input): COLOR0
{
	float4 Color = tex2D(TextureSampler, Tex);
	/*//input.ScreenPosition.xy /= input.ScreenPosition.w;
	float2 position = 0.5f * (float2(input.ScreenPos.x, -input.ScreenPos.y) + 1);
	//float distance = sqrt(pow(0.5 - position.x, 2) + pow(0.5 - position.y, 2));
	//float2 position = input.ScreenPos.xy / input.ScreenPos.w;
	/*if(distance > 0.5)
	{
		Color.r = 1;
		Color.g = 0;
		Color.b = 0;
	}
	if(Position.x > 0.5)
	{
		Color.r = 1;
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