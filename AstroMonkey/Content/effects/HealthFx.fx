#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

static const float PI = 3.14159265f;
matrix WorldViewProjection;

float healthLeft;

float angle;
float aspectRatio;

void MainVS()
{

}

sampler TextureSampler: register(s0);//, float2 Tex: TEXCOORD0
float4 MainPS(float2 Tex : TEXCOORD0) : COLOR0
{
	float4 Color = tex2D(TextureSampler, Tex);
	float2 position = Tex.xy;
	position -= 0.5;
	position *= 2.0;

	//float strength = sqrt(1.5 - 0.5 * length(position));
	float strength = 0.0 + length(position);

	strength *= 1 / (healthLeft + 0.5);
	//strength = sqrt(strength - 0.5);
	if(strength < 1.0) strength = 1.0;
	//if(healthLeft > 0.75)
		//strength = 1.0;

	Color.r *=  strength;
	if(Color.r > 1.0) Color.r = 1.0;
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