vec4 glitch(vec2 uv){
    float PI = 3.1415;
    float moveX = sin(uTime * 100.0) * 0.01;
    float moveY = sin(uTime * 100.0 + ( PI / 4.0 )) * 0.001;

    vec2 muv1 = vec2(floor(uv.x * 2.0) / 2.0, floor(uv.y * 10.0) / 10.0) + uTime * 0.01;
    vec2 muv2 = vec2(floor(uv.x * 4.0) / 4.0, floor(uv.y * 16.0) / 16.0) + uTime * 0.98;
    vec2 muv3 = vec2(floor(uv.x * 8.0) / 10.0, floor(uv.y * 14.0) / 14.0) + uTime * 0.5;

    float noise1 = step(0.7, snoise(vec3(muv1 * 4.0, 1.0)));
    float noise2 = step(0.6, snoise(vec3(muv2 * 4.0, 1.0)));
    float noise3 = step(0.8, snoise(vec3(muv3 * 6.0, 1.0)));

    float mergeNoise = noise1 + noise2 + noise3;

    vec2 mergeUv = uv + mergeNoise * 0.1;
    vec4 texture = vec4(
        texture2D(uTexture, vec2(mergeUv.x - moveX, mergeUv.y - moveY)).r,
        texture2D(uTexture, mergeUv).g,
        texture2D(uTexture, mergeUv).b,
        1.0
    );

    // Output to screen
	return texture;
}
