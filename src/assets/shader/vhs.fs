#pragma loader: import { whiteNoise } from './utils.fs';
#pragma loader: import verticalBar from './verticalBar.fs';

vec4 vhs(vec2 uv, vec2 p){
  float offsetIntensity = 0.01;
  float colorOffsetIntensity = .5;

  float len = length(p);
  vec2 barrel = p * (len + 6.0) * 0.135;
  uv = (barrel + 1.0) * 0.5;
  
  for (float i = 0.0; i < 0.71; i += 0.1313) {
    float d = mod(uTime * i, 0.7);
    float o = sin(1.0 - tan(uTime * .4 * i));
    o *= offsetIntensity;
    uv.y += verticalBar(d, uv.y, o);
  }

  vec2 offsetR = vec2(0.01 * sin(uTime* 1.7), 0.0) * colorOffsetIntensity;
  vec2 offsetG = vec2(0.01 * (cos(uTime * 1.27)), 0.0) * colorOffsetIntensity;
  
  float r = texture2D(uTexture, uv + offsetR).r;
  float g = texture2D(uTexture, uv + offsetG).g;
  float b = texture2D(uTexture, uv).b;

  vec4 color = vec4(r, g, b, 1.0);

  float vignette = 1.0 - (len - 0.5) + 0.5;
  color *= vignette;
  
  float scanLine = abs(sin(p.y * 200.0 + uTime * 10.0)) * 0.5 + 0.5;
  color.rgb *= (scanLine + 0.3);

  float noise = whiteNoise(gl_FragCoord.st + mod(uTime, 10.0));
  color *= noise * 0.25 + 1.0;

  return color;
}
