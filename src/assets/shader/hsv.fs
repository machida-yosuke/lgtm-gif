#pragma loader: import toHsv from './toHsv.fs';
vec4 hsv(vec2 uv){
  vec4 texture = texture2D(uTexture, uv);
  vec4 color = vec4(toHsv(texture.r + abs(sin(uTime / 5.0)), texture.g + abs(cos(uTime / 8.0)), texture.b + abs(tan(uTime / 3.0))), 1.0);
  return color;
}