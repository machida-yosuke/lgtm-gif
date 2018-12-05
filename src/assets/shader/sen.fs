#pragma loader: import { blockNoise } from './utils.fs';

vec4 sen(vec2 uv){
    // ビネット
    vec2 p = uv * 2.0 - 1.0;
    float vignet = length(p) - 0.5;

    // 色情報取得
    vec4 colors = texture2D(uTexture, uv);

    // ブロックノイズで加工。
    float noise = blockNoise(uv * vec2(0.05, 10.0));
    float formattedNoise = clamp(cos(noise), 0.0, 1.0);
    vec3 noiseColors = colors.rgb * formattedNoise * vec3(1.0, 0.5, 0.3);

    // ビネットと混ぜる。
    vec3 result = mix(noiseColors, vec3(0.1), vignet);

    return vec4(result, 1.0);
}
