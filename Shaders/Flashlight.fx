// fxc /T ps_3_0 /Fo Flashlight.ps Flashlight.fx

sampler2D input : register(s0);

float2 lightPos : register(c0);

float4 main(in float2 uv : TEXCOORD) : COLOR
{
    // Define the light source
    float3 lightColor = float3(1, 1, 1);
    float lightIntensity = 2.0f;
    float lightRadius = .0080f;

    // Calculate the distance between the light source and the surface
    float lightDistance = length(uv - lightPos);

    // Calculate the attenuation of the light
    float attenuation = 1.0f / (1.0f + ((lightDistance * lightDistance) / (lightRadius * lightRadius)));

    // Calculate the final color of the pixel
    float3 surfaceColor = float3(1, 1, 1);
    float3 finalColor = attenuation * lightIntensity * lightColor;

    return tex2D(input, uv) * float4(finalColor, 1);
}
