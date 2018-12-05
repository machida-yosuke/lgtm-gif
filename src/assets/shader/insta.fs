#pragma loader: import {greyScale, saturationMatrix, levels, levelsGamma, levelsGamma2, brightnessAdjust, contrastAdjust, colorBurn} from './instalib.fs';

vec4 insta(vec2 uv, vec2 p){
    vec4 texture = texture2D(uTexture, uv);
    float range = 0.8;
    float vignet = 1.0 - (length(p) - range);
    vec3 col = texture.rgb; 
    vec3 tint = vec3(252., 255., 235.) / 255.;
    col = levelsGamma(col, vec3(28., 0., 0.) / 255., vec3(1.0), vec3(0., 0., 45.) / 255., vec3(1.0), vec3(1.2), vec3(0.91, 0.94, 0.85) ); 
    col = brightnessAdjust(col, 0.05);
    col = contrastAdjust(col, 1.1);
    col = levelsGamma2(col, vec3(45., 0., 0.) / 255., vec3(255.,255.,255.) / 255., vec3(11., 0., 56.) / 255., vec3(232.,250.,238.) / 255., vec3(1.3), vec3(0.45, 0.8, 1.4),15./255., 243./255., 0./255., 238./255.); 
    col = contrastAdjust(col, 1.2);
    col = levels(col, vec3(0., 0., 0.) / 255., vec3(240.,255.,255.) / 255.,  vec3(0., 0., 14.) / 255., vec3(255.,255.,241.) / 255.);  
    col = col * tint * vec3(vignet); 
    return vec4(col, 1.0);
}