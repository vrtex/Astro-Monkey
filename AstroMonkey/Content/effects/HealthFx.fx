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

float healthLeft

void MainVS()
{

}

sampler TextureSampler: register(s0);//, float2 Tex: TEXCOORD0
float4 MainPS(float2 Tex : TEXCOORD0) : COLOR0
{
	float minDis = 0.05;
	float maxDis = 0.3;
	float maxDiff = 30.0;

	float4 Color = tex2D(TextureSampler, Tex);
	float2 position = Tex.xy;
	float distance = sqrt(pow(0.5 - position.x, 2) + pow(0.5 / aspectRatio - position.y / aspectRatio, 2));

	//obliczanie kąta pomiędzy punktem na ekranie a środkiem ekranu
	float x = atan2(0.5 - position.y, 0.5 - position.x);
	float pixelangle = x * 180 / PI;
	if(x < 0) pixelangle = (2 * PI + x) * 180 / PI;

	//normalizacja kąta, żeby 0 było na góże ekranu
	pixelangle -= 90.0;
	if(pixelangle < 0) pixelangle += 360.0;

	//policzneie różnicy pomiędzy kątem pixela, a obrotem postaci
	float diff = 0;
	float degrees = angle * 360;
	if(pixelangle < degrees)
		diff = min(pixelangle + 360 - degrees, degrees - pixelangle);
	else
		diff = min(degrees + 360 - pixelangle, pixelangle - degrees);

	if(diff < maxDiff)
	{

	}
	else if(distance > minDis && distance < maxDis)
	{
		Color.rgb = Color.rgb * lerp(1, 0, (distance - minDis) / (maxDis - minDis));
	}
	else if(distance >= maxDis)
	{
		Color.rgb = 0;
	}

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